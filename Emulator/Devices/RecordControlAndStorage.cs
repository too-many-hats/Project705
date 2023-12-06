namespace Emulator.Devices;

public class RecordControlAndStorage : IOutputDevice, IInputDevice
{
    public string Name => "760 Control & Storage";
    public decimal MonthlyRental1958 => 2500;
    public decimal PurchaseCost1958 => 111000;
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