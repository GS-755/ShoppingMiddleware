//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingMiddleware.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.CT_DonDatHang = new HashSet<CT_DonDatHang>();
            this.ChiTiet_SP = new HashSet<ChiTiet_SP>();
            this.DanhGia = new HashSet<DanhGia>();
            this.HinhAnh = new HashSet<HinhAnh>();
            this.NguoiDung = new HashSet<NguoiDung>();
        }
    
        public int IDSP { get; set; }
        public string TenSP { get; set; }
        public int IDThuongHieu { get; set; }
        public int IDLoai { get; set; }
        public int IDMau { get; set; }
        public int IDTrangThai { get; set; }
        public int IDNV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DonDatHang> CT_DonDatHang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_SP> ChiTiet_SP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhAnh> HinhAnh { get; set; }
        public virtual LoaiSP LoaiSP { get; set; }
        public virtual MauSac MauSac { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ThuongHieu ThuongHieu { get; set; }
        public virtual TrangThai TrangThai { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguoiDung> NguoiDung { get; set; }
    }
}
