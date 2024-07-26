using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBClient.ModbusMessages.Responses
{
    internal class ModbusErrorResponse:ModbusMessage
    {
        public byte ExceptionCode { get { return Data[1]; } }
        public ModbusErrorResponse(byte[] data) : base(data[0], data.Length)
        {
            this.Data = data;
        }
    }
}
