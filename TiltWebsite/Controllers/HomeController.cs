using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TiltWebsite.Models;

namespace TiltWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            // displays empty login screen with predefined returnURL
            LoginModel m = new LoginModel();
            m.message = TempData["Message"]?.ToString() ?? "";
            m.ReturnURL = TempData["ReturnURL"]?.ToString() ?? @"~/Home";
            m.Username = "genericuser";
            m.Password = "genericpassword";

            return View(m);
        }
        [HttpPost]
        public ActionResult Login(LoginModel info)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                if(!ModelState.IsValid)
                {
                    return View(info);
                }
                UserBLL user = ctx.FindUserByUsername(info.Username);
                if (user == null)
                {
                    info.message = $"The Username '{info.Username}' does not exist in the database";
                    return View(info);
                }
                string actual = user.Password;
                //string potential = user.Salt + info.Password;
                string potential = info.Password;
                //bool validateduser = System.Web.Helpers.Crypto.VerifyHashedPassword(actual,potential);
                bool validateduser = actual == potential;
                if (validateduser)
                {
                    Session["AUTHUsername"] = user.Username;
                    Session["AUTHRoles"] = user.RoleID.ToString();
                    return Redirect(info.ReturnURL);
                }
                info.message = "The password was incorrect";
                return View(info);
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("AUTHUsername");
            Session.Remove("AUTHRoles");
            return RedirectToAction("Index");
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel info)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                UserBLL user = ctx.FindUserByUsername(info.Username);
                if (user != null)
                {
                    info.Message = $"The Username'{info.Username}' already exists in the database";
                    return View(info);
                }
                
                else
                {
                    ctx.CreateUser(info.Username,info.EMail,info.Password,"asdf12345",5);
                    return RedirectToAction("Index");
                }
            }

        }
        public ActionResult Hash()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("NotLoggedIn");

            }
            if (User.Identity.AuthenticationType.StartsWith("HASHED"))
            {
                return View("AlreadyHashed");
            }
            if (User.Identity.AuthenticationType.StartsWith("IMPERSONATED"))
            {
                return View("ActionNotAllowed");
            }
            using (ContextBLL ctx = new ContextBLL())
            {
               UserBLL user = ctx.FindUserByEmailAddress(User.Identity.Name);
                if (user == null)
                {
                    Exception Message = new Exception($"The Username '{User.Identity.Name}' does not exist in the database");
                    ViewBag.Exception = Message;
                    return View("Error");
                }
                user.Salt = System.Web.Helpers.Crypto.GenerateSalt(SymbolicConstants.SaltSize);
                user.Hash = System.Web.Helpers.Crypto.HashPassword(user.Hash + user.Salt);
                ctx.JustUpdateUser(user);

                string ValidationType = $"HASHED:({user.UserID})";

                Session["AUTHEmailAddress"] = user.EmailAddress;
                Session["AUTHRoles"] = user.RoleName;
                Session["AUTHTYPE"] = ValidationType;

                return RedirectToAction("Index", "Home");
            }

        }
    }
}

