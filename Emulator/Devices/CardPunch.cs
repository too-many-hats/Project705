
using System.Diagnostics;

namespace Emulator.Devices;

[DebuggerVisualizer("{Name} - {AddressLow},{AddressHigh}")]
public class CardPunch : IOutputDevice
{
    public string Name => "722 Card Punch";
    public decimal MonthlyRental1958 => 800;
    public decimal PurchaseCost1958 => 43300;
    public List<IDevice> AttachedDevices => [];
    public int AddressLow { get; init; }
    public int AddressHigh { get; init; }
    public bool InputOutputIndicator { get; private set; }

    public void Cycle(int targetMicroseconds)
    {
        throw new NotImplementedException();
    }

    public ulong Write(byte[] data)
    {
        throw new NotImplementedException();
    }
}