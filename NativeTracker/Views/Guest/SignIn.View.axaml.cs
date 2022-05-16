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

        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, EventArgs e)
    {
        if (DataContext is not SignInViewModel vm)
            return;

        vm.LoginEnd += () =>
        {
            
        };
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}