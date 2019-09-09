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
    public class OrderController : Controller
    {
        // GET: Order
        
        public ActionResult Index()
        {

            List<OrderBLL> Model = new List<OrderBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.PageNumber = 0;
                    ViewBag.PageSize = ApplicationConfig.DefaultPageSize;
                    ViewBag.TotalOrderCount = ctx.ObtainOrderCount();
                    Model = ctx.GetOrders(0, ViewBag.PageSize);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }

            return View(Model); 
        }
        [MustBeLoggedIn]
        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            OrderBLL Order;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    Order = ctx.FindOrderByID(id);
                    if (null == Order)
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
            return View(Order);
        }
        [MustBeLoggedIn]
        // GET: Order/Create
        public ActionResult Create()
        {
            OrderBLL defOrder = new OrderBLL();
            defOrder.OrderID = 0;
            return View(defOrder);
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateOrder(collection);
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
        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            OrderBLL Order;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    Order = ctx.FindOrderByID(id);
                    if (null == User)
                    {
                        return View("ItemNotFound"); // BKW make this view
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error",ex);
            }
            return View(Order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrderBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.JustUpdateOrder(collection);
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
        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            OrderBLL Order;
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    Order = ctx.FindOrderByID(id);
                    if (null == Order)
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
            return View(Order);
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OrderBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.DeleteOrder(id);
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
            List<OrderBLL> Model = new List<OrderBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalOrderCount = ctx.ObtainOrderCount();
                    Model = ctx.GetOrders(PageN * PageS, PageS);
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
