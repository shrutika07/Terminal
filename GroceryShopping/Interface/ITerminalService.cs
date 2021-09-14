using GroceryShopping.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryShopping.Interface
{
    public interface ITerminalService
    {
        Task<decimal> CalCulateTotal(string groceryItems);
    }
}
