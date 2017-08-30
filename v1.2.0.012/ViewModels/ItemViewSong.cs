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
    public class ItemViewSong : INotifyPropertyChanged
    {

        private int _songID;
        /// <summary>
        /// Sample ViewSong1 property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public int SongID
        {
            get
            {
                return _songID;
            }
            set
            {
                if (value != _songID)
                {
                    _songID = value;
                    NotifyPropertyChanged("SongID");
                }
            }
        }
        
        private string _songTitle;
        /// <summary>
        /// Sample ViewSong1 property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string SongTitle
        {
            get
            {
                return _songTitle;
            }
            set
            {
                if (value != _songTitle)
                {
                    _songTitle = value.Replace("^", "'").Replace('+', '"');
                    NotifyPropertyChanged("SongTitle");
                }
            }
        }

        private string _songContent;
        /// <summary>
        /// Sample ViewSong1 property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string SongContent
        {
            get
            {
                return _songContent;
            }
            set
            {
                if (value != _songContent)
                {
                    _songContent = value.Replace("^", "'").Replace('+', '"');
                    NotifyPropertyChanged("SongContent");
                }
            }
        }

        private string _songIcon;
        /// <summary>
        /// Sample ViewSong1 property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string SongIcon
        {
            get
            {
                return _songIcon;
            }
            set
            {
                if (value != _songIcon)
                {
                    _songIcon = value.Replace("^", "'").Replace('+', '"');
                    NotifyPropertyChanged("SongContent");
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
