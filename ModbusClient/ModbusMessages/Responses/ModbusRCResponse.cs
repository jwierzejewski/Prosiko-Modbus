using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Responses
{
    internal class ModbusRCResponse:ModbusMessage
    {
        public byte ByteCount { get { return Data[1]; } }
        public byte[] CoilStatus { get { return Data.Skip(2).Take(ByteCount).ToArray(); } }

        public ModbusRCResponse(byte[] data):base(0x01,data.Length) 
        {
            this.Data = data;
        }
    }
}
