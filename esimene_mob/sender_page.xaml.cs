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
    public partial class sender_page : ContentPage
    {
        Stepper stp;
        Slider sld;
        Label lbl;
        
        public sender_page()
        {
            stp = new Stepper()
            {
                Minimum= 0,
                Maximum= 100,
                Value = 0,
                Increment = 5,
            };
            stp.ValueChanged += Stp_ValueChanged;
            lbl = new Label()
            {
                Text="TTHK",
                FontSize= stp.Value,
            };
            sld = new Slider()
            {
                Minimum= stp.Minimum,
                Maximum= stp.Maximum,
                Value= stp.Value,
                MinimumTrackColor=Color.LightSteelBlue
            };
            sld.ValueChanged+= Stp_ValueChanged;
            List<Object> objects=new List<Object> { stp, sld, lbl };
            AbsoluteLayout abs=new AbsoluteLayout();
            double y =0;
            foreach (var item in objects)
            {
                y = y + 0.2;
                AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.1,y,200,100));
                AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                abs.Children.Add((View)item);
            }
            Content= abs;
        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.FontSize= e.NewValue;
        }
    }
}