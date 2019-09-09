using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDAL
    {
        #region DirectMapping
       public int UserID { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
       public string Password { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }
        #endregion DirectMapping
        #region IndirectMapping
        public string RoleName { get; set; }
        #endregion IndirectMapping
    }
}
