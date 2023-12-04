namespace Emulator.Devices;

public class DrumPowerSupply : IDevice
{
    public string Name => "744 Magnetic Drum Power Supply";
    public decimal MonthlyRental1958 => 500;
    public decimal PurchaseCost1958 => 21500;
    public List<IDevice> AttachedDevices { get; init; } = [];
}