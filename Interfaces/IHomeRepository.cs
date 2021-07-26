using System.Collections.Generic;

namespace TripItemsForEleks.Models
{
    public interface IHomeRepository
    {
        IEnumerable<Item> GetFavorites();
    }
}