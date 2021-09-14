using GroceryShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopping.Interface
{
    /// <summary>
    /// Defination of <see cref="TerminalRepository"/>
    /// </summary>
    public interface ITerminalRepository
    {
        /// <summary>
        /// retrive grocery item by item name
        /// </summary>
        /// <param name="item">item name</param>
        /// <returns>item details</returns>
        Task<GroceryItems> GetById(string item);
    }
}
