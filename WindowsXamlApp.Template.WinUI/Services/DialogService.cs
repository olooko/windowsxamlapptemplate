﻿using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using WindowsXamlApp.Common.Services;
using WindowsXamlApp.Template.WinUI.Controls;

namespace WindowsXamlApp.Template.WinUI.Services
{
    public sealed class DialogService : IDialogService
    {
        static readonly Dictionary<Type, Type> _viewModelToViewMappings = [];

        public DialogService()
        {
        }

        public static void AddTransient<TDialog, TDialogViewModel>(IServiceCollection services)
            where TDialog : UserDialog
            where TDialogViewModel : INotifyPropertyChanged
        {
            _viewModelToViewMappings.Add(typeof(TDialogViewModel), typeof(TDialog));

            services.AddTransient(typeof(TDialog));
            services.AddTransient(typeof(TDialogViewModel));
        }

        public async Task<bool> ShowModalAsync<TViewModel>() where TViewModel : INotifyPropertyChanged
        {
            var window = Ioc.Default.GetRequiredService<MainWindow>();

            window.DialogContent.Visibility = Visibility.Visible;

            var userDialog = Ioc.Default.GetService(_viewModelToViewMappings[typeof(TViewModel)]) as UserDialog;
            window.DialogContent.Child = userDialog;

            bool result = false;

            if (userDialog != null)
                result = await userDialog.WaitAsync();

            window.DialogContent.Visibility = Visibility.Collapsed;
            window.DialogContent.Child = null;

            return result;
        }
    }
}
