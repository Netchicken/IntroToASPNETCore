using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntroToASPNETCore.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroToASPNETCore.Data
{
    public class ToDoContext : DbContext
    {
        //a set of all the items in the DB
        public DbSet<ToDoItem> Items { get; set; }

        //the Constructor
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }
    }
}
