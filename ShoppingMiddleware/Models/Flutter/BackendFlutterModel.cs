using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingMiddleware.Models.Flutter
{
    public class ProductInformations
    {
        // Thông tin sản phẩm cơ bản
        public int IDSP { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public int GiaBan { get; set; }
        public int GiaMua { get; set; }
        public int SoLuong { get; set; }

        public string TenNV { get; set; }

        // Thông tin thương hiệu
        public int IDThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }

        // Thông tin loại sản phẩm
        public int IDLoai { get; set; }
        public string TenLoaiSP { get; set; }

        // Thông tin màu sắc
        public int IDMau { get; set; }
        public string TenMau { get; set; }

        // Thông tin kích thước
        public int IDKichThuoc { get; set; }
        public string KichThuoc { get; set; }
        public string DonVi { get; set; }

        // Thông tin hình ảnh
        public List<string> HinhAnhs { get; set; }

        // Thông tin trạng thái
        public int IDTrangThai { get; set; }
        public string TenTrangThai { get; set; }

        // Thông tin đánh giá
        public List<DanhGia> DanhGias { get; set; }

        // Thông tin chi tiết đơn đặt hàng
        public List<CT_DonDatHang> CT_DonDatHangs { get; set; }
    }
}