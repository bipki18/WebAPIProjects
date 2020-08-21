using Honeywell.CodeExcercise.API.Models;
using Honeywell.CodeExercise.Component.ItemComponent;
using Honeywell.CodeExercise.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Honeywell.CodeExcercise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IItemComponentRepository itemComponentRepository;
        public ProductController(IItemComponentRepository itemComponentRepository)
        {
            this.itemComponentRepository = itemComponentRepository;
        }

        /// <summary>
        /// This method get called on initial request from user
        /// </summary>
        /// <returns></returns>
        /// 
        [NonAction]
        public async Task<ActionResult> GetItems()
        {
            try
            {
                return Ok(await itemComponentRepository.GetAllItem());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        /// <summary>
        /// This method will get called when user try to get item details based on item name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("")]
        [Route("view")]
        [Route("view/{name:minlength(3)}")]
        [HttpGet]
        public async Task<ActionResult<List<ItemViewModel>>> GetItemsByName(string name, [FromQuery] PagingParameterModel pagingParameterModel)
        {
            try
            {
                var result = await itemComponentRepository.GetItemsByName(name ?? "", pagingParameterModel);

                if (result == null || result.Count == 0) return NotFound($"Record not found for input {name} ");

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        ///// <summary>
        ///// This method will add new item to existing item list
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Item>> AddItem(Item item)
        {
            try
            {
                if (item == null)
                    return BadRequest();

                var createdItem = await itemComponentRepository.AddNewItem(item);

                 return CreatedAtAction(nameof(GetItems), new { id = createdItem.Id }, createdItem);
               // return CreatedAtAction("Record addedd successfully.", new { id = createdItem.Id }, createdItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating new item record");
            }
        }







    }
}
