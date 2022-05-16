using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NativeTracker.Views.Assets;

public partial class VehiclesView : UserControl
{
    public VehiclesView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}