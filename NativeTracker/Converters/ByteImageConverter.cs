using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Google.Protobuf;

namespace NativeTracker.Converters;

public class ByteImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch (value)
        {
            case byte[] bytes:
                return new Bitmap(new MemoryStream(bytes));
            case ByteString byteString:
                return new Bitmap(new MemoryStream(byteString.ToByteArray()));
            default:
                return null;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}