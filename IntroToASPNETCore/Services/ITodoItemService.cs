using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToASPNETCore.Models;

namespace IntroToASPNETCore.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(ApplicationUser user);
        //added the ApplicationUser user
        Task<bool> AddItemAsync(NewToDoItem newItem, ApplicationUser user);
        //added the ApplicationUser user
        Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);
    }
}
