using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToASPNETCore.Models;
using IntroToASPNETCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntroToASPNETCore.Controllers
{
    public class ToDoController : Controller
    {
        //this is just a private variable to use in the controller
        private readonly ITodoItemService _todoItemService;

        //this is the constructor of the controller, it is the first thing that runs when the class is called. We are passing all the fake data from the service to the private variable.
        public ToDoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            // todo Get to-do items from database
            var toDoItems = await _todoItemService.GetIncompleteItemsAsync();

            // todo Put items into a model
            var model = new ToDoViewModel
            {
                Items = toDoItems
            };
            //todo Pass the view to a model and render
            return View(model);
        }

        public async Task<IActionResult> AddItem(NewToDoItem newItem)
        {
            if (!ModelState.IsValid) //if the model returns an error
            { //do stuff
                return BadRequest(ModelState);
            }
            //check if the adding is successful (we still need to add AddItemAsync)
            bool IsSuccessful = await _todoItemService.AddItemAsync(newItem);
            if (!IsSuccessful) //if it fails
            {
                return BadRequest(new { error = "Could not add item" });
            }
            //otherwise, if it works return OK result
            return Ok();
        }
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var successful = await _todoItemService.MarkDoneAsync(id);
            if (!successful) return BadRequest();
            return Ok();
        }



    }

}