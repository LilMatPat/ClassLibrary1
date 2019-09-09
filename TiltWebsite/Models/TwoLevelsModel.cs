using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiltWebsite.Models
{
    public class TwoLevelsModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public int KnightID { get; set; }
        public string KnightName { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Precision { get; set; }
       
        public int OrderID { get; set; }
    }
        
    }
