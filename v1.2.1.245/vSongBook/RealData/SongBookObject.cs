using System;
using System.ComponentModel;

namespace vSongBook.RealData
{
    public class SongBookObject : INotifyPropertyChanged
    {
        private bool _unselected;

        public string Name { get; set; }

        public string Code { get; set; }

        public string Number { get; set; }


        public bool Unselected
        {
            get { return _unselected; }
            set
            {
                _unselected = value;
                NotifyPropertyChanged("Unselected");
            }
        }

        public SongBookObject(string name, string code, string number)
        {
            Name = name;
            Code = code;
            Number = number;
        }

        public SongBookObject(string name, string code, string number, bool unselected)
        {
            Name = name;
            Code = code;
            Number = number;
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
