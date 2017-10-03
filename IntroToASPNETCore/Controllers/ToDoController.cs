using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToASPNETCore.Models;
using IntroToASPNETCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IntroToASPNETCore.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        //this is just a private variable to use in the controller
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<ApplicationUser> _userManager;

        //this is the constructor of the controller, it is the first thing that runs when the class is called. We are passing all the  data from the service to the private variable.
        public ToDoController(ITodoItemService todoItemService, UserManager<ApplicationUser> userManager)
        {
            _todoItemService = todoItemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            // todo Get to-do items from database
            var toDoItems = await _todoItemService.GetIncompleteItemsAsync(currentUser);

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
            //new check for user logged in
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            //check if the adding is successful (we still need to add AddItemAsync)
            bool IsSuccessful = await _todoItemService.AddItemAsync(newItem, currentUser);
            if (!IsSuccessful) //if it fails
            {
                return BadRequest(new { error = "Could not add item" });
            }
            //otherwise, if it works return OK result
            return Ok();
        }
        public async Task<IActionResult> MarkDone(Guid id)
        {
            //if there is no login then Bork
            if (id == Guid.Empty) return BadRequest();

            //if the current user is not the logged in then Bork
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            //if the update dien't work then Bork
            var successful = await _todoItemService.MarkDoneAsync(id, currentUser);
            if (!successful) return BadRequest();

            //otherwise everything is OK
            return Ok();
        }



    }

}