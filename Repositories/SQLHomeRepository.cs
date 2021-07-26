using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripItemsForEleks.Models
{
    public class SQLHomeRepository : IHomeRepository
    {
        private readonly AppDBContext contextDB;

        public SQLHomeRepository(AppDBContext context)
        {
            contextDB = context;
        }

        public IEnumerable<Item> GetFavorites()
        {
           {
                // That is for future if we need to pass param to proc. Now proc is hardcoded.
                /*SqlParameter param = new SqlParameter("@count", "7");*/
                IEnumerable<Item> items = contextDB.Items.FromSqlRaw("Favorites").ToList();
                return items;
            }
        }
    }
}
