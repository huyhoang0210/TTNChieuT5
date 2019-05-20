using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNChieuT5.Models;
namespace ThucTapNhom.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        OnlShopDbContext db = new OnlShopDbContext();

        public ActionResult SanPham()
        {
            return View();
        }
        public ActionResult SanPhamQuanAo()
        {
            List<SanPham> m = db.SanPhams.Where(n => n.LoaiSanPham == 3 || n.LoaiSanPham == 4).ToList();
            return View(m);
        }
        public ActionResult SanPhamThucAn()
        {
            List<SanPham> m = db.SanPhams.Where(n => n.LoaiSanPham == 1 || n.LoaiSanPham == 2).ToList();
            return View(m);
        }
        public ActionResult SanPhamPhuKien()
        {
            List<SanPham> m = db.SanPhams.Where(n => n.LoaiSanPham == 5 || n.LoaiSanPham == 6).ToList();
            return View(m);
        }
        public ActionResult CTSanPham(int ma)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.IDSanPham == ma);
            return View(sp);
        }
    }
}