using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MobileDAL.cs;
using DapperProject.Models;

namespace DapperProject.Controllers
{
    public class HomeController : Controller
    {
        MobiledetailDAL _mdal = new MobiledetailDAL();
        DataTable dt;
        

        public ActionResult Index()
        {
            string mycmd = "select * from Mobiles";
            dt = new DataTable();

            dt = _mdal.SelactAll(mycmd);


            List<Mobiles> list = new List<Mobiles>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Mobiles mob = new Mobiles();
                mob.slno = Convert.ToInt32(dt.Rows[i]["slNo"]);
                mob.MobileName = dt.Rows[i]["MobileName"].ToString();
                mob.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                mob.Url = dt.Rows[i]["Url"].ToString();
                mob.ZoomUrl= dt.Rows[i]["ZoomUrl"].ToString();
                list.Add(mob);
            }
            return View(list);

        }

        public ActionResult AboutUs()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult EachProductDetails(Mobiles m)
        {
            
            string mycmd = "select m.slNo,m.MobileName,m.price,m.url,md.Features,md.model,md.color,md.SimType from mobiles m inner join MobileDetails md on m.slNo=md.MobileId where m.slNo="+m.slno+"";
            dt = new DataTable();

            dt = _mdal.SelactAll(mycmd);


            List<ProductDetails> list = new List<ProductDetails>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductDetails mob = new ProductDetails();
                mob.slno = Convert.ToInt32(dt.Rows[i]["slNo"]);
                mob.MobileName = dt.Rows[i]["MobileName"].ToString();
                mob.Price = Convert.ToDouble(dt.Rows[i]["Price"]);
                mob.Url = dt.Rows[i]["Url"].ToString();
                mob.Features= dt.Rows[i]["Features"].ToString();
                mob.color = dt.Rows[i]["color"].ToString();
                mob.SimType = dt.Rows[i]["SimType"].ToString();

                list.Add(mob);
            }
           
          
            return View(list);

           

        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}