using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

using VsbDatabase;
using Microsoft.Phone.Shell;

namespace vSongBook
{
    public partial class EeFavourite : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        int SelecSong, CurrSong, FontSize;

        public EeFavourite()
        {
            InitializeComponent();            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string favouritedSong = "";
                if (NavigationContext.QueryString.TryGetValue("favouritedSong", out favouritedSong))
                {
                    SelecSong = int.Parse(favouritedSong);
                    DataContext = App.VirtualSongBook.Favourites[SelecSong];
                    CurrSong = App.VirtualSongBook.Favourites[SelecSong].ID;
                    settings.CurrMysongSetting = CurrSong;
                    setTextContent();
                }
            } 
            
        }

        private void setTextContent()
        {
            TitleText.Text = strParser(App.VirtualSongBook.Favourites[SelecSong].Title);
            string songcontent = strParser(App.VirtualSongBook.Favourites[SelecSong].Content);
            string[] song_stanzas = songcontent.Split(new string[] { " ` " }, StringSplitOptions.None);

            for (int i = 0; i < song_stanzas.Length; i++)
            {
                Current_SongView vsb_obj = new Current_SongView();
                vsb_obj.Song_Stanza = strParser(song_stanzas[i]);
                SongViewList.Items.Add(vsb_obj);
            }
            SongViewList.ScrollIntoView(0);
        }

        public class Current_SongView
        {
            public string Song_Stanza { get; set; }
        }

        private void DeleteThisSong(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string SongTitle = App.VirtualSongBook.Favourites[SelecSong].Title;
            MessageBoxResult WarnMeNow = MessageBox.Show("Are you sure you want to delete the song: \"" + SongTitle
             + "\" from your favourites? This action is permanent and can not be reversed.",
            "Just a minute...", MessageBoxButton.OKCancel);

            if (WarnMeNow == MessageBoxResult.OK)
            {
                FavouritesDelete deleteFav = new FavouritesDelete();
                deleteFav.DeleteFavourite(CurrSong);

                ShellToast toast = new ShellToast();
                toast.Title = "vSongBook";
                toast.Content = "You have deleted the song " + SongTitle;
                toast.Show();

                this.NavigationService.GoBack();
            }

            else if (WarnMeNow == MessageBoxResult.Cancel) settings.Hint2Setting = false;

           
        }

        public void PreviousSong(object sender, EventArgs e)
        {
            int NewSong = CurrSong - 1;
            if (NewSong < 0 || NewSong > 3793)
            {

            }
            else
            {
                SelecSong = NewSong;
                DataContext = App.VirtualSongBook.Favourites[SelecSong];
                CurrSong = App.VirtualSongBook.Favourites[SelecSong].ID;
                settings.CurrMysongSetting = CurrSong;
                SongViewList.Items.Clear();
                setTextContent();
            }
        }

        public void NextSong(object sender, EventArgs e)
        {
            int NewSong = CurrSong + 1;
            if (NewSong < 0 || NewSong > 3793)
            {

            }
            else
            {
                SelecSong = NewSong;
                DataContext = App.VirtualSongBook.Favourites[SelecSong];
                CurrSong = App.VirtualSongBook.Favourites[SelecSong].ID;
                settings.CurrMysongSetting = CurrSong;
                SongViewList.Items.Clear();
                setTextContent();
            }
        }

        public void SmallerFont(object sender, EventArgs e)
        {
            FontSize = FontSize - 2;
            if (FontSize >= 4)
            {
                settings.FontSizeSetting = FontSize;
                SongViewList.Items.Clear();
                setTextContent();
            }
        }

        public void BiggerFont(object sender, EventArgs e)
        {
            FontSize = FontSize + 2;
            if (FontSize <= 100)
            {
                settings.FontSizeSetting = FontSize;
                SongViewList.Items.Clear();
                setTextContent();
            }
        }

        public String strParser(String mystring)
        {
            mystring = mystring.Replace("^", "'");
            mystring = mystring.Replace('+', '"');
            mystring = mystring.Replace("$", "\n");
            return mystring;
        }

        public String strParserFinal(String mystring)
        {
            mystring = mystring.Replace("^", "'");
            mystring = mystring.Replace('+', '"');
            mystring = mystring.Replace("$", "\n");
            mystring = mystring.Replace("`", "\n\n");
            return mystring;
        }

    }
}