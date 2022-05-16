using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia.Collections;
using Avalonia.Threading;
using nativeTrackerClientService;
using ReactiveUI;
using VehicleService = nativeTrackerClientLibrary.Services.VehicleService;

namespace NativeTracker.ViewModels.Assets;

public class VehicleListViewModel : ViewModel
{
    public AvaloniaList<GetVehiclesResponse> Vehicles { get; } = new();

    public ICommand AddVehicleCommand { get; }

    private readonly VehicleService _vehicleService = new();

    public VehicleListViewModel()
    {
        AddVehicleCommand = ReactiveCommand.Create(async () =>
        {
            var addVm = await Interactions.AddVehicleInteraction.Handle(Unit.Default);
        });

        Update();
    }

    private async void Update()
    {
        Vehicles.Clear();
        await foreach (var vehicle in _vehicleService.GetVehicles())
        {
            await Dispatcher.UIThread.InvokeAsync(() => Vehicles.Add(vehicle));
        }
    }
}