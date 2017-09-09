using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace vSongBook.RealData
{
    public class MultilineItemCollection
    {
        public MultilineItemCollection()
        {
            this.Items = new ObservableCollection<MultilineItem>();
        }

        /// <summary>
        /// A collection for MultilineItem objects.
        /// </summary>
        public ObservableCollection<MultilineItem> Items { get; private set; }
    }
}
