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
    
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            this.CT_DonDatHang = new HashSet<CT_DonDatHang>();
        }
    
        public System.DateTime NgayDat { get; set; }
        public int IDDonDatHang { get; set; }
        public int PhiGiaoHang { get; set; }
        public int TongTien { get; set; }
        public string TrangThai { get; set; }
        public string DiaChiNhanHang { get; set; }
        public string SDTNhanHang { get; set; }
        public int IDND { get; set; }
        public int IDNV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DonDatHang> CT_DonDatHang { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
