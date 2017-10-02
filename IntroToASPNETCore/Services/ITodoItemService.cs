using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToASPNETCore.Models;

namespace IntroToASPNETCore.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync();

        Task<bool> AddItemAsync(NewToDoItem newItem);

        Task<bool> MarkDoneAsync(Guid id);
    }
}
