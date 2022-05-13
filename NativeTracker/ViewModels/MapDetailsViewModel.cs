using Avalonia.Collections;
using Avalonia.OpenStreetMap.Control.Map;
using nativeTrackerClientLibrary;

namespace NativeTracker.ViewModels;

public class MapDetailsViewModel : ViewModelBase
{
    public AvaloniaList<MapPoint> Points { get; } = new();
    
    //private readonly VehicleTracker _tracker = new();

    public MapDetailsViewModel()
    {
        //_tracker.TrackVehicle(1, OnUpdate);
        
        Points.Add(new MapPoint(0, 0));        
    }

    private void OnUpdate(VehicleState obj)
    {
        
    }
}