using GroceryShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopping.Interface
{
    public interface ITerminalRepository
    {
        Task<GroceryItems> GetById(string item);
    }
}
