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

namespace vSongBook
{
    public partial class EeFavourites : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        public EeFavourites()
        {
            InitializeComponent();
            DataContext = App.VirtualSongBook;
            this.Loaded += new RoutedEventHandler(EeFavourites_Loaded);
            if (!settings.Hint2Setting) ShowHintTwo();
        }

        private void EeFavourites_Loaded(object sender, RoutedEventArgs e)
        {
            App.VirtualSongBook.ListMyFavourites();            
            //MyFavourites fetch = new MyFavourites();
            //MainListBox.ItemsSource = fetch.getFavorites();
        }

        private void ShowHintTwo()
        {
            MessageBoxResult HintMeNow = MessageBox.Show("God bless you! This is a list of songs that you have liked or "
            + "rather favourited from the main song list. You can favourite a song by pressing the \"Favourite\" icon "
            + " when viewing a song. \n\n Press \"OKAY\" to prevent this hint "
            + "from showing in future or press \"CANCEL\" to see this hint in future again!",
            "Start Favouriting Songs!", MessageBoxButton.OKCancel);
            if (HintMeNow == MessageBoxResult.OK) settings.Hint2Setting = true;
            else if (HintMeNow == MessageBoxResult.Cancel) settings.Hint2Setting = false;
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainListBox.SelectedIndex == -1)
                return;
            NavigationService.Navigate(new Uri("/EeFavourite.xaml?favouritedSong=" + MainListBox.SelectedIndex, UriKind.Relative));
            
            MainListBox.SelectedIndex = -1;
        }

    }
}