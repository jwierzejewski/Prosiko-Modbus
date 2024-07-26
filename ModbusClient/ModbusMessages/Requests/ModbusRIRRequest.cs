using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MBClient.ModbusMessages.Requests
{
    public class ModbusRIRRequest : ModbusMessage
    {
        public ModbusRIRRequest(ushort startAdress, ushort quantity) : base(0x04, 4)
        {
            Data.FillTwoBytes(1, startAdress);
            Data.FillTwoBytes(3, quantity);
        }
    }
}
