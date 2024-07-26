using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Responses
{
    internal class ModbusRDIResponse:ModbusMessage
    {
        public byte ByteCount { get { return Data[1]; } }
        public byte[] InputStatus { get { return Data.Skip(2).Take(ByteCount).ToArray(); } }

        public ModbusRDIResponse(byte[] data):base(0x02,data.Length)
        {
            Data = data;
        }
    }
}
