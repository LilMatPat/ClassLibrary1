using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderBLL
    {
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public string  OrderBonus { get; set; }

        public OrderBLL()
        {

        }

        public OrderBLL(DataAccessLayer.OrderDAL dal)
        {
            this.OrderID = dal.OrderID;
            this.OrderName = dal.OrderName;
            this.OrderBonus = dal.OrderBonus;
        }

        public override string ToString()
        {
            return $"OrderID: {OrderID,5} OrderName:{OrderName} OrderBonus:{OrderBonus}";
        }
    }
}
