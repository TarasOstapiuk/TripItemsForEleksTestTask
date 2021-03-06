using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripItemsForEleks.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public virtual List<ItemsToTrip> ItemsToTrip { get; set; }
    }
}
