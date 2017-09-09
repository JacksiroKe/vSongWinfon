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
    public partial class SongBook1 : PhoneApplicationPage
    {
        // Constructor
        private AppSettings settings = new AppSettings();
        public SongBook1()
        {
            InitializeComponent();

            DataContext = App.ViewSong1;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            if (!App.ViewSong1.IsDataLoaded)
            {
                App.ViewSong1.LoadData();
            }

            ListBox1.ItemsSource = App.ViewSong1.Songs.Where(w => w.SongContent.Contains("#NyimboCiaKuiniraNgai"));
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.SelectedIndex == -1)
                return;
            ItemViewSong1 myresults = ListBox1.SelectedItem as ItemViewSong1;
            settings.CurrSongSetting = myresults.SongNo - 1;
            NavigationService.Navigate(new Uri("/SongView1.xaml", UriKind.Relative));            
            ListBox1.SelectedIndex = -1;
        }

        public void Searchable(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Searchable1.xaml", UriKind.Relative));
        }
        
        private void MyOwnSongs(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/VsbOwnSongs.xaml", UriKind.Relative));
        }

        private void MyFavourites(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/VsbFavourites.xaml", UriKind.Relative));
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