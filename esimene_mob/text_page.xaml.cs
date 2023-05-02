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
    public partial class text_page : ContentPage
    {
        Editor editor;
        Label lbl;
        Button Tagasibtn;
        public text_page()
        {
            Tagasibtn = new Button
            {
                Text = "Tagasi",
                BackgroundColor = Color.AliceBlue,
                TextColor = Color.Black
            };
            Tagasibtn.Clicked += Tagasibtn_Clicked;
            editor = new Editor
            {
                Placeholder="Kirjuta tekst",
                BackgroundColor = Color.LightGreen,
                PlaceholderColor= Color.BlueViolet,
                TextColor=Color.Brown
            };
            editor.TextChanged += Editor_TextChanged;
            lbl = new Label
            {
                Text = "Siia tuleb ka tekst",
                BackgroundColor = Color.Salmon,
                TextColor = Color.Green,
                FontSize= 22
            };
            Content = new StackLayout
            {
                Children = { editor,lbl,Tagasibtn }
            };
        }
        int i;
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbl.Text = editor.Text;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';
            if (key=='A' || key=='a')
            {
                i++;
                Tagasibtn.Text=key.ToString() + ": " + i.ToString();
            }
        }
        private async void Tagasibtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}