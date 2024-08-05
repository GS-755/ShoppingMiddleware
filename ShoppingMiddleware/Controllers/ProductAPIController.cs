using System.Net;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Data.Entity;
using System.Threading.Tasks;
using ShoppingMiddleware.Models;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;
using static ShoppingMiddleware.Models.DTOModel.DBShopingDTOModel;

namespace ShoppingMiddleware.Controllers
{
    public class ProductAPIController : ApiController
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

        // GET: api/ProductAPI
        /// <summary>
        /// Đã sài được. :3 IQueryable<ProductDTO> 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult CheckCookie()
        {
            string sessionId = "vcl";

            var cookie = Request.Headers.GetCookies("userInfo").FirstOrDefault();
            if (cookie != null)
            {
                sessionId = cookie["session-id"].Value;

                var message = $" cookie đã le chị*h: {cookie} - " +
                    $" sessionId: {sessionId}";
                return Ok(message);
            }
            else
                return Unauthorized();

            //return db.SanPham.Select(sp => new ProductDTO
            //{
            //    IDSP = sp.IDSP,
            //    TenSP = sp.TenSP,
            //    IDThuongHieu = sp.IDThuongHieu,
            //    IDLoai = sp.IDLoai,
            //    IDMau = sp.IDMau,
            //    IDTrangThai = sp.IDTrangThai,
            //    IDNV = sp.IDNV
            //});
        }

        [HttpGet]
        // GET: api/ProductAPI
        /// <summary>
        /// Đã sài được. :3 IQueryable<ProductDTO> 
        /// </summary>
        /// <returns></returns>
        public IQueryable<ProductDTO> GetListproduct()
        {

            //var cookie = Request.Headers.GetCookies("userInfo").FirstOrDefault();
            //if (cookie == null)
            //{
            //    return Unauthorized();
            //}
            var products = db.SanPham.Select(sp => new ProductDTO
            {
                IDSP = sp.IDSP,
                TenSP = sp.TenSP,
                IDThuongHieu = sp.IDThuongHieu,
                IDLoai = sp.IDLoai,
                IDMau = sp.IDMau,
                IDTrangThai = sp.IDTrangThai,
                IDNV = sp.IDNV
            });

            return db.SanPham.Select(sp => new ProductDTO
            {
                IDSP = sp.IDSP,
                TenSP = sp.TenSP,
                IDThuongHieu = sp.IDThuongHieu,
                IDLoai = sp.IDLoai,
                IDMau = sp.IDMau,
                IDTrangThai = sp.IDTrangThai,
                IDNV = sp.IDNV
            });
        }

        // GET: api/ProductAPI/5
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> GetSanPham(int id)
        {
            var sanPham = await db.SanPham
                .Where(sp => sp.IDSP == id)
                .Select(sp => new ProductDTO
                {
                    IDSP = sp.IDSP,
                    TenSP = sp.TenSP,
                    // Chọn các thuộc tính cần thiết khác
                })
                .FirstOrDefaultAsync();

            if (sanPham == null)
            {
                return NotFound();
            }

            return Ok(sanPham);
        }

        // PUT: api/ProductAPI/5
        [HttpPost]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSanPham(int id, ProductDTO sanPhamDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanPhamDTO.IDSP)
            {
                return BadRequest();
            }

            var sanPham = await db.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            sanPham.TenSP = sanPhamDTO.TenSP;
            // Cập nhật các thuộc tính khác

            db.Entry(sanPham).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductAPI
        [HttpPost]
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> PostProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            SanPham sp = new SanPham
            {
                TenSP = productDTO.TenSP,
                IDThuongHieu = productDTO.IDThuongHieu,
                IDLoai = productDTO.IDLoai,
                IDMau = productDTO.IDMau,
                IDTrangThai = productDTO.IDTrangThai,
                IDNV = productDTO.IDNV
            };

            db.SanPham.Add(sp);
            await db.SaveChangesAsync();

            if (sp == null)
            {
                return NotFound();
            }

            // Return the created entity
            // return CreatedAtRoute("DefaultApi", new { id = sanPham.IDSP }, productDTO);
            return Ok(sp);
        } 

        // DELETE: api/ProductAPI/5
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> DeleteSanPham(int id)
        {
            var sanPham = await db.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            db.SanPham.Remove(sanPham);
            await db.SaveChangesAsync();

            return Ok(new ProductDTO
            {
                IDSP = sanPham.IDSP,
                TenSP = sanPham.TenSP,
                IDThuongHieu = sanPham.IDThuongHieu,
                IDLoai = sanPham.IDLoai,
                IDMau = sanPham.IDMau,
                IDTrangThai = sanPham.IDTrangThai,
                IDNV = sanPham.IDNV
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanPhamExists(int id)
        {
            return db.SanPham.Count(e => e.IDSP == id) > 0;
        }
    }
}