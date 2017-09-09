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
    public partial class SongViewCopy1 : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();

        public SongViewCopy1()
        {
            InitializeComponent();
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            string copyingSong = "";
            if (NavigationContext.QueryString.TryGetValue("CopyingSong", out copyingSong))
            {
                int mysong = int.Parse(copyingSong);
                settings.CurrSongSetting = mysong;
                DataContext = App.ViewSong1.Songs[mysong];
                int fontsize = settings.FontSizeSetting / 2;
                string ContText = App.ViewSong1.Songs[mysong].SongContent;
                string SiteHeader = "<html><head><title>vSongBook On a Window</title><style>html{font-size:"
                    + fontsize + "px;}</style>";
                ContentText.NavigateToString(SiteHeader + "</head><body><p>" + ContText.Replace("$", "<br>")
                  + "<br>" + "</p></body></html>");
            }
        }

    }
}