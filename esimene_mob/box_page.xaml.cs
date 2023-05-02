using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace esimene_mob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class box_page : ContentPage
    {
        //DeviceDisplay.MainDisplayInfo
        Button tagasi;
        BoxView box;
        public box_page()
        {
            InitializeComponent();
            tagasi = new Button
            {
                Text = "Tagasi",
                BackgroundColor = Color.AliceBlue,
                TextColor = Color.Black
            };
            tagasi.Clicked += Tagasi_Clicked;
            box = new BoxView
            {
                Color= Color.Chocolate,
                CornerRadius=10,
                WidthRequest=20,
                HeightRequest=30,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions=LayoutOptions.Center,
            };
            TapGestureRecognizer tap=new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);

            Content = new StackLayout
            {
                Children = {box, tagasi}
            };
        }
        Random rnd= new Random();
        int a = 10;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            a += 10;
            box.Color= Color.FromRgb(rnd.Next(0,255), rnd.Next(0, 255), rnd.Next(0, 255));
            //box.CornerRadius=a;
            box.WidthRequest = box.Width + 5;
            box.HeightRequest= box.Height + 7;
            box.Rotation += 10;
            /*if (box.Height== DeviceDisplay.MainDisplayInfo.Width)
            {
                box.WidthRequest=box.Width - 200;
            }*/
            /*try
            {
                Vibration.Vibrate();
                var k = TimeSpan.FromSeconds(0.5);
                Vibration.Vibrate(k);
            }
            catch (Exception)
            {
            }*/
            
        }
        private async void Tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}