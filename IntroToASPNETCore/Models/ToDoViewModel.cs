using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroToASPNETCore.Models
{
    public class ToDoViewModel
    {
        public IEnumerable<ToDoItem> Items
        { get; set; }
    }
}
