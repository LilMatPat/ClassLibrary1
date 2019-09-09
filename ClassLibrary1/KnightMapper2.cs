using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class KnightMapper : Mapper
    {
        int OffsetToKnightID;
        int OffsetToKnightName;
        int OffsetToStrength;
        int OffsetToDexterity;
        int OffsetToConstitution;
        int OffsetToPrecision;
        int OffsetToOrderID;
        int OffsetToOrderName;
        int OffsetToOrderBonus;
        int OffsetToUserID;
        int OffsetToUsername;
        int OffsetToEmailAddress;
        int OffsetToPassword;
        int OffsetToHash;
        int OffsetToRoleID;
        int OffsetToRoleName;

        public KnightMapper(SqlDataReader reader)
        {
            OffsetToKnightID = reader.GetOrdinal("KnightID");
            Assert(0 == OffsetToKnightID, $"KnightID is {OffsetToKnightID} not 0 as expected");
            OffsetToKnightName = reader.GetOrdinal("KnightName");
            Assert(1 == OffsetToKnightName, $"KnightName is {OffsetToKnightName} not 1 as expected");
            OffsetToStrength = reader.GetOrdinal("Strength");
            Assert(2 == OffsetToStrength, $"Strength is {OffsetToStrength} not 2 as expected");
            OffsetToDexterity = reader.GetOrdinal("Dexterity");
            Assert(3 == OffsetToDexterity, $"Dexterity is {OffsetToDexterity} not 3 as expected");
            OffsetToConstitution = reader.GetOrdinal("Constitution");
            Assert(4 == OffsetToConstitution, $"Consitution is {OffsetToConstitution}not 4 as expected");
            OffsetToPrecision = reader.GetOrdinal("Precision");
            Assert(5 == OffsetToPrecision, $"Precision is {OffsetToPrecision}not 5 as expected");
            OffsetToOrderID = reader.GetOrdinal("OrderID");
            Assert(6 == OffsetToOrderID, $"OrderID is {OffsetToOrderID}not 6 as expected");
            //OffsetToOrderName = reader.GetOrdinal("OrderName");
            //Assert(7 == OffsetToOrderName, $"OrderName is {OffsetToOrderName}not 7 as expected");
            //OffsetToOrderBonus = reader.GetOrdinal("OrderBonus");
            //Assert(8 == OffsetToOrderBonus, $"OrderBonus is {OffsetToOrderBonus}not 8 as expected");

            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(7 == OffsetToUserID, $"UserID is {OffsetToUserID} not 7 as expected");
            //OffsetToUserID = reader.GetOrdinal("UserID");
            //Assert(9 == OffsetToUsername, $"UserID is {OffsetToUsername} not 9 as expected");
            //OffsetToEmailAddress = reader.GetOrdinal("EmailAddress");
            //Assert(10 == OffsetToEmailAddress, $"EmailAddress is {OffsetToEmailAddress} not 10 as expected");
            //OffsetToPassword = reader.GetOrdinal("Password");
            //Assert(11 == OffsetToPassword, $"Password is {OffsetToPassword} not 11 as expected");
            //OffsetToHash = reader.GetOrdinal("Hash");
            //Assert(12 == OffsetToHash, $"Hash is {OffsetToHash} not 12 as expected");
            //OffsetToRoleID = reader.GetOrdinal("RoleID");
            //Assert(13 == OffsetToRoleID, $"RoleID is {OffsetToRoleID}not 13 as expected");
            //OffsetToRoleName = reader.GetOrdinal("UserID");
            //Assert(14 == OffsetToRoleName, $"RoleName is {OffsetToRoleName}not 14 as expected");


        }
        public KnightDAL KnightFromReader(SqlDataReader reader)
        {
            KnightDAL ProposedReturnValue = new KnightDAL();
            ProposedReturnValue.KnightID = reader.GetInt32(OffsetToKnightID);
            ProposedReturnValue.KnightName = reader.GetString(OffsetToKnightName);
            ProposedReturnValue.Strength = reader.GetInt32(OffsetToStrength);
            ProposedReturnValue.Dexterity = reader.GetInt32(OffsetToDexterity);
            ProposedReturnValue.Constitution = reader.GetInt32(OffsetToConstitution);
            ProposedReturnValue.Precision = reader.GetInt32(OffsetToPrecision);
            ProposedReturnValue.OrderID = reader.GetInt32(OffsetToOrderID);
            //ProposedReturnValue.OrderName = reader.GetString(OffsetToOrderName);
            //ProposedReturnValue.OrderBonus = reader.GetString(OffsetToOrderBonus);
            ProposedReturnValue.UserID = reader.GetInt32(OffsetToUserID);
            //ProposedReturnValue.Username = reader.GetString(OffsetToUsername);
            //ProposedReturnValue.EmailAddress = reader.GetString(OffsetToEmailAddress);
            //ProposedReturnValue.Password = reader.GetString(OffsetToPassword);
            //ProposedReturnValue.Hash = reader.GetString(OffsetToHash);
            //ProposedReturnValue.RoleID = reader.GetInt32(OffsetToRoleID);

            return ProposedReturnValue;

        }
    }
}
