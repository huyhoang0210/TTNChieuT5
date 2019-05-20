using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNChieuT5.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace TTNChieuT5.Controllers
{
    public class ManageProductsController : Controller
    {
        OnlShopDbContext db = new OnlShopDbContext();


        // GET: ManageProducts
        public ActionResult Index(int ? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var lst = db.SanPhams.ToList().OrderBy(n=>n.TenSanPham).ToPagedList(pageNumber,pageSize);
            return View(lst);
        }
        public ActionResult Insert()
        {
            ViewBag.IDDanhMuc=db.DanhMucSanPhams.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Insert(SanPham sp,HttpPostedFileBase fileUpLoad)
        {
            
            if (fileUpLoad.ContentLength == 0)
            {
                ViewBag.ThongBao = "Bạn chưa chọn ảnh";
                return View();
            }
            if (ModelState.IsValid)
            {
                string _fileName = Path.GetFileName(fileUpLoad.FileName);
                string _path = Path.Combine(Server.MapPath("/Images"), _fileName);
                fileUpLoad.SaveAs(_path);

                sp.HinhAnh = fileUpLoad.FileName;

                db.SanPhams.Add(sp);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
           
        }
        public ActionResult Update(int id)
        {

            return View();
        }
    }
}