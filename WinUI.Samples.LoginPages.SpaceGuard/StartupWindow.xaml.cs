using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using Windows.UI;
using WinUI.Samples.LoginPages.SpaceGuard.AnimatedVisuals;

namespace WinUI.Samples.LoginPages.SpaceGuard;

public sealed partial class StartupWindow : Window
{
    public StartupWindow()
    {
        
        this.InitializeComponent();
        SetTitleBar(AppTitleBar);
        ExtendsContentIntoTitleBar = true;
    }

    private void GoToRegister_Click(object sender, RoutedEventArgs e)
    {
        Storyboard1.Children[0].SetValue(DoubleAnimation.FromProperty, Translation1.X);
        Storyboard1.Children[0].SetValue(DoubleAnimation.ToProperty, Translation1.X > 0 ? 0 : -DisplayArea.Primary.OuterBounds.Width);
        Storyboard1.Children[1].SetValue(DoubleAnimation.FromProperty, Translation2.X);
        Storyboard1.Children[1].SetValue(DoubleAnimation.ToProperty, Translation2.X > 0 ? 0 : -DisplayArea.Primary.OuterBounds.Width);
        Storyboard1.Begin();
    }

    private void GoToLogin_Click(object sender, RoutedEventArgs e)
    {
        Storyboard2.Children[0].SetValue(DoubleAnimation.FromProperty, Translation1.X);
        Storyboard2.Children[0].SetValue(DoubleAnimation.ToProperty, Translation1.X < 0 ? 0 : +DisplayArea.Primary.OuterBounds.Width);
        Storyboard2.Children[1].SetValue(DoubleAnimation.FromProperty, Translation2.X);
        Storyboard2.Children[1].SetValue(DoubleAnimation.ToProperty, Translation2.X > 0 ? 0 : +DisplayArea.Primary.OuterBounds.Width);
        Storyboard2.Begin();
    }


    private async void ForgotPassword_Click(object sender, RoutedEventArgs e)
    {
        StackPanel stackPanel = new()
        {
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
        };

        AnimatedVisualPlayer player = new()
        {
            Source = new Space404()
            {
                Color_849AF5 = Color.FromArgb(255, 199, 199, 213),
                Color_758BDF = Color.FromArgb(255, 221, 216, 228),
                Color_2E03E4 = Color.FromArgb(255, 72, 63, 173),
            },
            MaxHeight = 200,
            AutoPlay = false,
        };
        stackPanel.Children.Add(player);
        stackPanel.Children.Add(new TextBlock()
        {
            Text = "Recovering account is not available.",
        });
        ContentDialog dialog = new()
        {
            XamlRoot = this.Content.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            CloseButtonText = "OK",
            DefaultButton = ContentDialogButton.Primary,
            Content = stackPanel
        };
        _ = player.PlayAsync(0, 1, true);
        await dialog.ShowAsync();
        player.Stop();

    }

}
