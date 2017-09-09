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
using Microsoft.Phone.Shell;

namespace vSongBook
{
    public partial class DdSongView : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        int CurrSong, FontSize;

        public DdSongView()
        {
            InitializeComponent();
            
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedSong = "";
                if (NavigationContext.QueryString.TryGetValue("selectedSong", out selectedSong))
                {
                    CurrSong = int.Parse(selectedSong);
                    settings.CurrSongSetting = CurrSong;
                    DataContext = App.VirtualSongBook.SongList[CurrSong];
                    setTextContent();            

                }
            } 
            
            if (!settings.RatedVsbwpSetting) PleaseRateMe();
        }

        private void setTextContent()
        {
            TitleText.Text = strParser(App.VirtualSongBook.SongList[CurrSong].Title);
            string songcontent = strParser(App.VirtualSongBook.SongList[CurrSong].Content);
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

        private void PleaseRateMe()
        {
            long used_time, used_secs;
            DateTime unixEpoch = new DateTime(1970, 1, 1);
            DateTime localDate = DateTime.Now;
            long nowMilSecond = (localDate.Ticks - unixEpoch.Ticks) / 10000;

            used_time = nowMilSecond - settings.SkippedRatingSetting;
            used_secs = (int)(used_time / 1000);

            if (used_secs > 18000)
            {
                MessageBoxResult RateMyApp = MessageBox.Show("Now that you have turned your phone into a songbook, would you mind to take a minute or two to rate my app on Play Store. It help others to find this app quickly.", "Just a Minute...", MessageBoxButton.OKCancel);
                if (RateMyApp == MessageBoxResult.OK)
                {
                    settings.RatedVsbwpSetting = true;
                    MarketplaceReviewTask nowrateme = new MarketplaceReviewTask();
                    nowrateme.Show();
                }
                else if (RateMyApp == MessageBoxResult.Cancel)
                {
                    long totMilSecond = (localDate.Ticks - unixEpoch.Ticks) / 10000;
                    settings.SkippedRatingSetting = totMilSecond;
                    settings.RatedVsbwpSetting = false;
                }
            }

        }

        private void FavouriteThisSong(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Favouriting favour = new Favouriting();
            string SongTitle = App.VirtualSongBook.SongList[CurrSong].Title;
            string SongContent = App.VirtualSongBook.SongList[CurrSong].Content;


            favour.FavoriteThis(SongTitle, SongContent);
            
            ShellToast toast = new ShellToast();
            toast.Title = "vSongBook";
            toast.Content = SongTitle + " favourited!";
            toast.Show();
        }

        private void ShareThisSong(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string song_text = App.VirtualSongBook.SongList[CurrSong].Content;
            ShareStatusTask nowshareme = new ShareStatusTask();
            nowshareme.Status = strParserFinal(song_text) + "\n\n Via vSongBook";
            nowshareme.Show();
        }

       public void PreviousSong(object sender, EventArgs e)
        {
		    int NewSong = CurrSong - 1;
            if (NewSong < 0 || NewSong > 3793) {            
                
            } else{
        	    CurrSong = NewSong;
                settings.CurrMysongSetting = CurrSong;
                DataContext = App.VirtualSongBook.SongList[CurrSong];
                SongViewList.Items.Clear();
                setTextContent();
            }           
	    }

        public void NextSong(object sender, EventArgs e)
        {
		    int NewSong = CurrSong + 1;
            if (NewSong < 0 || NewSong > 3793) {            
                
            } else{
                CurrSong = NewSong;
                settings.CurrMysongSetting = CurrSong;
                DataContext = App.VirtualSongBook.SongList[CurrSong];
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

        public void CopyThisSong(object sender, EventArgs e)
        {
            int current_song = settings.CurrMysongSetting;
            NavigationService.Navigate(new Uri("/DdSongViewCopy.xaml?CopyingSong=" + current_song, UriKind.Relative));
        }

    }
}