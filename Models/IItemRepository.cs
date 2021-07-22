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
        Item AddItem(Item trip);
        Item Update(Item tripChanges);
        Item Delete(int id);
    }
}
