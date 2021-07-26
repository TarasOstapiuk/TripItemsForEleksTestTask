using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripItemsForEleks.Models
{
    public class SQLItemRepository : IItemRepository
    {
        private readonly AppDBContext contextDB;

        public SQLItemRepository(AppDBContext context)
        {
            contextDB = context;
        }

        public Item AddItem(Item item)
        {
            contextDB.Items.Add(item);
            contextDB.SaveChanges();
            return item;
        }
        
        public Item Delete(int id)
        {
            Item itemToDelete = contextDB.Items.FirstOrDefault(i => i.Id == id);
            if (itemToDelete != null)
            {
                contextDB.Items.Remove(itemToDelete);
                contextDB.SaveChanges();
            }
            return itemToDelete;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return contextDB.Items;
        }

        public Item GetItem(int id)
        {
            return contextDB.Items.FirstOrDefault(i => i.Id==id);
        }

         public Item Update(Item itemChanges)
        {
            var item = contextDB.Items.Attach(itemChanges);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contextDB.SaveChanges();
            return itemChanges;
        }
    }
}
