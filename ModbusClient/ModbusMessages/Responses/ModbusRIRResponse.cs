using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Responses
{
    internal class ModbusRIRResponse:ModbusMessage
    {
        public byte ByteCount { get { return Data[1]; } }
        public ushort[] InputRegisters { get { return Data.Skip(2).Take(ByteCount).ToArray().ConvertByteDataToUShortData(); } }

        public ModbusRIRResponse(byte[] data):base(0x04,data.Length) 
        {
            this.Data = data;
        }
    }
}
