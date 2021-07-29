using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripItemsForEleks.Models
{
    public class ItemsToTrip
    {
        public int Id { get; set; }

        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }

        public int  ItemId { get; set; }
        public virtual Item Item { get; set; }

    }
}
