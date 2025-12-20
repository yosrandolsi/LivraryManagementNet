using System;
using System.Collections.Generic;

namespace BibliothequeWinForm.Models
{
    public class Admin
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }

        
        public static List<Admin> Admins = new List<Admin>();
    }
}
