using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripItemsForEleks.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public string TripName { get; set; }

        public virtual List<ItemsToTrip> ItemsToTrip { get; set; } 
    }
}
