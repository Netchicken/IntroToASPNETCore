using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroToASPNETCore.Models
{
    public class ManageUsersViewModel
    {
        //a list of admins
        public IEnumerable<ApplicationUser> Administrators { get; set; }
        //a list of Users
        public IEnumerable<ApplicationUser> Everyone { get; set; }
    }

}
