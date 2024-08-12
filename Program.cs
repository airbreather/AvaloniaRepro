using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace AvaloniaRepro;

public sealed class ToolTipViewModel
{
    public required string Tip { get; init; }
}

public sealed class ViewLocator : IDataTemplate
{
    public bool Match(object? data) => data is ToolTipViewModel;
    public Control? Build(object? param) => new ToolTipView { DataContext = param };
}

internal static class Program
{
    [STAThread]
    private static void Main(string[] args) => AppBuilder.Configure<App>()
        .UsePlatformDetect()
        .WithInterFont()
        .LogToTrace()
        .StartWithClassicDesktopLifetime(args);
}
