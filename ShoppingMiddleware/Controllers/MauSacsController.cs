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
    public class MauSacsController : Controller
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

        // GET: MauSacs
        public async Task<ActionResult> Index()
        {
            return View(await db.MauSac.ToListAsync());
        }

        // GET: MauSacs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauSac mauSac = await db.MauSac.FindAsync(id);
            if (mauSac == null)
            {
                return HttpNotFound();
            }
            return View(mauSac);
        }

        // GET: MauSacs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MauSacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDMau,TenMau")] MauSac mauSac)
        {
            if (ModelState.IsValid)
            {
                db.MauSac.Add(mauSac);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mauSac);
        }

        // GET: MauSacs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauSac mauSac = await db.MauSac.FindAsync(id);
            if (mauSac == null)
            {
                return HttpNotFound();
            }
            return View(mauSac);
        }

        // POST: MauSacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDMau,TenMau")] MauSac mauSac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mauSac).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mauSac);
        }

        // GET: MauSacs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauSac mauSac = await db.MauSac.FindAsync(id);
            if (mauSac == null)
            {
                return HttpNotFound();
            }
            return View(mauSac);
        }

        // POST: MauSacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MauSac mauSac = await db.MauSac.FindAsync(id);
            db.MauSac.Remove(mauSac);
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
