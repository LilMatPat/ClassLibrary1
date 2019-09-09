
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserMapper : Mapper
    {
        int OffsetToUserID; //should be 0
        int OffsetToUsername; //should be 1
        int OffsetToEmailAddress; //should be 2
        int OffsetToPassword; //should be 3
        int OffsetToHash; //should be 4
        int OffsetToRoleID;// should be 5
        int OffsetToRoleName; //should be 6
        public UserMapper(SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, $"UserID is {OffsetToUserID} not 0 as expected");
            OffsetToUsername = reader.GetOrdinal("Username");
            Assert(1 == OffsetToUsername, $"Username is {OffsetToUsername} not 1 as expected");
            OffsetToEmailAddress = reader.GetOrdinal("EmailAddress");
            Assert(2 == OffsetToEmailAddress, $"EmailAddress is {OffsetToEmailAddress} not 2 as expected");
            OffsetToPassword = reader.GetOrdinal("Password");
            Assert(3 == OffsetToPassword, $"Password is {OffsetToPassword} not 3 as expected");
            OffsetToHash = reader.GetOrdinal("Hash");
            Assert(4 == OffsetToHash, $"Hash is {OffsetToHash} not 4 as expected");
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(5 == OffsetToRoleID, $"RoleID is {OffsetToRoleID}not 5 as expected");
            //OffsetToRoleName = reader.GetOrdinal("RoleName");
            //Assert(6 == OffsetToRoleName, $"RoleName is {OffsetToRoleName}not 6 as expected");


        }
        public UserDAL UserFromReader(SqlDataReader reader)
        {
            UserDAL ProposedReturnValue = new UserDAL();
            ProposedReturnValue.UserID = reader.GetInt32(OffsetToUserID);
            ProposedReturnValue.Username = this.GetStringOrDefault(reader,OffsetToUsername);
            ProposedReturnValue.EmailAddress = this.GetStringOrDefault(reader,OffsetToEmailAddress);
            ProposedReturnValue.Password = this.GetStringOrDefault(reader, OffsetToPassword);
            ProposedReturnValue.Hash = this.GetStringOrDefault(reader, OffsetToHash);
            ProposedReturnValue.RoleID = this.GetInt32OrDefault(reader, OffsetToRoleID);
            //ProposedReturnValue.RoleName = this.GetStringOrDefault(reader, OffsetToRoleName);
            return ProposedReturnValue;

        }
    }
   
}
