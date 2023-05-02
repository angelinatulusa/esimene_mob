using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;

namespace esimene_mob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class colors : ContentPage
    {
        Frame rgb_color;
        Button rgb_btn;
        Slider r_sld, g_sld, b_sld;
        Random rnd = new Random();
        Label r_lbl, g_lbl, b_lbl;
        Stepper stp;
        List<string> lbl = new List<string> { "r_lbl", "g_lbl", "b_lbl" };
        List<string> name = new List<string> { "Red = 0", "Green = 0", "Blue = 0" };
        public colors()
        {
            rgb_color = new Frame()
            {
                BackgroundColor = Color.Black,
                WidthRequest = 400,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            rgb_btn = new Button()
            {
                Text ="random värv",
                FontSize = 15,
                BackgroundColor = Color.DarkGray,
                TextColor = Color.White,
                WidthRequest = 160,
                HeightRequest = 50,
            };
            rgb_btn.Clicked += Rgb_btn_Clicked;
            r_sld = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 1,
                MinimumTrackColor = Color.LightCoral
            };
            r_sld.ValueChanged += rgb_ValueChanged;
            g_sld = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 1,
                MinimumTrackColor = Color.LightGreen
            };
            g_sld.ValueChanged += rgb_ValueChanged;
            b_sld = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 1,
                MinimumTrackColor = Color.LightSteelBlue
            };
            b_sld.ValueChanged += rgb_ValueChanged;
            stp = new Stepper()
            {
                Minimum = 0.0,
                Maximum = 1.0,
                Value = 0.1,
                Increment=0.1
            };
            stp.ValueChanged += Stp_ValueChanged;
            r_lbl = new Label() { Text = "red = 0"};
            g_lbl = new Label() { Text = "Green = 0" };
            b_lbl = new Label() { Text = "Blue = 0" };
            /*var lbl = new Label();
            for (int i = 0; i < 3; i++)
            {
                lbl = new Label
                {
                    Text = name[i].ToString(),

                };
            }*/
            List<Object> objects = new List<Object>() { rgb_color, r_sld, r_lbl, g_sld,g_lbl, b_sld,b_lbl };
            AbsoluteLayout abs = new AbsoluteLayout();
            double y = 0;
            foreach (var item in objects)
            {
                y+=0.1;
                AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.1, y, 400, 100));
                AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                abs.Children.Add((View)item);
            }
            List<Object> objects2 = new List<Object>() { rgb_btn, stp};
            double x = 0;
            foreach (var item in objects2)
            {
                AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(x, 0, 160, 50));
                AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                abs.Children.Add((View)item);
                x += 0.8;
                abs.Children.Add((View)item);
            }
           // abs.Children.Add((View)rgb_btn);
            Content = abs;
        }
        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            rgb_color.Opacity= e.NewValue;
        }

        private void rgb_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender==r_sld)
            {
                r_lbl.Text = String.Format("Red = {0}",(int)e.NewValue);
            }
            else if (sender==g_sld)
            {
                g_lbl.Text = String.Format("Green = {0}", (int)e.NewValue);
            }
            else if (sender==b_sld)
            {
                b_lbl.Text = String.Format("Blue = {0}", (int)e.NewValue);
            }
            rgb_color.BackgroundColor=Color.FromRgb((int)r_sld.Value, (int)g_sld.Value, (int)b_sld.Value);
        }
        int r, g, b;
        private void Rgb_btn_Clicked(object sender, EventArgs e)
        {
            r = rnd.Next(0, 255);
            r_lbl.Text=String.Format("Red = {0}",r);
            r_sld.Value=r;
            g = rnd.Next(0, 255);
            g_lbl.Text = String.Format("Green = {0}", g);
            g_sld.Value=g;
            b = rnd.Next(0, 255);
            b_lbl.Text = String.Format("Blue = {0}", b);
            b_sld.Value=b;
            rgb_color.BackgroundColor = Color.FromRgb(r,g,b);
        }
    }
}