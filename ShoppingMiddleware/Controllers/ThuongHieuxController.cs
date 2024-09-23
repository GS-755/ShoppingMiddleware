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
using System.IO;
using System.Web.Services.Description;
using System.Web.WebPages;

namespace ShoppingMiddleware.Controllers
{
    public class ThuongHieuxController : Controller
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

        private const string imgUrl = "~/assets/img/categoryIcon";
        private const string NaNImg = "Default.png";

        // GET: ThuongHieux
        public async Task<ActionResult> Index()
        {
            return View(await db.ThuongHieu.ToListAsync());
        }

        // GET: ThuongHieux/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuongHieu thuongHieu = await db.ThuongHieu.FindAsync(id);
            if (thuongHieu == null)
            {
                return HttpNotFound();
            }
            return View(thuongHieu);
        }

        // GET: ThuongHieux/Create
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: ThuongHieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDThuongHieu,TenThuongHieu")]
        ThuongHieu thuongHieu, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string message = "";

                // Kiểm tra: Thương Hiệu đã tồn tại chưa ?
                if (db.ThuongHieu
                    .Where(t => t.TenThuongHieu == thuongHieu.TenThuongHieu)
                    .Count() > 0)
                {

                    message = $"Xin lỗi, " +
                        $"thương hiệu {thuongHieu.TenThuongHieu} " +
                        $"này đã được đăng ký từ trước đó.";

                    TempData["ErrorMessage"] = message;

                    return RedirectToAction("Index");
                }

                if (file == null || file.ContentLength < 0)
                {
                    // Default Logo:
                    thuongHieu.Logo = NaNImg;
                }
                else
                {
                    // Upload Img to assets:
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath(imgUrl), fileName);
                    file.SaveAs(path);
                    string name = fileName.ToString(); 
                    // save Logo name:
                    thuongHieu.Logo = name;
                }


                db.ThuongHieu.Add(thuongHieu);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(thuongHieu);
        }

        // GET: ThuongHieux/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuongHieu thuongHieu = db.ThuongHieu.Find(id);
            if (thuongHieu == null)
            {
                return HttpNotFound();
            }

            ViewBag.Logo = new SelectList(db.ThuongHieu, "Logo", "Logo");

            return PartialView("Edit", thuongHieu);
        }

        // POST: ThuongHieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDThuongHieu,TenThuongHieu,Logo")]
        ThuongHieu thuongHieu, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null || file.ContentLength < 0)
                {
                    // Default Logo:
                    thuongHieu.Logo = !thuongHieu.Logo.IsEmpty() 
                        ? thuongHieu.Logo 
                        : NaNImg;
                }
                else
                {
                    // Upload Img to assets:
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath(imgUrl), fileName);
                    file.SaveAs(path);
                    string name = fileName.ToString();
                    // save Logo name:
                    thuongHieu.Logo = name;
                }

                db.Entry(thuongHieu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: ThuongHieux/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuongHieu thuongHieu = await db.ThuongHieu.FindAsync(id);
            if (thuongHieu == null)
            {
                return HttpNotFound();
            }
            return View(thuongHieu);
        }

        // POST: ThuongHieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ThuongHieu thuongHieu = await db.ThuongHieu.FindAsync(id);
            db.ThuongHieu.Remove(thuongHieu);
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
