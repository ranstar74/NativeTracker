using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NativeTracker.Views;

public partial class MapDetailsView : UserControl
{
    public MapDetailsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}