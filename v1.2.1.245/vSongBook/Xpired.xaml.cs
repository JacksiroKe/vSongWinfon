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
    public partial class Xpired : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        public Xpired()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Xpired_Loaded);
        }

        private void Xpired_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavigationService.RemoveBackEntry();
            long expires;
            int expired;

            DateTime unixEpoch = new DateTime(1970, 1, 1);
            DateTime localDate = DateTime.Now;
            long nowMilSecond = (localDate.Ticks - unixEpoch.Ticks) / 10000;

            expires = nowMilSecond - settings.ExpiresonSetting;
            expired = (int)(expires / 1000);

            ContentText.FontSize = settings.FontSizeSetting;
            if (expired < 60) ContentText.Text = "vSongBook had to terminate " + expired + " seconds ago. To continue using this app without having to install afresh you will need to use one of the following ways to pay: \n send Kshs 300 to \n - 0711474787 via M-Pesa \n - 0731973180 via Airtelmoney \n - send 3 USD via Paypal to smataweb@gmail.com \n\n You will immediately get the Activation code via SMS if you used mobile money or via Email if you used Paypal. \n\n Click on the Pay Now icon to Activate this app if you already have the Activation code.";
            else if (expired < 3600) ContentText.Text = "vSongBook had to terminate " + expired / 60 + " minutes ago. To continue using this app without having to install afresh you will need to use one of the following ways to pay: \n send Kshs 300 to \n - 0711474787 via M-Pesa \n - 0731973180 via Airtelmoney \n - send 3 USD via Paypal to smataweb@gmail.com \n\n You will immediately get the Activation code via SMS if you used mobile money or via Email if you used Paypal. \n\n Click on the Pay Now icon to Activate this app if you already have the Activation code.";
            else if (expired < 86400) ContentText.Text = "vSongBook had to terminate " + expired / 3600 + " hours ago. To continue using this app without having to install afresh you will need to use one of the following ways to pay: \n send Kshs 300 to \n - 0711474787 via M-Pesa \n - 0731973180 via Airtelmoney \n - send 3 USD via Paypal to smataweb@gmail.com \n\n You will immediately get the Activation code via SMS if you used mobile money or via Email if you used Paypal. \n\n Click on the Pay Now icon to Activate this app if you already have the Activation code.";
            else if (expired < 604800) ContentText.Text = "vSongBook had to terminate " + expired / 86400 + " days ago. To continue using this app without having to install afresh you will need to use one of the following ways to pay: \n send Kshs 300 to \n - 0711474787 via M-Pesa \n - 0731973180 via Airtelmoney \n - send 3 USD via Paypal to smataweb@gmail.com \n\n You will immediately get the Activation code via SMS if you used mobile money or via Email if you used Paypal. \n\n Click on the Pay Now icon to Activate this app if you already have the Activation code.";
            else if (expired < 2419200) ContentText.Text = "vSongBook had to terminate " + expired / 604800 + " weeks ago. To continue using this app without having to install afresh you will need to use one of the following ways to pay: \n send Kshs 300 to \n - 0711474787 via M-Pesa \n - 0731973180 via Airtelmoney \n - send 3 USD via Paypal to smataweb@gmail.com \n\n You will immediately get the Activation code via SMS if you used mobile money or via Email if you used Paypal. \n\n Click on the Pay Now icon to Activate this app if you already have the Activation code.";
            else if (expired < 29030400) ContentText.Text = "vSongBook had to terminate " + expired / 2419200 + " months ago. To continue using this app without having to install afresh you will need to use one of the following ways to pay: \n send Kshs 300 to \n - 0711474787 via M-Pesa \n - 0731973180 via Airtelmoney \n - send 3 USD via Paypal to smataweb@gmail.com \n\n You will immediately get the Activation code via SMS if you used mobile money or via Email if you used Paypal. \n\n Click on the Pay Now icon to Activate this app if you already have the Activation code.";
            else if (expired > 29030400) ContentText.Text = "vSongBook had to terminate " + expired / 29030400 + " years ago. To continue using this app without having to install afresh you will need to use one of the following ways to pay: \n send Kshs 300 to \n - 0711474787 via M-Pesa \n - 0731973180 via Airtelmoney \n - send 3 USD via Paypal to smataweb@gmail.com \n\n You will immediately get the Activation code via SMS if you used mobile money or via Email if you used Paypal. \n\n Click on the Pay Now icon to Activate this app if you already have the Activation code.";

        }

        public void PayNow(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings2.xaml", UriKind.Relative));
        }

        public void HowItWorks(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HowItWorks.xaml", UriKind.Relative));
        }
        
        public void AboutThisApp(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Information.xaml", UriKind.Relative));
        }

    }
}