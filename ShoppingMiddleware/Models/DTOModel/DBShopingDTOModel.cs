using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingMiddleware.Models.DTOModel
{
    public class DBShopingDTOModel
    {
        public class DetailProductDTO
        {
            public string MoTa { get; set; }
            public int GiaBan { get; set; }
            public int GiaMua { get; set; }
            public int SoLuong { get; set; }
            public int IDSP { get; set; }
            public int IDKichThuoc { get; set; }
        }

        public class DetailUserAddressDTO
        {
            public string TenDuong { get; set; }
            public string SoNha { get; set; }
            public int IDND { get; set; }
            public int IDdiaChi { get; set; }
        }
        public class DetailOrderDTO
        {
            public int soluong { get; set; }
            public int ThanhTien { get; set; }
            public int IDDonDatHang { get; set; }
            public int IDSP { get; set; }
        }
        public class ReviewProductDTO
        {
            public System.DateTime ThoiGian { get; set; }
            public int LuotThich { get; set; }
            public int IDDanhGia { get; set; }
            public string BinhLuan { get; set; }
            public int IDND { get; set; }
            public int IDSP { get; set; }
        }
        public class UserAddressDTO
        {
            public int IDdiaChi { get; set; }
            public string TenDiaChi { get; set; }
            public int IDThanhPho { get; set; }
            public int IDtinh { get; set; }
        }
        public class OrderDTO
        {
            public System.DateTime NgayDat { get; set; }
            public int IDDonDatHang { get; set; }
            public int PhiGiaoHang { get; set; }
            public int TongTien { get; set; }
            public string TrangThai { get; set; }
            public string DiaChiNhanHang { get; set; }
            public string SDTNhanHang { get; set; }
            public int IDND { get; set; }
        }
        public class ProductImageDTO
        {
            public int IDHinh { get; set; }
            public string TenHinh { get; set; }
            public int IDSP { get; set; }
        }
        public class ProductSizeDTO
        {
            public int IDKichThuoc { get; set; }
            public string Sodo { get; set; }
            public string DonVi { get; set; }
        }
        public class CategoryDTO
        {

            public int IDLoai { get; set; }
            public string TenLoai { get; set; }
        }
        public class ColorDTO
        {
            public int IDMau { get; set; }
            public string TenMau { get; set; }
        }
        public class UserDTO
        {

            public int IDND { get; set; }
            public string TenND { get; set; }
            public string Ho_TenDem { get; set; }
            public string Email { get; set; }
            public string GioiTinh { get; set; }
            public string SDT { get; set; }
            public Nullable<int> Tuoi { get; set; }
            public string MatKhau { get; set; }
            public string TenDangNhap { get; set; }
        }
        public class EmployeeDTO
        {

            public int IDNV { get; set; }
            public string TenNV { get; set; }
            public string SDT { get; set; }
            public string Email { get; set; }
            public bool TrangThaiNV { get; set; }
            public int IDQuyen { get; set; }
        }
        public class RoleDTO
        {
            public int IDQuyen { get; set; }
            public string TenQuyen { get; set; }
        }
        public class ProductDTO
        {
            public int IDSP { get; set; }
            public string TenSP { get; set; }
            public int IDThuongHieu { get; set; }
            public int IDLoai { get; set; }
            public int IDMau { get; set; }
            public int IDTrangThai { get; set; }
            public int IDNV { get; set; }
        }
        public class CityDTO
        {
            public int IDThanhPho { get; set; }
            public string TenThanhPho { get; set; }
        }
        public class trademarkDTO
        {
            public int IDThuongHieu { get; set; }
            public string TenThuongHieu { get; set; }
        }
        public class State
        {
            public int IDTrangThai { get; set; }
            public string TenTrangThaI { get; set; }
        }
        public class provinceDTO
        {
            public int IDtinh { get; set; }
            public string TenTinh { get; set; }
        }
    }
}