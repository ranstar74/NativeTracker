using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia.Collections;
using Avalonia.OpenStreetMap.Control.Map;
using BingMapsRESTToolkit;
using DynamicData;
using nativeTrackerClientLibrary;
using ReactiveUI;

namespace NativeTracker.ViewModels;

public class MapDetailsViewModel : ViewModel
{
    public AvaloniaList<MapPoint> Points { get; } = new();
    public AvaloniaList<Vehicle> Vehicles { get; } = new();

    // private readonly VehicleTracker _tracker = new();

    public MapDetailsViewModel()
    {
        //_tracker.TrackVehicle(1, OnUpdate);

        Vehicles.Add(new Vehicle()
        {
            Name = "Lada 2109",
            Position = new MapPoint(37.742141, 55.758013)
        });
        this.RaisePropertyChanged(nameof(Vehicles));

        //GetRoutePoints();
    }
    //
    // private async void GetRoutePoints()
    // {
    //     var request = new RouteRequest()
    //     {
    //         RouteOptions = new RouteOptions()
    //         {
    //             Tolerances = new List<double>()
    //             {
    //                 0.00000344978,
    //                 0.00000344978,
    //                 0.00000344978,
    //                 0.00000344978,
    //                 0.00001,
    //                 0.00001,
    //             },
    //             RouteAttributes = new List<RouteAttributeType>()
    //             {
    //                 RouteAttributeType.RoutePath
    //             }
    //         },
    //         Waypoints = new List<SimpleWaypoint>()
    //         {
    //             new SimpleWaypoint("3-я Владимирская улица, 8к2"),
    //             new SimpleWaypoint("Хабаровская улица, 19к2"),
    //         },
    //         BingMapsKey =
    //             "F4EqM7NpwsMAEwrpnNLY~ej6S-BnVhZlwfr1d4Y78mg~AogF2wuNPVeqF9dep6CmCHMHZfG_GeP6r0tpriW_g15Ecp_wdOk01em_Wkqj2_KG"
    //     };
    //
    //     var responce = await request.Execute();
    //     var points = ((Route)responce.ResourceSets[0].Resources[0]).RoutePath.Line.Coordinates
    //         .Select(x => new MapPoint(x[1], x[0]))
    //         .ToList();
    //
    //     Points.AddRange(points);
    //     this.RaisePropertyChanged(nameof(Points));
    // }
    //
    // private void OnUpdate(VehicleState update)
    // {
    //     Points.Add(new MapPoint(update.Longitude, update.Latitude));
    //     Debug.WriteLine(update.Time);
    //
    //     this.RaisePropertyChanged(nameof(Points));
    // }
}

public class Vehicle
{
    public string Name { get; set; }
    public MapPoint Position { get; set; }
}