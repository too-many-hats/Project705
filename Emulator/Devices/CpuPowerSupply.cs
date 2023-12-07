using System.Diagnostics;

namespace Emulator.Devices;

[DebuggerVisualizer("{Name} - {AddressLow},{AddressHigh}")]
public class CpuPowerSupply : IDevice
{
    public string Name => "745 Power Supply";
    public decimal MonthlyRental1958 => 1200;
    public decimal PurchaseCost1958 => 62400;
    public List<IDevice> AttachedDevices { get; init; } = [];
}