using System;
using System.ComponentModel;

namespace vSongBook.RealData
{
    public class SongObject : INotifyPropertyChanged
    {
        private bool _unselected;

        public string Title { get; set; }

        public string Content { get; set; }

        public string ID { get; set; }


        public bool Unselected
        {
            get { return _unselected; }
            set
            {
                _unselected = value;
                NotifyPropertyChanged("Unselected");
            }
        }

        public SongObject(string title, string content, string id)
        {
            Title = title;
            Content = content;
            ID = id;
        }

        public SongObject(string title, string content, string id, bool unselected)
        {
            Title = title;
            Content = content;
            ID = id;
            Unselected = unselected;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
