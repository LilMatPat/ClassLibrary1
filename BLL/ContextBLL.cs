using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ContextBLL : IDisposable
    {
        ContextDAL _context = new ContextDAL();

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }

        bool Log(Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }

        public ContextBLL()
        {
            try
            {
                string connectionstring;
                connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
                _context.ConnectionString = connectionstring;
            }
            catch (Exception ex) when (Log(ex))
            {
                // this exception does not have a 
                // reasonable handler, simply log it.
            }
        }

        #region Roles
        public RoleBLL FindRoleByID(int RoleID)
        {
            RoleBLL ProposedReturnValue = null;
            RoleDAL DataLayerObject = _context.FindRoleByID(RoleID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new RoleBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }

        public List<RoleBLL> GetRoles(int skip, int take)
        {
            List<RoleBLL> ProposedReturnValue = new List<RoleBLL>();
            List<RoleDAL> ListOfDataLayerObjects = _context.GetRoles(skip, take);
            foreach (RoleDAL role in ListOfDataLayerObjects)
            {
                RoleBLL BusinessObject = new RoleBLL(role);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }

        public int ObtainRoleCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.ObtainRoleCount();
            return proposedReturnValue;
        }

        public int CreateRole(string RoleName)
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.CreateRole(RoleName);
            return proposedReturnValue;
        }
        public int CreateRole(RoleBLL role)
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.CreateRole(role.RoleName);
            return proposedReturnValue;
        }

        public void JustUpdateRole(int RoleID, string RoleName)
        {

            _context.JustUpdateRole(RoleID, RoleName);

        }


        public void DeleteRole(int RoleID)
        {
            _context.DeleteRole(RoleID);
        }
        public void DeleteRole(RoleBLL Role)
        {
            _context.DeleteRole(Role.RoleID);
        }
        #endregion Roles
        #region Users
        public UserBLL FindUserByUsername(string Username)
        {
            UserBLL ProposedReturnValue = null;
            UserDAL DataLayerObject = _context.FindUserByUsername(Username);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new UserBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public UserBLL FindUserByEmailAddress(string EmailAddress)
        {
            UserBLL ProposedReturnValue = null;
            UserDAL DataLayerObject = _context.FindUserByEmailAddress(EmailAddress);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new UserBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public int CreateUser(string Username, string EMail, string Password, string Hash, int RoleID)
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.CreateUser(Username, EMail, Password, Hash, RoleID);
            return proposedReturnValue;
        }

        public int CreateUser(UserBLL user)
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.CreateUser(user.Username, user.EmailAddress, user.Password, user.Hash, user.RoleID);
            return proposedReturnValue;
        }

        public void JustUpdateUser(int UserID, string Username, string EmailAddress, string Password, string Hash, int RoleID, string RoleName)
        {

            _context.JustUpdateUser(UserID, Username, EmailAddress, Password, Hash, RoleID);

        }

        public void JustUpdateUser(UserBLL user)
        {

            _context.JustUpdateUser(user.UserID, user.Username, user.EmailAddress, user.Password, user.Hash, user.RoleID);

        }

        public void DeleteUser(int UserID)
        {
            _context.DeleteUser(UserID);
        }

        public void DeleteUser(UserBLL User)
        {
            _context.DeleteUser(User.UserID);
        }
        public int ObtainUserCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.ObtainUserCount();
            return proposedReturnValue;
        }
        public List<UserBLL> GetUsers(int skip, int take)
        {
            List<UserBLL> ProposedReturnValue = new List<UserBLL>();
            List<UserDAL> ListOfDataLayerObjects = _context.GetUsers(skip, take);
            foreach (UserDAL role in ListOfDataLayerObjects)
            {
               UserBLL BusinessObject = new UserBLL(role);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public UserBLL FindUserByID(int UserID)
        {
            UserBLL ProposedReturnValue = null;
            UserDAL DataLayerObject = _context.FindUserByID(UserID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new UserBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        #endregion Users
        #region Orders
        public OrderBLL FindOrderByID(int OrderID)
        {
            OrderBLL ProposedReturnValue = null;
            OrderDAL DataLayerObject = _context.FindOrderByID(OrderID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new OrderBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public int CreateOrder(string OrderName, string OrderBonus)
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.CreateOrder(OrderName, OrderBonus);
            return proposedReturnValue;
        }

        public int CreateOrder(OrderBLL order)
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.CreateOrder(order.OrderName, order.OrderBonus);
            return proposedReturnValue;
        }

        public void JustUpdateOrder(int OrderID, string OrderName, string OrderBonus)
        {

            _context.JustUpdateOrder(OrderID, OrderName, OrderBonus);

        }

        public void JustUpdateOrder(OrderBLL order)
        {

            _context.JustUpdateOrder(order.OrderID, order.OrderName, order.OrderBonus);

        }

        public void DeleteOrder(int OrderID)
        {
            _context.DeleteOrder(OrderID);
        }

        public void DeleteOrder(OrderBLL users)
        {
            _context.DeleteOrder(users.OrderID);
        }
        public List<OrderBLL> GetOrders(int skip, int take)
        {
            List<OrderBLL> ProposedReturnValue = new List<OrderBLL>();
            List<OrderDAL> ListOfDataLayerObjects = _context.GetOrders(skip, take);
            foreach (OrderDAL order in ListOfDataLayerObjects)
            {
                OrderBLL BusinessObject = new OrderBLL(order);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public int ObtainOrderCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.ObtainOrderCount();
            return proposedReturnValue;
        }
        #endregion Orders
        #region Knights
        public KnightBLL FindKnightByID(int KnightID)
        {
            KnightBLL ProposedReturnValue = null;
           KnightDAL DataLayerObject = _context.FindKnightByID(KnightID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new KnightBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public int CreateKnight(string KnightName,int Strength, int Dexterity, int Constitution, int Precision, int UserID, int OrderID)
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.CreateKnight(KnightName, Strength, Dexterity, Constitution, Precision, UserID, OrderID);
            return proposedReturnValue;
        }

        public int CreateKnight(KnightBLL knight)
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.CreateKnight(knight.KnightName, knight.Strength, knight.Dexterity, knight.Constitution, knight.Precision, knight.UserID, knight.OrderID);
            return proposedReturnValue;
        }

        public void JustUpdateKnight(int KnightID, string KnightName, int Strength, int Dexterity, int Constitution, int Precision, int UserID, int OrderID)
        {

            _context.JustUpdateKnight(KnightID,KnightName,Strength, Dexterity, Constitution, Precision,UserID, OrderID);

        }

        public void JustUpdateKnight(KnightBLL knight)
        {

            _context.JustUpdateKnight(knight.KnightID, knight.KnightName, knight.Strength, knight.Dexterity, knight.Constitution, knight.Precision, knight.UserID, knight.OrderID);

        }

        public void DeleteKnight(int KnightID)
        {
            _context.DeleteKnight(KnightID);
        }

        public void DeleteKnight(KnightBLL users)
        {
            _context.DeleteKnight(users.KnightID);
        }
        public int ObtainKnightCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.ObtainKnightCount();
            return proposedReturnValue;
        }
        public List<KnightBLL> GetKnights(int skip, int take)
        {
            List<KnightBLL> ProposedReturnValue = new List<KnightBLL>();
            List<KnightDAL> ListOfDataLayerObjects = _context.GetKnights(skip, take);
            foreach (KnightDAL role in ListOfDataLayerObjects)
            {
                KnightBLL BusinessObject = new KnightBLL(role);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        #endregion Knights
    }
}
