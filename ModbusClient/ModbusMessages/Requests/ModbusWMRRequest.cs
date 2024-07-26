using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Requests
{
    public class ModbusWMRRequest : ModbusMessage
    {
        public ModbusWMRRequest(ushort[] values, ushort startAdress) : base(0x10, 2 * values.Length + 5)
        {
            Data.FillTwoBytes(1, startAdress);
            Data.FillTwoBytes(3, (ushort)values.Length);
            Data[5] = (byte)(2 * values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                Data.FillTwoBytes(6 + 2 * i, values[i]);
            }
        }
    }
}
