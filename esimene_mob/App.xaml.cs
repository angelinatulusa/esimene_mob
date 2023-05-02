using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace esimene_mob
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage(new start_page());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
