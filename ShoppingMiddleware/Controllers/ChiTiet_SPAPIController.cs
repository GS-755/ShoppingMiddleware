using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ShoppingMiddleware.Models;
using static ShoppingMiddleware.Models.DTOModel.DBShopingDTOModel;

namespace ShoppingMiddleware.Controllers
{
    public class ChiTiet_SPAPIController : ApiController
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();


        //[HttpGet]
        //public IQueryable<DetailProductDTO> GetListproduct()
        //{
        //    var DetailProduct = db.ChiTiet_SP.Select(sp => new DetailProductDTO
        //    {
        //        IDSP = sp.IDSP,
        //        IDKichThuoc = sp.IDKichThuoc,
        //        GiaBan = sp.GiaBan,
        //        GiaMua = sp.GiaMua,
        //        SoLuong = sp.SoLuong,
        //    });

        //    return DetailProduct;
        //}

        //// GET: api/ChiTiet_SPAPI/5
        //[ResponseType(typeof(ChiTiet_SP))]
        //public async Task<IHttpActionResult> GetChiTiet_SP(int id)
        //{
        //    ChiTiet_SP chiTiet_SP = await db.ChiTiet_SP.FindAsync(id);
        //    if (chiTiet_SP == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(chiTiet_SP);
        //}

        //// PUT: api/ChiTiet_SPAPI/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutChiTiet_SP(int id, ChiTiet_SP chiTiet_SP)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != chiTiet_SP.IDSP)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(chiTiet_SP).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ChiTiet_SPExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/ChiTiet_SPAPI
        //[ResponseType(typeof(ChiTiet_SP))]
        //public async Task<IHttpActionResult> PostChiTiet_SP(ChiTiet_SP chiTiet_SP)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ChiTiet_SP.Add(chiTiet_SP);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ChiTiet_SPExists(chiTiet_SP.IDSP))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = chiTiet_SP.IDSP }, chiTiet_SP);
        //}

        //// DELETE: api/ChiTiet_SPAPI/5
        //[ResponseType(typeof(ChiTiet_SP))]
        //public async Task<IHttpActionResult> DeleteChiTiet_SP(int id)
        //{
        //    ChiTiet_SP chiTiet_SP = await db.ChiTiet_SP.FindAsync(id);
        //    if (chiTiet_SP == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ChiTiet_SP.Remove(chiTiet_SP);
        //    await db.SaveChangesAsync();

        //    return Ok(chiTiet_SP);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ChiTiet_SPExists(int id)
        //{
        //    return db.ChiTiet_SP.Count(e => e.IDSP == id) > 0;
        //}
    }
}