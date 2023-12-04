namespace Emulator.Devices;

public class Drum : IDevice, IOutputDevice, IInputDevice
{
    public string Name => "734 Magnetic Drum Storage";
    public decimal MonthlyRental1958 => 2300;
    public decimal PurchaseCost1958 => 90000;
    public List<IDevice> AttachedDevices { get; init; } = [];
    public int AddressLow { get; init; }
    public int AddressHigh { get; init; }
    public bool InputOutputIndicator { get; private set; }

    public void Cycle(int targetMicroseconds)
    {
        throw new NotImplementedException();
    }

    public ReadResult Read()
    {
        throw new NotImplementedException();
    }

    public ulong Write(byte[] data)
    {
        throw new NotImplementedException();
    }
}