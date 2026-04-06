using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace AbiturientApp;

/// <summary>
/// Simple helper that shows modal message dialogs using Avalonia windows.
/// </summary>
internal static class MessageHelper
{
    public static Task ShowInfoAsync(Window owner, string title, string message)
        => ShowDialogAsync(owner, title, message, confirm: false);

    public static Task<bool> ShowConfirmAsync(Window owner, string title, string message)
        => ShowDialogAsync(owner, title, message, confirm: true);

    private static async Task<bool> ShowDialogAsync(Window owner, string title, string message, bool confirm)
    {
        bool result = false;

        var window = new Window
        {
            Title = title,
            Width = 400,
            MinHeight = 130,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            CanResize = false,
            SizeToContent = SizeToContent.Height
        };

        var okButton = new Button
        {
            Content = confirm ? "Да" : "ОК",
            Width = 80,
            Margin = new Thickness(0, 0, confirm ? 8 : 0, 0)
        };
        okButton.Click += (_, _) => { result = true; window.Close(); };

        var buttonPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        buttonPanel.Children.Add(okButton);

        if (confirm)
        {
            var noButton = new Button { Content = "Нет", Width = 80 };
            noButton.Click += (_, _) => { result = false; window.Close(); };
            buttonPanel.Children.Add(noButton);
        }

        var panel = new StackPanel
        {
            Margin = new Thickness(16),
            Spacing = 12
        };
        panel.Children.Add(new TextBlock
        {
            Text = message,
            TextWrapping = TextWrapping.Wrap
        });
        panel.Children.Add(buttonPanel);

        window.Content = panel;
        await window.ShowDialog(owner);
        return result;
    }
}
