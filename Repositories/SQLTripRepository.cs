using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripItemsForEleks.Models
{
    public class SQLTripRepository : ITripRepository
    {
        private readonly AppDBContext contextDB;

        public SQLTripRepository(AppDBContext context)
        {
            contextDB = context;
        }

        public Trip AddTrip(Trip trip)
        {
            contextDB.Trips.Add(trip);
            contextDB.SaveChanges();
            return trip;
        }

        public Trip Delete(int id)
        {
            Trip tripToDelete = contextDB.Trips.Find(id);
            if (tripToDelete !=null)
            {
                contextDB.Trips.Remove(tripToDelete);
                contextDB.SaveChanges();
            }
            return tripToDelete;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return contextDB.Trips;
        }

        public Trip GetTrip(int id)
        {
            return contextDB.Trips.Find(id);
        }

        public Trip Update(Trip tripChanges)
        {
            var trip = contextDB.Trips.Attach(tripChanges);
            trip.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contextDB.SaveChanges();
            return tripChanges;
        }
    }
}
