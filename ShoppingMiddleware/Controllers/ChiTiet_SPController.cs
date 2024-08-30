using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingMiddleware.Models;

namespace ShoppingMiddleware.Controllers
{
    public class ChiTiet_SPController : Controller
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

        // GET: ChiTiet_SP
        public async Task<ActionResult> Index()
        {
            var chiTiet_SP = db.ChiTiet_SP.Include(c => c.KichThuoc).Include(c => c.SanPham);
            return View(await chiTiet_SP.ToListAsync());
        }

        // GET: ChiTiet_SP/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTiet_SP chiTiet_SP = await db.ChiTiet_SP.FindAsync(id);
            if (chiTiet_SP == null)
            {
                return HttpNotFound();
            }
            return View(chiTiet_SP);
        }

        // GET: ChiTiet_SP/Create
        public ActionResult Create()
        {
            ViewBag.IDKichThuoc = new SelectList(db.KichThuoc, "IDKichThuoc", "Sodo");
            ViewBag.IDSP = new SelectList(db.SanPham, "IDSP", "TenSP");
            return View();
        }

        // POST: ChiTiet_SP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MoTa,GiaBan,GiaMua,SoLuong,IDSP,IDKichThuoc")] ChiTiet_SP chiTiet_SP)
        {
            if (ModelState.IsValid)
            {
                db.ChiTiet_SP.Add(chiTiet_SP);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDKichThuoc = new SelectList(db.KichThuoc, "IDKichThuoc", "Sodo", chiTiet_SP.IDKichThuoc);
            ViewBag.IDSP = new SelectList(db.SanPham, "IDSP", "TenSP", chiTiet_SP.IDSP);
            return View(chiTiet_SP);
        }

        // GET: ChiTiet_SP/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTiet_SP chiTiet_SP = await db.ChiTiet_SP.FindAsync(id);
            if (chiTiet_SP == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKichThuoc = new SelectList(db.KichThuoc, "IDKichThuoc", "Sodo", chiTiet_SP.IDKichThuoc);
            ViewBag.IDSP = new SelectList(db.SanPham, "IDSP", "TenSP", chiTiet_SP.IDSP);
            return View(chiTiet_SP);
        }

        // POST: ChiTiet_SP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MoTa,GiaBan,GiaMua,SoLuong,IDSP,IDKichThuoc")] ChiTiet_SP chiTiet_SP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTiet_SP).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDKichThuoc = new SelectList(db.KichThuoc, "IDKichThuoc", "Sodo", chiTiet_SP.IDKichThuoc);
            ViewBag.IDSP = new SelectList(db.SanPham, "IDSP", "TenSP", chiTiet_SP.IDSP);
            return View(chiTiet_SP);
        }

        // GET: ChiTiet_SP/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTiet_SP chiTiet_SP = await db.ChiTiet_SP.FindAsync(id);
            if (chiTiet_SP == null)
            {
                return HttpNotFound();
            }
            return View(chiTiet_SP);
        }

        // POST: ChiTiet_SP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ChiTiet_SP chiTiet_SP = await db.ChiTiet_SP.FindAsync(id);
            db.ChiTiet_SP.Remove(chiTiet_SP);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
