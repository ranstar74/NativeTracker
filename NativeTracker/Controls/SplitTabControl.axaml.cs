using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Metadata;

namespace NativeTracker.Controls;

public class SplitTabControl : TabControl, IContentControl
{
    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public static readonly AvaloniaProperty<object> ContentProperty =
        AvaloniaProperty.Register<SplitTabControl, object>(nameof(Content));
}