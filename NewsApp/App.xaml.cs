﻿using NewsApp.Pages;
using Microsoft.Maui.Controls; 
namespace NewsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            this.MainPage = new NavigationPage(new NewsHomePage()); 
        }
    }
}
