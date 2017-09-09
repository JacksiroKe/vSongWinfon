using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using System.Threading;
using System.IO.IsolatedStorage;
using System.ComponentModel;

namespace vSongBook
{
    public partial class CcLoading : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        bool startedLoading;
        public CcLoading()
        {
            InitializeComponent();
            startedLoading = false;
            this.Loaded += new RoutedEventHandler(CcLoading_Loaded);
        }

        private void CcLoading_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();

            if (!settings.InitialSetupSetting)
            {
                settings.InitialSetupSetting = true;
                LoadVirtualSongBook();
            }
            txtProgress.Text = "This app is going load the songs for the first time. Your screen should be on during this time "
                + "and not get locked. You may opt to go back and change lockscreen settings to like more than 3 minutes. "
                + "before you proceed with loading the vSongBook";

            NavigationService.Navigate(new Uri("/CcSongBook.xaml", UriKind.Relative));
        }

        private void LoadVirtualSongBook()
        {
            String line;
            String pathoffile = "RealData/vsongbook.txt";
            System.IO.StreamReader reader = new System.IO.StreamReader(pathoffile);
            try
            {
                
                while ((line = reader.ReadLine()) != null)
                {
                    String[] strings = line.Split('%');
                    if (strings.Length < 2) continue;
                    SongBookAdd add = new SongBookAdd();
                    add.AddSongBook(strings[0], strings[1], strings[2]);
                }
            }
            catch (Exception)
            {
                reader.Close();
            }
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            //base.OnBackKeyPress(e);
            if (startedLoading)
            {
                if (!settings.InitialSetupSetting)
                {
                    MessageBoxResult BeforeUExit = MessageBox.Show("Are you sure you want to exit this app? "
                        + "The current task will be aborted and will never resume even after you reopen it.", 
                        "Warning on Exit", MessageBoxButton.OK);

                    if (BeforeUExit == MessageBoxResult.OK)
                    {
                        NavigationService.GoBack();
                    }

                    /*
                    else if (BeforeUExit == MessageBoxResult.Cancel)
                    {
                        
                    }
                         */
                }
            }
        }
        
    }
}