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
            Trip currentTrip = contextDB.Trips.FirstOrDefault(i => i.Id == id);
            return currentTrip;
        }

        public Trip Update(Trip tripChanges)
        {
            var trip = contextDB.Trips.Attach(tripChanges);
            trip.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contextDB.SaveChanges();
            return tripChanges;
        }
        public void DeleteItemFromTrip(int id)
        {
            Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@IDRow", id);
            contextDB.Database.ExecuteSqlRaw("Exec DeleteItemFromTrip @IDRow", param);
        }

        public void AddingItemToExistingTrip(int IdTrip, int IdItem)
        {
            Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@IDTrip", IdTrip);
            Microsoft.Data.SqlClient.SqlParameter param1 = new Microsoft.Data.SqlClient.SqlParameter("@IDItem", IdItem);

            contextDB.Database.ExecuteSqlInterpolated($"AddingItemToExistingTrip {IdTrip}, {IdItem}");
        }

        public void RenameTrip(int id, string newName)
        {
            Trip trip = contextDB.Trips.FirstOrDefault(t => t.Id== id);
            trip.TripName = newName;
            contextDB.SaveChanges();
        }

        public void CreateTripFromExistingOne(string tripNameFromOld, int oldTripID)
        {
            int[] items = (from its in contextDB.ItemsToTrips
                           where its.TripId == oldTripID
                           select its.ItemId).ToArray();

            CreateTrip(tripNameFromOld, items);
        }
    }
}
