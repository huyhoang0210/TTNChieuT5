using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNChieuT5.Models;
namespace ThucTapNhom.Controllers
{
    public class HomeController : Controller
    {
        OnlShopDbContext db = new OnlShopDbContext();
        public ActionResult Index()
        {
            var lstSanPham = db.SanPhams.Take(12).ToList();
            return View(lstSanPham);
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

        public ActionResult TestAdmin()
        {
            return View();
        }
    }
}