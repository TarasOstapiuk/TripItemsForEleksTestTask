using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripItemsForEleks.Models
{
    public interface ITripRepository
    {
        Trip GetTrip(int id);
        IEnumerable<Trip> GetAllTrips();
        Trip AddTrip(Trip trip);
        Trip Update(Trip tripChanges);
        Trip Delete(int id);
        void CreateTrip(string name, int[] itemsId);
        void DeleteItemFromTrip(int id);
        void AddingItemToExistingTrip(int IdItem, int IdTrip);
    }
}
