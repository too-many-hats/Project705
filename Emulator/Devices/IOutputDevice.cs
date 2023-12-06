namespace Emulator.Devices;

public interface IOutputDevice : IDevice
{
    public int AddressLow { get; }
    public int AddressHigh { get; }
    public bool InputOutputIndicator { get; }

    public void Cycle(int targetMicroseconds);
    public ulong Write(byte[] data);
}
