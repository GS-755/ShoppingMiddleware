using System;
using System.Net;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using ShoppingMiddleware.Models;
using System.Web.WebPages;

namespace ShoppingMiddleware.Controllers
{
    public class NguoiDungsController : Controller
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

        // GET: NguoiDungs
        public async Task<ActionResult> Index()
        {
            var phanquyen = db.PhanQuyen.ToListAsync();
            return View(await phanquyen);
        }


        [HttpGet]
        public async Task<ActionResult> UsersTable(string roleID)
        {
            // Account list:
            if (roleID == "Defaul")
            {
                var userList = db.NguoiDung.ToList();
                return PartialView("NguoiDung", userList);
            }

            // Account by id:
            IQueryable<NguoiDung> usersQuery = db.NguoiDung;

            if (!string.IsNullOrEmpty(roleID) && int.TryParse(roleID, out int parsedRoleID))
            {
                usersQuery = usersQuery.Where(u => u.IDQuyen == parsedRoleID);
            }

            // Pratial View table Account list:
            var users = await usersQuery.ToListAsync();
            return PartialView("NguoiDung", users);
        }


        [HttpGet]
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
                try
                {
                    // check user is exist:
                    var exist = db.NguoiDung.Where(n => n.TenDangNhap == nguoiDung.TenDangNhap).Count();
                    if (exist >= 1)
                    {
                        ModelState.AddModelError(
                            // field Model:
                            "",
                            // message:
                            $"xin lỗi tài khoản" +
                            $" {nguoiDung.TenDangNhap} " +
                            $"này đã được đăng ký từ trước đó.");

                    }

                    // if Account is not exist => check Regex values:
                    else
                    {
                        /* ************************ Documents ************************
                            
                        RegexValues:
                            => messages: List[string] show message invalid values.
                            => functions: 
                                 + UserNameIsValid(string) => bool
                                 + IsStrongPassword(string) => bool
                                 + 

                           ************************ Documents ************************ */

                        // setup:
                        RegexValues regexValues = new RegexValues();
                        string listRegex;

                        // check regex user name:
                        if (!regexValues.UserNameIsValid(nguoiDung.TenDangNhap))
                        {
                            /*
                             * todo: list default = "";
                             */
                            listRegex = "";

                            // show list regex:
                            foreach (string mess in regexValues.messages)
                            {
                                // Add regex message to list:
                                listRegex +=
                                $"<br />" +
                                $". {mess}";
                            }

                            ModelState.AddModelError(
                            // Field Model:
                            "TenDangNhap",
                            // messages:
                            $"User name {nguoiDung.TenDangNhap} " +
                            $"violates our policy: " +
                            // list regex:
                            listRegex
                           );
                        }
                        // Check password regex:
                        else if (!regexValues.IsStrongPassword(nguoiDung.MatKhau))
                        {
                            /*
                             * todo: list default = "";
                             */
                            listRegex = "";

                            // show list regex:
                            foreach (string mess in regexValues.messages)
                            {
                                // Add regex message to list:
                                listRegex +=
                                $"<br />" +
                                $". {mess}";
                            }

                            ModelState.AddModelError(
                            // Field Model:
                            "MatKhau",
                            // messages:
                            $"password " +
                            $"violates our policy: " +
                            // list regex:
                            listRegex
                           );


                        }
                        // Check password regex:
                        else if (!regexValues.PhoneNumberValid(nguoiDung.SDT))
                        {
                            /*
                             * todo: list default = "";
                             */
                            listRegex = "";

                            // show list regex:
                            foreach (string mess in regexValues.messages)
                            {
                                // Add regex message to list:
                                listRegex +=
                                $"<br />" +
                                $". {mess}";
                            }

                            ModelState.AddModelError(
                            // Field Model:
                            "SDT",
                            // messages:
                            $"Phone number " +
                            $"violates our policy: " +
                            // list regex:
                            listRegex
                           );
                        }
                        else
                        {
                            db.NguoiDung.Add(nguoiDung);
                            //await db.SaveChangesAsync();
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
                            //  Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }

                    ModelState.AddModelError("", "Đã xảy ra lỗi khi lưu dữ liệu. Vui lòng kiểm tra lại các trường thông tin.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Đã xảy ra lỗi hệ thống. Vui lòng thử lại.");
                    //  Console.WriteLine($"Exception: {ex.Message}");
                }
            }

            // Đảm bảo rằng ViewBag.IDQuyen được thiết lập để dropdown list vẫn hoạt động khi trả về view
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
