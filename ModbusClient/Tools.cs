using MBClient.ModbusMessages.Responses;
using MBClient.ModbusMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MBClient
{
    public static class Tools
    {
        public static void FillTwoBytes(this byte[] data, int offset, ushort value, bool bigEndian = true)
        {
            if (bigEndian)
            {
                data[offset] = (byte)(value >> 8);
                data[offset + 1] = (byte)value;
            }
            else
            {
                data[offset] = (byte)value;
                data[offset + 1] = (byte)(value >> 8);
            }
        }

        public static ushort GetTwoBytes(this byte[] data, int offset)
        {
            return (ushort)((data[offset] << 8) | data[offset+1]);
        }

        public static ushort[] ConvertByteDataToUShortData(this byte[] data)
        { 
            ushort[] ushortData = new ushort[data.Length / 2];

            for (int i = 0; i < ushortData.Length; i++)
            {
                ushortData[i] = data.GetTwoBytes(i * 2);
            }

            return ushortData;
        }
    }
}
