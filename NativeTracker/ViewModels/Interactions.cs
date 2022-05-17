using System.Reactive;
using NativeTracker.ViewModels.Assets;
using nativeTrackerClientService;
using ReactiveUI;

namespace NativeTracker.ViewModels;

public static class Interactions
{
    public static Interaction<Unit, VehicleAddViewModel> AddVehicleInteraction { get; } = new();
    public static Interaction<GetVehiclesResponse, VehicleAddViewModel> EditVehicleInteraction { get; } = new();
    public static Interaction<Unit, bool> ShowLoginDialogInteraction { get; } = new();
    public static Interaction<TrackModelsViewModel, GetTrackModelResponse> PickTrackModel { get; } = new();
    public static Interaction<Unit, CreateTrackIssueViewModel> CreateIssueInteraction { get; } = new();
}