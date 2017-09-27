using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToASPNETCore.Models;
using IntroToASPNETCore.Services;

namespace IntroToASPNETCore.Data
{/// <summary>
 /// Check to see if the Data has been added to the DB
 /// Here you'll use the EnsureCreated method to automatically create the database. In a later tutorial you'll see how to handle model changes by using Code First Migrations to change the database schema instead of dropping and re-creating the database.

    ///In the Data folder, create a new class file named DbInitializer.cs and replace the template code with the following code, which causes a database to be created when needed and loads test data into the new database.
    /// 
    /// </summary>
    public class DbInitializer
    {
        public static void Initialize(ToDoContext context)
        {
            // context.Database.EnsureCreated();
            //if (context.Items.Count() > 0) // Look for any data.
            //{
            //    return; // DB has been seeded
            //}

            //this is just a private variable to use in the controller
            // ITodoItemService _todoItemService = null;

            //Get all the existing data
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

            foreach (var entry in items)
            {
                //add it to the db context
                context.Items.Add(entry);
            }



            context.SaveChanges();
        }
    }
}
