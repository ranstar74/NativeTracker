using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NativeTracker.Views.Assets;

public partial class CreateTrackIssueWindow : Window
{
    public CreateTrackIssueWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}