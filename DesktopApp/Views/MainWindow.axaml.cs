using Avalonia.Controls;
using Emulator;

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
    }
}
