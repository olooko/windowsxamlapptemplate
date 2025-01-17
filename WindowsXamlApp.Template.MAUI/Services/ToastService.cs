﻿using CommunityToolkit.Maui.Alerts;
using WindowsXamlApp.Common.Services;

namespace WindowsXamlApp.Template.MAUI.Services
{
    public sealed class ToastService : IToastService
    {
        public void Show(string message)
        {
            Toast.Make(message).Show();
        }
    }
}
