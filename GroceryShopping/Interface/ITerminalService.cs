using GroceryShopping.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryShopping.Interface
{
    /// <summary>
    /// Defination of <see cref="TerminalService"/>
    /// </summary>
    public interface ITerminalService
    {
        /// <summary>
        /// Calculate total for grocery items
        /// </summary>
        /// <param name="groceryItems">item list</param>
        /// <returns>total of items in decimal format</returns>
        Task<decimal> CalCulateTotal(string groceryItems);
    }
}
