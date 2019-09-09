using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{ 
 public class KnightBLL
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

    public KnightBLL()
    {

    }

    public KnightBLL(DataAccessLayer.KnightDAL dal)
    {
        this.KnightID = dal.KnightID;
        this.KnightName = dal.KnightName;
        this.Strength = dal.Strength;
        this.Dexterity = dal.Dexterity;
        this.Constitution = dal.Constitution;
        this.Precision = dal.Precision;
        this.UserID = dal.UserID;
        this.OrderID = dal.OrderID;

    }

    public override string ToString()
    {
        return $"KnightID:{KnightID} KnightName:{KnightName} Strength:{Strength} Dexterity:{Dexterity} Constitution:{Constitution} Precision: {Precision} UserID:{UserID} OrderID:{OrderID}";
    }
}
}