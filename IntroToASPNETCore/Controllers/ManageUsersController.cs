using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToASPNETCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroToASPNETCore.Controllers
{//only Admin can access this page
    [Authorize(Roles = "Administrator")]
    public class ManageUsersController : Controller
    {
        //Inject the UserManager into the class
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageUsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {//get the data for the roles
            var admins = await _userManager.GetUsersInRoleAsync("Administrator");
            var everyone = await _userManager.Users.ToArrayAsync();
            //pass all the admins and everyone else to a model and then pass that model to the View. 
            var model = new ManageUsersViewModel
            {
                Administrators = admins,
                Everyone = everyone
            };
            return View(model);
        }

    }
}