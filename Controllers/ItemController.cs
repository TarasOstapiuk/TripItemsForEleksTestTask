using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripItemsForEleks.Models;

namespace TripItemsForEleks.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> item = _itemRepository.GetAllItems();
            return View(item);
        }
        [HttpGet]
        public ViewResult CreateItem()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult CreateItem(Item item)
        {
            if (ModelState.IsValid)
            {
                Item i = _itemRepository.AddItem(item);
                return RedirectToAction("Current", new { id = i.Id });
            }
            else return RedirectToAction("CreateItem");
        }
        public ActionResult Current(int? id)
        {
            if (id != null)
            {
                Item item = _itemRepository.GetItem((int)id);
                return View(item);
            }
            else return View();
        }

        [HttpPost]
        public RedirectToActionResult Delete(Item item)
        {
             _itemRepository.Delete(item.Id);
            return RedirectToAction("Index");
        }
        
       
    }
}
