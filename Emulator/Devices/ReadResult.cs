namespace Emulator.Devices;

public class ReadResult
{
    public byte[] Characters { get; set; } = [];
    public ulong Duration { get; set; }
}