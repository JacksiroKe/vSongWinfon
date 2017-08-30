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

namespace vSongBook
{
    public partial class Aaa : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        public Aaa()
        {
            InitializeComponent();
            if (!settings.FirstTimeSetting) SetFirstUse();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!settings.SeenTutorialSetting)
            {
                NavigationService.Navigate(new Uri("/AaaStart.xaml", UriKind.Relative));
                SetFirstUse();
            }

            else
            {
                if (!settings.PaidforSetting) ExpiringMode();
                else NavigationService.Navigate(new Uri("/SongBook.xaml", UriKind.Relative));
            }

        }

        private void ExpiringMode()
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
                if (remst < 60) NavigationService.Navigate(new Uri("/SongBook.xaml", UriKind.Relative));
                else if (remst < 3600) NavigationService.Navigate(new Uri("/SongBook.xaml", UriKind.Relative));
                else if (remst < 86400) NavigationService.Navigate(new Uri("/SongBook.xaml", UriKind.Relative));
                else if (remst < 432000) NavigationService.Navigate(new Uri("/SongBook.xaml", UriKind.Relative));
            }
            else if (secst > 440000) NavigationService.Navigate(new Uri("/Xpired.xaml", UriKind.Relative));

        }


        private void SetFirstUse()
        {
            settings.RatedVsbwpSetting = false;
            settings.FirstTimeSetting = true;
            DateTime unixEpoch = new DateTime(1970, 1, 1);
            DateTime localDate = DateTime.Now;
            long totMilSecond = (localDate.Ticks - unixEpoch.Ticks) / 10000;
            settings.InstalledonSetting = totMilSecond;
            settings.ExpiresonSetting = totMilSecond + 440000000;

        }

    }
}
