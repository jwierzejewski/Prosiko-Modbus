using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Requests
{
    internal class ModbusWMCRequest : ModbusMessage
    {
        public ModbusWMCRequest(byte[] values, ushort startAdress) : base(0x0F, values.Length + 5)
        {
            Data.FillTwoBytes(1, startAdress);
            Data.FillTwoBytes(3, (ushort)(8*values.Length));
            Data[5] = (byte)(values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                Data[6+i] = (byte)(values[i]);
            }
        }
    }
}
