using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using vSongBook.RealData;

namespace vSongBook
{
    public partial class CcFirstLoad : PhoneApplicationPage
    {
        public CcFirstLoad()
        {
            InitializeComponent();
        }

        private void OnItemContentTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SongBookObject item = ((FrameworkElement)sender).DataContext as SongBookObject;
            if (item != null)
            {
                item.Unselected = false;
            }
        }
    }
}