using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroToASPNETCore;
using IntroToASPNETCore.Data;
using IntroToASPNETCore.Models;
using IntroToASPNETCore.Services;
using Microsoft.EntityFrameworkCore;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {

        [TestMethod]
        public async Task ToDoItemServiceTest()
        {
            //================================= Create new DB and stick sample data in 
            //set the options for the DB,  UseInMemoryDatabase and give it the name AddNewItem (we could call the DB using the name so we could have multiple DBs in memory, but we won't)

            var options = new DbContextOptionsBuilder<ToDoContext>()
                .UseInMemoryDatabase(databaseName: "AddNewItem").Options;

            // Set up a context (connection to the DB) for writing to DB with the UseInMemoryDatabase

            using (var inMemoryContext = new ToDoContext(options))
            {
                var service = new TodoItemService(inMemoryContext);
                var fakeUser = new ApplicationUser //Creating a fake User entry
                {
                    Id = "fake-000", //using a fake ID
                    UserName = "fake@fake" //using a fake Username
                };
                //add the fakeUser to the DB with the title Testing?
                await service.AddItemAsync(new NewToDoItem { Title = "Testing?" }, fakeUser);
            }
            //==================================== Get the data back out 
            //take in the new in memory database  
            using (var inMemoryContext = new ToDoContext(options))
            {
                //Check that there is only 1 item in the DB
                Assert.AreEqual(1, await inMemoryContext.Items.CountAsync());

                //check that the data that has been taken in matches the data in the Unit test

                //get the first item from the memory
                var item = await inMemoryContext.Items.FirstAsync();

                Assert.AreEqual("WrongTesting?", item.Title); //Is the title Testing?
                Assert.AreEqual(false, item.IsDone); //Is the isDone False?
                Assert.IsTrue(DateTimeOffset.Now.AddDays(3) - item.DueAt < TimeSpan.FromSeconds(1)); //Is the date 3 days from today?
            }        }
    }
}
