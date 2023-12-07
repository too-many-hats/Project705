using System.Diagnostics;

namespace Emulator.Devices;

[DebuggerVisualizer("{Name} - {AddressLow},{AddressHigh}")]
public class ConsoleAndTypewriter : IDevice, IOutputDevice
{
    public string Name => "782 Console and Typewriter";
    public decimal MonthlyRental1958 => 1000;
    public decimal PurchaseCost1958 => 52000;
    public List<IDevice> AttachedDevices { get; init; } = [];
    public int AddressLow { get; init; }
    public int AddressHigh { get; init; }
    public bool InputOutputIndicator => throw new NotImplementedException();

    public void Cycle(int targetMicroseconds)
    {
        throw new NotImplementedException();
    }

    public ulong Write(byte[] data)
    {
        throw new NotImplementedException();
    }
}