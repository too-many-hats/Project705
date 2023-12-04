namespace Emulator.Devices;

public class TapeUnit : IDevice, IOutputDevice, IInputDevice
{
    public string Name => "727 Magnetic Tape Unit";
    public decimal MonthlyRental1958 => 550;
    public decimal PurchaseCost1958 => 18200;
    public List<IDevice> AttachedDevices => [];
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