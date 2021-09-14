using GroceryShopping.Interface;
using GroceryShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopping.Repository
{
    public class TerminalRepository : ITerminalRepository
    {
        public async Task<GroceryItems> GetById(string item)
        {
            List<GroceryItems> groceryList = new()
            {
                new GroceryItems { GroceryId = 1, Item = "A", Price = "1.25" },
                new GroceryItems { GroceryId = 2, Item = "B", Price = "4.25" },
                new GroceryItems { GroceryId = 3, Item = "C", Price = "1" },
                new GroceryItems { GroceryId = 4, Item = "D", Price = "0.75" }
            };

            var groceryItem = groceryList.FirstOrDefault(x => x.Item == item);
            return groceryItem;
        }
    }
}
