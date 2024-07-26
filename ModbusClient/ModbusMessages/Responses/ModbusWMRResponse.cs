using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Responses
{
    internal class ModbusWMRResponse:ModbusMessage
    {
        public ushort StartingAddress  { get { return Data.GetTwoBytes(1); } }
        public ushort QuantityOfRegisters { get { return Data.GetTwoBytes(3); } }

        public ModbusWMRResponse(byte[] data):base(0x10,data.Length) 
        {
            this.Data = data;
        }
    }
}
