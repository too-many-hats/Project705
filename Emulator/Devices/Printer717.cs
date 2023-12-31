﻿using System.Diagnostics;

namespace Emulator.Devices;

[DebuggerVisualizer("{Name} - {AddressLow},{AddressHigh}")]
public class Printer717 : IOutputDevice
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