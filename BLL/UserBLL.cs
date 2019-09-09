using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBLL
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

        public UserBLL()
        {

        }

        public UserBLL(DataAccessLayer.UserDAL dal)
        {
            this.UserID = dal.UserID;
            this.Username = dal.Username;
            this.EmailAddress = dal.EmailAddress;
            this.Password = dal.Password;
            this.RoleID = dal.RoleID;
            this.RoleName = dal.RoleName;
            this.Hash = dal.Hash;
            this.Salt = dal.Salt;
        }

        public override string ToString()
        {
            return $"UserID:{UserID} Username: {Username} EmailAddress:{EmailAddress} Password: {Password} Hash:{Hash}";
        }
    }
}
