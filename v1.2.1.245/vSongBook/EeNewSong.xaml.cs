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
    public partial class EeNewSong : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        public EeNewSong()
        {
            InitializeComponent();
            if (!settings.Hint4Setting) ShowHintFour();
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
            if (TitleText.Text.Length > 0)
            {
                OwnSongAdd myown = new OwnSongAdd();
                myown.AddOwnSong(TitleText.Text, ContentText.Text);
                NavigationService.GoBack();

            }
        }

        private void CancelSave(object sender, EventArgs e)
        {
            NavigationService.GoBack();
            
        }
    }
}