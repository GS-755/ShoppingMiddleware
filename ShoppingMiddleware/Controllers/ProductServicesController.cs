using ShoppingMiddleware.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using static ShoppingMiddleware.Models.Flutter.FlutterServiceDTOModel;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ShoppingMiddleware.Controllers
{
   
    public class ProductServicesController : ApiController
    {

         private BackendFlutter2024Entities db = new BackendFlutter2024Entities();
        /// <summary>
        /// Get list Card Item for home page Flutter 
        /// </summary>
        /// <returns></returns>
        // GET: api/ProductServices
        [HttpGet]
        [Route("api/ProductServices")]
        public IHttpActionResult GetProductCart()
        {
            try
            {
                var query = db.SanPham
                    .Select(sp => new ProductCartItemDTO
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

        private bool SanPhamExists(int id)
        {
            return db.SanPham.Count(e => e.IDSP == id) > 0;
        }
    }
}
    }
}