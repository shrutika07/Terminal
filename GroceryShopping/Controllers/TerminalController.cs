using GroceryShopping.Interface;
using GroceryShopping.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly ITerminalService _grocery;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="grocery"></param>
        public TerminalController(ITerminalService grocery)
        {
            _grocery = grocery;
        }

        /// <summary>
        /// Total grocery item price
        /// </summary>
        /// <param name="groceryItems">list of items</param>
        /// <returns>Ok result</returns>
        [HttpPost]
        public async Task<ActionResult> CalCulateTotal([FromBody] string groceryItems)
        {
            var result = await _grocery.CalCulateTotal(groceryItems);
            return Ok(result);
        }
    }
}
