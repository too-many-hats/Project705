using Emulator.Devices;
using Emulator.Devices.Cpu;

namespace Emulator;

public class Installation
{
    public required string Name { get; init; }
    public List<IDevice> IndependentDevices { get; set; } = [];

    public InstallationStatistics GetStatistics()
    {
        var result = new InstallationStatistics();

        foreach (var device in IndependentDevices)
        {
            CalculateStatistics(device, result);
        }

        result.PurchaseCost = InflationUtils.Adjust1958ToToday(result.PurchaseCost);
        result.MonthlyCost = InflationUtils.Adjust1958ToToday(result.MonthlyCost);

        return result;
    }

    private static void CalculateStatistics(IDevice device, InstallationStatistics installationStatistics)
    {
        installationStatistics.PurchaseCost += device.PurchaseCost1958;
        installationStatistics.MonthlyCost += device.MonthlyRental1958;

        foreach(var attachedDevice in device.AttachedDevices)
        {
            CalculateStatistics(attachedDevice, installationStatistics);
        }
    }

    public static Installation CreateDefault()
    {
        var installation = new Installation { Name = "Default Installation"};

        var cardPunch = new CardPunch
        {
            AddressHigh = 300,
            AddressLow = 300,
        };

        var cardPunchControl = new CardPunchControl
        {
            AttachedDevices = [cardPunch]
        };

        var cardReader = new CardReader
        {
            AddressHigh = 100,
            AddressLow = 100,
        };

        var cardReaderControl = new CardReaderControl
        {
            AttachedDevices = [cardReader]
        };

        var printer717 = new Printer717
        {
            AddressHigh = 400,
            AddressLow = 400,
        };

        var printer717Control = new PrinterControl
        {
            AttachedDevices = [printer717]
        };

        var cpuPowerSupply = new CpuPowerSupply();

        var tapeUnits = Enumerable.Range(0, 4).Select(x => new TapeUnit
        {
            AddressHigh = 200 + x,
            AddressLow = 200 + x,
        });

        var tapeUnitControl = new TapeUnitControl
        {
            AttachedDevices = tapeUnits.Cast<IDevice>().ToList()
        };

        var drumPowerSupply = new DrumPowerSupply();

        var drum = new Drum
        {
            AddressLow = 1000,
            AddressHigh = 1299,
            AttachedDevices = [drumPowerSupply]
        };

        var printer730 = new Printer730
        {
            AddressLow = 0,
            AddressHigh = 0,
        };

        var recordStorageAndControl = new RecordControlAndStorage
        {
            AttachedDevices = [printer730],
            AddressLow = 210,
            AddressHigh = 214,
        };

        var console = new ConsoleAndTypewriter
        {
            AddressLow = 500,
            AddressHigh = 500,
        };

        var cpu = new Processor
        { 
            AttachedDevices =
            [
                cardPunchControl, cardReaderControl, printer717Control, cpuPowerSupply, tapeUnitControl, drum, recordStorageAndControl, console
            ]
        };

        installation.IndependentDevices.Add(cpu);

        return installation;
    }

    public IEnumerable<T> GetDevices<T>()
    {
        var matchingDevices = new List<IDevice>();

        foreach (var device in IndependentDevices)
        {
            FindDevicesByType<T>(device, matchingDevices);
        }

        return matchingDevices.Cast<T>();
    }

    private List<IDevice> FindDevicesByType<T>(IDevice device, List<IDevice> matchingDevices)
    {
        if (device.GetType() == typeof(T))
        {
            matchingDevices.Add(device);
        }

        foreach (var attachedDevice in device.AttachedDevices)
        {
            FindDevicesByType<T>(attachedDevice, matchingDevices);
        }

        return matchingDevices;
    }
}