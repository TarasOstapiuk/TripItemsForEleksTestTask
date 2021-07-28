using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void CreateTrip(string name, int[] itemsId)
        {
            /*contextDB.ItemsToTrips.FromSqlRaw(" ").ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            
            dt.Rows.Add(1, 'John');
            dt.Rows.Add(2, 'Mark');
            dt.Rows.Add(3, 'Stacy');*/
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
            return contextDB.Trips.;

            

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
