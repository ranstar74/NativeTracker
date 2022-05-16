using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NativeTracker.ViewModels.Guest;

namespace NativeTracker.Views.Guest;

public partial class SignUpView : UserControl
{
    public SignUpView()
    {
        InitializeComponent();

        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, EventArgs e)
    {
        if (DataContext is not SignUpViewModel vm)
            return;

        var createBtn = this.FindControl<Button>("CreateButton");
        vm.LoginBegin += () => { createBtn.IsEnabled = false; };

        vm.LoginEnd += () => { createBtn.IsEnabled = true; };
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}