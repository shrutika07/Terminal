using GroceryShopping.Interface;
using GroceryShopping.Model;
using GroceryShopping.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopping.Service
{
    /// <summary>
    /// Implementation of <see cref="ITerminalService"/>
    /// </summary>
    public class TerminalService : ITerminalService
    {
        private readonly ITerminalRepository _groceryRepository;

        /// <summary>
        /// Initilizes a new instance
        /// </summary>
        /// <param name="groceryRepository">to interact with <see cref="ITerminalRepository"/></param>
        public TerminalService(ITerminalRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

        //</inhertdoc>
        public async Task<decimal> CalCulateTotal(string groceryItems)
        {
            
            if (groceryItems == null)
            {
                throw new ArgumentException("Items cannot be null", nameof(groceryItems));
            };
            var results = groceryItems.ToList().GroupBy(p => p.ToString()).Select(x => (item: x.Key, count: x.Count())).ToList();
            decimal total = 0;
            foreach (var groceryTotal in results)
            {
                switch (groceryTotal.item)
                {

                    case "A":
                        var groceryPrice = await _groceryRepository.GetById(groceryTotal.item);
                        if (groceryTotal.count == 3)
                        {
                            var price = groceryTotal.count * 1;
                            total += price;
                        }
                        else
                        {
                            total += decimal.Parse(groceryPrice.Price) * groceryTotal.count;
                        }
                        break;

                    case "B":
                        var itemBResult = await _groceryRepository.GetById(groceryTotal.item);
                        total += decimal.Parse(itemBResult.Price) * groceryTotal.count;
                        break;

                    case "C":
                        var itemCResult = await _groceryRepository.GetById(groceryTotal.item);
                        var remaningItem = 0;
                        int packOf6 = 0;
                        if (groceryTotal.count > 6)
                        {
                            remaningItem = groceryTotal.count - 6; //1
                            packOf6 = groceryTotal.count - remaningItem; //6
                            total += 5;
                            if (remaningItem >= 6)
                            {
                                remaningItem -= 6;
                                packOf6 = groceryTotal.count - remaningItem;
                                total += 5;
                            } 
                        }
                        if(remaningItem >= 1)
                        {
                            total += decimal.Parse(itemCResult.Price) * remaningItem;
                        }
                        else
                        {
                            total += decimal.Parse(itemCResult.Price) * groceryTotal.count;
                        }
                        break;

                    case "D":
                        var itemDResult = await _groceryRepository.GetById(groceryTotal.item);
                        total += decimal.Parse(itemDResult.Price) * groceryTotal.count;
                        break;

                    default:
                        break;
                }
            }
            return total;
        }
    }
}
