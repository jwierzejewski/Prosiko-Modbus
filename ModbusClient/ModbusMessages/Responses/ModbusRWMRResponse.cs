using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Responses
{
    internal class ModbusRWMRResponse:ModbusMessage
    {
        public byte ByteCount { get { return Data[1]; } }
        public ushort[] ReadRegistersValue { get { return Data.Skip(2).Take(ByteCount).ToArray().ConvertByteDataToUShortData(); } }

        public ModbusRWMRResponse(byte[] data):base(0x17,data.Length) 
        {
            this.Data = data;
        }
    }
}
