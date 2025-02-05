using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.WPF.Services
{
    public class ToastService : IToastService
    {
        public void Show(string message)
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            (window.ToastContent.Child as TextBlock)!.Text = message;

            window.ToastContent.Visibility = System.Windows.Visibility.Visible;

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
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Border.OpacityProperty));

            var showToastStoryBoard = new Storyboard();
            showToastStoryBoard.Children.Add(doubleAnimation);
            showToastStoryBoard.Completed += ShowToastStoryBoard_Completed;
            showToastStoryBoard.Begin(window.ToastContent);
        }

        private void ShowToastStoryBoard_Completed(object? sender, EventArgs e)
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();
            window.ToastContent.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
