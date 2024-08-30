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
    public class CT_DonDatHangController : Controller
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

        // GET: CT_DonDatHang
        public async Task<ActionResult> Index()
        {
            var cT_DonDatHang = db.CT_DonDatHang.Include(c => c.DonDatHang).Include(c => c.SanPham);
            return View(await cT_DonDatHang.ToListAsync());
        }

        // GET: CT_DonDatHang/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DonDatHang cT_DonDatHang = await db.CT_DonDatHang.FindAsync(id);
            if (cT_DonDatHang == null)
            {
                return HttpNotFound();
            }
            return View(cT_DonDatHang);
        }

        // GET: CT_DonDatHang/Create
        public ActionResult Create()
        {
            ViewBag.IDDonDatHang = new SelectList(db.DonDatHang, "IDDonDatHang", "TrangThai");
            ViewBag.IDSP = new SelectList(db.SanPham, "IDSP", "TenSP");
            return View();
        }

        // POST: CT_DonDatHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "soluong,ThanhTien,IDDonDatHang,IDSP")] CT_DonDatHang cT_DonDatHang)
        {
            if (ModelState.IsValid)
            {
                db.CT_DonDatHang.Add(cT_DonDatHang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDDonDatHang = new SelectList(db.DonDatHang, "IDDonDatHang", "TrangThai", cT_DonDatHang.IDDonDatHang);
            ViewBag.IDSP = new SelectList(db.SanPham, "IDSP", "TenSP", cT_DonDatHang.IDSP);
            return View(cT_DonDatHang);
        }

        // GET: CT_DonDatHang/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DonDatHang cT_DonDatHang = await db.CT_DonDatHang.FindAsync(id);
            if (cT_DonDatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDonDatHang = new SelectList(db.DonDatHang, "IDDonDatHang", "TrangThai", cT_DonDatHang.IDDonDatHang);
            ViewBag.IDSP = new SelectList(db.SanPham, "IDSP", "TenSP", cT_DonDatHang.IDSP);
            return View(cT_DonDatHang);
        }

        // POST: CT_DonDatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "soluong,ThanhTien,IDDonDatHang,IDSP")] CT_DonDatHang cT_DonDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_DonDatHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDDonDatHang = new SelectList(db.DonDatHang, "IDDonDatHang", "TrangThai", cT_DonDatHang.IDDonDatHang);
            ViewBag.IDSP = new SelectList(db.SanPham, "IDSP", "TenSP", cT_DonDatHang.IDSP);
            return View(cT_DonDatHang);
        }

        // GET: CT_DonDatHang/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DonDatHang cT_DonDatHang = await db.CT_DonDatHang.FindAsync(id);
            if (cT_DonDatHang == null)
            {
                return HttpNotFound();
            }
            return View(cT_DonDatHang);
        }

        // POST: CT_DonDatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CT_DonDatHang cT_DonDatHang = await db.CT_DonDatHang.FindAsync(id);
            db.CT_DonDatHang.Remove(cT_DonDatHang);
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
