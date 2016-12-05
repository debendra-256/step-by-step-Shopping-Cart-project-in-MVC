using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperProject.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using MobileDAL.cs;
using System.Reflection;

namespace DapperProject.Controllers
{
    public class DetailsController : Controller
    {
        MobiledetailDAL _mdal = new MobiledetailDAL();
        DataTable dt;
       
        public DetailsController()
        {
         
        }

       
      public ActionResult Index()
        {
            string mycmd = "select * from productDetails";
            dt = new DataTable();

            dt = _mdal.SelactAll(mycmd);


                List<productDetails> list = new List<productDetails>();
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                productDetails pdet = new productDetails();
                pdet.slno = Convert.ToInt32(dt.Rows[i]["slNo"]);
                pdet.productName = dt.Rows[i]["productName"].ToString();
                pdet.productDetail = dt.Rows[i]["productDetail"].ToString();
                pdet.price =Convert.ToInt32(dt.Rows[i]["price"]);
                list.Add(pdet);
            }
            return View(list);
            

            }

        public ActionResult DisplayProducts()
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
                list.Add(mob);
            }
            return View(list);

        }
            
        }
    }
