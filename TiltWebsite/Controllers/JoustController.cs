using BLL;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiltWebsite.Models;

namespace TiltWebsite.Controllers
{
    public class JoustController : Controller
    {
        // GET: Joust
        //public ActionResult KnightOneIndex(int id)
        //{
        //    try
        //    {
        //        using (ContextBLL ctx = new ContextBLL())
        //        {

        //            int knightcount = ctx.ObtainKnightCount();
        //            var k1 = ctx.GetKnights(0, knightcount);                 
                    
        //            return View(k1);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return View("Error", ex);
        //    }
            
        //}
        [HttpGet]
        [MustBeInRole(Roles = "6,7")]
        public ActionResult Index()
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    int knightcount = ctx.ObtainKnightCount();
                    var k1 = ctx.GetKnights(0, knightcount);

                    return View(k1);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }
        
        [MustBeInRole(Roles = "6,7")]
        public ActionResult Index(int id)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    var CoK = ctx.ObtainKnightCount();
                    var k2 = ctx.GetKnights(0,CoK);
                    return View(k2);
                }
            }
            catch (Exception ex)
            {   
                return View("Error", ex);
            }

        }
        public ActionResult Challenge(int id)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    var CoK = ctx.ObtainKnightCount();
                    UserBLL UserObject = ctx.FindUserByUsername(User.Identity.Name);
                    KnightBLL K2 = ctx.FindKnightByID(id);
                    List<KnightBLL> ListOfKnights = ctx.GetKnightsRelatedToUser( 0, CoK, UserObject.UserID);
                    KnightBLL K1 = ListOfKnights[0];
                    BLL.MeaningFull mc = new BLL.MeaningFull(K1, K2);
                    mc.Joust();
                    return View(mc);
                    
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Joust/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Joust/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Joust/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Joust/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Joust/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Joust/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Joust/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
