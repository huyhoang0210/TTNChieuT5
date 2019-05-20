using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNChieuT5.Models;
namespace ThucTapNhom.Controllers
{
    public class DangNhapController : Controller
    {
        OnlShopDbContext db = new OnlShopDbContext();
        // GET: DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string tk = Request.Form["TaiKhoan"];
            string mk = Request.Form["MatKhau"];
            user taikhoan = db.users.SingleOrDefault(n => n.TaiKhoan == tk && n.MatKhau.Trim() == mk);
            if (taikhoan != null)
            {
                Session["DangNhap"] = taikhoan;
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("DangNhap", "DangNhap");
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(FormCollection f)
        {
            user TaiKhoan = new user();
            TaiKhoan.HoTen = Request.Form["HoTen"];
            TaiKhoan.TaiKhoan = Request.Form["TaiKhoan"];
            TaiKhoan.MatKhau = Request.Form["MatKhau"];
            TaiKhoan.SDT = Request.Form["SDT"];
            TaiKhoan.DiaChi = Request.Form["DiaChi"];
            db.users.Add(TaiKhoan);
            db.SaveChanges();
            return RedirectToAction("DangNhap", "DangNhap");
        }
        public ActionResult DangXuat()
        {
            Session["DangNhap"] = null;
            return RedirectToAction("DangNhap", "DangNhap");
        }
    }
}