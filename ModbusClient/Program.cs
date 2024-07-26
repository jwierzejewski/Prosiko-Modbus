

using MBClient;
using MBClient.ModbusMessages;
using MBClient.ModbusMessages.Requests;
using MBClient.ModbusMessages.Responses;

//ModbusClient client = new ModbusTCPClient("localhost",502);
ModbusClient client = new ModbusRSClient("COM1", 1);

float[,] brightness = Bitmaps.GetBrightness("D:\\jacek\\jacek\\Prosiko\\np.png", 10,10);

ushort[] tab = {3,3};

ModbusMessage response = client.QA(new ModbusWSCRequest(173, 1));
if (response.Function >= 0x80)
{
    ModbusErrorResponse modbusErrorResponse = (ModbusErrorResponse)response;
    Console.WriteLine($"Error: errorFunctionCode: {modbusErrorResponse.Function} exceptionCode: {modbusErrorResponse.ExceptionCode}");
}
else
{
    ModbusWSCResponse modbusWSCResponse = (ModbusWSCResponse)response;
    Console.WriteLine($"Write Single Coil Successful OutputValue:{modbusWSCResponse.OutputValue}");
}

response = client.QA(new ModbusRCRequest(0, 1));
if (response.Function >= 0x80)
{
    ModbusErrorResponse modbusErrorResponse = (ModbusErrorResponse)response;
    Console.WriteLine($"Error: errorFunctionCode: {modbusErrorResponse.Function} exceptionCode: {modbusErrorResponse.ExceptionCode}");
}
else
{
    ModbusRCResponse modbusRCResponse = (ModbusRCResponse)response;
    Console.Write($"Read Coil Successful\n Coils Values:");
    for (int i = 0; i < modbusRCResponse.CoilStatus.Length; i++)
    {
        Console.Write($" {i}:{modbusRCResponse.CoilStatus[i]}");
    }
    Console.WriteLine();
}


response = client.QA(new ModbusWSRRequest(0, 3));
if (response.Function >= 0x80)
{
    ModbusErrorResponse modbusErrorResponse = (ModbusErrorResponse)response;
    Console.WriteLine($"Error: errorFunctionCode: {modbusErrorResponse.Function} exceptionCode: {modbusErrorResponse.ExceptionCode}");
}
else
{
    ModbusWSRResponse modbusWSRResponse = (ModbusWSRResponse)response;
    Console.WriteLine($"Write Single Register Successful RegisterValue:{modbusWSRResponse.RegisterValue}");
}


response = client.QA(new ModbusRHRRequest(0, 3));
if (response.Function >= 0x80)
{
    ModbusErrorResponse modbusErrorResponse = (ModbusErrorResponse)response;
    Console.WriteLine($"Error: errorFunctionCode: {modbusErrorResponse.Function} exceptionCode: {modbusErrorResponse.ExceptionCode}");
}
else
{
    ModbusRHRResponse modbusRHRResponse = (ModbusRHRResponse)response;
    Console.Write($"Read Holding Registers Successful\n Registers Values:");
    for (int i = 0; i < modbusRHRResponse.RegisterValue.Length; i++)
    {
        Console.Write($" {i}:{modbusRHRResponse.RegisterValue[i]}");
    }
    Console.WriteLine();
}


response = client.QA(new ModbusRIRRequest(0, 5));
if (response.Function >= 0x80)
{
    ModbusErrorResponse modbusErrorResponse = (ModbusErrorResponse)response;
    Console.WriteLine($"Error: errorFunctionCode: {modbusErrorResponse.Function} exceptionCode: {modbusErrorResponse.ExceptionCode}");
}
else
{
    ModbusRIRResponse modbusRIRResponse = (ModbusRIRResponse)response;
    Console.Write($"Read Input Registers Successful\n Registers Values:");
    for (int i = 0; i < modbusRIRResponse.InputRegisters.Length; i++)
    {
        Console.Write($" {i}:{modbusRIRResponse.InputRegisters[i]}");
    }
    Console.WriteLine();
}


response = client.QA(new ModbusRDIRequest(0, 5));
if (response.Function >= 0x80)
{
    ModbusErrorResponse modbusErrorResponse = (ModbusErrorResponse)response;
    Console.WriteLine($"Error: errorFunctionCode: {modbusErrorResponse.Function} exceptionCode: {modbusErrorResponse.ExceptionCode}");
}
else
{
    ModbusRDIResponse modbusRDIResponse = (ModbusRDIResponse)response;
    Console.Write($"Read Discrete Inputs Successful\n Inputs Values:");
    for (int i = 0; i < modbusRDIResponse.InputStatus.Length; i++)
    {
        Console.Write($" {i}:{modbusRDIResponse.InputStatus[i]}");
    }
    Console.WriteLine();
}

byte[] coils = {77,1};
response = client.QA(new ModbusWMCRequest(coils, 27));
if (response.Function >= 0x80)
{
    ModbusErrorResponse modbusErrorResponse = (ModbusErrorResponse)response;
    Console.WriteLine($"Error: errorFunctionCode: {modbusErrorResponse.Function} exceptionCode: {modbusErrorResponse.ExceptionCode}");
}
else
{
    ModbusWMCResponse modbusWMCResponse = (ModbusWMCResponse)response;
    Console.WriteLine($"Write Multiple Coils Successful QuantityOfOutputs:{modbusWMCResponse.QuantityOfOutputs}");
}

ushort[] registersValues = { 255, 255, 255 };
response = client.QA(new ModbusWMRRequest(registersValues, 0));
if (response.Function >= 0x80)
{
    ModbusErrorResponse modbusErrorResponse = (ModbusErrorResponse)response;
    Console.WriteLine($"Error: errorFunctionCode: {modbusErrorResponse.Function} exceptionCode: {modbusErrorResponse.ExceptionCode}");
}
else
{
    ModbusWMRResponse modbusWMRResponse = (ModbusWMRResponse)response;
    Console.WriteLine($"Write Multiple Registers Successful QuantityOfRegisters:{modbusWMRResponse.QuantityOfRegisters}");
}

/*
response = client.QA(new ModbusRWMRRequest(3,6,registersValues,14));
if (response.Function >= 0x80)
{
    ModbusErrorResponse modbusErrorResponse = (ModbusErrorResponse)response;
    Console.WriteLine($"Error: errorFunctionCode: {modbusErrorResponse.Function} exceptionCode: {modbusErrorResponse.ExceptionCode}");
}
else
{
    ModbusRWMRResponse modbusRWMRResponse = (ModbusRWMRResponse)response;
    Console.Write($"Read/Write Multiple Registers Successful \nRegisterValues:");
    for (int i = 0; i < modbusRWMRResponse.ReadRegistersValue.Length; i++)
    {
        Console.Write($" {i}:{modbusRWMRResponse.ReadRegistersValue[i]}");
    }
    Console.WriteLine();
}*/



for (int i = 0; i < 10; i++)
{
    var answer = client.QA(new ModbusWMRRequest(
        Enumerable.Range(0, 10).Select(x => (ushort)(brightness[i, x] > 0.000006 ? 8888 : 1)).ToArray(),
        (ushort)(10 * i)
        ));
}
