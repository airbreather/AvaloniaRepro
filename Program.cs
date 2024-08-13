using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Shapes;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Media;

Application app = AppBuilder.Configure<Application>()
    .UsePlatformDetect()
    .SetupWithClassicDesktopLifetime(args)
    .Instance!;

app.DataTemplates.Add(new ViewLocator());
Window window = new()
{
    Content = new Rectangle
    {
        Fill = Brushes.Red,
        [ToolTip.TipProperty] = new { Tip = "Testing 123" },
    },
};
window.Show();
app.Run(window);

public sealed class ViewLocator : IDataTemplate
{
    public bool Match(object? data) => data?.GetType().GetProperty("Tip") is not null;
    public Control Build(object? param) => new ContentPresenter
    {
        [!ContentPresenter.ContentProperty] = new Binding
        {
            Source = param,
            Path = "Tip",
            StringFormat = "{0} (from tooltip!)",
        },
    };
}
