using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HidLibrary;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading;

namespace Redragon_Driver
{
    public partial class Form1 : Form
    {

        private HidDevice hid;
        public Form1()
        {
            InitializeComponent();

       
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct KeyColorChange
        {
            internal byte unk0;
            public ushort KeyRGBVal;
            internal ushort unk1;
            public ushort keyIndex;
            internal byte unk2;
            public byte r;
            public byte g;
            public byte b;
        }

        public static UInt16 ReverseBytes(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        public void SetKeyColor(HidDevice device, ushort key, Color color)
        {
            KeyColorChange kcc = new KeyColorChange();
            kcc.unk0 = 0x04;

            kcc.KeyRGBVal = (ushort)((key > 84 ? ((key - 85) * 3) : (key * 3)) + color.R + color.G + color.B + 0x14); 
            kcc.unk1 = 0x311;
            kcc.keyIndex = (ushort)(key * 3);
            kcc.unk2 = 0x00;
            kcc.r = color.R;
            kcc.g = color.G;
            kcc.b = color.B;

            device.Write(ToByteArray(kcc));
        }
        
        byte[] ToByteArray<T>(T t)
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(t, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
            HidLibrary.HidDevice[] devices = Enumerable.ToArray<HidDevice>(HidDevices.Enumerate());

            hid = devices[7];
            timer1.Start();
            //byte[] b = {0x04, 0x94, 0x01,
            //            0x11, 0x03, 0x81, 0x00, 0x00, 0xff, 0x00, 0x00};
            //foreach (HidLibrary.HidDevice hid in HidDevices.Enumerate())
            //{
            //    if(hid.Attributes.ProductId == 0x5004)
            //    {
            //        hid.Write(b);
            //    }
            //}
            //HidLibrary.
            //SharpLib.Hid.Device d = new SharpLib.Hid.Device()
            //foreach (HidDevice hd in DeviceList.Local.GetDevices(DeviceTypes.Hid))
            //{
            //    if(hd.GetManufacturer() == "SONiX")
            //    {
            //        HidStream hs;

            //        bool open = hd.TryOpen(out hs);

            //        if (!open)
            //            continue;

            //        byte[] b = {0x04, 0x94, 0x01,
            //            0x11, 0x03, 0x81, 0x00, 0x00, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            //            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            //            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            //            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

            //        if (hs.CanWrite)
            //            .Write(b);


            //        hs.Close();

            //    }
            //            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(ColorDialog cd = new ColorDialog())
            {
                HidLibrary.HidDevice[] devices = Enumerable.ToArray<HidDevice>(HidDevices.Enumerate());
                if (cd.ShowDialog() == DialogResult.OK)
                {
                
                        if (devices[7].Attributes.ProductId == 0x5004)
                        {
                            SetKeyColor(devices[7], 109, cd.Color);
                        }
                
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HidLibrary.HidDevice[] devices = Enumerable.ToArray<HidDevice>(HidDevices.Enumerate());
            if (hid.Attributes.ProductId == 0x5004)
                {
                    Random r = new Random();

                    for (int i = 0; i < 125; i++)
                    {
                   //Thread.Sleep(100);
                        SetKeyColor(hid, (ushort)i, Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
                    }
                }
            }
        }
    }

