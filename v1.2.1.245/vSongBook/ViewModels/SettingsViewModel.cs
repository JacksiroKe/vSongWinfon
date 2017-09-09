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
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public SettingsViewModel()
        {
            this.Items = new ObservableCollection<SettingsModel>();
        }

        /// <summary>
        /// A collection for SettingsModel objects.
        /// </summary>
        public ObservableCollection<SettingsModel> Items { get; private set; }

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

        /// <summary>
        /// Creates and adds a few SettingsModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            this.Items.Add(new SettingsModel() { SettTitle = "Display Settings", SettDescri = "display, font-size" });
            this.Items.Add(new SettingsModel() { SettTitle = "Application Mode", SettDescri = "the mode of this app" });
            this.Items.Add(new SettingsModel() { SettTitle = "Call/SMS/Whatsapp", SettDescri = "+254711474787 / 731973180" });
            this.Items.Add(new SettingsModel() { SettTitle = "Email Address", SettDescri = "smataweb@gmail.com" });
            this.Items.Add(new SettingsModel() { SettTitle = "Follow on Facebook", SettDescri = "Jack Siro fb.me/jaksiro" });
            this.Items.Add(new SettingsModel() { SettTitle = "Follow on Twitter", SettDescri = "Jack Siro @jaksiro" });
            this.Items.Add(new SettingsModel() { SettTitle = "Follow on Instagram", SettDescri = "Jack Siro @jaksiro" });
            this.Items.Add(new SettingsModel() { SettTitle = "Application Version", SettDescri = "1.1.8.593" });
			
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