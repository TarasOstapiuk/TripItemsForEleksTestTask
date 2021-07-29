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
            Trip trip = new Trip { TripName = name };
            var newtrips = contextDB.Trips.Add(trip);
            contextDB.SaveChanges();
            var newList = new List<ItemsToTrip>();
            foreach (var item in itemsId)
            {
                newList.Add(new ItemsToTrip { TripId = trip.Id,  ItemId = item }) ;
            }
            contextDB.ItemsToTrips.AddRange(newList);
            contextDB.SaveChanges();
            //{
            //    contextDB.ItemsToTrips.FromSqlRaw("insert into ItemsToTrips values (2, 7),(1, 5),(1, 4),(3, 2),(3, 3)");
            //    contextDB.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    throw new Exception();
            //}
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID");
            
            //dt.Rows.Add(1, 'John');
            //dt.Rows.Add(2, 'Mark');
            //dt.Rows.Add(3, 'Stacy');*/
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
            var trips = contextDB.Trips.ToList();
            return trips;

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
