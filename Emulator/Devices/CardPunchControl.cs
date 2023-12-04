
namespace Emulator.Devices;

public class CardPunchControl : IDevice
{
    public string Name => "758 Card Punch Control";
    public decimal MonthlyRental1958 => 600;
    public decimal PurchaseCost1958 => 36000;
    public List<IDevice> AttachedDevices { get; init; } = [];
}