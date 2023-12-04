namespace Emulator.Devices;

public interface IDevice
{
    public string Name { get; }
    public decimal MonthlyRental1958 { get; }
    public decimal PurchaseCost1958 { get; }
    public List<IDevice> AttachedDevices { get; }
}
