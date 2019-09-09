using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class OrderMapper : Mapper
    {
      int OffsetToOrderID;
         int OffsetToOrderName;
         int OffsetToOrderBonus;

        public OrderMapper(SqlDataReader reader)
        {
            OffsetToOrderID = reader.GetOrdinal("OrderID");
            Assert(0 == OffsetToOrderID, $"OrderID is {OffsetToOrderID} not 0 as expected");
            OffsetToOrderName = reader.GetOrdinal("OrderName");
            Assert(1 == OffsetToOrderName, $"OrderName is {OffsetToOrderName} not 1 as expected");
            OffsetToOrderBonus = reader.GetOrdinal("OrderBonus");
            Assert(2 == OffsetToOrderBonus, $"OrderBonus is {OffsetToOrderBonus} not 2 as expected");
        }
        public OrderDAL OrderFromReader(SqlDataReader reader)
        {
            OrderDAL ProposedReturnValue = new OrderDAL();
            ProposedReturnValue.OrderID = reader.GetInt32(OffsetToOrderID);
            ProposedReturnValue.OrderName = reader.GetString(OffsetToOrderName);
            ProposedReturnValue.OrderBonus = reader.GetString(OffsetToOrderBonus);
            return ProposedReturnValue;
        }
    }
}
