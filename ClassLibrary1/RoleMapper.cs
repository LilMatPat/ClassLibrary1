using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleMapper : Mapper
    {
      
       public int OffsetToRoleID;// should be 0
       public int OffsetToRoleName; //should be 1
        public RoleMapper(SqlDataReader reader)
        {
           
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(0 == OffsetToRoleID, $"RoleID is {OffsetToRoleID}not 0 as expected");
            OffsetToRoleName = reader.GetOrdinal("RoleName");
            Assert(1 == OffsetToRoleName, $"RoleName is {OffsetToRoleName}not 1 as expected");


        }
        public RoleDAL RoleFromReader(SqlDataReader reader)
        {
            RoleDAL ProposedReturnValue = new RoleDAL();
            
            ProposedReturnValue.RoleID = reader.GetInt32(OffsetToRoleID);
            ProposedReturnValue.RoleName = reader.GetString(OffsetToRoleName);
            return ProposedReturnValue;

        }
    }

}


