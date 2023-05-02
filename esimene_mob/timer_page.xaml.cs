using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace esimene_mob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class timer_page : ContentPage
    {
        Button tagasi;

        public timer_page()
        {
            InitializeComponent();
            tagasi = new Button
            {
                Text = "Tagasi",
                BackgroundColor = Color.AliceBlue,
                TextColor = Color.Black
            };
            tagasi.Clicked += Tagasi_Clicked;
            Content = new StackLayout
            {
                Children = { lbl, tagasi, onoff_btn }
            };
        }
        private async void Tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        bool onoff = false;
        private async void NaitaAeg()
        {
            while (onoff)
            {
                lbl.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            NaitaAeg();
        }
        private void onoff_btn_Clicked(object sender, EventArgs e)
        {
            if (onoff)
            {
                onoff = false;
                onoff_btn.Text = "Lülita välja";
            }
            else
            {
                onoff = true;
                onoff_btn.Text = "Lülita sisse";
            }
        }
    }
}