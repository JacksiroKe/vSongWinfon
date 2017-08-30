using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace VsbDatabase.ViewModels
{

    public class VsbDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public VsbDataContext(string connectionString)
            : base(connectionString)
        { }

        public Table<VsbFavour> VsbFavourItem;
        public Table<VsbMysong> VsbMysongItem;
        public Table<VsbSongbook> VsbSongBookItem;

    }


    [Table]
    public class VsbFavour : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _songID;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int SongID
        {
            get { return _songID; }
            set
            {
                if (_songID != value)
                {
                    NotifyPropertyChanging("SongID");
                    _songID = value;
                    NotifyPropertyChanged("SongID");
                }
            }
        }

        private string _songTitle;

        [Column]
        public string SongTitle
        {
            get { return _songTitle; }
            set
            {
                if (_songTitle != value)
                {
                    NotifyPropertyChanging("SongTitle");
                    _songTitle = value;
                    NotifyPropertyChanged("SongTitle");
                }
            }
        }

        private string _songContent;

        [Column]
        public string SongContent
        {
            get { return _songContent; }
            set
            {
                if (_songContent != value)
                {
                    NotifyPropertyChanging("SongContent");
                    _songContent = value;
                    NotifyPropertyChanged("SongContent");
                }
            }
        }

        private string _otherDetails;

        [Column]

        public string OtherDetails
        {
            get { return _otherDetails; }
            set
            {
                if (_otherDetails != value)
                {
                    NotifyPropertyChanging("OtherDetails");
                    _otherDetails = value;
                    NotifyPropertyChanged("OtherDetails");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyDate)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyDate));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyDate)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyDate));
            }
        }

        #endregion
    }

    [Table]
    public class VsbMysong : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _songID;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int SongID
        {
            get { return _songID; }
            set
            {
                if (_songID != value)
                {
                    NotifyPropertyChanging("SongID");
                    _songID = value;
                    NotifyPropertyChanged("SongID");
                }
            }
        }

        private string _songTitle;

        [Column]
        public string SongTitle
        {
            get { return _songTitle; }
            set
            {
                if (_songTitle != value)
                {
                    NotifyPropertyChanging("SongTitle");
                    _songTitle = value;
                    NotifyPropertyChanged("SongTitle");
                }
            }
        }

        private string _songContent;

        [Column]
        public string SongContent
        {
            get { return _songContent; }
            set
            {
                if (_songContent != value)
                {
                    NotifyPropertyChanging("SongContent");
                    _songContent = value;
                    NotifyPropertyChanged("SongContent");
                }
            }
        }

        private string _otherDetails;

        [Column]

        public string OtherDetails
        {
            get { return _otherDetails; }
            set
            {
                if (_otherDetails != value)
                {
                    NotifyPropertyChanging("OtherDetails");
                    _otherDetails = value;
                    NotifyPropertyChanged("OtherDetails");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyDate)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyDate));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyDate)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyDate));
            }
        }

        #endregion
    }

    [Table]
    public class VsbSongbook : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _songID;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int SongID
        {
            get { return _songID; }
            set
            {
                if (_songID != value)
                {
                    NotifyPropertyChanging("SongID");
                    _songID = value;
                    NotifyPropertyChanged("SongID");
                }
            }
        }

        private string _songTitle;

        [Column]
        public string SongTitle
        {
            get { return _songTitle; }
            set
            {
                if (_songTitle != value)
                {
                    NotifyPropertyChanging("SongTitle");
                    _songTitle = value;
                    NotifyPropertyChanged("SongTitle");
                }
            }
        }

        private string _songContent;

        [Column]
        public string SongContent
        {
            get { return _songContent; }
            set
            {
                if (_songContent != value)
                {
                    NotifyPropertyChanging("SongContent");
                    _songContent = value;
                    NotifyPropertyChanged("SongContent");
                }
            }
        }

        private string _songIcon;

        [Column]

        public string SongIcon
        {
            get { return _songIcon; }
            set
            {
                if (_songIcon != value)
                {
                    NotifyPropertyChanging("SongIcon");
                    _songIcon = value;
                    NotifyPropertyChanged("SongIcon");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyDate)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyDate));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyDate)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyDate));
            }
        }

        #endregion
    }

}
