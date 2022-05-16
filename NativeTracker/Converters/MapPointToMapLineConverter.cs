using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Collections;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.OpenStreetMap.Control.Map;
using Avalonia.OpenStreetMap.Control.Map.Shapes;

namespace NativeTracker.Converters;

public class MapPointToMapLineConverter : IValueConverter
{
    public IPen Pen { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var points = (value as IEnumerable<MapPoint>).ToList();

        var lines = new AvaloniaList<MapLine>();

        for (int i = 0; i < points.Count - 1; i++)
        {
            lines.Add(new MapLine(Pen, points[i], points[i + 1]));
        }

        return lines;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}