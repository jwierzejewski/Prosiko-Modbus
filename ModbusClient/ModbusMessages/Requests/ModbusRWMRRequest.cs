using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Requests
{
    internal class ModbusRWMRRequest : ModbusMessage
    {
        public ModbusRWMRRequest(ushort readStartAdress, ushort quantityToRead, ushort[] valuesToWrite, ushort writeStartAdress) : base(0x17, 2 * valuesToWrite.Length + 9)
        {
            Data.FillTwoBytes(1, readStartAdress);
            Data.FillTwoBytes(3, (ushort)quantityToRead);
            Data.FillTwoBytes(5, writeStartAdress);
            Data.FillTwoBytes(7, (ushort)valuesToWrite.Length);
            Data[9] = (byte)(2 * valuesToWrite.Length);
            for (int i = 0; i < valuesToWrite.Length; i++)
            {
                Data.FillTwoBytes(10 + 2 * i, valuesToWrite[i]);
            }
        }
    }
}
