using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace vSongBook.RealData
{
    public class SongBookCollection : ObservableCollection<SongBookObject>
    {
        public SongBookCollection()
            : base()
        {

            Add(new SongBookObject("Songs of Worship", "worship", "1", true));
            Add(new SongBookObject("Nyimbo za Injili", "injili", "2", true));
            Add(new SongBookObject("Believers Songs", "believers", "3", false));
            Add(new SongBookObject("Nyimbo za Wokovu", "wokovu", "4", false));
            Add(new SongBookObject("Tenzi za Rohoni", "tenzi", "5", false));
        }
    }

}
