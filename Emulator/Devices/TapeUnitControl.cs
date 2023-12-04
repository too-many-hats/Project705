namespace Emulator.Devices;

public class TapeUnitControl : IDevice
{
    public string Name => "754 Tape Control";
    public decimal MonthlyRental1958 => 1500;
    public decimal PurchaseCost1958 => 78000;
    public List<IDevice> AttachedDevices { get; init; } = [];
}