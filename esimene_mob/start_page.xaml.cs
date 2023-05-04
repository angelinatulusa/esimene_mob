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
    public partial class start_page : ContentPage
    {
        List<ContentPage> contentPages = new List<ContentPage>() { new text_page(), new timer_page(), new box_page(), new sender_page(), new colors(),  new datetime_page(), new tripstraptrull(), new carousel()};
        string[] tekstid ={ "Text page", "Timer", "BoxView","Stepper", "RGB colors", "Date time", "Trips Traps Trull"};
        public start_page()
        {
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Beige,
            };
            for (int i = 0; i < tekstid.Length; i++)
            {
                Button button = new Button
                {
                    Text = tekstid[i],
                    TabIndex= i,
                    BackgroundColor= Color.LightGray,
                    TextColor= Color.Black,
                };
                button.Clicked += Button_Clicked;
                st.Children.Add(button);
            }
            Content = st;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender; //=sender as Button
            await Navigation.PushAsync(contentPages[b.TabIndex]);
        }
    }
}