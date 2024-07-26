using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Responses
{
    internal class ModbusWSRResponse:ModbusMessage
    {
        public ushort RegisterAdress { get { return Data.GetTwoBytes(1); } }
        public ushort RegisterValue { get { return Data.GetTwoBytes(3); } }

        public ModbusWSRResponse(byte[] data):base(0x06,data.Length) 
        {
            this.Data = data;
        }
    }
}
