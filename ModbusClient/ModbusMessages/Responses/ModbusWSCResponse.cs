using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Responses
{
    internal class ModbusWSCResponse:ModbusMessage
    {
        public ushort OutputAdress { get { return Data.GetTwoBytes(1); } }
        public ushort OutputValue { get { return Data.GetTwoBytes(3); } }

        public ModbusWSCResponse(byte[] data):base(0x05,data.Length) 
        {
            this.Data = data;
        }
    }
}
