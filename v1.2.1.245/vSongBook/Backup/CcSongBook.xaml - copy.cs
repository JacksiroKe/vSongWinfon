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
using System.Xml.Linq;
using Microsoft.Phone.Tasks;

namespace vSongBook
{
    public partial class CcSongBook : PhoneApplicationPage
    {
        // Constructor
        private AppSettings settings = new AppSettings();
        public CcSongBook()
        {
            InitializeComponent();
            pSongBook.Visibility = Visibility.Collapsed;
            ApplicationBar.IsVisible = false;
            this.Loaded += new RoutedEventHandler(CcSongBook_Loaded);

            if (!settings.PaidforSetting) ExpiringMessage();
        }

        private void CcSongBook_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavigationService.RemoveBackEntry();

            if (!App.ViewSong.IsDataLoaded)
            {
                App.ViewSong.LoadData();
            }

            FetchSongBook fetch = new FetchSongBook();
            ListBox1.ItemsSource = fetch.getSongBook("Songs of Worship");
            ListBox2.ItemsSource = fetch.getSongBook("Nyimbo zaInjili");
            ListBox3.ItemsSource = fetch.getSongBook("Believers Songs");
            ListBox4.ItemsSource = fetch.getSongBook("Nyimbo za Wokovu");
            ListBox5.ItemsSource = fetch.getSongBook("Redemption Songs");
            ListBox6.ItemsSource = fetch.getSongBook("Tenzi za Rohoni");
            ListBox7.ItemsSource = fetch.getSongBook("Kuinira Ngai");
            ListBox8.ItemsSource = fetch.getSongBook("Kumutaiia Ngai");
            ListBox9.ItemsSource = fetch.getSongBook("Kilosune Jehovah");

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
            ItemViewSong myresults = ListBox1.SelectedItem as ItemViewSong;
            settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/SongView.xaml", UriKind.Relative));
            ListBox1.SelectedIndex = -1;
        }

        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox2.SelectedIndex == -1)
                return;
            
        }

        private void ListBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox3.SelectedIndex == -1)
                return;
            
        }

        private void ListBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox4.SelectedIndex == -1)
                return;
            
        }

        private void ListBox5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox5.SelectedIndex == -1)
                return;
            
        }

        private void ListBox6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox6.SelectedIndex == -1)
                return;
            
        }

        private void ListBox7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox7.SelectedIndex == -1)
                return;

        }

        private void ListBox8_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox8.SelectedIndex == -1)
                return;

        }

        private void ListBox9_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox9.SelectedIndex == -1)
                return;

        }

        public void Searchable(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Searchable.xaml", UriKind.Relative));
        }

        private void MyOwnSongs(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/VsbOwnSongs.xaml", UriKind.Relative));
        }

        private void MyFavourites(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/VsbFavourites.xaml", UriKind.Relative));
        }

        public void Searchable1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SongBook1.xaml", UriKind.Relative));
        }

        public void MySettings(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }


        public void AppTutorial(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AaaStart.xaml", UriKind.Relative));
        }

        public void HowItWorks(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HowItWorks.xaml", UriKind.Relative));
        }


        public void AboutThisApp(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Information.xaml", UriKind.Relative));
        }


    }
}