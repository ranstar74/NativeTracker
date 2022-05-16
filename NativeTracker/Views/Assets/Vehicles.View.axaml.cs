using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NativeTracker.ViewModels.Assets;

namespace NativeTracker.Views.Assets;

public partial class VehiclesView : UserControl
{
    public VehiclesView()
    {
        InitializeComponent();

        var vm = new VehicleListViewModel();
        DataContext = vm;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}