using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Phone.Tasks;
using vSongBook.RealData;

namespace vSongBook
{
    
    public partial class DdSongBookNew : PhoneApplicationPage
    {
        class PivotCallbacks
        {
            public Action Init { get; set; }
            public Action OnActivated { get; set; }
            public Action<CancelEventArgs> OnBackKeyPress { get; set; }
        }

        Dictionary<object, PivotCallbacks> _callbacks;

        private AppSettings appsettings = new AppSettings();
        public DdSongBookNew()
        {
            InitializeComponent();

            this.Loaded += DdSongBookNew_Loaded;

            _callbacks = new Dictionary<object, PivotCallbacks>();
            _callbacks[MultiselectLbxItem1] = new PivotCallbacks
            {
                Init = CreateSongApplicationBarItems,
                OnActivated = OnSong1PivotItemActivated,
                OnBackKeyPress = OnSong1BackKeyPressed
            };
            _callbacks[MultiselectLbxItem2] = new PivotCallbacks
            {
                Init = CreateSongApplicationBarItems,
                OnActivated = OnSong2PivotItemActivated,
                OnBackKeyPress = OnSong2BackKeyPressed
            };
            _callbacks[MultiselectLbxItem3] = new PivotCallbacks
            {
                Init = CreateSongApplicationBarItems,
                OnActivated = OnSong3PivotItemActivated,
                OnBackKeyPress = OnSong3BackKeyPressed
            };
            _callbacks[MultiselectLbxItem4] = new PivotCallbacks
            {
                Init = CreateSongApplicationBarItems,
                OnActivated = OnSong4PivotItemActivated,
                OnBackKeyPress = OnSong4BackKeyPressed
            };
            _callbacks[MultiselectLbxItem5] = new PivotCallbacks
            {
                Init = CreateSongApplicationBarItems,
                OnActivated = OnSong5PivotItemActivated,
                OnBackKeyPress = OnSong5BackKeyPressed
            };
            _callbacks[MultiselectLbxItem6] = new PivotCallbacks
            {
                Init = CreateSongApplicationBarItems,
                OnActivated = OnSong6PivotItemActivated,
                OnBackKeyPress = OnSong6BackKeyPressed
            };
            _callbacks[MultiselectLbxItem7] = new PivotCallbacks
            {
                Init = CreateSongApplicationBarItems,
                OnActivated = OnSong7PivotItemActivated,
                OnBackKeyPress = OnSong7BackKeyPressed
            };
            _callbacks[MultiselectLbxItem8] = new PivotCallbacks
            {
                Init = CreateSongApplicationBarItems,
                OnActivated = OnSong8PivotItemActivated,
                OnBackKeyPress = OnSong8BackKeyPressed
            };
            _callbacks[MultiselectLbxItem9] = new PivotCallbacks
            {
                Init = CreateSongApplicationBarItems,
                OnActivated = OnSong9PivotItemActivated,
                OnBackKeyPress = OnSong9BackKeyPressed
            };
            foreach (var callbacks in _callbacks.Values)
            {
                if (callbacks.Init != null)
                {
                    callbacks.Init();
                }
            }
        }

        void DdSongBookNew_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavigationService.RemoveBackEntry();

        }
        
        private void OnPivotSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PivotCallbacks callbacks;
            if (_callbacks.TryGetValue(pSongBook.SelectedItem, out callbacks) && (callbacks.OnActivated != null))
            {
                callbacks.OnActivated();
            }
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            PivotCallbacks callbacks;
            if (_callbacks.TryGetValue(pSongBook.SelectedItem, out callbacks) && (callbacks.OnBackKeyPress != null))
            {
                callbacks.OnBackKeyPress(e);
            }
        }

        void ClearApplicationBar()
        {
            while (ApplicationBar.Buttons.Count > 0)
            {
                ApplicationBar.Buttons.RemoveAt(0);
            }

            while (ApplicationBar.MenuItems.Count > 0)
            {
                ApplicationBar.MenuItems.RemoveAt(0);
            }
        }

        #region MultiselectListbox item
        ApplicationBarIconButton searchable;
        ApplicationBarIconButton ownsongs;
        ApplicationBarIconButton favourites;
        ApplicationBarIconButton settings;
        ApplicationBarIconButton favourite;
        ApplicationBarMenuItem select;
        ApplicationBarMenuItem tutorial;
        ApplicationBarMenuItem aboutapp;
        ApplicationBarMenuItem howitworks;

        /// <summary>
        /// Creates ApplicationBar items for email list
        /// </summary>
        private void CreateSongApplicationBarItems()
        {

            searchable = new ApplicationBarIconButton();
            searchable.IconUri = new Uri("/Assets/AppBar/appbar_search.png", UriKind.RelativeOrAbsolute);
            searchable.Text = "Search";
            searchable.Click += OnSearchClick;
            
            ownsongs = new ApplicationBarIconButton();
            ownsongs.IconUri = new Uri("/Assets/AppBar/appbar_edit.png", UriKind.RelativeOrAbsolute);
            ownsongs.Text = "My Songs";
            ownsongs.Click += OnOwnsongsClick;

            favourites = new ApplicationBarIconButton();
            favourites.IconUri = new Uri("/Assets/AppBar/appbar_favall.png", UriKind.RelativeOrAbsolute);
            favourites.Text = "Favourites";
            favourites.Click += OnFavouritesClick;

            settings = new ApplicationBarIconButton();
            settings.IconUri = new Uri("/Assets/AppBar/appbar_settings.png", UriKind.RelativeOrAbsolute);
            settings.Text = "Settings";
            settings.Click += OnSettingsClick;

            favourite = new ApplicationBarIconButton();
            favourite.IconUri = new Uri("/Assets/AppBar/appbar_favadd.png", UriKind.RelativeOrAbsolute);
            favourite.Text = "Favourite";
            favourite.Click += OnFavouriteClick;

            select = new ApplicationBarMenuItem();
            select.Text = "Select Songs";
            select.Click += OnSelectClick;

            tutorial = new ApplicationBarMenuItem();
            tutorial.Text = "App Tutorial";
            tutorial.Click += OnTutorialClick;

            aboutapp = new ApplicationBarMenuItem();
            aboutapp.Text = "About this App";
            aboutapp.Click += OnAboutClick;

            howitworks = new ApplicationBarMenuItem();
            howitworks.Text = "How it Works";
            howitworks.Click += OnHowitworksClick;

        }

        void OnSong1PivotItemActivated()
        {
            if (SongList1.IsSelectionEnabled)
            {
                SongList1.IsSelectionEnabled = false;
            }
            else
            {
                SetupSongApplicationBar();
            }
        }

        void OnSong2PivotItemActivated()
        {
            if (SongList2.IsSelectionEnabled)
            {
                SongList2.IsSelectionEnabled = false;
            }
            else
            {
                SetupSongApplicationBar();
            }
        }

        void OnSong3PivotItemActivated()
        {
            if (SongList3.IsSelectionEnabled)
            {
                SongList3.IsSelectionEnabled = false;
            }
            else
            {
                SetupSongApplicationBar();
            }
        }

        void OnSong4PivotItemActivated()
        {
            if (SongList4.IsSelectionEnabled)
            {
                SongList4.IsSelectionEnabled = false;
            }
            else
            {
                SetupSongApplicationBar();
            }
        }

        void OnSong5PivotItemActivated()
        {
            if (SongList5.IsSelectionEnabled)
            {
                SongList5.IsSelectionEnabled = false;
            }
            else
            {
                SetupSongApplicationBar();
            }
        }

        void OnSong6PivotItemActivated()
        {
            if (SongList6.IsSelectionEnabled)
            {
                SongList6.IsSelectionEnabled = false;
            }
            else
            {
                SetupSongApplicationBar();
            }
        }

        void OnSong7PivotItemActivated()
        {
            if (SongList7.IsSelectionEnabled)
            {
                SongList7.IsSelectionEnabled = false;
            }
            else
            {
                SetupSongApplicationBar();
            }
        }

        void OnSong8PivotItemActivated()
        {
            if (SongList8.IsSelectionEnabled)
            {
                SongList8.IsSelectionEnabled = false;
            }
            else
            {
                SetupSongApplicationBar();
            }
        }

        void OnSong9PivotItemActivated()
        {
            if (SongList9.IsSelectionEnabled)
            {
                SongList9.IsSelectionEnabled = false;
            }
            else
            {
                SetupSongApplicationBar();
            }
        }

        private void SetupSongApplicationBar()
        {
            ClearApplicationBar();            
            if (SongList1.IsSelectionEnabled)
            {
                ApplicationBar.Buttons.Add(favourite);
                UpdateSongApplicationBar();
            }
            else
            {
                ApplicationBar.Buttons.Add(searchable);
                ApplicationBar.Buttons.Add(ownsongs);
                ApplicationBar.Buttons.Add(favourites);
                ApplicationBar.Buttons.Add(settings);
                ApplicationBar.MenuItems.Add(tutorial);
                ApplicationBar.MenuItems.Add(aboutapp);
                ApplicationBar.MenuItems.Add(howitworks);
                ApplicationBar.MenuItems.Add(select);
            }
            ApplicationBar.IsVisible = true;
        }

        /// <summary>
        /// Updates the email Application bar items depending on selection
        /// </summary>
        private void UpdateSongApplicationBar()
        {
            if (SongList1.IsSelectionEnabled)
            {
                bool hasSelection = ((SongList1.SelectedItems != null) && (SongList1.SelectedItems.Count > 0));
                favourite.IsEnabled = hasSelection;
            }
        }

        protected void OnSong1BackKeyPressed(CancelEventArgs e)
        {
            if (SongList1.IsSelectionEnabled)
            {
                SongList1.IsSelectionEnabled = false;
                e.Cancel = true;
            }
        }

        protected void OnSong2BackKeyPressed(CancelEventArgs e)
        {
            if (SongList2.IsSelectionEnabled)
            {
                SongList2.IsSelectionEnabled = false;
                e.Cancel = true;
            }
        }

        protected void OnSong3BackKeyPressed(CancelEventArgs e)
        {
            if (SongList3.IsSelectionEnabled)
            {
                SongList3.IsSelectionEnabled = false;
                e.Cancel = true;
            }
        }

        protected void OnSong4BackKeyPressed(CancelEventArgs e)
        {
            if (SongList4.IsSelectionEnabled)
            {
                SongList4.IsSelectionEnabled = false;
                e.Cancel = true;
            }
        }

        protected void OnSong5BackKeyPressed(CancelEventArgs e)
        {
            if (SongList5.IsSelectionEnabled)
            {
                SongList5.IsSelectionEnabled = false;
                e.Cancel = true;
            }
        }

        protected void OnSong6BackKeyPressed(CancelEventArgs e)
        {
            if (SongList6.IsSelectionEnabled)
            {
                SongList6.IsSelectionEnabled = false;
                e.Cancel = true;
            }
        }

        protected void OnSong7BackKeyPressed(CancelEventArgs e)
        {
            if (SongList7.IsSelectionEnabled)
            {
                SongList7.IsSelectionEnabled = false;
                e.Cancel = true;
            }
        }

        protected void OnSong8BackKeyPressed(CancelEventArgs e)
        {
            if (SongList8.IsSelectionEnabled)
            {
                SongList8.IsSelectionEnabled = false;
                e.Cancel = true;
            }
        }

        protected void OnSong9BackKeyPressed(CancelEventArgs e)
        {
            if (SongList9.IsSelectionEnabled)
            {
                SongList9.IsSelectionEnabled = false;
                e.Cancel = true;
            }
        }

        void OnSearchClick(object sender, EventArgs e)
        {
           
        }

        void OnOwnsongsClick(object sender, EventArgs e)
        {
            
        }

        void OnFavouritesClick(object sender, EventArgs e)
        {

        }

        void OnSettingsClick(object sender, EventArgs e)
        {

        }

        void OnFavouriteClick(object sender, EventArgs e)
        {

        }

        void OnSelectClick(object sender, EventArgs e)
        {
            SongList1.IsSelectionEnabled = true;
        }

        void OnTutorialClick(object sender, EventArgs e)
        {

        }

        void OnAboutClick(object sender, EventArgs e)
        {

        }

        void OnHowitworksClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Deletes selected items 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDeleteClick(object sender, EventArgs e)
        {
            IList source = SongList1.ItemsSource as IList;
            while (SongList1.SelectedItems.Count > 0)
            {
                source.Remove((SongObject)SongList1.SelectedItems[0]);
            }
        }

        /// <summary>
        /// Mark all items as read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMarkAsReadClick(object sender, EventArgs e)
        {
            foreach (SongObject obj in SongList1.SelectedItems)
            {
                obj.Unselected = false;
            }

            SongList1.IsSelectionEnabled = false;
        }

        /// <summary>
        /// Mark all items as unread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMarkAsUnselectedClick(object sender, EventArgs e)
        {
            foreach (SongObject obj in SongList1.SelectedItems)
            {
                obj.Unselected = true;
            }

            SongList1.IsSelectionEnabled = false;
        }

        /// <summary>
        /// Adjusts the user interface according to the number of selected emails
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSongList1SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSongApplicationBar();
        }

        private void OnSongList2SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSongApplicationBar();
        }

        private void OnSongList3SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSongApplicationBar();
        }

        private void OnSongList4SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSongApplicationBar();
        }

        private void OnSongList5SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSongApplicationBar();
        }

        private void OnSongList6SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSongApplicationBar();
        }

        private void OnSongList7SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSongApplicationBar();
        }

        private void OnSongList8SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSongApplicationBar();
        }

        private void OnSongList9SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSongApplicationBar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSongListIsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetupSongApplicationBar();
        }



        /// <summary>
        /// Tap on an item : depending on the selection state, either unselect it or consider it as read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemContentTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SongObject item = ((FrameworkElement)sender).DataContext as SongObject;
            if (item != null)
            {
                item.Unselected = false;
            }
        }

        #endregion

        private void OnSongList1IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void OnSongList2IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void OnSongList3IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void OnSongList4IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void OnSongList5IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void OnSongList6IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void OnSongList7IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void OnSongList8IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void OnSongList9IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }


        public void ExpiringMessage()
        {
            long usedt, remt, secst, remst;
            DateTime unixEpoch = new DateTime(1970, 1, 1);
            DateTime localDate = DateTime.Now;
            long nowMilSecond = (localDate.Ticks - unixEpoch.Ticks) / 10000;

            usedt = nowMilSecond - appsettings.InstalledonSetting;
            remt = appsettings.ExpiresonSetting - nowMilSecond;
            secst = (int)(usedt / 1000);
            remst = (int)(remt / 1000);

            if (secst < 440000)
            {
                if (remst < 60)
                    MessageBox.Show("vSongBook is in its Evaluation(Trial) Mode. It will expire " + remst + " seconds from now. Please click on the Settings icon and go APPLICATION MODE to learn how to Upgrade to Premium Mode! It will cost you Kshs. 300 to do that.", "God bless you!", MessageBoxButton.OK);

                else if (remst < 3600)
                    MessageBox.Show("vSongBook is in its Evaluation(Trial) Mode. It will expire " + remst / 60 + " minutes from now. Please click on the Settings icon and go APPLICATION MODE to learn how to Upgrade to Premium Mode! It will cost you Kshs. 300 to do that.", "God bless you!", MessageBoxButton.OK);

                else if (remst < 86400)
                    MessageBox.Show("vSongBook is in its Evaluation(Trial) Mode. It will expire " + remst / 3600 + " hours from now. Please click on the Settings icon and go APPLICATION MODE to learn how to Upgrade to Premium Mode! It will cost you Kshs. 300 to do that.", "God bless you!", MessageBoxButton.OK);

                else if (remst < 440000)
                    MessageBox.Show("vSongBook is in its Evaluation(Trial) Mode. It will expire " + remst / 86400 + " days from now. Please click on the Settings icon and go APPLICATION MODE to learn how to Upgrade to Premium Mode! It will cost you Kshs. 300 to do that.", "God bless you!", MessageBoxButton.OK);

            }
            else if (secst > 440000)
            {
                MessageBox.Show("vSongBook's Evaluation(Trial) Mode has already expired. Please click on the Settings icon and go APPLICATION MODE to learn how to Upgrade to Premium Mode! It will cost you Kshs. 300 to do that.", "God bless you!", MessageBoxButton.OK);

            }
        }
        
    }
}