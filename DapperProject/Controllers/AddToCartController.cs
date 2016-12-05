using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperProject.Models;
using System.Data;
using System.Data.SqlClient;
using MobileDAL.cs;

namespace DapperProject.Controllers
{
    public class AddToCartController : Controller
    {
        DataTable dt;
        MobiledetailDAL _mdal = new MobiledetailDAL();
        // GET: AddToCart
        public ActionResult Add( Mobiles mo)
        {
            
            if (Session["cart"]==null)
            {
                List<Mobiles> li = new List<Mobiles>();

                li.Add(mo);
                Session["cart"] = li;
                ViewBag.cart = li.Count();

               
                    Session["count"] = 1;


            }
            else
            {
                List<Mobiles> li = (List<Mobiles>)Session["cart"];
                li.Add(mo);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }
            return RedirectToAction("Index", "Home");

           
        }

        public ActionResult Myorder()
        {
            
            return View((List<Mobiles>)Session["cart"]);

        }

        public ActionResult Remove(Mobiles mob)
        {
            List<Mobiles> li = (List<Mobiles>)Session["cart"];
            li.RemoveAll(x=>x.slno==mob.slno);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");
            //return View();
        }
    }
}