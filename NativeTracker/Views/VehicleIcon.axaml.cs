using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NativeTracker.Views;

public partial class VehicleIcon : UserControl
{
    public VehicleIcon()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}