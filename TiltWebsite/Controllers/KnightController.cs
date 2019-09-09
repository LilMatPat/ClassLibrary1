using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiltWebsite.App_Start;
using TiltWebsite.Models;

namespace TiltWebsite.Controllers
{
    public class KnightController : Controller
    {
        // GET: Knight
        public ActionResult Index()
        {

            List<KnightBLL> Model = new List<KnightBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.PageNumber = 0;
                    ViewBag.PageSize = ApplicationConfig.DefaultPageSize;
                    ViewBag.TotalKnightCount = ctx.ObtainKnightCount();
                    Model = ctx.GetKnights(0,20);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }

            return View(Model); // model is list of roles, name of view is same as method name
        }
        [MustBeLoggedIn]
        // GET: Knight/Details/5
        public ActionResult Details(int id)
        {
            KnightBLL Knight;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                   Knight = ctx.FindKnightByID(id);
                    if (null == Knight)
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
            return View(Knight);
        }
        [MustBeLoggedIn]
        // GET: Knight/Create
        public ActionResult Create()
        {
            KnightBLL defKnight = new KnightBLL();
            defKnight.RoleID = 0;
            return View(defKnight);
        }

        // POST: Knight/Create
        [HttpPost]
        public ActionResult Create(KnightBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateKnight(collection);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }
        [MustBeLoggedIn]
        // GET: Knight/Edit/5
        public ActionResult Edit(int id)
        {
            KnightBLL Knight;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    Knight = ctx.FindKnightByID(id);
                    if (null == Knight)
                    {
                        return View("ItemNotFound"); // BKW make this view
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            return View(Knight);
        }

        // POST: Knight/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,string KnightName, int Strength, int Dexterity, int Constitution, int Precision,int UserID, int OrderID)
        {

            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.JustUpdateKnight(id, KnightName, Strength, Dexterity, Constitution, Precision, UserID, OrderID);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }
        [MustBeLoggedIn]
        // GET: Knight/Delete/5
        public ActionResult Delete(int id)
        {
            KnightBLL knight;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    knight = ctx.FindKnightByID(id);
                    if (null == knight)
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
            return View(knight);
        }

        // POST: Knight/Delete/5
        [HttpPost]
       
        public ActionResult Delete(int id, KnightBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.DeleteKnight(id);
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
            List<KnightBLL> Model = new List<KnightBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalKnightCount = ctx.ObtainKnightCount();
                    Model = ctx.GetKnights(PageN * PageS, PageS);
                }
                return View("Index", Model);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }

        }
    }
}
