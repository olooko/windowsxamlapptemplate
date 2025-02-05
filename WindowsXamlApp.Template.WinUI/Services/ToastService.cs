using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml;
using System;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.WinUI.Services
{
    public class ToastService : IToastService
    {
        public void Show(string message)
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            (window.ToastContent.Child as TextBlock)!.Text = message;

            window.ToastContent.Visibility = Microsoft.UI.Xaml.Visibility.Visible;

            var doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = TimeSpan.FromSeconds(3);
            doubleAnimation.AutoReverse = true;

            var powerEase = new PowerEase();
            powerEase.Power = 10;
            powerEase.EasingMode = EasingMode.EaseOut;
            doubleAnimation.EasingFunction = powerEase;

            Storyboard.SetTargetName(doubleAnimation, window.ToastContent.Name);
            Storyboard.SetTargetProperty(doubleAnimation, "Border.Opacity");
            Storyboard.SetTarget(doubleAnimation, window.ToastContent);

            var showToastStoryBoard = new Storyboard();
            showToastStoryBoard.Children.Add(doubleAnimation);
            showToastStoryBoard.Completed += ShowToastStoryBoard_Completed;
            
            showToastStoryBoard.Begin();
        }

        private void ShowToastStoryBoard_Completed(object? sender, object e)
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            window.ToastContent.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
        }
    }
}
