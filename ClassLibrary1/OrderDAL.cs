using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class OrderDAL
    {
        #region DirectMapping
       public int OrderID { get; set; }
        public string OrderName { get; set; }
        public string OrderBonus { get; set; }
        #endregion DirectMapping
    }
}
