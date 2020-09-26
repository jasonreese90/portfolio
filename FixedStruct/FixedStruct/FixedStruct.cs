
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Kunihiro.FixedStruct
{
    public class FixedStruct
    {
        private static object GetBitFieldValue(FixedFieldAttribute att,Type type, byte[] buffer)
        {
            int size = att.Size;
            int offset = att.Offset;
            int bitoffset = att.BitOffset;

            if(type == typeof(bool))
            {
                long val = Convert.ToInt64(GetFieldValue(att, att.BitFieldType, buffer));

                return ((val & bitoffset) == bitoffset);
            }

            return null;
        }

        private static object GetFieldValue(FixedFieldAttribute att,Type type, byte[] buffer)
        {
            int size = att.Size;
            int offset = att.Offset;

            if (type == typeof(int))
            {
                return BitConverter.ToInt32(buffer, offset);
            }

            if (type == typeof(short))
            {
                return BitConverter.ToInt16(buffer, offset);
            }

            if (type == typeof(long))
            {
                return BitConverter.ToInt64(buffer, offset);
            }

            if (type == typeof(uint))
            {
                return BitConverter.ToUInt32(buffer, offset);
            }

            if (type == typeof(ushort))
            {
                return BitConverter.ToUInt16(buffer, offset);
            }

            if (type == typeof(ulong))
            {
                return BitConverter.ToUInt64(buffer, offset);
            }

            if (type == typeof(float))
            {
                return BitConverter.ToSingle(buffer, offset);
            }

            if (type == typeof(double))
            {
                return BitConverter.ToDouble(buffer, offset);
            }

            if (type == typeof(int))
            {
                return BitConverter.ToInt32(buffer, offset);
            }

            if (type == typeof(byte))
            {
                return buffer[offset];
            }

            if (type == typeof(sbyte))
            {
                return (sbyte)buffer[offset];
            }

            if (type == typeof(char))
            {
                return (char)buffer[offset];
            }

            if (type == typeof(bool))
            {
                return BitConverter.ToBoolean(buffer, offset);
            }

            if(type == typeof(string))
            {
                return Encoding.ASCII.GetString(buffer, offset, size);
            }

            if (type == typeof(IntPtr))
            {
                return (IntPtr)BitConverter.ToInt32(buffer, offset);
            }

            if (type == typeof(decimal))
            {
               
            }
            if (type == typeof(object))
            {
                
            }

            return null;
        }

        public static T ReadStruct<T>(IntPtr processHandle, IntPtr address) where T : struct
        {
            Type type = typeof(T);

            FixedStructAttribute fixedAttribute =
                (FixedStructAttribute)type.GetCustomAttributes(typeof(FixedStructAttribute), false)[0];

            if(fixedAttribute == null)
            {
                //todo
                return default(T);
            }

            int structSize = fixedAttribute.Size;

            byte[] buffer = new byte[structSize];
            ReadProcessMemory(processHandle, address, buffer, structSize, 0);

            FieldInfo[] fields = type.GetFields();

            T t = new T();
            TypedReference r = __makeref(t);

            foreach (FieldInfo f in fields)
            {
                FixedFieldAttribute fieldAttribute = f.GetCustomAttribute<FixedFieldAttribute>();

                if (fieldAttribute == null)
                    continue;

                if (fieldAttribute.Type == FixedFieldType.Value)
                {
                    f.SetValueDirect(r, GetFieldValue(fieldAttribute, f.FieldType, buffer));
                }
                else if(fieldAttribute.Type == FixedFieldType.BitField)
                {
                    f.SetValueDirect(r, GetBitFieldValue(fieldAttribute, f.FieldType, buffer));
                }
            }

            return t;
        }

        [DllImport("kernel32")]
        static extern bool ReadProcessMemory(IntPtr handle, IntPtr address, byte[] buffer, int size, int zero);
    }
}
