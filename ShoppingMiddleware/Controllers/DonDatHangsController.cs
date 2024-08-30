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
    public class DonDatHangsController : Controller
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

        // GET: DonDatHangs
        public async Task<ActionResult> Index()
        {
            var donDatHang = db.DonDatHang.Include(d => d.NguoiDung).Include(d => d.NhanVien);
            return View(await donDatHang.ToListAsync());
        }

        // GET: DonDatHangs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = await db.DonDatHang.FindAsync(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // GET: DonDatHangs/Create
        public ActionResult Create()
        {
            ViewBag.IDND = new SelectList(db.NguoiDung, "IDND", "TenND");
            ViewBag.IDNV = new SelectList(db.NhanVien, "IDNV", "TenNV");
            return View();
        }

        // POST: DonDatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NgayDat,IDDonDatHang,PhiGiaoHang,TongTien,TrangThai,DiaChiNhanHang,SDTNhanHang,IDND,IDNV")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.DonDatHang.Add(donDatHang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDND = new SelectList(db.NguoiDung, "IDND", "TenND", donDatHang.IDND);
            ViewBag.IDNV = new SelectList(db.NhanVien, "IDNV", "TenNV", donDatHang.IDNV);
            return View(donDatHang);
        }

        // GET: DonDatHangs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = await db.DonDatHang.FindAsync(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDND = new SelectList(db.NguoiDung, "IDND", "TenND", donDatHang.IDND);
            ViewBag.IDNV = new SelectList(db.NhanVien, "IDNV", "TenNV", donDatHang.IDNV);
            return View(donDatHang);
        }

        // POST: DonDatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NgayDat,IDDonDatHang,PhiGiaoHang,TongTien,TrangThai,DiaChiNhanHang,SDTNhanHang,IDND,IDNV")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donDatHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDND = new SelectList(db.NguoiDung, "IDND", "TenND", donDatHang.IDND);
            ViewBag.IDNV = new SelectList(db.NhanVien, "IDNV", "TenNV", donDatHang.IDNV);
            return View(donDatHang);
        }

        // GET: DonDatHangs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = await db.DonDatHang.FindAsync(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // POST: DonDatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DonDatHang donDatHang = await db.DonDatHang.FindAsync(id);
            db.DonDatHang.Remove(donDatHang);
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
