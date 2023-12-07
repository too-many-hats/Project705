using Avalonia.Controls;
using DebugAssembler;
using Emulator;
using Emulator.Devices;
using Emulator.Devices.Cpu;
using System.Linq;

namespace DesktopApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var installation = Installation.CreateDefault();
        var statistics = installation.GetStatistics();

        InstallationCostLabel.Content = statistics.PurchaseCost.ToString("C");
        InstallationRentalLabel.Content = statistics.MonthlyCost.ToString("C");
        InstallationExecutionTimeCostLabel.Content = statistics.MonthlyCost.ToString("C");

        var testProgram = new Dasm()
            .Ins(Dasm.RAD, 12)
            .Ins(Dasm.HLT, 1)
            .Num(5, 3)
            .GetCharacters();

        var cpu = installation.GetDevices<Processor>().First();

        for (int i = 0; i < testProgram.Length; i++)
        {
            cpu.Memory[i] = testProgram[i];
        }

        var consoleDevice = installation.GetDevices<ConsoleAndTypewriter>().First();

        var consoleWindow = new OperatorsConsole.MainWindow(consoleDevice);
        consoleWindow.Show();

        //Create a tree of all the devices in our installation, their component addresses and cost.
        // This gives a way to glance at the device configuration of our entire installation.

        // A 705 only allows three levels of devices, an independentDevice (like the CPU), then a controller, and finally the I/O device itself.
        // So we can safely use three loops here to traverse all devices without risk of missing any.
        var rowNumber = 1;
        foreach (var independentDevice in installation.IndependentDevices)
        {
            CreateInstallationDeviceUI(independentDevice, rowNumber, 0);
            rowNumber++;

            foreach (var attachedDevice in independentDevice.AttachedDevices)
            {
                CreateInstallationDeviceUI(attachedDevice, rowNumber, 1);
                rowNumber++;

                foreach (var finalDevice in attachedDevice.AttachedDevices)
                {
                    CreateInstallationDeviceUI(finalDevice, rowNumber, 2);
                    rowNumber++;
                }
            }
        }
    }

    private void CreateInstallationDeviceUI(IDevice device, int rowNumber, int indentLevel)
    {
        InstallationComponetsGrid.RowDefinitions.Add(new RowDefinition(28, GridUnitType.Pixel));
        var nameLabel = new Label
        {
            // ghetto implementation of indenting until I set up a proper one.
            Content = new string(Enumerable.Range(0, indentLevel * 4).Select(_ => ' ').ToArray()) + device.Name,
        };

        InstallationComponetsGrid.Children.Add(nameLabel);
        Grid.SetRow(nameLabel, rowNumber);

        var componentAddressLow = -1;
        var componentAddressHigh = -1;

        if (device is IOutputDevice outputDevice)
        {
            componentAddressLow = outputDevice.AddressLow;
            componentAddressHigh = outputDevice.AddressHigh;
        }

        if (device is IInputDevice inputDevice)
        {
            componentAddressLow = inputDevice.AddressLow;
            componentAddressHigh = inputDevice.AddressHigh;
        }

        if (componentAddressHigh > -1 && componentAddressLow > -1)
        {
            var addressLabel = new Label
            {
                Content = componentAddressLow == componentAddressHigh ? componentAddressLow : componentAddressLow + "-" + componentAddressHigh,
            };

            InstallationComponetsGrid.Children.Add(addressLabel);
            Grid.SetColumn(addressLabel, 1);
            Grid.SetRow(addressLabel, rowNumber);
        }

        var costLabel = new Label
        {
            Content = InflationUtils.Adjust1958ToToday(device.MonthlyRental1958).ToString("C"),
            HorizontalContentAlignment = Avalonia.Layout.HorizontalAlignment.Right
        };

        InstallationComponetsGrid.Children.Add(costLabel);
        Grid.SetColumn(costLabel, 2);
        Grid.SetRow(costLabel, rowNumber);
    }
}
