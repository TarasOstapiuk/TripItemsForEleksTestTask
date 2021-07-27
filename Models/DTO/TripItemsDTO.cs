using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripItemsForEleks.Models.DTO
{
    
    public class TripItemsDTO
    {
        public string TripName { get; set; }
        public int[] ItemsListToTrip { get; set; }
        public TripItemsDTO()
        {}
    }
}
