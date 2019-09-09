using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiltWebsite.Controllers
{
    public class TwoLevelsController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        // POST: TwoLevels/Create
        [HttpPost]
        public ActionResult Create(Models.TwoLevelsModel two)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {


                    string salt = System.Web.Helpers.Crypto.GenerateSalt(10);
                    //string VerifyPhrase = System.Web.Helpers.Crypto.GenerateSalt(100);
                    string hashedpass = System.Web.Helpers.Crypto.HashPassword(salt + two.Password);

                    two.Salt = salt;
                    two.Hash = hashedpass;
                    int newUserID = ctx.CreateUser(two.Username, two.Email, two.Password, two.Hash, two.RoleID);
                                                 

                    ctx.CreateKnight( two.KnightName, two.Strength, two.Dexterity, two.Constitution, two.Precision, newUserID,two.OrderID);
                    return Redirect("~/Home");
                }
            }
            catch (Exception ex) 
            {
                return View("Error", ex);
            }
        }
    }
}
