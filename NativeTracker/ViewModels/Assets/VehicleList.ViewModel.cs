using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Collections;
using Avalonia.Threading;
using Google.Protobuf;
using nativeTrackerClientLibrary;
using nativeTrackerClientService;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using VehicleService = nativeTrackerClientLibrary.Services.VehicleService;

namespace NativeTracker.ViewModels.Assets;

public class VehicleListViewModel : ViewModel
{
    public AvaloniaList<GetVehiclesResponse> Vehicles { get; } = new();

    [Reactive] public GetVehiclesResponse SelectedVehicle { get; set; }

    public ICommand AddVehicleCommand { get; }
    public ICommand EditVehicleCommand { get; }
    public ICommand RefreshCommand { get; }

    [Reactive] public bool IsUpdating { get; set; }

    private readonly VehicleService _vehicleService = new();

    public VehicleListViewModel()
    {
        AddVehicleCommand = ReactiveCommand.Create(async () =>
        {
            var addVm = await Interactions.AddVehicleInteraction.Handle(Unit.Default);

            await _vehicleService.AddVehicle(new AddVehicleRequest()
            {
                Name = addVm.Name,
                Photo = ByteString.CopyFrom(addVm.Photo)
            });

            await Update();
        });
        //
        // EditVehicleCommand = ReactiveCommand.Create(async () =>
        // {
        //     var addVm = await Interactions.EditVehicleInteraction.Handle(new VehicleAddViewModel());
        //
        //     await _vehicleService.AddVehicle(new AddVehicleRequest()
        //     {
        //         Name = addVm.Name,
        //         Photo = ByteString.CopyFrom(addVm.Photo)
        //     });
        //
        //     await Update();
        // });


        var canRefresh = this.WhenAnyValue(
            x => x.IsUpdating,
            isUpdating => !isUpdating);

        RefreshCommand = ReactiveCommand.CreateFromTask(async () => { await Update(); }, canRefresh);

        _ = Update();
    }

    private async Task Update()
    {
        if (!await CredentialsManager.IsAuthorized())
            return;

        IsUpdating = true;

        Vehicles.Clear();
        await foreach (var vehicle in _vehicleService.GetVehicles())
        {
            await Dispatcher.UIThread.InvokeAsync(() => Vehicles.Add(vehicle));
        }

        IsUpdating = false;
    }
}