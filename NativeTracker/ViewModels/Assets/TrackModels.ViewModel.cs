using System.Threading.Tasks;
using Avalonia.Collections;
using nativeTrackerClientService;
using ReactiveUI.Fody.Helpers;
using VehicleTrackService = nativeTrackerClientLibrary.Services.VehicleTrackService;

namespace NativeTracker.ViewModels.Assets;

public class TrackModelsViewModel : ViewModel
{
    public AvaloniaList<GetTrackModelResponse> Models { get; } = new();

    [Reactive] public string Search { get; set; }


    private readonly VehicleTrackService _track = new();

    public TrackModelsViewModel()
    {
        _ = Update();
    }

    private async Task Update()
    {
        var request = new GetTrackModelsRequest()
        {
            ElementsOnPage = 100,
            MinPrice = double.MinValue,
            MaxPrice = double.MaxValue,
            Features = { },
            Manufacturers = { },
            Page = 0,
            Search = ""
        };

        Models.Clear();
        await foreach (var model in _track.GetModels(request))
        {
            Models.Add(model);
        }
    }
}