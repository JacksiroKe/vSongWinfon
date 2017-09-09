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
    public partial class FfSettings2 : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();

        public FfSettings2()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(FfSettings2_Loaded);

        }

        private void FfSettings2_Loaded(object sender, RoutedEventArgs e)
        {

            long used_time_l, rem_time_l, expires_l;
            int used_time_i, rem_time_i, expired_i;

            DateTime unixEpoch = new DateTime(1970, 1, 1);
            DateTime localDate = DateTime.Now;
            long nowMilSecond = (localDate.Ticks - unixEpoch.Ticks) / 10000;

            used_time_l = nowMilSecond - settings.InstalledonSetting;
            rem_time_l = settings.ExpiresonSetting - nowMilSecond;
            expires_l = nowMilSecond - settings.ExpiresonSetting;

            used_time_i = (int)(used_time_l / 1000);
            rem_time_i = (int)(rem_time_l / 1000);
            expired_i = (int)(expires_l / 1000);

            if (!settings.PaidforSetting)
            {
                MessageBox.Show("God bless you. \n Upgrade your vSongBook to Premium by Paying Kshs. 300 to the developer via: \n - M-PESA to 0711474787 \n -  AIRTELMONEY to 0731973180 \n or Alternatively use you can use PAYPAL to: \n smataweb@gmail.com. \n\n You may opt to pay directly to the developer's Bank Account: \n BANK: Cooperative Bank of Kenya\n ACC.NO: 01108614130800 \n NAME: Jackson Silla Siro \n\n Once done wait for an SMS with the Unlock Code if you used MOBILE MONEY. If you didn't inform the developer on SMS or WHATSAPP +254711474787 or email: smataweb@gmail.com.\n\n For help SMS/WHATSAPP on +254711474787 or Email on smataweb@gmail.com. God bless you.", "Upgrade to Premium Now", MessageBoxButton.OK);

                PageTitle.Text = "Evaluation Mode";
                if (used_time_i < 440000)
                {
                    if (rem_time_i < 60) textcont3.Text = "Expires " + rem_time_i + " seconds from Now";
                    else if (rem_time_i < 3600) textcont3.Text = "Expires " + rem_time_i / 60 + " minutes from Now";
                    else if (rem_time_i < 86400) textcont3.Text = "Expires " + rem_time_i / 3600 + " hours from Now";
                    else if (rem_time_i < 440000) textcont3.Text = "Expires " + rem_time_i / 86400 + " days from Now";
                }
                else if (used_time_i > 440000)
                {
                    if (expired_i < 60) textcont3.Text = "Expired " + expired_i + " seconds ago";
                    else if (expired_i < 3600) textcont3.Text = "Expired " + expired_i / 60 + " minutes ago";
                    else if (expired_i < 86400) textcont3.Text = "Expired " + expired_i / 3600 + " hours ago";
                    else if (expired_i < 440000) textcont3.Text = "Expired " + expired_i / 86400 + " days ago";
                }
            }
            else if (settings.PaidforSetting)
            {
                PageTitle.Text = "Premium Mode";
                textcont3.Text = "God bless you so much for staying with vSongBook for all that time. More updates coming soon, so stay put.";
                textcont4.Visibility = Visibility.Collapsed;
                textcont5.Visibility = Visibility.Collapsed;
                textcont6.Visibility = Visibility.Collapsed;
                activation.Visibility = Visibility.Collapsed;
                activator.Visibility = Visibility.Collapsed;
            }

            if (used_time_i < 60) textcont2.Text = "Installed " + used_time_i + " seconds ago";
            else if (used_time_i < 3600) textcont2.Text = "Installed " + used_time_i / 60 + " minutes ago";
            else if (used_time_i < 86400) textcont2.Text = "Installed " + used_time_i / 3600 + " hours ago";
            else if (used_time_i < 604800) textcont2.Text = "Installed " + used_time_i / 86400 + " days ago";
            else if (used_time_i < 2419200) textcont2.Text = "Installed " + used_time_i / 604800 + " weeks ago";
            else if (used_time_i < 29030400) textcont2.Text = "Installed " + used_time_i / 2419200 + " months ago";
            else if (used_time_i > 29030400) textcont2.Text = "Installed " + used_time_i / 29030400 + " years ago";

        }

        private void HowToPay(object sender, EventArgs e)
        {
            MessageBox.Show("God bless you. \n Upgrade your vSongBook to Premium by Paying Kshs. 300 to the developer via: \n - M-PESA to 0711474787 \n -  AIRTELMONEY to 0731973180 \n or Alternatively use you can use PAYPAL to: \n smataweb@gmail.com. \n\n You may opt to pay directly to the developer's Bank Account: \n BANK: Cooperative Bank of Kenya\n ACC.NO: 01108614130800 \n NAME: Jackson Silla Siro \n\n Once done wait for an SMS with the Unlock Code if you used MOBILE MONEY. If you didn't inform the developer on SMS or WHATSAPP +254711474787 or email: smataweb@gmail.com.\n\n For help SMS/WHATSAPP on +254711474787 or Email on smataweb@gmail.com. God bless you.", "Upgrade to Premium Now", MessageBoxButton.OK);

        }


        private void ActivateApp(object sender, EventArgs e)
        {
            String ActivatorCode = activation.Text;
            String CurrentHr = DateTime.Now.ToString("HH");
            int CurHour = int.Parse(CurrentHr);

            if (ActivatorCode.Contains("JCSR"))
            {
                String[] CodeHr = ActivatorCode.Split(new string[] { "JCSR" }, StringSplitOptions.None);
                int CdHour = int.Parse(CodeHr[1]);
                //MessageBox.Show("CodeHour = " + CdHour + " and CurrentHour = " + CurHour);

                if ((CurHour - CdHour) < 3)
                {
                    settings.PaidforSetting = true;
                    textcont4.Visibility = Visibility.Collapsed;
                    textcont5.Visibility = Visibility.Collapsed;
                    activation.Visibility = Visibility.Collapsed;
                    activator.Visibility = Visibility.Collapsed;
                    MessageBox.Show("God bless you. vSongBook Application on your device has been unlocked. It is now Premium. If you loose this app in anyway and install again please do not hesitate to contact the developer Bro. Jack Siro for an Activation Code via SMS on +254711474787 or Email on smataweb@gmail.com. God bless you.", "App Unlocked!", MessageBoxButton.OK);

                    NavigationService.Navigate(new Uri("/CcSongBook.xaml", UriKind.Relative));

                }
                else
                {
                    MessageBox.Show("God bless you. Unfortunately vSongBook Application on your device can not be unlocked. The code you enterered is invalid or has expired_i. Please try again or request for another from the developer Bro. Jack Siro for help via SMS on +254711474787 or Email on smataweb@gmail.com. God bless you.", "Error in the code!", MessageBoxButton.OK);
                    activation.Text = "";
                }
            }
            else
            {
                MessageBox.Show("God bless you. Unfortunately vSongBook Application on your device can not be unlocked. The code you enterered is invalid or has expired_i. Please try again or request for another from the developer Bro. Jack Siro for help via SMS on +254711474787 or Email on smataweb@gmail.com. God bless you.", "Error in the code!", MessageBoxButton.OK);
                activation.Text = "";
            }

        }


    }
}