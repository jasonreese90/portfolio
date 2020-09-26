using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace Kunihiro.ExternHelper
{
    public abstract class ExternHelper
    {
        private Process process;

        public ExternHelper(Process process)
        {
            this.process = process;
      
        }


        private byte[] StructToByteArray(object t)
        {
            int size = Marshal.SizeOf(t);
            byte[] buffer = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(t, ptr, true);
            Marshal.Copy(ptr, buffer, 0, size);
            Marshal.FreeHGlobal(ptr);
            return buffer;
        }

        private int GetAddress(string module, int offset)
        {
            foreach (ProcessModule pm in process.Modules)
            {
                if (pm.ModuleName.ToLower() == module.ToLower())
                {
                    return (int)pm.BaseAddress + offset;
                }
            }

            return 0;
        }

        private string MapToUnmanagedType(Type type)
        {
            if (type == typeof(string))
            {
                return "char*";
            }

            if (type == typeof(int))
            {
                return "int";
            }

            if (type == typeof(bool))
            {
                return "bool";
            }

            if (type == typeof(byte))
            {
                return "unsigned char";
            }

            if (type == typeof(sbyte))
            {
                return "signed char";
            }

            if (type == typeof(float))
            {
                return "float";
            }

            if (type == typeof(char))
            {
                return "wchar_t";
            }

            if (type == typeof(double))
            {
                return "double";
            }

            if (type == typeof(uint))
            {
                return "unsigned int";
            }

            if (type == typeof(long))
            {
                return "__int64";
            }

            if (type == typeof(ulong))
            {
                return "unsigned __int64";
            }

            if (type == typeof(short))
            {
                return "short";
            }

            if (type == typeof(ushort))
            {
                return "unsigned short";
            }

            if (type == typeof(IntPtr))
            {
                return "void*";
            }

            if (type == typeof(Pointer))
            {
                return "pointer";
            }

            if (type.IsValueType)
            {
                return "struct";
            }


            return "void*";
        }

        private string GetXmlDocumentAsString(XmlDocument doc)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                    doc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    return stringWriter.GetStringBuilder().ToString();
                }
            }
        }

        private XmlDocument PrepareDocument(ExternFunctionAttribute att, params object[] parameters)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
            doc.AppendChild(dec);

            XmlElement exter = doc.CreateElement("Extern");

            XmlElement element = doc.CreateElement("Address");

            if (att.UseStaticAddress)
            {
                element.InnerText = att.Address.ToString();
            }
            else
            {
                element.InnerText = GetAddress(att.Module, att.Offset).ToString();
            }
            exter.AppendChild(element);

            element = doc.CreateElement("CallingConvention");
            element.InnerText = ((int)att.CallingConvention).ToString();
            exter.AppendChild(element);


            element = doc.CreateElement("Parameters");

            XmlAttribute count = doc.CreateAttribute("Count");
            count.Value = parameters.Length.ToString();
            element.Attributes.Append(count);

            XmlElement param = null;

          
            for(int i =parameters.Length-1; i >= 0;i--)
            {
                param = doc.CreateElement("Parameter");
                XmlAttribute attr = doc.CreateAttribute("Offset");
                attr.Value = i.ToString();
                param.Attributes.Append(attr);

                attr = doc.CreateAttribute("Type");
                attr.Value = MapToUnmanagedType(parameters[i].GetType());
                param.Attributes.Append(attr);


                

                //if (attr.Value == "struct")
                //{
                //    param.InnerText = Convert.ToBase64String(StructToByteArray(parameters[i]));
                //}
                //else if (attr.Value == "pointer")
                //{
                //    attr.Value = "struct";
                //    Pointer p = (Pointer)parameters[i];
                //    param.InnerText = Convert.ToBase64String(StructToByteArray(p.Value));
                //}
                //else
                //{
                    param.InnerText = parameters[i].ToString();
               // }

             
                element.AppendChild(param);
            }

            exter.AppendChild(element);

            doc.AppendChild(exter);


            return doc;
        }

        protected void CallFunction(params object[] parameters)
        {
            StackTrace st = new StackTrace();
            StackFrame frame = st.GetFrame(1);
            var method = frame.GetMethod();
           
            var attribute = method.GetCustomAttributes(typeof(ExternFunctionAttribute), false);
           

            ExternFunctionAttribute externAtt = null;

            if (attribute.Length > 0)
            {
                externAtt = (ExternFunctionAttribute)attribute[0];
            }

            XmlDocument doc = PrepareDocument(externAtt, parameters);
            string s = GetXmlDocumentAsString(doc);

            string pipe = "extern_" + process.Id.ToString();
            NamedPipeClientStream client = new NamedPipeClientStream(".", pipe, PipeDirection.InOut, PipeOptions.Asynchronous);
            client.Connect();
            
            client.Write(Encoding.ASCII.GetBytes(s), 0, s.Length);
            client.Close();

        }
    }
}
