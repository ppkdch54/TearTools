using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵撕检测.Helpers
{
    class CRC16
    {
        public static byte[] crc_16(byte[] data)
        {
            uint IX, IY;
            ushort crc = 0xFFFF;//set all 1

            int len = data.Length;
            if (len <= 0)
                crc = 0;
            else
            {
                len--;
                for (IX = 0; IX <= len; IX++)
                {
                    crc = (ushort)(crc ^ (data[IX]));
                    for (IY = 0; IY <= 7; IY++)
                    {
                        if ((crc & 1) != 0)
                            crc = (ushort)((crc >> 1) ^ 0xA001);
                        else
                            crc = (ushort)(crc >> 1); //
                    }
                }
            }

            byte buf1 = (byte)((crc & 0xff00) >> 8);//高位置
            byte buf2 = (byte)(crc & 0x00ff); //低位置

            crc = (ushort)(buf1 << 8);
            crc += buf2;

            return new byte[] { buf1, buf2 };
        }

    }
}
