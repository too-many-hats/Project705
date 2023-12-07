using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Emulator.Devices;

namespace DesktopApp.Views.OperatorsConsole;

public partial class MainWindow : Window
{
    public MainWindow(ConsoleAndTypewriter consoleAndTypewriter)
    {
        InitializeComponent();
    }
}