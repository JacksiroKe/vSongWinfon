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
    public partial class DdSongViewCopy : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();

        public DdSongViewCopy()
        {
            InitializeComponent();

        }

        public String strParser(String mystring)
        {
            mystring = mystring.Replace("^", "'");
            mystring = mystring.Replace('+', '"');
            mystring = mystring.Replace("$", "<br>");
            mystring = mystring.Replace("`", "<br><br>");
            return mystring;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            string copyingSong = "";
            if (NavigationContext.QueryString.TryGetValue("CopyingSong", out copyingSong))
            {
                int mysong = int.Parse(copyingSong);
                settings.CurrSongSetting = mysong;
                DataContext = App.VirtualSongBook.SongList[mysong];
                int fontsize = settings.FontSizeSetting / 2;
                string ContText = strParser(App.VirtualSongBook.SongList[mysong].Content);
                string SiteHeader = "<!DOCTYPE html><head><title>vSongBook On a Window</title><style>html{font-size:" +
                    fontsize + "px;}</style>";
                ContentText.NavigateToString(SiteHeader + "</head><body><p>" + ContText + "<br>" + 
                    "</p><p><br><br>Via vSongBook</p></body></html>");
            }
        }

    }
}