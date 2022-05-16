using System.Reactive;
using NativeTracker.ViewModels.Assets;
using ReactiveUI;

namespace NativeTracker.ViewModels;

public static class Interactions
{
    public static Interaction<Unit, VehicleAddViewModel> AddVehicleInteraction { get; } = new();
    public static Interaction<VehicleAddViewModel, VehicleAddViewModel> EditVehicleInteraction { get; } = new();
    public static Interaction<Unit, bool> ShowLoginDialogInteraction { get; } = new();
}