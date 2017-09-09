using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace vSongBook
{
    public class SettingsModel : INotifyPropertyChanged
    {
        private string _settTitle;
        /// <summary>
        /// Sample ViewSett1 property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string SettTitle
        {
            get
            {
                return _settTitle;
            }
            set
            {
                if (value != _settTitle)
                {
                    _settTitle = value;
                    NotifyPropertyChanged("SettTitle");
                }
            }
        }

        private string _settDescri;
        /// <summary>
        /// Sample ViewSett1 property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string SettDescri
        {
            get
            {
                return _settDescri;
            }
            set
            {
                if (value != _settDescri)
                {
                    _settDescri = value;
                    NotifyPropertyChanged("SettDescri");
                }
            }
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