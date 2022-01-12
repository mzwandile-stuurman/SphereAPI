using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SphereAPI.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public int Phone_Number { get; set; }
        public string User_email { get; set; }
    }
}
