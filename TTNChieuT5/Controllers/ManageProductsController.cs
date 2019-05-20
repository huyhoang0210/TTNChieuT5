using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNChieuT5.Models;
using PagedList;
using PagedList.Mvc;


namespace TTNChieuT5.Controllers
{
    public class ManageProductsController : Controller
    {
        OnlShopDbContext db = new OnlShopDbContext();


        // GET: ManageProducts
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult PetFoodPartialView()
        {
            ViewBag.PetFood = db.SanPhams.Where(n => n.DanhMucSanPham.IDDanhMuc == 1 || n.DanhMucSanPham.IDDanhMuc == 2).ToList();
            return PartialView();
        }
        public ActionResult PetDressPartialView()
        {
            var lst = db.SanPhams.Where(n => n.DanhMucSanPham.IDDanhMuc == 3 || n.DanhMucSanPham.IDDanhMuc == 4).ToList();
            return PartialView(lst);
        }
        public ActionResult PetSupPortPartialView()
        {
            var lst = db.SanPhams.Where(n => n.DanhMucSanPham.IDDanhMuc == 5 || n.DanhMucSanPham.IDDanhMuc == 6).ToList();
            return PartialView(lst);
        }
    }
}