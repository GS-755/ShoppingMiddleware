//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;
//using ShoppingMiddleware.Models;

//namespace ShoppingMiddleware.Controllers
//{
//    public class HinhAnhsAPIController : ApiController
//    {
//        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

//        // GET: api/HinhAnhsAPI
//        public IQueryable<HinhAnh> GetHinhAnh()
//        {
//            return db.HinhAnh;
//        }

//        // GET: api/HinhAnhsAPI/5
//        [ResponseType(typeof(HinhAnh))]
//        public async Task<IHttpActionResult> GetHinhAnh(int id)
//        {
//            HinhAnh hinhAnh = await db.HinhAnh.FindAsync(id);
//            if (hinhAnh == null)
//            {
//                return NotFound();
//            }

//            return Ok(hinhAnh);
//        }

//        // PUT: api/HinhAnhsAPI/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutHinhAnh(int id, HinhAnh hinhAnh)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != hinhAnh.IDHinh)
//            {
//                return BadRequest();
//            }

//            db.Entry(hinhAnh).State = EntityState.Modified;

//            try
//            {
//                await db.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!HinhAnhExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/HinhAnhsAPI
//        [ResponseType(typeof(HinhAnh))]
//        public async Task<IHttpActionResult> PostHinhAnh(HinhAnh hinhAnh)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.HinhAnh.Add(hinhAnh);
//            await db.SaveChangesAsync();

//            return CreatedAtRoute("DefaultApi", new { id = hinhAnh.IDHinh }, hinhAnh);
//        }

//        // DELETE: api/HinhAnhsAPI/5
//        [ResponseType(typeof(HinhAnh))]
//        public async Task<IHttpActionResult> DeleteHinhAnh(int id)
//        {
//            HinhAnh hinhAnh = await db.HinhAnh.FindAsync(id);
//            if (hinhAnh == null)
//            {
//                return NotFound();
//            }

//            db.HinhAnh.Remove(hinhAnh);
//            await db.SaveChangesAsync();

//            return Ok(hinhAnh);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool HinhAnhExists(int id)
//        {
//            return db.HinhAnh.Count(e => e.IDHinh == id) > 0;
//        }
//    }
//}