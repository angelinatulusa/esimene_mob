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
    public partial class tripstraptrull : ContentPage
    {
        Grid kast;
        Image img;
        Button reeglid, stop, start;
        StackLayout st;
        Picker pl1, pl2;
        int tulemus = -1;
        int[,] Tulemused = new int[3, 3];
        int klik = 0;
        public tripstraptrull()
        {
            //InitializeComponent();
            start = new Button
            {
                Text = "Alusta mäng"
            };
            pl1 = new Picker
            {
                Title = "Esimene mängija, palun vali millega sa tahad mängima"
            };
            pl1.Items.Add("x");
            pl1.Items.Add("o");
            pl1.Items.Add("suda");
            pl1.Items.Add("taht");
            pl2 = new Picker
            {
                Title = "Teine mängija, palun vali millega sa tahad mängima"
            };
            pl2.Items.Add("x");
            pl2.Items.Add("o");
            pl2.Items.Add("suda");
            pl2.Items.Add("taht");
            start.Clicked += Start_Clicked;
            st = new StackLayout
            {
                Children = { pl1, pl2, start }
            };
            Content = st;
        }
        private void Start_Clicked(object sender, EventArgs e)
        {
            tulemus = 0;
            klik = 0;
            st.Children.Clear();
            mang();
            st.Children.Add(kast);
            st.Children.Add(reeglid);
            st.Children.Add(stop);
        }
        public void mang()
        {
            kast = new Grid();
            for (int i = 0; i < 4; i++)
            {
                kast.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                kast.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    img = new Image { Source = "fon.png" };
                    kast.Children.Add(img, i, j);
                    var tap = new TapGestureRecognizer();
                    img.GestureRecognizers.Add(tap);
                    tap.Tapped += Tap_Tapped;
                }
            }
            reeglid = new Button
            {
                Text = "Reeglid"
            };
            reeglid.Clicked += Reeglid_Clicked;
            stop = new Button
            {
                Text = "Taaskäivita mäng"
            };
            stop.Clicked += Stop_Clicked;
        }
        private void uuesti()
        {
            tulemus = 0;
            klik = 0;
            st.Children.Clear();
            st.Children.Add(pl1);
            st.Children.Add(pl2);
            st.Children.Add(start);
            start.Clicked += Start_Clicked;
        }
        private void Stop_Clicked(object sender, EventArgs e)
        {
            tulemus = 0;
            klik = 0;
            st.Children.Clear();
            st.Children.Add(pl1);
            st.Children.Add(pl2);
            st.Children.Add(start);
            start.Clicked += Start_Clicked;
        }
        private void Reeglid_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Reeglid", "Üks mängija mängib \"ristiga\", teine \"nulliga\". Mäng vormistatakse järgmiselt:. Ristiga mängija alustab ja joonistab risti keskele. Nulliga mängija joonistab nulli ükskõik millisesse ülejäänud ruutu. Mängu eesmärgiks on saada ritta (kas diagonaalis, ülevalt alla või vasakult paremale) kolm ühesugust kujundit ja takistada teisel seda saamast. Mängu võitja ongi see, kes kolm \"oma\" kujundit ritta saab. Mängu mängivad algklasside ja põhikooli õpilased. See on tuntud üle Eesti.", "OK");
        }
        string a = "x";
        private void Tap_Tapped(object sender, EventArgs e)
        {
            img = sender as Image;
            var r = Grid.GetRow(img);
            var c = Grid.GetColumn(img);
            klik += 1;
            if (a == "x")
            {
                img.Source = pl1.SelectedItem + ".png";
                a = "o";
                Tulemused[r, c] = 1;
            }
            else if (a == "o")
            {
                img.Source = pl2.SelectedItem + ".png";
                a = "x";
                Tulemused[r, c] = 2;
            }
            else
            {
                DisplayAlert("!!!", "See väli on juba hõivatud", "OK");
            }
            lopp();
        }
        private int kontroll()
        {
            //esimene inimene
            if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[1, 2] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }
            //teine inimene
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 0] == 2 && Tulemused[2, 0] == 2 || Tulemused[0, 1] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 1] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 2] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[0, 1] == 2 && Tulemused[0, 2] == 2 || Tulemused[1, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[1, 2] == 2 || Tulemused[2, 0] == 2 && Tulemused[2, 1] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 2] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 0] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 1)
            {
                tulemus = 3;
            }
            else
            {
                tulemus = -1;
            }
            return tulemus;
        }
        public void lopp()
        {
            tulemus = kontroll();
            if (klik >= 5)
            {
                if (tulemus == 1)
                {
                    DisplayAlert("Võit", pl1.SelectedItem + " on võitja!", "Ok");
                    uuesti();
                }
                else if (tulemus == 2)
                {
                    DisplayAlert("Võit", pl2.SelectedItem + " on võitja!", "Ok");
                    uuesti();
                }
                else if (tulemus == 3)
                {
                    DisplayAlert("Ei keegi ei võit", "Provige uuesti", "Ok");
                    uuesti();
                }
            }
        }
    }
}