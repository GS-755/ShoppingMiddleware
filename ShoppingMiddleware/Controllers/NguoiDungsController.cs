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
    public class NguoiDungsController : Controller
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

        // GET: NguoiDungs
        public async Task<ActionResult> Index()
        {
            var nguoiDung = db.NguoiDung.Include(n => n.PhanQuyen);
            return View(await nguoiDung.ToListAsync());
        }

        // GET: NguoiDungs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = await db.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Create
        public ActionResult Create()
        {
            ViewBag.IDQuyen = new SelectList(db.PhanQuyen, "IDQuyen", "TenQuyen");
            return View();
        }

        // POST: NguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDND,TenND,Ho_TenDem,Email,GioiTinh,SDT,Tuoi,MatKhau,TenDangNhap,IDQuyen")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDung.Add(nguoiDung);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDQuyen = new SelectList(db.PhanQuyen, "IDQuyen", "TenQuyen", nguoiDung.IDQuyen);
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = await db.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyen, "IDQuyen", "TenQuyen", nguoiDung.IDQuyen);
            return View(nguoiDung);
        }

        // POST: NguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDND,TenND,Ho_TenDem,Email,GioiTinh,SDT,Tuoi,MatKhau,TenDangNhap,IDQuyen")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiDung).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyen, "IDQuyen", "TenQuyen", nguoiDung.IDQuyen);
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = await db.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // POST: NguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NguoiDung nguoiDung = await db.NguoiDung.FindAsync(id);
            db.NguoiDung.Remove(nguoiDung);
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
