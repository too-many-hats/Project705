﻿namespace Emulator.Devices;

public interface IInputDevice
{
    public int AddressLow { get; }
    public int AddressHigh { get; }
    public bool InputOutputIndicator { get; }

    public void Cycle(int targetMicroseconds);
    public ReadResult Read();
}
