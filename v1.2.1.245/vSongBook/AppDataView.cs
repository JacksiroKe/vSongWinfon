using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace vSongBook
{
    public class AppDataView : INotifyPropertyChanged
    {
        private AppDatabase vSongBookDb;
        public AppDataView(string DBConnectionString) 
        {
            vSongBookDb = new AppDatabase(AppDatabase.DBConnectionString); 
        }

        private ObservableCollection<vsb_songbook> _songList;
        public ObservableCollection<vsb_songbook> SongList
        { 
            get 
            { 
                return _songList; 
            } 
            set 
            { 
                _songList = value;
                NotifyPropertyChanged("SongList"); 
            } 
        }

        public void ListTheSongBook()
        {
            var songsfromdb = from vsb_songbook mysonglist in 
                 vSongBookDb.SongBooks.OrderBy(v => v.ID) select mysonglist;
            SongList = new ObservableCollection<vsb_songbook>(songsfromdb);
        }

        private ObservableCollection<vsb_favourite> _favourites;
        public ObservableCollection<vsb_favourite> Favourites
        {
            get
            {
                return _favourites;
            }
            set
            {
                _favourites = value;
                NotifyPropertyChanged("Favourites");
            }
        }

        public void ListMyFavourites()
        {
            var songsfromdb = from vsb_favourite mysonglist in
                vSongBookDb.Favourites.OrderByDescending(v => v.ID) select mysonglist;
            Favourites = new ObservableCollection<vsb_favourite>(songsfromdb);
        }

        private ObservableCollection<vsb_ownsong> _myOwnSongs;
        public ObservableCollection<vsb_ownsong> MyOwnSongs
        {
            get
            {
                return _myOwnSongs;
            }
            set
            {
                _myOwnSongs = value;
                NotifyPropertyChanged("MyOwnSongs");
            }
        }

        public void ListMyOwnSongs()
        {
            var songsfromdb = from vsb_ownsong mysonglist in
               vSongBookDb.OwnSongs.OrderByDescending(v => v.ID) select mysonglist;
            MyOwnSongs = new ObservableCollection<vsb_ownsong>(songsfromdb);
        }

        public void SaveChangesToDB() 
        {
            vSongBookDb.SubmitChanges(); 
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
