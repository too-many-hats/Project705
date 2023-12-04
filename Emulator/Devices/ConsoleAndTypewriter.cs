namespace Emulator.Devices;

public class ConsoleAndTypewriter : IDevice
{
    public string Name => "782 Console and Typewriter";
    public decimal MonthlyRental1958 => 1000;
    public decimal PurchaseCost1958 => 52000;
    public List<IDevice> AttachedDevices { get; init; } = [];
}