using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NativeTracker.Views.Assets;

public partial class TrackIssuesView : UserControl
{
    public TrackIssuesView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}