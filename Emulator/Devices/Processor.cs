namespace Emulator.Devices;

public class Processor : IDevice
{
    public string Name => "705 II CPU";
    public decimal MonthlyRental1958 => 14150;
    public decimal PurchaseCost1958 => 590000;
    public List<IDevice> AttachedDevices { get; init; } = [];

    public ulong Cycle(ulong targetMicroseconds)
    {
        return 0;
    }
}

