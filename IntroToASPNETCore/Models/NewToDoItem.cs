using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IntroToASPNETCore.Models
{
    public class NewToDoItem
    {
        [Required]  //Required means you can't make a new Entry without the Title field
        public string Title { get; set; }
    }
}
