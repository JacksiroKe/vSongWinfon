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
using VsbDatabase.ViewModels;

namespace vSongBook
{
    public partial class SongView1 : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();

        public SongView1()
        {
            InitializeComponent();
            Display_Current_Song(settings.CurrSongSetting);
        }


        public class Current_SongView
        {
            public string Song_Stanza { get; set; }
        }

        private void Load_Song_Text(string CurrentSongText)
        {
            string[] song_stanzas = CurrentSongText.Split(new string[] { "$ $" }, StringSplitOptions.None);

            for (int i = 0; i < song_stanzas.Length; i++)
            {
                Current_SongView vsb_obj = new Current_SongView();
                vsb_obj.Song_Stanza = song_stanzas[i].Replace("$", "\n");
                SongViewList.Items.Add(vsb_obj);
            }
            SongViewList.ScrollIntoView(0);
        }

        private void Display_Current_Song(int songno)
        {
            DataContext = App.ViewSong1.Songs[songno];

            string song_title = App.ViewSong1.Songs[songno].SongTitle;
            string song_text = App.ViewSong1.Songs[songno].SongContent;
            string song_text_i = song_text.Replace("^", "'").Replace('+', '"');
            TitleText.Text = song_title.Replace("^", "'").Replace('+', '"');
            Load_Song_Text(song_text_i);

        }

        private void FavouriteThisSong(object sender, GestureEventArgs e)
        {
            int songno = settings.CurrSongSetting;

            VsbFavour newFavour = new VsbFavour
            {
                SongTitle = App.ViewSong1.Songs[songno].SongTitle,
                SongContent = App.ViewSong1.Songs[songno].SongContent
            };
            App.ViewSongBook.AddVsbFavour(newFavour);
        }

        private void ShareThisSong(object sender, GestureEventArgs e)
        {
            int songno = settings.CurrSongSetting;
            string song_text = App.ViewSong1.Songs[songno].SongContent;
            ShareStatusTask nowshareme = new ShareStatusTask();
            nowshareme.Status = song_text.Replace("$", "\n") + "\n\n Via vSongBook";
            nowshareme.Show();
        }

        public void PreviousSong(object sender, EventArgs e)
        {
            int newsong = settings.CurrSongSetting - 1;
            if (newsong <= 0) MessageBox.Show("Sorry, there is no song before the current song you should looking for songs after the current song.", "vSongBook Error", MessageBoxButton.OK);
            else
            {
                settings.CurrSongSetting = newsong;
                SongViewList.Items.Clear();
                Display_Current_Song(newsong);
            }
        }
        public void NextSong(object sender, EventArgs e)
        {
            int newsong = settings.CurrSongSetting + 1;
            if (newsong >= 604) MessageBox.Show("Sorry, there is no song after the current song you should looking for songs before the current song.", "vSongBook Error", MessageBoxButton.OK);
            else
            {
                settings.CurrSongSetting = newsong;
                SongViewList.Items.Clear();
                Display_Current_Song(newsong);
            }
        }

        public void SmallerFont(object sender, EventArgs e)
        {
            int newfonts = settings.FontSizeSetting - 2;
            if (newfonts >= 4)
            {
                settings.FontSizeSetting = newfonts;
                int curr_song = settings.CurrSongSetting;
                SongViewList.Items.Clear();
                Display_Current_Song(curr_song);
            }
        }

        public void BiggerFont(object sender, EventArgs e)
        {
            int newfonts = settings.FontSizeSetting + 2;
            if (newfonts <= 100)
            {
                settings.FontSizeSetting = newfonts;
                int curr_song = settings.CurrSongSetting;
                SongViewList.Items.Clear();
                Display_Current_Song(curr_song);
            }
        }

        public void CopyThisSong(object sender, EventArgs e)
        {
            int current_song = settings.CurrSongSetting;
            NavigationService.Navigate(new Uri("/SongViewCopy1.xaml?CopyingSong=" + current_song, UriKind.Relative));
        }

    }
}