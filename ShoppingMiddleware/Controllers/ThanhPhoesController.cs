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
    public class ThanhPhoesController : Controller
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

        // GET: ThanhPhoes
        public async Task<ActionResult> Index()
        {
            return View(await db.ThanhPho.ToListAsync());
        }

        // GET: ThanhPhoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhPho thanhPho = await db.ThanhPho.FindAsync(id);
            if (thanhPho == null)
            {
                return HttpNotFound();
            }
            return View(thanhPho);
        }

        // GET: ThanhPhoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThanhPhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDThanhPho,TenThanhPho")] ThanhPho thanhPho)
        {
            if (ModelState.IsValid)
            {
                db.ThanhPho.Add(thanhPho);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(thanhPho);
        }

        // GET: ThanhPhoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhPho thanhPho = await db.ThanhPho.FindAsync(id);
            if (thanhPho == null)
            {
                return HttpNotFound();
            }
            return View(thanhPho);
        }

        // POST: ThanhPhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDThanhPho,TenThanhPho")] ThanhPho thanhPho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhPho).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(thanhPho);
        }

        // GET: ThanhPhoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhPho thanhPho = await db.ThanhPho.FindAsync(id);
            if (thanhPho == null)
            {
                return HttpNotFound();
            }
            return View(thanhPho);
        }

        // POST: ThanhPhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ThanhPho thanhPho = await db.ThanhPho.FindAsync(id);
            db.ThanhPho.Remove(thanhPho);
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
