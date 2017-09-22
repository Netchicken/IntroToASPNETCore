using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToASPNETCore.Models;

namespace IntroToASPNETCore.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync()
        {
            // Return an array of TodoItems
            IEnumerable<ToDoItem> items = new[] {
                new ToDoItem
                {
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },
                new ToDoItem
                {
                    Title = "Build awesome apps",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                }             };
            return Task.FromResult(items);
        }
    }
}

