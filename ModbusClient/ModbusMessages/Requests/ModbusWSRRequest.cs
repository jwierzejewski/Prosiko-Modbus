using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Requests
{
    internal class ModbusWSRRequest : ModbusMessage
    {
        public ModbusWSRRequest(ushort registerAdress, ushort registerValue) : base(0x06, 4)
        {
            Data.FillTwoBytes(1, registerAdress);
            Data.FillTwoBytes(3, registerValue);
        }
    }
}
