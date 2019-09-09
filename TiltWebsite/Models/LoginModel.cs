using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiltWebsite.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string message { get; set; }
        public string ReturnURL { get; set; }
    }
}