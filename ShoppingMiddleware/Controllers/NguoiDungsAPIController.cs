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

namespace ShoppingMiddleware.Controllers
{
    public class NguoiDungsAPIController : ApiController
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

        // GET: api/NguoiDungs
        public IQueryable<NguoiDung> GetNguoiDung()
        {
            return db.NguoiDung;
        }

        // GET: api/NguoiDungs/5
        [ResponseType(typeof(NguoiDung))]
        public async Task<IHttpActionResult> GetNguoiDung(int id)
        {
            NguoiDung nguoiDung = await db.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return Ok(nguoiDung);
        }

        // PUT: api/NguoiDungs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNguoiDung(int id, NguoiDung nguoiDung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoiDung.IDND)
            {
                return BadRequest();
            }

            db.Entry(nguoiDung).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungExists(id))
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

        // POST: api/NguoiDungs
        [ResponseType(typeof(NguoiDung))]
        public async Task<IHttpActionResult> PostNguoiDung(NguoiDung nguoiDung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NguoiDung.Add(nguoiDung);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = nguoiDung.IDND }, nguoiDung);
        }

        // DELETE: api/NguoiDungs/5
        [ResponseType(typeof(NguoiDung))]
        public async Task<IHttpActionResult> DeleteNguoiDung(int id)
        {
            NguoiDung nguoiDung = await db.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            db.NguoiDung.Remove(nguoiDung);
            await db.SaveChangesAsync();

            return Ok(nguoiDung);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NguoiDungExists(int id)
        {
            return db.NguoiDung.Count(e => e.IDND == id) > 0;
        }
    }
}