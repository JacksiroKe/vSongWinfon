﻿using System;
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
    public partial class Information : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
		public Information()
        {
            InitializeComponent();
            ContentText.Text = ContentText.Text.Replace("$", "\n");
            ContentText.FontSize = settings.FontSizeSetting;
		}
    }
}