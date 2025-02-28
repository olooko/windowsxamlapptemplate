﻿using CommunityToolkit.Mvvm.DependencyInjection;
using System.Windows.Controls;
using WindowsXamlApp.Common.ViewModels.Pages;

namespace WindowsXamlApp.Template.WPF.Views.Pages
{
    public partial class IndexPage : Page
    {
        public IndexPage()
        {
            InitializeComponent();

            this.DataContext = Ioc.Default.GetRequiredService<IndexPageViewModel>();
        }
    }
}
