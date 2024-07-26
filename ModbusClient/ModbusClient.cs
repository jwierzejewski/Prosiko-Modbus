using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBClient.ModbusMessages;
using MBClient.ModbusMessages.Responses;

namespace MBClient
{
    public abstract class ModbusClient
    {
        public ModbusMessage QA(ModbusMessage modbusRequest)
        {
            if (!WriteRequest(modbusRequest))
                return null;
            return ReadMessage();
        }

        protected abstract ModbusMessage ReadMessage();
        protected abstract bool WriteRequest(ModbusMessage modbusRequest);

        public ModbusMessage GetResponseMessage(byte[] data)
        {
            ModbusMessage answer;
            switch (data[0])
            {
                case 0x01:
                    answer = new ModbusRCResponse(data);
                    break;
                case 0x02:
                    answer = new ModbusRDIResponse(data);
                    break;
                case 0x03:
                    answer = new ModbusRHRResponse(data);
                    break;
                case 0x04:
                    answer = new ModbusRIRResponse(data);
                    break;
                case 0x05:
                    answer = new ModbusWSCResponse(data);
                    break;
                case 0x06:
                    answer = new ModbusWSRResponse(data);
                    break;
                case 0x0F:
                    answer = new ModbusWMCResponse(data);
                    break;
                case 0x10:
                    answer = new ModbusWMRResponse(data);
                    break;
                case 0x17:
                    answer = new ModbusRWMRResponse(data);
                    break;
                default:
                    if (data[0] >= 0x80)
                        answer = new ModbusErrorResponse(data);
                    else
                    {
                        answer = new ModbusMessage(0, data.Length);
                    }
                    break;
            }
            return answer;
        }
    }
}
