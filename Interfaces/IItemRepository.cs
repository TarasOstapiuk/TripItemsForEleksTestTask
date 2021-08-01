using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripItemsForEleks.Models
{
    public interface IItemRepository
    {
        Item GetItem(int id);
        IEnumerable<Item> GetAllItems();
        Item AddItem(Item item);
        //Item Update(Item itemChanges);
        Item Delete(int id);
    }
}
