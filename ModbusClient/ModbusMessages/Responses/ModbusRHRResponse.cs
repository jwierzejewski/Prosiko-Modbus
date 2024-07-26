using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Responses
{
    internal class ModbusRHRResponse:ModbusMessage
    {
        public byte ByteCount { get { return Data[1]; } }
        public ushort[] RegisterValue { get { return Data.Skip(2).Take(ByteCount).ToArray().ConvertByteDataToUShortData(); } }

        public ModbusRHRResponse(byte[] data):base(0x03,data.Length) 
        {
            this.Data = data;
        }
    }
}
