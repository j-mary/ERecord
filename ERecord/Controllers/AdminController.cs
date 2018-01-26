using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ERecord.Models;


namespace ERecord.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class AdminController : Controller
    {
        private ApplicationDbContext db;

        public AdminController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Admin
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.SalarySortParm = sortOrder == "YearlySalary" ? "salary_desc" : "YearlySalary";
            ViewBag.Gender = sortOrder == "Gender" ? "gender_desc" : "Gender";
            ViewBag.Position = sortOrder == "Position" ? "position_desc" : "Position";
            var users = db.Users.Where(u => u.Email != "admin@erecord.com" && u.Email != "guest@erecord.com");

            //Takes care of serachString **********
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper()) || s.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            if (users.Count() == 0)
            {
                ViewBag.SearchMessage = "No Employee Found based on your search term";
            }//*********** End of serachString

            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    users = users.OrderBy(s => s.EmploymentDay);
                    break;
                case "date_desc":
                    users = users.OrderByDescending(s => s.EmploymentDay);
                    break;
                case "YearlySalary":
                    users = users.OrderBy(s => s.YearlySalary);
                    break;
                case "salary_desc":
                    users = users.OrderByDescending(s => s.YearlySalary);
                    break;
                case "Gender":
                    users = users.OrderBy(s => s.Gender);
                    break;
                case "gender_desc":
                    users = users.OrderByDescending(s => s.Gender);
                    break;
                case "Position":
                    users = users.OrderBy(s => s.Position);
                    break;
                case "position_desc":
                    users = users.OrderByDescending(s => s.Position);
                    break;
                default:
                    users = users.OrderBy(s => s.FirstName);
                    break;
            }

            return View(users.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,IsActive,Address,City,State,Nationality,Gender,Dob,MaritalStatus,NumberOfChildren,EmploymentDay,SchoolAttended,MaximumQulaification,ServiceYear,LastPromoted,YearlySalary,DateCreated,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Position")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                if (applicationUser.Position == 0)
                {
                    ViewBag.Message = "Please asign a position to this employee.";
                    return View(applicationUser);
                }
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }
   
        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
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
