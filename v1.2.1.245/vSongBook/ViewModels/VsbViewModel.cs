using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace VsbDatabase
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
            var VsbFavoursInDB = from VsbFavour mysonglist in VsbDB.VsbFavourItem.OrderByDescending(v => v.SongId) select mysonglist;
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
            var VsbMysongsInDB = from VsbMysong mysonglist in VsbDB.VsbMysongItem.OrderByDescending(v => v.SongId) select mysonglist;
            VsbMysongItems = new ObservableCollection<VsbMysong>(VsbMysongsInDB);
        }

        public void AddVsbMysong(VsbMysong VsbToAdd)
        {
            VsbDB.VsbMysongItem.InsertOnSubmit(VsbToAdd);
            VsbDB.SubmitChanges();
        }

        public void EditVsbMysong(int VsbId, string VsbTitle, string VsbContent)
        {
            var VsbMysongsInDB = from VsbMysong mysonglist in VsbDB.VsbMysongItem where mysonglist.SongId.Equals(VsbId) select mysonglist;
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
    }
}
