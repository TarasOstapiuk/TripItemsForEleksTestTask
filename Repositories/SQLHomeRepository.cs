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
                IEnumerable<Item> items = contextDB
                    .Items.FromSqlRaw("Favorites").ToList();
                return items;
            }
        }
    }
}
