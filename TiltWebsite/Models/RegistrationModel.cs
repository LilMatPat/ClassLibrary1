using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiltWebsite.Models
{
    public class RegistrationModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public string EMail { get; set; }
       
        public string Message { get; set; }
        //  any other user information you wish to collect during registration
    }
}