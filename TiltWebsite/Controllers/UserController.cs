using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiltWebsite.App_Start;

namespace TiltWebsite.Controllers
{
    public class UserController : Controller
    {
        List<SelectListItem> GetRoleItems()
        {
            List<SelectListItem> ProposedReturnValue = new List<SelectListItem>();
            using (ContextBLL ctx = new ContextBLL())
            {
                List<RoleBLL> roles = ctx.GetRoles(0, 25);
                foreach (RoleBLL r in roles)
                {
                    SelectListItem x = new SelectListItem();
                    x.Value = r.RoleID.ToString();
                    x.Text = r.RoleName;
                    ProposedReturnValue.Add(x);
                }
            }
            return ProposedReturnValue;
        }
        // GET: User
        public ActionResult Index()
        {

            List<UserBLL> Model = new List<UserBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.PageNumber = 0;
                    ViewBag.PageSize = ApplicationConfig.DefaultPageSize;
                    ViewBag.TotalUserCount = ctx.ObtainOrderCount();
                    Model = ctx.GetUsers(0, 20);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }

            return View(Model); // model is list of roles, name of view is same as method name
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            UserBLL User;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    User = ctx.FindUserByID(id);
                    if (null == User)
                    {
                        return View("ItemNotFound"); // BKW make this view
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(User);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            UserBLL defUser = new UserBLL();
            defUser.UserID = 0;
            ViewBag.Roles = GetRoleItems();
            return View(defUser);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateUser(collection);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            UserBLL User;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    User = ctx.FindUserByID(id);
                    if (null == User)
                    {
                        return View("ItemNotFound"); // BKW make this view
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
            return View(User);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.JustUpdateUser(collection);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            UserBLL User;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    User = ctx.FindUserByID(id);
                    if (null == User)
                    {
                        return View("ItemNotFound"); // BKW make this view
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(User);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.DeleteUser(id);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }
        public ActionResult Page(int? PageNumber, int? PageSize)
        {
            int PageN = (PageNumber.HasValue) ? PageNumber.Value : 0;
            int PageS = (PageSize.HasValue) ? PageSize.Value : ApplicationConfig.DefaultPageSize;
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<UserBLL> Model = new List<UserBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalUserCount = ctx.ObtainUserCount();
                    Model = ctx.GetUsers(PageN * PageS, PageS);
                }
                return View("Index", Model);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }

        }
       
    
        public ActionResult CreateWithKnight()
        {
            return View();
        }

        // POST: TwoLevels/Create
        [HttpPost]
        public ActionResult CreateWithKnight(Models.TwoLevelsModel two)
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


                    ctx.CreateKnight(two.KnightName, two.Strength, two.Dexterity, two.Constitution, two.Precision, newUserID, two.OrderID);
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

