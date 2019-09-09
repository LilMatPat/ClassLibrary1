using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class KnightDAL
    {
        #region #region DirectMapping
       public int KnightID { get; set; }
        public string KnightName { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
       public int Precision { get; set; }
        public int UserID { get; set; }
        public int OrderID { get; set; }
        #endregion DirectMapping
        #region IndirectMapping
        public string OrderName { get; set; }
        public string OrderBonus { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
        public int RoleID { get; set; }
        #endregion IndirectMapping
        
    }
}
