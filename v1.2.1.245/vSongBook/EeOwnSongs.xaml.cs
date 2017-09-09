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
    public partial class EeOwnSongs : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        public EeOwnSongs()
        {
            InitializeComponent();
            DataContext = App.VirtualSongBook;
            this.Loaded += new RoutedEventHandler(EeOwnSongs_Loaded);
            if (!settings.Hint3Setting) ShowHintThree();
        }

        private void EeOwnSongs_Loaded(object sender, RoutedEventArgs e)
        {
            App.VirtualSongBook.ListMyOwnSongs();
        }

        private void ShowHintThree()
        {
            MessageBoxResult HintMeNow = MessageBox.Show("God bless you! This is a list of songs that you have written or "
            + "rather saved from other sources like WhatsApp, Internet, Email etc. You can save a song by pressing the "
            + "\"New Song\" icon below. \n\n Press \"OKAY\" to prevent this hint "
            + "from showing in future or press \"CANCEL\" to see this hint in future again!",
            "Start Saving Your Own Songs!", MessageBoxButton.OKCancel);
            if (HintMeNow == MessageBoxResult.OK) settings.Hint3Setting = true;
            else if (HintMeNow == MessageBoxResult.Cancel) settings.Hint3Setting = false;
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainListBox.SelectedIndex == -1)
                return;
            NavigationService.Navigate(new Uri("/EeOwnSong.xaml?myOwnSong=" + MainListBox.SelectedIndex, UriKind.Relative));
            
            MainListBox.SelectedIndex = -1;
        }

        private void SaveNewSong(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EeNewSong.xaml", UriKind.Relative));
        }

    }
}