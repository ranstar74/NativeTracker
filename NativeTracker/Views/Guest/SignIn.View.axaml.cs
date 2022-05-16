using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NativeTracker.ViewModels.Guest;

namespace NativeTracker.Views.Guest;

public partial class SignInView : UserControl
{
    public SignInView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}