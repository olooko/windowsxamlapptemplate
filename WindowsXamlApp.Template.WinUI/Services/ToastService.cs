using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml;
using System;
using WindowsXamlApp.Common.Services;
using System.Threading.Tasks;

namespace WindowsXamlApp.Template.WinUI.Services
{
    public class ToastService : IToastService
    {
        public async Task ShowAsync(string message, long duration, double fontSize)
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            var textblock = (window.ToastContent.Child as TextBlock)!;

            textblock.Text = message;
            textblock.FontSize = fontSize;

            window.ToastContent.Visibility = Visibility.Visible;

            var doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = TimeSpan.FromMilliseconds(duration / 2);
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

            await Task.CompletedTask;
        }

        private void ShowToastStoryBoard_Completed(object? sender, object e)
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            window.ToastContent.Visibility = Visibility.Collapsed;
        }
    }
}
