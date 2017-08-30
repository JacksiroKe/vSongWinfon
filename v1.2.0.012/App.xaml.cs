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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;
using VsbDatabase.ViewModels;

namespace vSongBook
{
    public partial class App : Application
    {
        private AppSettings settings = new AppSettings();
        private static MainViewSong viewSong = null;
        public static MainViewSong ViewSong
        {
            get
            {
                if (viewSong == null)
                    viewSong = new MainViewSong();

                return viewSong;
            }
        }
			
        private static SettingsViewModel viewSett = null;
        public static SettingsViewModel ViewSett
        {
            get
            {
                if (viewSett == null)
                    viewSett = new SettingsViewModel();

                return viewSett;
            }
        }

        private static VsbViewModel viewSongBook;
        public static VsbViewModel ViewSongBook { get { return viewSongBook; } }


        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

            // Specify the local database connection string.
            string DBConnectionString = "Data Source=isostore:/vSongBook_One.sdf";

            using (VsbDataContext db = new VsbDataContext(DBConnectionString))
            {
                if (db.DatabaseExists() == false)
                {
                    db.CreateDatabase();
                    db.SubmitChanges();
                }
            }

            // Create the ViewModel object.
            viewSongBook = new VsbViewModel(DBConnectionString);

            if (!settings.InitialSetupSetting)
            {
                
                LoadSongBookItems();
                settings.InitialSetupSetting = true;
            }

            //App.viewSongBook.LoadParasFromDatabase(settings.CurrentCodeSetting);

        }

        private void LoadSongBookItems()
        {
            XDocument XmlDyta = XDocument.Load("RealData/vSongBook.xml");
            var songitems = from query in XmlDyta.Descendants("ItemViewSong") select new SongItem() 
            {
                SongTitle = query.Attribute("SongTitle").Value, 
                SongContent = query.Attribute("SongContent").Value, 
                SongIcon = query.Attribute("SongIcon").Value 
            };

            foreach (var song in songitems)
            {
                VsbSongbook SongAdd = new VsbSongbook 
                { 
                    SongTitle = song.SongTitle, SongContent = song.SongContent, SongIcon = song.SongIcon 
                };
                App.viewSongBook.AddVsbSongbook(SongAdd);
            }

        }

        public class SongItem
        {
            string song_title; string song_cont; string song_icon;
            public string SongTitle { get { return song_title; } set { song_title = value; } }
            public string SongContent { get { return song_cont; } set { song_cont = value; } }
            public string SongIcon { get { return song_icon; } set { song_icon = value; } }
        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            

            
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
            // Ensure that required application state is persisted here.
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}
