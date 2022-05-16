using Avalonia.OpenStreetMap.Control.Map;
using NativeTracker.ViewModels;

namespace NativeTracker.DesignData;

public static class DesignData
{
    public static Vehicle Vehicle { get; } = new Vehicle()
    {
        Name = "DAF 2021",
        Position = new MapPoint(37.617627, 55.755829)
    };
}