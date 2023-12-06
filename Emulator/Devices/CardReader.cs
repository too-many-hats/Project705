
namespace Emulator.Devices;

public class CardReader : IInputDevice
{
    public string Name => "714 Card Reader";
    public decimal MonthlyRental1958 => 1500;
    public decimal PurchaseCost1958 => 64450;
    public List<IDevice> AttachedDevices { get; set; } = [];
    public int AddressLow { get; set; }
    public int AddressHigh { get; set; }
    public bool InputOutputIndicator { get; set; }

    public void Cycle(int targetMicroseconds)
    {
        throw new NotImplementedException();
    }

    public ReadResult Read()
    {
        throw new NotImplementedException();
    }
}