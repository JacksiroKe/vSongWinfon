using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using vSongBook.RealData;

namespace vSongBook
{
    /// <summary>
    /// Sample code for LongListMultiSelector
    /// </summary>
    public partial class CcSongBook : PhoneApplicationPage
    {
        class PivotCallbacks
        {
            public Action Init { get; set; }
            public Action OnActivated { get; set; }
            public Action<CancelEventArgs> OnBackKeyPress { get; set; }
        }

        Dictionary<object, PivotCallbacks> _callbacks;

        /// <summary>
        /// Initializes the dictionary of delegates to call when each pivot is selected
        /// </summary>
        public CcSongBook()
        {
            InitializeComponent();

            this.Loaded += CcSongBook_Loaded;


            _callbacks = new Dictionary<object, PivotCallbacks>();
            _callbacks[MultiselectLbxItem] = new PivotCallbacks
            {
                Init = CreateEmailApplicationBarItems,
                OnActivated = OnEmailPivotItemActivated,
                OnBackKeyPress = OnEmailBackKeyPressed
            };
            
            foreach (var callbacks in _callbacks.Values)
            {
                if (callbacks.Init != null)
                {
                    callbacks.Init();
                }
            }
        }

        void CcSongBook_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("multiselect"))
            {
                MessageBox.Show(
    @"The MultiSelectList has been deprecated in Windows Phone 8 in favor of LongListMultiSelector which is built on top of the more performant LongListSelector.
This sample and the sample code demonstrates how to use the new LongListMultiSelector control.");
            }
        }

        /// <summary>
        /// Setup the application bar buttons according to the active Pivot Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPivotSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PivotCallbacks callbacks;
            if (_callbacks.TryGetValue(SamplePivot.SelectedItem, out callbacks) && (callbacks.OnActivated != null))
            {
                callbacks.OnActivated();
            }
        }

        /// <summary>
        /// Defers back treatment to active pivot function
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            /*
            if (CurrentPicture != null)
            {
                CurrentPicture = null;
                e.Cancel = true;
            }
            else
            {
                PivotCallbacks callbacks;
                if (_callbacks.TryGetValue(SamplePivot.SelectedItem, out callbacks) && (callbacks.OnBackKeyPress != null))
                {
                    callbacks.OnBackKeyPress(e);
                }
            }*/
        }

        /// <summary>
        /// Resets the application bar
        /// </summary>
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
        private void CreateEmailApplicationBarItems()
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

        /// <summary>
        /// Called when Email pivot item is activated : makes sure that selection is disabled and updates the application bar
        /// </summary>
        void OnEmailPivotItemActivated()
        {
            if (EmailList.IsSelectionEnabled)
            {
                EmailList.IsSelectionEnabled = false; // Will update the application bar too
            }
            else
            {
                SetupEmailApplicationBar();
            }
        }

        /// <summary>
        /// Configure ApplicationBar items for email list
        /// </summary>
        private void SetupEmailApplicationBar()
        {
            ClearApplicationBar();
            
            if (EmailList.IsSelectionEnabled)
            {
                ApplicationBar.Buttons.Add(favourite);
                UpdateEmailApplicationBar();
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
        private void UpdateEmailApplicationBar()
        {
            if (EmailList.IsSelectionEnabled)
            {
                bool hasSelection = ((EmailList.SelectedItems != null) && (EmailList.SelectedItems.Count > 0));
                favourite.IsEnabled = hasSelection;
                //markAsRead.IsEnabled = hasSelection;
                //markAsUnread.IsEnabled = hasSelection;
            }
        }

        /// <summary>
        /// Back Key Pressed = leaves the selection mode
        /// </summary>
        /// <param name="e"></param>
        protected void OnEmailBackKeyPressed(CancelEventArgs e)
        {
            if (EmailList.IsSelectionEnabled)
            {
                EmailList.IsSelectionEnabled = false;
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
            EmailList.IsSelectionEnabled = true;
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
            IList source = EmailList.ItemsSource as IList;
            while (EmailList.SelectedItems.Count > 0)
            {
                source.Remove((EmailObject)EmailList.SelectedItems[0]);
            }
        }

        /// <summary>
        /// Mark all items as read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMarkAsReadClick(object sender, EventArgs e)
        {
            foreach (EmailObject obj in EmailList.SelectedItems)
            {
                obj.Unread = false;
            }

            EmailList.IsSelectionEnabled = false;
        }

        /// <summary>
        /// Mark all items as unread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMarkAsUnreadClick(object sender, EventArgs e)
        {
            foreach (EmailObject obj in EmailList.SelectedItems)
            {
                obj.Unread = true;
            }

            EmailList.IsSelectionEnabled = false;
        }

        /// <summary>
        /// Adjusts the user interface according to the number of selected emails
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEmailListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEmailApplicationBar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEmailListIsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetupEmailApplicationBar();
        }



        /// <summary>
        /// Tap on an item : depending on the selection state, either unselect it or consider it as read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemContentTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailObject item = ((FrameworkElement)sender).DataContext as EmailObject;
            if (item != null)
            {
                item.Unread = false;
            }
        }

        #endregion

        
    }
}