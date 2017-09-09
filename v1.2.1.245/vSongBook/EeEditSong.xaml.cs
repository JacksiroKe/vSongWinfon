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

using VsbDatabase;

namespace vSongBook
{
    public partial class VsbEditSong : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        int SelecSong, CurrSong, FontSize;
        
        public VsbEditSong()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string editOwnSong = "";
                if (NavigationContext.QueryString.TryGetValue("editOwnSong", out editOwnSong))
                {
                    SelecSong = int.Parse(editOwnSong);
                    DataContext = App.VirtualSongBook.MyOwnSongs[SelecSong];
                    CurrSong = App.VirtualSongBook.MyOwnSongs[SelecSong].ID;
                    settings.CurrMysongSetting = CurrSong;
                    setTextContent();
                }
            }

            if (!settings.Hint4Setting) ShowHintFour();
        }

        private void setTextContent()
        {
            NavigationService.RemoveBackEntry();
            TitleText.Text = App.VirtualSongBook.MyOwnSongs[SelecSong].Title;
            ContentText.Text = App.VirtualSongBook.MyOwnSongs[SelecSong].Content;
        }

        private void ShowHintFour()
        {
            MessageBoxResult HintMeNow = MessageBox.Show("God bless you! Use the first input box at the top to write the title "
            + "of your song and the second input box at the bottom to write the the rest of the content of your song. "
            + "Press the \"Save Song\" icon to save or \"Cancel\" icon to cancel. \n\n Press \"OKAY\" to prevent this hint "
            + "from showing in future or press \"CANCEL\" to see this hint in future again!",
            "How to save your own song!", MessageBoxButton.OKCancel);
            if (HintMeNow == MessageBoxResult.OK) settings.Hint4Setting = true;
            else if (HintMeNow == MessageBoxResult.Cancel) settings.Hint4Setting = false;
        }


        private void SaveSong(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TitleText.Text) && !String.IsNullOrEmpty(ContentText.Text))
            {
                OwnsongUpdate updateOwn = new OwnsongUpdate();
                updateOwn.UpdateOwnSong(CurrSong, TitleText.Text, ContentText.Text);
                NavigationService.GoBack();
            }
        }

        private void CancelSave(object sender, EventArgs e)
        {
            NavigationService.GoBack();

        }
    }
}