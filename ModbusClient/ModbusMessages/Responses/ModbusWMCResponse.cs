using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Responses
{
    internal class ModbusWMCResponse:ModbusMessage
    {
        public ushort StartingAddress  { get { return Data.GetTwoBytes(1); } }
        public ushort QuantityOfOutputs { get { return Data.GetTwoBytes(3); } }

        public ModbusWMCResponse(byte[] data):base(0x0F,data.Length) 
        {
            this.Data = data;
        }
    }
}
