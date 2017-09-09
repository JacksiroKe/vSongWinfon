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
    public class SongCollection : ObservableCollection<SongObject>
    {
        public SongCollection()
            : base()
        {
            
            Add(new SongObject("1# Only Believe", "Fear not little flock, $ From the cross to the throne, $ From death into life He went for His own; $ All power in earth, all power above, $ Is given to Him for the flock of His love.", "1", true));
            Add(new SongObject("2# Amazing Grace", "Amazing grace! How Sweet the sound, $ That saved a wretch like me! $ I once was lost, but now am found, $ Was blind, but now I see. ` +Twas grace that taught my heart to fear, $ And grace my fears relieved; $ How precious did that grace appear $ The hour I first believed!", "2", true));
            Add(new SongObject("3# They Come", "They come from the east and west, $ They comes from the lands afar, $ To feast with the King, to dine as His guest; $ How blessed these pilgrims are! $ Beholding His hallowed face $ Aglow with light divine; $ Blest partakers of His grace, $ As germs in His crown to shine.", "3", false));
            Add(new SongObject("4# I Love Him", "Gone from my heart the world and all its charms; $ Now, through the blood, I'm saved from all alarms; $ Down at the cross my heart is bending low; $ The precious blood of Jesus cleanses white as snow.", "4", false));
            Add(new SongObject("6# Oh, How I Love Jesus", "There is a name I love to hear, $ I love to sing its worth; $ It sounds like music in mine ear, $ The sweetest name on earth. ` CHORUS $ Oh, how I love Jesus, $ Oh, how I love Jesus, $ Oh, how I love Jesus, $ Because He first loved me. ` It tells me of a Saviour's love, $ Who died to set me free; $ It tells me of His precious blood; $ The sinner's perfect plea.", "6", false));
            Add(new SongObject("7# When The Redeemed Gather", "I am thinking of the rapture in our blessed home on high, $ When the redeemed are gathering in; $ How we'll raise the heavenly anthem in that city in the sky $ When the redeemed are gathering in. ` CHORUS $ When the redeemed are gathering in $ Washed like snow, and free from all sin; $ How we shout, and how we will sing, $ When the redeemed are gathering in. ", "7", false));
            Add(new SongObject("8# Oh, I Want To See Him", "As I journey through the land, singing as I go, $ Pointing souls to Calvary, to the crimson flow, $ Many arrows pierce my soul from without, within; $ But my Lord leads me on, through Him I must win. ", "8", false));
            Add(new SongObject("9# Feeling So Much Better", "Feeling so much better talking about this good old way, $ Feeling so much better talking about the Lord; $ Let's go on, let's go on talking about this good old way $ Let's go on, let's go on talking about the Lord.", "9", false));
            Add(new SongObject("10# Teach Me Lord, To Wait", "Teach me, Lord, to wait down on my knees, $ Till in Your own good time You answer my pleas; $ Teach me not to rely on what others do, $ But to wait in prayer for an answer from You.", "10", false));

        }
    }

    public class SongCollection1 : ObservableCollection<SongObject>
    {
        public SongCollection1()
            : base()
        {
            AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString);
            var query = from songlist in context.SongBooks where songlist.Content.Contains("Songs of Worship") select songlist;
            foreach (vsb_songbook song in query)
            {
                Add(new SongObject(song.Title, song.Content, song.ID.ToString(), false));
            }
        }

    }

    public class SongCollection2 : ObservableCollection<SongObject>
    {
        public SongCollection2()
            : base()
        {
            AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString);
            var query = from songlist in context.SongBooks where songlist.Content.Contains("Nyimbo za Injili") select songlist;
            foreach (vsb_songbook song in query)
            {
                Add(new SongObject(song.Title, song.Content, song.ID.ToString(), false));
            }
        }

    }

    public class SongCollection3 : ObservableCollection<SongObject>
    {
        public SongCollection3()
            : base()
        {
            AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString);
            var query = from songlist in context.SongBooks where songlist.Content.Contains("Believers Songs") select songlist;
            foreach (vsb_songbook song in query)
            {
                Add(new SongObject(song.Title, song.Content, song.ID.ToString(), false));
            }
        }

    }

    public class SongCollection4 : ObservableCollection<SongObject>
    {
        public SongCollection4()
            : base()
        {
            AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString);
            var query = from songlist in context.SongBooks where songlist.Content.Contains("Nyimbo za Wokovu") select songlist;
            foreach (vsb_songbook song in query)
            {
                Add(new SongObject(song.Title, song.Content, song.ID.ToString(), false));
            }
        }

    }

    public class SongCollection5 : ObservableCollection<SongObject>
    {
        public SongCollection5()
            : base()
        {
            AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString);
            var query = from songlist in context.SongBooks where songlist.Content.Contains("Redemption Songs") select songlist;
            foreach (vsb_songbook song in query)
            {
                Add(new SongObject(song.Title, song.Content, song.ID.ToString(), false));
            }
        }

    }

    public class SongCollection6 : ObservableCollection<SongObject>
    {
        public SongCollection6()
            : base()
        {
            AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString);
            var query = from songlist in context.SongBooks where songlist.Content.Contains("Tenzi za Rohoni") select songlist;
            foreach (vsb_songbook song in query)
            {
                Add(new SongObject(song.Title, song.Content, song.ID.ToString(), false));
            }
        }

    }

    public class SongCollection7 : ObservableCollection<SongObject>
    {
        public SongCollection7()
            : base()
        {
            AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString);
            var query = from songlist in context.SongBooks where songlist.Content.Contains("Kuinira Ngai") select songlist;
            foreach (vsb_songbook song in query)
            {
                Add(new SongObject(song.Title, song.Content, song.ID.ToString(), false));
            }
        }

    }

    public class SongCollection8 : ObservableCollection<SongObject>
    {
        public SongCollection8()
            : base()
        {
            AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString);
            var query = from songlist in context.SongBooks where songlist.Content.Contains("Kumutaiia Ngai") select songlist;
            foreach (vsb_songbook song in query)
            {
                Add(new SongObject(song.Title, song.Content, song.ID.ToString(), false));
            }
        }

    }

    public class SongCollection9 : ObservableCollection<SongObject>
    {
        public SongCollection9()
            : base()
        {
            AppDatabase context = new AppDatabase(AppDatabase.DBConnectionString);
            var query = from songlist in context.SongBooks where songlist.Content.Contains("Kilosune Jehovah") select songlist;
            foreach (vsb_songbook song in query)
            {
                Add(new SongObject(song.Title, song.Content, song.ID.ToString(), false));
            }
        }

    }

}
