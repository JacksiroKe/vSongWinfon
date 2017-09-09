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
    public partial class BbDemo : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        public BbDemo()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(BbDemo_Loaded);
        }

        private void BbDemo_Loaded(object sender, RoutedEventArgs e)
        {


            ContentText1.Text = ContentText1.Text.Replace("$", "\n");
            ContentText1.FontSize = settings.FontSizeSetting;
            ContentText2.Text = ContentText2.Text.Replace("$", "\n");
            ContentText2.FontSize = settings.FontSizeSetting;
            ContentText3.Text = ContentText3.Text.Replace("$", "\n");
            ContentText3.FontSize = settings.FontSizeSetting;
            ContentText4.Text = ContentText4.Text.Replace("$", "\n");
            ContentText4.FontSize = settings.FontSizeSetting;

            if (!settings.SeenTutorialSetting)
            {
                AcceptBtn.Content = "ACCEPT";
                this.NavigationService.RemoveBackEntry();
            
            }
            else
            {
                AcceptBtn.Content = "FINISH";
            }

        }

        private void Accept_This(object sender, EventArgs e)
        {
            
            if (!settings.SeenTutorialSetting) settings.SeenTutorialSetting = true;
            if (!settings.InitialSetupSetting)
            {
                NavigationService.Navigate(new Uri("/CcLoading.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.GoBack();
            }
        }

    }
}