namespace Emulator.Devices;

public class Printer717 : IDevice, IOutputDevice
{
    public string Name => "717 Printer";
    public decimal MonthlyRental1958 => 1400;
    public decimal PurchaseCost1958 => 55000;
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