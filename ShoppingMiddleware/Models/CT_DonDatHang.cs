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
    
    public partial class CT_DonDatHang
    {
        public int soluong { get; set; }
        public int ThanhTien { get; set; }
        public int IDDonDatHang { get; set; }
        public int IDSP { get; set; }
    
        public virtual DonDatHang DonDatHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
