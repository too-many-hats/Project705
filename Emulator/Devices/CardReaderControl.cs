namespace Emulator.Devices;

public class CardReaderControl : IDevice
{
    public string Name => "759 Card Reader Control";
    public decimal MonthlyRental1958 => 900;
    public decimal PurchaseCost1958 => 45000;
    public List<IDevice> AttachedDevices { get; init; } = [];
}