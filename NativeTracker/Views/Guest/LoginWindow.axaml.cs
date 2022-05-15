using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NativeTracker.ViewModels.Guest;

namespace NativeTracker.Views.Guest;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        var vm = new LoginWindowViewModel();
        DataContext = vm;
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}