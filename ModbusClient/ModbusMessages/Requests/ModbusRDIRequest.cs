using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Requests
{

    public class ModbusRDIRequest : ModbusMessage
    {
        public ModbusRDIRequest(ushort startAdress, ushort quantity) : base(0x02, 4)
        {
            Data.FillTwoBytes(1, startAdress);
            Data.FillTwoBytes(3, quantity);
        }
    }
}
