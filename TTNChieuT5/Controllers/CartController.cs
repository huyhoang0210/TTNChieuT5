using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTNChieuT5.Models;


namespace TTNChieuT5.Controllers
{
    public class CartController : Controller
    {
        OnlShopDbContext db = new OnlShopDbContext();



        public List<CartItem> GetCartItem()
        {
            List<CartItem> List = Session["CartSession"] as List<CartItem>;
            if (List == null)
            {
                List<CartItem> ListItem = new List<CartItem>();
                Session["CartSession"] = ListItem;
                return ListItem;
            }

            return List;
        }

        public ActionResult ViewCart()
        {
            List<CartItem> lst = GetCartItem();
            return View(lst);
        }

        public ActionResult AddToCart1(int _IdSanPham, string _url)
        {
            var product = db.SanPhams.SingleOrDefault(n => n.IDSanPham == _IdSanPham);
            if (product == null)
            {
                return RedirectToAction("");
            }

            CartItem item = new CartItem(product.IDSanPham);

            List<CartItem> List = GetCartItem();
            CartItem newItem = List.SingleOrDefault(n => n.IdSanPham == item.IdSanPham);
            if (newItem == null)
            {
                List.Add(item);
                return Redirect(_url);
            }
            newItem.SoLuong++;

            return Redirect(_url);
        }

        public ActionResult AddToCart2(int _IdSanPham, int _SoLuong, string _url)
        {
            var product = db.SanPhams.SingleOrDefault(n => n.IDSanPham == _IdSanPham);
            if (product == null)
            {
                return RedirectToAction("");
            }

            CartItem item = new CartItem(product.IDSanPham, _SoLuong);
            if (item.SoLuong > product.SoLuong)
            {
                ViewBag.ThongBao = "Số lượng sản phẩm không đủ !";
                return Redirect(_url);
            }

            List<CartItem> List = GetCartItem();
            CartItem newItem = List.SingleOrDefault(n => n.IdSanPham == item.IdSanPham);
            if (newItem == null)
            {
                List.Add(item);
                return RedirectToAction("Index","Home");
            }
            newItem.SoLuong += item.SoLuong;

            return RedirectToAction("Index", "Home");
        }
    }
}