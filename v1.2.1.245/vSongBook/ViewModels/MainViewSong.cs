using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace vSongBook
{
    public class MainViewSong : INotifyPropertyChanged
    {
        public MainViewSong()
        {
            this.SongList = new ObservableCollection<ItemViewSong>();
        }

        /// <summary>
        /// A collection for SettingsModel objects.
        /// </summary>
        public ObservableCollection<ItemViewSong> SongList { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewSong1 property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;private set;
        }

        public void LoadData()
        {
            FetchSongBook fetch = new FetchSongBook();
            //ListBox1.ItemsSource = fetch.GetAllSongs("Songs of Worship");
            //this.Songs.Add(fetch.GetAllSongs("Songs of Worship"));
            //this.Items.Add(new SettingsModel() { SettTitle = "Application Version", SettDescri = "1.1.8.593" });
			
			this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}