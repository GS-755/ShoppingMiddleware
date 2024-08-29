namespace ShoppingMiddleware.Controllers
{
    using ShoppingMiddleware.Models;
    using ShoppingMiddleware.Models.Flutter;
    using System.Data.Entity;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var nguoiDung = db.NguoiDung.Include(n => n.PhanQuyen);
            return View(await nguoiDung.ToListAsync());
        }



        [HttpGet]        
        public ActionResult LoadPartial(string partialViewName)
        {

            if (partialViewName == "Nguoidung")
            {
                var nguoiDung = db.NguoiDung.Include(n => n.PhanQuyen);
                return PartialView("Nguoidung", nguoiDung);
            }
            else if (partialViewName == "test")
            {
                return PartialView("test");
            }
            else if (partialViewName == "ProductList")
            {
                var sanPhams = db.SanPham
                        .Include(s => s.LoaiSP)
                        .Include(s => s.MauSac)
                        .Include(s => s.ThuongHieu)
                        .Include(s => s.TrangThai)
                        .Include(s => s.ChiTiet_SP.Select(c => c.KichThuoc))
                        .Include(s => s.HinhAnh)
                        .Include(s => s.DanhGia)
                        .ToList();

                var productInformations = sanPhams.Select(sp => new ProductInformations
                {
                    // SanPham
                    IDSP = sp.IDSP,
                    TenSP = sp.TenSP,

                    // ChiTiet_SP
                    MoTa = sp.ChiTiet_SP.FirstOrDefault()?.MoTa,
                    GiaBan      = sp.ChiTiet_SP.FirstOrDefault()?.GiaBan ?? 0,
                    GiaMua      = sp.ChiTiet_SP.FirstOrDefault()?.GiaMua ?? 0,
                    SoLuong     = sp.ChiTiet_SP.FirstOrDefault()?.SoLuong ?? 0,
                    IDKichThuoc = sp.ChiTiet_SP.FirstOrDefault()?.KichThuoc.IDKichThuoc ?? 0,
                    KichThuoc   = sp.ChiTiet_SP.FirstOrDefault()?.KichThuoc.Sodo,
                    DonVi       = sp.ChiTiet_SP.FirstOrDefault()?.KichThuoc.DonVi,

                    // ThuongHieu
                    IDThuongHieu = sp.ThuongHieu.IDThuongHieu,
                    TenThuongHieu = sp.ThuongHieu.TenThuongHieu,

                    // NhanVien
                    TenNV = sp.NhanVien.TenNV,

                    // LoaiSP
                    IDLoai = sp.LoaiSP.IDLoai,
                    TenLoaiSP = sp.LoaiSP.TenLoai,

                    // MauSac
                    IDMau = sp.MauSac.IDMau,
                    TenMau = sp.MauSac.TenMau,

                    // HinhAnh
                    HinhAnhs = sp.HinhAnh.Select(h => h.TenHinh).ToList(),

                    // TrangThai
                    IDTrangThai = sp.TrangThai.IDTrangThai,
                    TenTrangThai = sp.TrangThai.TenTrangThaI,

                    // DanhGia
                    DanhGias = sp.DanhGia.ToList(),

                    // CT_DonDatHang
                    CT_DonDatHangs = sp.CT_DonDatHang.ToList()
                })
                .ToList(); 
                return PartialView("ProductList", productInformations);
            }

            return PartialView("Error");
        }
    }
}
