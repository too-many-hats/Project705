namespace Emulator.Devices;

public class PrinterControl : IDevice
{
    public string Name => "757 Printer Control";
    public decimal MonthlyRental1958 => 650;
    public decimal PurchaseCost1958 => 44000;
    public List<IDevice> AttachedDevices { get; init; } = [];
}