using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MBClient.ModbusMessages.Requests
{
    internal class ModbusWSCRequest : ModbusMessage
    {
        public ModbusWSCRequest(ushort outputAdress, ushort outputValue) : base(0x05, 4)
        {
            Data.FillTwoBytes(1, outputAdress);
            Data.FillTwoBytes(3, outputValue);
        }
    }
}
