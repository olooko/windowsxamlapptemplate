﻿using CommunityToolkit.Mvvm.DependencyInjection;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Common.ViewModels;
using WindowsXamlApp.Template.MAUI.Controls;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class DialogService : IDialogService
    {
        static readonly Dictionary<Type, Type> _viewModelToViewMappings = [];

        public static void AddSingleton<TDialog, TDialogViewModel>(IServiceCollection services)
            where TDialog : UserDialog
            where TDialogViewModel : ViewModelBase
        {
            _viewModelToViewMappings.Add(typeof(TDialogViewModel), typeof(TDialog));

            services.AddSingleton(typeof(TDialog));
            services.AddSingleton(typeof(TDialogViewModel));
        }

        public static void AddTransient<TDialog, TDialogViewModel>(IServiceCollection services)
            where TDialog : UserDialog
            where TDialogViewModel : ViewModelBase
        {
            _viewModelToViewMappings.Add(typeof(TDialogViewModel), typeof(TDialog));

            services.AddTransient(typeof(TDialog));
            services.AddTransient(typeof(TDialogViewModel));
        }

        public async Task<bool> ShowModalAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            bool result = false;

            var currentPage = Shell.Current.CurrentPage;
            var userDialog = Ioc.Default.GetService(_viewModelToViewMappings[typeof(TViewModel)]) as UserDialog;

            if (currentPage != null && userDialog != null)
            {
                var newPage = new ContentPage
                {
                    BackgroundColor = Color.FromArgb("#88000000"),
                    Content = userDialog,
                };

                await currentPage.Navigation.PushModalAsync(newPage, false);
                result = await userDialog.WaitAsync();
            }

            return result;
        }
    }
}