using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTNChieuT5.Models
{
    public class CartItem
    {
        OnlShopDbContext db = new OnlShopDbContext();

        public int IdSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public int? SoLuong { get; set; }
        public int? DonGia { get; set; }
        public int? ThanhTien { get { return SoLuong * DonGia; } }

        public CartItem(int _idSanPham)
        {
            IdSanPham = _idSanPham;
            SanPham product = db.SanPhams.Find(_idSanPham);
            TenSanPham = product.TenSanPham;
            HinhAnh = product.HinhAnh;
            SoLuong = 1;
            DonGia = product.Gia;
        }
        public CartItem(int _idSanPham, int _SoLuong)
        {
            IdSanPham = _idSanPham;
            SanPham product = db.SanPhams.Find(_idSanPham);
            TenSanPham = product.TenSanPham;
            HinhAnh = product.HinhAnh;
            SoLuong = _SoLuong;
            DonGia = product.Gia;
        }
    }
}