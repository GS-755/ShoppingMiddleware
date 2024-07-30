using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static ShoppingMiddleware.Models.Flutter.FlutterServiceDTOModel;
using System.Web.Http.Description;
using ShoppingMiddleware.Models;
using static ShoppingMiddleware.Models.DTOModel.DBShopingDTOModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Swashbuckle.Swagger;
using System.Web.WebPages;
using System.Xml.Linq;
using System.Web.Helpers;

namespace ShoppingMiddleware.Controllers
{
    public class FlutterAPIServiceController : ApiController
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();
        private CookieHeaderValue serverCookie;

        /// <summary>
        /// Get Detail User Flutter 
        /// </summary>
        /// <returns>List Product</returns>
        // GET: api/NguoiDungs/5
        [ResponseType(typeof(UserDTO))]
        [Route("api/userDetail")]
        public async Task<IHttpActionResult> GetUserDetails()
        {
            try {
                
            CookieHeaderValue ck = Request.Headers.GetCookies("userInfo").FirstOrDefault();
                if (ck == null)
                {
                    return Unauthorized();
                }
                //HttpCookie ck = HttpContext.Current.Response.Cookies.Get("userInfo");

                if (ck.ToString().Length == 0)
                {
                    return Unauthorized();
                }
                string result = ck.ToString().Replace("userInfo=", "");
                NguoiDung nguoiDung = await db.NguoiDung.FindAsync(int.Parse(result));
                if (nguoiDung == null){
                    return Ok("con cặc");
                }

                return Ok(new UserDTO {
                    IDND = nguoiDung.IDND,
                    TenND = nguoiDung.TenND,
                    Ho_TenDem = nguoiDung.Ho_TenDem,
                    Email = nguoiDung.Email,
                    GioiTinh = nguoiDung.GioiTinh,
                    SDT = nguoiDung.SDT,
                    Tuoi = nguoiDung.Tuoi,
                    MatKhau = nguoiDung.MatKhau,
                    TenDangNhap = nguoiDung.TenDangNhap
                });

            }
            catch
            {
                return Unauthorized();
            }
        }



        /// <summary>
        /// Get Detail User Flutter 
        /// </summary>
        /// <returns>List Product</returns>
        // GET: api/NguoiDungs/5
        [ResponseType(typeof(CategoryDTO))]
        [Route("api/CategoryDTO")]
        public IHttpActionResult GetCategorry()
        {
                var categorys = db.LoaiSP.Select(sp => new CategoryDTO
                {
                    IDLoai = sp.IDLoai,
                    TenLoai = sp.TenLoai
                }).ToList();
            return Ok(categorys);
        }


        /// <summary>
        /// Get Detail User Flutter 
        /// </summary>
        /// <returns>List Product</returns>
        // GET: api/NguoiDungs/5
        [ResponseType(typeof(void))]
        [Route("api/logout")]
        public async Task<IHttpActionResult> logout()
        {
            CookieHeaderValue ck = Request.Headers.GetCookies("userInfo").FirstOrDefault();
            if(ck.ToString() != null)
            {
                ck.Cookies.Clear();

                return Ok("chim kút");
            }
            else
            {
                return Ok("bạn chưa đang nhập!");
            }

        }



        /// <summary>
        /// Get list Card Item for home page Flutter 
        /// </summary>
        /// <returns>List Product</returns>
        // GET: api/ProductServices
        [HttpGet]
        [Route("api/DetailProduct")]
        public async Task<FlutterDetailProductDTO> GetDetailProduct(int id)
        {
            ChiTiet_SP chiTiet_SP = db.ChiTiet_SP.Where(i => i.IDSP == id).FirstOrDefault();
            KichThuoc kichThuoc = db.KichThuoc.Where(i => i.IDKichThuoc == chiTiet_SP.IDKichThuoc).FirstOrDefault();

            FlutterDetailProductDTO query = new FlutterDetailProductDTO();

            query.IDSP = chiTiet_SP.IDSP;
            query.MoTa = chiTiet_SP.MoTa;
            query.SoLuong = chiTiet_SP.SoLuong;
            query.DonVi = kichThuoc.DonVi;
            query.SoLuong = chiTiet_SP.SoLuong;
            query.GiaMua = chiTiet_SP.GiaMua;
            query.GiaBan = chiTiet_SP.GiaBan;
            query.Sodo = kichThuoc.Sodo;
            return query;
        }

        /// <summary>
        /// Get list Card Item for home page Flutter by category
        /// </summary>
        /// <returns>List Product by Category</returns>
        // GET: api/ProductServices
        [HttpGet]
        [Route("api/ProductByCategory")]
        public IHttpActionResult GetProductByCategory(int categoryId)
        {
            try
            {
                var query = db.SanPham
                    .Where(sp => sp.IDLoai == categoryId)
                    .Select(sp => new FlutterProductCartItemDTO
                    {
                        IDSP = sp.IDSP,
                        TenSP = sp.TenSP,
                        Img_Url = db.HinhAnh
                                    .Where(i => i.IDSP == sp.IDSP)
                                    .Select(i => i.TenHinh)
                                    .FirstOrDefault(),
                        GiaBan = db.ChiTiet_SP
                                    .Where(ct => ct.IDSP == sp.IDSP)
                                    .Select(ct => ct.GiaBan)
                                    .FirstOrDefault(),
                    }).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetProductCart: {ex.Message}");
                return InternalServerError();
            }
        }


        /// <summary>
        /// Get list Card Item for home page Flutter 
        /// </summary>
        /// <returns>List Product</returns>
        // GET: api/ProductServices
        [HttpGet]
        [Route("api/ProductCartItem")]
        public IHttpActionResult GetProductCart()
        {
            try
            {
                var query = db.SanPham
                    .Select(sp => new FlutterProductCartItemDTO
                    {
                        IDSP = sp.IDSP,
                        TenSP = sp.TenSP,
                        Img_Url = db.HinhAnh
                                    .Where(i => i.IDSP == sp.IDSP)
                                    .Select(i => i.TenHinh)
                                    .FirstOrDefault(),
                        GiaBan = db.ChiTiet_SP
                                    .Where(ct => ct.IDSP == sp.IDSP)
                                    .Select(ct => ct.GiaBan)
                                    .FirstOrDefault(),
                    }).ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetProductCart: {ex.Message}");
                return InternalServerError();
            }
        }

        /// <summary>
        /// Get list Card Item for home page Flutter 
        /// </summary>
        /// <returns>User Cookie Token and Id User</returns>
        [HttpPost]
        [Route("api/Login")]
        [ResponseType(typeof(FlutterCookieUser))]
        public async Task<IHttpActionResult> Login(string username, string password)
        {
            try
            {
                username = "user1";
                password = "password1";
                // Kiểm tra tên đăng nhập và mật khẩu
                var user = db.NguoiDung
                    .FirstOrDefault(
                    u => u.TenDangNhap == username.Trim()
                    && u.MatKhau == password.Trim());

                if (user == null)
                {
                    return NotFound();
                }

                UserDTO userDTO = new UserDTO
                {
                    IDND = user.IDND,
                    TenND = user.TenND,
                    TenDangNhap = user.TenDangNhap,
                    MatKhau = user.MatKhau
                };


                // Lấy thông tin user:
                var userInfo = JsonConvert.SerializeObject(userDTO);
                var hashedUserInfo = HashString(userInfo);
                
                // tạo cookie:
                HttpCookie cookie = new HttpCookie("userInfo", userDTO.IDND.ToString());
                //cookie.Values["userInfo"] = userDTO.IDND.ToString();
                
                
                // hạn sử dụng
                cookie.Expires = DateTime.Now.AddMinutes(1);
                
                // thêm cookie:
                HttpContext.Current.Response.Cookies.Add(cookie);



                // DTO cookieUser:
                return Ok(new FlutterCookieUser
                {
                    UserID = userDTO.IDND,
                    Token = hashedUserInfo
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private string HashString(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var builder = new StringBuilder();
                foreach (var @byte in bytes)
                {
                    builder.Append(@byte.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool SanPhamExists(int id)
        {
            return db.SanPham.Count(e => e.IDSP == id) > 0;
        }

    }
}
