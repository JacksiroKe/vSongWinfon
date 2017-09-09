using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vSongBook
{
    public class AppDatabase : DataContext
    {
        public static string DBConnectionString = @"isostore:/vSongBook_One.sdf";
        public AppDatabase(string connectionString)
            : base(connectionString)
        { }

        public Table<vsb_songbook> SongBooks
        {
            get
            {
                return this.GetTable<vsb_songbook>();
            }
        }

        public Table<vsb_ownsong> OwnSongs
        {
            get
            {
                return this.GetTable<vsb_ownsong>();
            }
        }

        public Table<vsb_search> Searches
        {
            get
            {
                return this.GetTable<vsb_search>();
            }
        }

        public Table<vsb_favourite> Favourites
        {
            get
            {
                return this.GetTable<vsb_favourite>();
            }
        }

        public Table<vsb_copy> Copies
        {
            get
            {
                return this.GetTable<vsb_copy>();
            }
        }



    }

    [Table]
    public class vsb_songbook : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }
        
        private string _icon;

        [Column]
        public string Icon
        {
            get { return _icon; }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                    NotifyPropertyChanged("Icon");
                }
            }
        }

        private string _title;

        [Column]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _content;

        [Column]
        public string Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    NotifyPropertyChanged("Content");
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
    public class vsb_ownsong : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _title;

        [Column]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _content;

        [Column]
        public string Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    NotifyPropertyChanged("Content");
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
    public class vsb_search : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _stext;

        [Column]
        public string Stext
        {
            get { return _stext; }
            set
            {
                if (_stext != value)
                {
                    _stext = value;
                    NotifyPropertyChanged("Stext");
                }
            }
        }

        private string _stime;

        [Column]
        public string Stime
        {
            get { return _stime; }
            set
            {
                if (_stime != value)
                {
                    _stime = value;
                    NotifyPropertyChanged("Stime");
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
    public class vsb_favourite : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        private string _title;

        [Column]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _content;

        [Column]
        public string Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    NotifyPropertyChanged("Content");
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
    public class vsb_copy : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _id;
        
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get 
            { 
                return _id; 
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }
        
        private string _ctext;

        [Column]
        public string Ctext
        {
            get { return _ctext; }
            set
            {
                if (_ctext != value)
                {
                    _ctext = value;
                    NotifyPropertyChanged("Ctext");
                }
            }
        }

        private string _ctime;

        [Column]
        public string Ctime
        {
            get { return _ctime; }
            set
            {
                if (_ctime != value)
                {
                    _ctime = value;
                    NotifyPropertyChanged("Ctime");
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

    public class SongBook
    {
        public int ID { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class MyOwnSong
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class Favorited
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class SongBookAdd
    {
        public void AddSongBook(String title, String content, String icon)
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                vsb_songbook newsong = new vsb_songbook();
                newsong.Icon = icon;
                newsong.Title = title;
                newsong.Content = content;
                context.SongBooks.InsertOnSubmit(newsong);
                context.SubmitChanges();
            }
        }
    }

    public class OwnSongAdd
    {
        public void AddOwnSong(String title, String content)
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                vsb_ownsong ownsong = new vsb_ownsong();
                ownsong.Title = title;
                ownsong.Content = content;
                context.OwnSongs.InsertOnSubmit(ownsong);
                context.SubmitChanges();
            }
        }
    }

    public class Favouriting
    {
        public void FavoriteThis(String title, String content)
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                vsb_favourite favour = new vsb_favourite();
                favour.Title = title;
                favour.Content = content;
                context.Favourites.InsertOnSubmit(favour);
                context.SubmitChanges();
            }
        }
    }

    public class ViewSongBook
    {
        public void ViewSong(String id)
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_songbook> entityQuery = from slist in context.SongBooks 
                        where slist.ID.Equals(id) select slist;
                vsb_songbook songview = entityQuery.FirstOrDefault();
                context.SongBooks.DeleteOnSubmit(songview);
                context.SubmitChanges();
            }
        }
    }

    public class FetchSongBook
    {
        public IList<vsb_songbook> GetAllSongs(String sarch)
        {
            IList<vsb_songbook> list = null;
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_songbook> query = from plist in context.SongBooks
                      where (plist.Content.Contains(sarch)) select plist;
                list = query.ToList();
            }
            return list;
        }
        public List<SongBook> getSongBook(String sarch)
        {
            IList<vsb_songbook> songlist = this.GetAllSongs(sarch);
            List<SongBook> finallist = new List<SongBook>();
            foreach (vsb_songbook final_a in songlist)
            {
                SongBook final_b = new SongBook();
                final_b.ID = final_a.ID;
                final_b.Icon = final_a.Icon;
                final_b.Title = final_a.Title;
                final_b.Content = final_a.Content;
                finallist.Add(final_b);
            }
            return finallist;
        }
    }

    public class MyFavourites
    {
        public IList<vsb_favourite> GetFavourites()
        {
            IList<vsb_favourite> list = null;
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_favourite> query = from plist in context.Favourites select plist;
                list = query.ToList();
            }
            return list;
        }
        public List<Favorited> getFavorites()
        {
            IList<vsb_favourite> songlist = this.GetFavourites();
            List<Favorited> finallist = new List<Favorited>();
            foreach (vsb_favourite final_a in songlist)
            {
                Favorited final_b = new Favorited();
                final_b.ID = final_a.ID;
                final_b.Title = final_a.Title;
                final_b.Content = final_a.Content;
                finallist.Add(final_b);
            }
            return finallist;
        }
    }

    public class MyOwnSongs
    {
        public IList<vsb_ownsong> GetOwnSongs()
        {
            IList<vsb_ownsong> list = null;
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_ownsong> query = from plist in context.OwnSongs select plist;
                list = query.ToList();
            }
            return list;
        }
        public List<MyOwnSong> getMyownSongs()
        {
            IList<vsb_ownsong> songlist = this.GetOwnSongs();
            List<MyOwnSong> finallist = new List<MyOwnSong>();
            foreach (vsb_ownsong final_a in songlist)
            {
                MyOwnSong final_b = new MyOwnSong();
                final_b.ID = final_a.ID;
                final_b.Title = final_a.Title;
                final_b.Content = final_a.Content;
                finallist.Add(final_b);
            }
            return finallist;
        }
    }

    public class FindSongBook
    {
        public IList<vsb_songbook> GetSingleOne(String sarch)
        {
            IList<vsb_songbook> list = null;
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_songbook> query = from plist in context.SongBooks
                 where plist.Content.Equals(sarch) select plist;
                list = query.ToList();
            }
            return list;
        }
        public List<SongBook> getJustOne(String sarch)
        {
            IList<vsb_songbook> songlist = this.GetSingleOne(sarch);
            List<SongBook> finallist = new List<SongBook>();
            foreach (vsb_songbook final_a in songlist)
            {
                SongBook final_b = new SongBook();
                final_b.ID = final_a.ID;
                final_b.Icon = final_a.Icon;
                final_b.Title = final_a.Title;
                final_b.Content = final_a.Content;
                finallist.Add(final_b);
            }
            return finallist;
        }
    }
    
    public class FavouritesDelete
    {
        public void DeleteAllFavourites()
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_favourite> entityQuery = from favs in context.Favourites select favs;
                IList<vsb_favourite> entityToDelete = entityQuery.ToList();
                context.Favourites.DeleteAllOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }
        public void DeleteFavourite(int id)
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_favourite> entityQuery = from fav in context.Favourites where fav.ID.Equals(id) select fav;
                vsb_favourite entityToDelete = entityQuery.FirstOrDefault();
                context.Favourites.DeleteOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }
    }


    public class OwnsongsDelete
    {
        public void DeleteAllOwnsongs()
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_ownsong> entityQuery = from owns in context.OwnSongs select owns;
                IList<vsb_ownsong> entityToDelete = entityQuery.ToList();
                context.OwnSongs.DeleteAllOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }
        public void DeleteOwnsong(int id)
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_ownsong> entityQuery = from own in context.OwnSongs where own.ID.Equals(id) select own;
                vsb_ownsong entityToDelete = entityQuery.FirstOrDefault();
                context.OwnSongs.DeleteOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }
    }

    public class OwnsongUpdate
    {
        public void UpdateOwnSong(int id, String title, string content)
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_ownsong> entityQuery = from own in context.OwnSongs where own.ID == id select own;
                vsb_ownsong entityToUpdate = entityQuery.FirstOrDefault();
                entityToUpdate.Title = title;
                entityToUpdate.Content = content;
                context.SubmitChanges();
            }
        }
        public void UpdateUserToLower()
        {
            using (AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString))
            {
                IQueryable<vsb_ownsong> entityQuery = from own in context.OwnSongs select own;
                IList<vsb_ownsong> entityToUpdate = entityQuery.ToList();
                foreach (vsb_ownsong song in entityToUpdate)
                {
                    song.Title = song.Title.ToLower();
                }
                context.SubmitChanges();
            }
        }
    }

}
