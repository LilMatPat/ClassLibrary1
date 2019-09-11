using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class ContextDAL : IDisposable
    {
        #region Context
        SqlConnection _connection;
        public ContextDAL()
        {
            _connection = new SqlConnection();
        }
        public string ConnectionString
        {
            get { return _connection.ConnectionString; }
            set { _connection.ConnectionString = value; }
        }
        void EnsureConnected()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                // there is nothing to do here after being connected
            }
            else if (_connection.State == System.Data.ConnectionState.Broken)
            {
                _connection.Close();
                _connection.Open();
            }
            else if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            else
            {
                // other states don't need processing
            }
        }
        bool Log(Exception ex)
        {
            return false;
        }
        public void Dispose()
        {
            _connection.Dispose();
        }
        #endregion Context
        #region Role Stuff
        public RoleDAL FindRoleByID(int RoleID)
        {
            RoleDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command
                    = new SqlCommand("FindRoleByID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper m = new RoleMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = m.RoleFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new
                              Exception($"Found more than 1 Role with key {RoleID}");

                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;

        }
        public List<RoleDAL> GetRoles(int skip, int take)
        {
            List<RoleDAL> proposedReturnValue = new List<RoleDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetRoles", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper m = new RoleMapper(reader);
                        while (reader.Read())
                        {
                            RoleDAL r = m.RoleFromReader(reader);
                            proposedReturnValue.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int ObtainRoleCount()
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ObtainRoleCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }

            return proposedReturnValue;
        }
        public int CreateRole(string RoleName)
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateRole", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", RoleName);
                    command.Parameters.AddWithValue("@RoleID", 0);
                    command.Parameters["@RoleID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    proposedReturnValue =
                        Convert.ToInt32(command.Parameters["@RoleID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public void JustUpdateRole(int RoleID, string RoleName)
        {

            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateRole", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@RoleName", RoleName);

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public void DeleteRole(int RoleID)
        {

            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteRole", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
            #endregion Roles

        
        #region User stuff
        public UserDAL FindUserByID(int UserID)
        {
            UserDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command
                    = new SqlCommand("FindUserByID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper m = new UserMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = m.UserFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new
                              Exception($"Found more than 1 User with key {UserID}");

                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;

        }
        public UserDAL FindUserByUsername(string Username)
        {
            UserDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command
                    = new SqlCommand("FindUserByUsername", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", Username);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper m = new UserMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = m.UserFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new
                              Exception($"Found more than 1 User with key {Username}");

                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;

        }
        public UserDAL FindUserByEmailAddress(string EmailAddress)
        {
            UserDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command
                    = new SqlCommand("FindUserByEmailAddress", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmailAddress", EmailAddress);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper m = new UserMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = m.UserFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new
                              Exception($"Found more than 1 User with key {EmailAddress}");

                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;

        }
        public void DeleteUser(int UserID)
        {

            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteUser", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public void JustUpdateUser(int UserID, string Username, string EmailAddress, string Password, string Hash, int RoleID )
        {

            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateUser", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"UserID", UserID);
                    command.Parameters.AddWithValue(@"Username", Username);
                    command.Parameters.AddWithValue(@"EmailAddress", EmailAddress);
                    command.Parameters.AddWithValue(@"Password", Password);
                    command.Parameters.AddWithValue(@"Hash", Hash);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Log(ex))
            {
            }
        }

                public List<UserDAL> GetUsers(int skip, int take)
        {
            List<UserDAL> proposedReturnValue = new List<UserDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetUsers", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper m = new UserMapper(reader);
                        while (reader.Read())
                        {
                            UserDAL r = m.UserFromReader(reader);
                            proposedReturnValue.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }

        public int ObtainUserCount()
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ObtainUserCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }

            return proposedReturnValue;
        }



        public int CreateUser(string Username, string EmailAddress, string Password, string Hash, int RoleID)
        {
            int ProposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateUser", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", 0);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@EmailAddress", EmailAddress);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Hash", Hash);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    
                    command.Parameters["@UserID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ProposedReturnValue =
                        Convert.ToInt32(command.Parameters["@UserID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;
        }
            #endregion Users


        
        #region Knights
        public KnightDAL FindKnightByID(int KnightID)
        {
            KnightDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command
                    = new SqlCommand("FindKnightByID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@KnightID", KnightID);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        KnightMapper m = new KnightMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = m.KnightFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new
                              Exception($"Found more than 1 knight with key {KnightID}");

                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;

        }
        public int ObtainKnightCount()
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ObtainKnightCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }

            return proposedReturnValue;
        }
        public void DeleteKnight(int KnightID)
        {

            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteKnight", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@KnightID", KnightID);

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public List<KnightDAL> GetKnights(int skip, int take)
        {
            List<KnightDAL> proposedReturnValue = new List<KnightDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetKnights", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        KnightMapper m = new KnightMapper(reader);
                        while (reader.Read())
                        {
                            KnightDAL r = m.KnightFromReader(reader);
                            proposedReturnValue.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public List<KnightDAL> GetKnightsRelatedToUser(int skip, int take, int UserID)
        {
            List<KnightDAL> proposedReturnValue = new List<KnightDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetKnightsRelatedToUser", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        KnightMapper m = new KnightMapper(reader);
                        while (reader.Read())
                        {
                            KnightDAL r = m.KnightFromReader(reader);
                            proposedReturnValue.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }


        public int CreateKnight(string KnightName, int Strength, int Dexterity, int Constitution, int Precision, int UserID, int OrderID)
        {//proposed return false unless otherwise changed
            int ProposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateKnight", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@KnightID", 0);
                    command.Parameters.AddWithValue("@KnightName", KnightName);
                    command.Parameters.AddWithValue("@Strength", Strength);
                    command.Parameters.AddWithValue("@Dexterity", Dexterity);
                    command.Parameters.AddWithValue("@Constitution", Constitution);
                    command.Parameters.AddWithValue("@Precision", Precision);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.Parameters["@KnightID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ProposedReturnValue =
                        Convert.ToInt32(command.Parameters["@KnightID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;
        }
        public void JustUpdateKnight(int KnightID, string KnightName, int Strength, int Dexterity, int Constitution, int Precision, int UserID, int OrderID)
        {

            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateKnight", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"KnightID", KnightID);
                    command.Parameters.AddWithValue(@"KnightName", KnightName);
                    command.Parameters.AddWithValue(@"Strength", Strength);
                    command.Parameters.AddWithValue(@"Dexterity", Dexterity);
                    command.Parameters.AddWithValue(@"Constitution", Constitution);
                    command.Parameters.AddWithValue("@Precision", Precision);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Log(ex))
            {
            }
        }
        #endregion Knights



        #region Orders
        public OrderDAL FindOrderByID(int OrderID)
        {
            OrderDAL ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command
                    = new SqlCommand("FindOrderByID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", OrderID);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        OrderMapper m = new OrderMapper(reader);   
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = m.OrderFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new
                              Exception($"Found more than 1 User with key {OrderID}");

                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;

        }
        public int ObtainOrderCount()
        {
            int proposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ObtainOrderCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }

            return proposedReturnValue;
        }
        public List<OrderDAL> GetOrders(int skip, int take)
        {
            List<OrderDAL> proposedReturnValue = new List<OrderDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetOrders", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        OrderMapper m = new OrderMapper(reader);
                        while (reader.Read())
                        {
                            OrderDAL r = m.OrderFromReader(reader);
                            proposedReturnValue.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public void JustUpdateOrder( int OrderID, string OrderName, string OrderBonus)
        {

            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateOrder", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.Parameters.AddWithValue(@"OrderName", OrderName);
                    command.Parameters.AddWithValue(@"OrderBonus", OrderBonus);
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Log(ex))
            {
            }
        }
        
        public void DeleteOrder(int OrderID)
        {

            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteOrder", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@OrderID",OrderID);

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public int CreateOrder(string OrderName, string OrderBonus)
        {
            //proposed return false unless otherwise changed
            int ProposedReturnValue = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateOrder", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", 0);
                    command.Parameters.AddWithValue("@OrderName", OrderName);
                    command.Parameters.AddWithValue("@OrderBonus", OrderBonus);
                    command.Parameters["@OrderID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ProposedReturnValue =
                        Convert.ToInt32(command.Parameters["@OrderID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;
        }
            #endregion Order
        
    }
}
