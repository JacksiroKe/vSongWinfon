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
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.ComponentModel;
using Microsoft.Phone.Tasks;

namespace vSongBook
{
    public partial class CcSongBook : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        public CcSongBook()
        {
            InitializeComponent();
            DataContext = App.VirtualSongBook;

            pSongBook.Visibility = Visibility.Collapsed;
            ApplicationBar.IsVisible = false;
            this.Loaded += new RoutedEventHandler(CcSongBook_Loaded);

            if (!settings.PaidforSetting) ExpiringMessage();
        }

        private void CcSongBook_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavigationService.RemoveBackEntry();
            
            App.VirtualSongBook.ListTheSongBook();
            ListBox1.ItemsSource = App.VirtualSongBook.SongList.Where(w => w.Content.Contains("Songs of Worship"));
            ListBox2.ItemsSource = App.VirtualSongBook.SongList.Where(w => w.Content.Contains("Nyimbo za Injili"));
            ListBox3.ItemsSource = App.VirtualSongBook.SongList.Where(w => w.Content.Contains("Believers Songs"));
            ListBox4.ItemsSource = App.VirtualSongBook.SongList.Where(w => w.Content.Contains("Nyimbo za Wokovu"));
            ListBox5.ItemsSource = App.VirtualSongBook.SongList.Where(w => w.Content.Contains("Redemption Songs"));
            ListBox6.ItemsSource = App.VirtualSongBook.SongList.Where(w => w.Content.Contains("Tenzi za Rohoni"));
            ListBox7.ItemsSource = App.VirtualSongBook.SongList.Where(w => w.Content.Contains("Kuinira Ngai"));
            ListBox8.ItemsSource = App.VirtualSongBook.SongList.Where(w => w.Content.Contains("Kumutaiia Ngai"));
            ListBox9.ItemsSource = App.VirtualSongBook.SongList.Where(w => w.Content.Contains("Kilosune Jehovah"));

            pSongBook.Visibility = Visibility.Visible;
            ApplicationBar.IsVisible = true;
        }

        private void ExpiringMessage()
        {

            long usedt, remt, secst, remst;
            DateTime unixEpoch = new DateTime(1970, 1, 1);
            DateTime localDate = DateTime.Now;
            long nowMilSecond = (localDate.Ticks - unixEpoch.Ticks) / 10000;

            usedt = nowMilSecond - settings.InstalledonSetting;
            remt = settings.ExpiresonSetting - nowMilSecond;
            secst = (int)(usedt / 1000);
            remst = (int)(remt / 1000);

            if (secst < 440000)
            {
                if (remst < 60)
                    MessageBox.Show("vSongBook is in its Evaluation(Trial) Mode. It will expire " + remst + " seconds from now. Please click on the Settings icon and go APPLICATION MODE to learn how to Upgrade to Premium Mode! It will cost you Kshs. 300 to do that.", "God bless you!", MessageBoxButton.OK);

                else if (remst < 3600)
                    MessageBox.Show("vSongBook is in its Evaluation(Trial) Mode. It will expire " + remst / 60 + " minutes from now. Please click on the Settings icon and go APPLICATION MODE to learn how to Upgrade to Premium Mode! It will cost you Kshs. 300 to do that.", "God bless you!", MessageBoxButton.OK);

                else if (remst < 86400)
                    MessageBox.Show("vSongBook is in its Evaluation(Trial) Mode. It will expire " + remst / 3600 + " hours from now. Please click on the Settings icon and go APPLICATION MODE to learn how to Upgrade to Premium Mode! It will cost you Kshs. 300 to do that.", "God bless you!", MessageBoxButton.OK);

                else if (remst < 440000)
                    MessageBox.Show("vSongBook is in its Evaluation(Trial) Mode. It will expire " + remst / 86400 + " days from now. Please click on the Settings icon and go APPLICATION MODE to learn how to Upgrade to Premium Mode! It will cost you Kshs. 300 to do that.", "God bless you!", MessageBoxButton.OK);

            }
            else if (secst > 440000)
            {
                MessageBox.Show("vSongBook's Evaluation(Trial) Mode has already expired. Please click on the Settings icon and go APPLICATION MODE to learn how to Upgrade to Premium Mode! It will cost you Kshs. 300 to do that.", "God bless you!", MessageBoxButton.OK);

            }
        }


        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.SelectedIndex == -1)
                return;
            vsb_songbook myresults = ListBox1.SelectedItem as vsb_songbook;
            //settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/DdSongView.xaml?selectedSong=" + (myresults.ID - 1).ToString(), UriKind.Relative));
            
            ListBox1.SelectedIndex = -1;
        }

        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox2.SelectedIndex == -1)
                return;
            vsb_songbook myresults = ListBox2.SelectedItem as vsb_songbook;
            //settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/DdSongView.xaml?selectedSong=" + (myresults.ID - 1).ToString(), UriKind.Relative));
            
            ListBox2.SelectedIndex = -1;
        }

        private void ListBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox3.SelectedIndex == -1)
                return;
            vsb_songbook myresults = ListBox3.SelectedItem as vsb_songbook;
            //settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/DdSongView.xaml?selectedSong=" + (myresults.ID - 1).ToString(), UriKind.Relative));
            
            ListBox3.SelectedIndex = -1;
        }

        private void ListBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox4.SelectedIndex == -1)
                return;
            vsb_songbook myresults = ListBox4.SelectedItem as vsb_songbook;
            //settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/DdSongView.xaml?selectedSong=" + (myresults.ID - 1).ToString(), UriKind.Relative));
            
            ListBox4.SelectedIndex = -1;
        }

        private void ListBox5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox5.SelectedIndex == -1)
                return;
            vsb_songbook myresults = ListBox5.SelectedItem as vsb_songbook;
            //settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/DdSongView.xaml?selectedSong=" + (myresults.ID - 1).ToString(), UriKind.Relative));
            
            ListBox5.SelectedIndex = -1;
        }

        private void ListBox6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox6.SelectedIndex == -1)
                return;
            vsb_songbook myresults = ListBox6.SelectedItem as vsb_songbook;
            //settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/DdSongView.xaml?selectedSong=" + (myresults.ID - 1).ToString(), UriKind.Relative));
            
            ListBox6.SelectedIndex = -1;
        }

        private void ListBox7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox7.SelectedIndex == -1)
                return;
            vsb_songbook myresults = ListBox7.SelectedItem as vsb_songbook;
            //settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/DdSongView.xaml?selectedSong=" + (myresults.ID - 1).ToString(), UriKind.Relative));
            
            ListBox7.SelectedIndex = -1;
        }

        private void ListBox8_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox8.SelectedIndex == -1)
                return;
            vsb_songbook myresults = ListBox8.SelectedItem as vsb_songbook;
            //settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/DdSongView.xaml?selectedSong=" + (myresults.ID - 1).ToString(), UriKind.Relative));
            
            ListBox8.SelectedIndex = -1;
        }

        private void ListBox9_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox9.SelectedIndex == -1)
                return;
            vsb_songbook myresults = ListBox9.SelectedItem as vsb_songbook;
            //settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/DdSongView.xaml?selectedSong=" + (myresults.ID - 1).ToString(), UriKind.Relative));
            
            ListBox9.SelectedIndex = -1;
        }

        public void Searchable(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/CcSearchable.xaml", UriKind.Relative));
        }

        private void MyOwnSongs(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EeOwnSongs.xaml", UriKind.Relative));
        }

        private void MyFavourites(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EeFavourites.xaml", UriKind.Relative));
        }

        public void MySettings(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FfSettings.xaml", UriKind.Relative));
        }


        public void AppTutorial(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BbDemo.xaml", UriKind.Relative));
        }

        public void HowItWorks(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FfHowItWorks.xaml", UriKind.Relative));
        }


        public void AboutThisApp(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FfInformation.xaml", UriKind.Relative));
        }


    }
}