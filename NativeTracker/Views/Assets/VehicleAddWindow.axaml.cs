using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using NativeTracker.ViewModels.Assets;
using ReactiveUI;

namespace NativeTracker.Views.Assets;

public partial class VehicleAddWindow : ReactiveWindow<VehicleAddViewModel>
{
    private readonly List<FileDialogFilter> _filters;

    public VehicleAddWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        _filters = new List<FileDialogFilter>()
        {
            new()
            {
                Name = "Images (.png; .jpg)"
            }
        };

        this.WhenActivated(d => d(ViewModel!.ShowOpenFileDialog.RegisterHandler(
            ShowOpenFileDialog)));
        this.WhenActivated(d => d(ViewModel!.CancelCommand.Subscribe(_ => Close())));
        this.WhenActivated(d => d(ViewModel!.SaveCommand.Subscribe(Close)));
    }

    private async Task ShowOpenFileDialog(InteractionContext<Unit, string> interaction)
    {
        var dialog = new OpenFileDialog()
        {
            Title = "Pick a photo",
            Filters = _filters
        };
        string[] result = await dialog.ShowAsync(this);

        string path = result == null || result.Length == 0 ? string.Empty : result[0];
        interaction.SetOutput(path);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}