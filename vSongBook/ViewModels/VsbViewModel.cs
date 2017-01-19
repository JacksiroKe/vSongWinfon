using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace VsbDatabase.ViewModels
{
    public class VsbViewModel : INotifyPropertyChanged
    {
        private VsbDataContext VsbDB;
        public VsbViewModel(string VsbDBConnectionString) { VsbDB = new VsbDataContext(VsbDBConnectionString); }
        public void SaveChangesToDB() { VsbDB.SubmitChanges(); }

        private ObservableCollection<VsbFavour> _vsbFavourItems;
        public ObservableCollection<VsbFavour> VsbFavourItems
        { get { return _vsbFavourItems; } set { _vsbFavourItems = value; NotifyPropertyChanged("VsbFavourItems"); } }

        public void ListFavoursFromDatabase()
        {
            var VsbFavoursInDB = from VsbFavour mysonglist in VsbDB.VsbFavourItem.OrderByDescending(v => v.SongID) select mysonglist;
            VsbFavourItems = new ObservableCollection<VsbFavour>(VsbFavoursInDB);
        }

        public void AddVsbFavour(VsbFavour VsbToAdd)
        {
            VsbDB.VsbFavourItem.InsertOnSubmit(VsbToAdd);
            VsbDB.SubmitChanges();
        }

        public void DeleteVsbFavour(VsbFavour VsbForDelete)
        {
            VsbFavourItems.Remove(VsbForDelete);
            VsbDB.VsbFavourItem.DeleteOnSubmit(VsbForDelete);
            VsbFavourItems.Remove(VsbForDelete);
            VsbDB.SubmitChanges();
        }
        
        private ObservableCollection<VsbMysong> _vsbMysongItems;
        public ObservableCollection<VsbMysong> VsbMysongItems
        { get { return _vsbMysongItems; } set { _vsbMysongItems = value; NotifyPropertyChanged("VsbMysongItems"); } }

        public void ListMysongsFromDatabase()
        {
            var VsbMysongsInDB = from VsbMysong mysonglist in VsbDB.VsbMysongItem.OrderByDescending(v => v.SongID) select mysonglist;
            VsbMysongItems = new ObservableCollection<VsbMysong>(VsbMysongsInDB);
        }

        public void AddVsbMysong(VsbMysong VsbToAdd)
        {
            VsbDB.VsbMysongItem.InsertOnSubmit(VsbToAdd);
            VsbDB.SubmitChanges();
        }

        public void EditVsbMysong(int VsbId, string VsbTitle, string VsbContent)
        {
            var VsbMysongsInDB = from VsbMysong mysonglist in VsbDB.VsbMysongItem where mysonglist.SongID.Equals(VsbId) select mysonglist;
            foreach (VsbMysong mysonglist in VsbMysongsInDB)
            {
                mysonglist.SongTitle = VsbTitle;
                mysonglist.SongContent = VsbContent;
            }

            VsbDB.SubmitChanges();
        }

        public void DeleteVsbMysong(VsbMysong VsbForDelete)
        {
            VsbMysongItems.Remove(VsbForDelete);
            VsbDB.VsbMysongItem.DeleteOnSubmit(VsbForDelete);
            VsbMysongItems.Remove(VsbForDelete);
            VsbDB.SubmitChanges();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private ObservableCollection<VsbSongbook> _vsbSongBookItems;
        public ObservableCollection<VsbSongbook> VsbSongBookItems
        { get { return _vsbSongBookItems; } set { _vsbSongBookItems = value; NotifyPropertyChanged("VsbSongBookItems"); } }

        public void ListSongsFromDatabase()
        {
            var VsbSongbooksInDB = from VsbSongbook Songbooklist in VsbDB.VsbSongBookItem.OrderBy(v => v.SongID) select Songbooklist;
            VsbSongBookItems = new ObservableCollection<VsbSongbook>(VsbSongbooksInDB);
        }

        public void AddVsbSongbook(VsbSongbook VsbToAdd)
        {
            VsbDB.VsbSongBookItem.InsertOnSubmit(VsbToAdd);
            VsbDB.SubmitChanges();
        }

        public void EditVsbSongbook(int VsbId, string VsbTitle, string VsbContent, string VsbIcon)
        {
            var VsbSongbooksInDB = from VsbSongbook Songbooklist in VsbDB.VsbSongBookItem where Songbooklist.SongID.Equals(VsbId) select Songbooklist;
            foreach (VsbSongbook Songbooklist in VsbSongbooksInDB)
            {
                Songbooklist.SongTitle = VsbTitle;
                Songbooklist.SongContent = VsbContent;
                Songbooklist.SongIcon = VsbIcon;
            }

            VsbDB.SubmitChanges();
        }

        public void DeleteVsbSongbook(VsbSongbook VsbForDelete)
        {
            VsbSongBookItems.Remove(VsbForDelete);
            VsbDB.VsbSongBookItem.DeleteOnSubmit(VsbForDelete);
            VsbSongBookItems.Remove(VsbForDelete);
            VsbDB.SubmitChanges();
        }

        public void SearchSongsFromDatabase(string find_text)
        {
            //var VsbSongbooksInDB = from VsbSongbook Songbooklist in VsbDB.VsbSongBookItem.OrderByDescending(v => v.SongID) select Songbooklist;
            //VsbSongBookItems = new ObservableCollection<VsbSongbook>(VsbSongbooksInDB);

            var VsbSongbooksInDB = from VsbSongbook songlist in VsbDB.VsbSongBookItem
                                   where songlist.SongTitle.Contains(find_text) || songlist.SongContent.Contains(find_text)
                                   select songlist;
            VsbSongBookItems = new ObservableCollection<VsbSongbook>(VsbSongbooksInDB);
        }

    }
}
