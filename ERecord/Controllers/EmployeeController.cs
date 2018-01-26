﻿using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERecord.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ERecord.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.States = sortOrder == "States" ? "states_desc" : "States";
            ViewBag.Gender = sortOrder == "Gender" ? "gender_desc" : "Gender";
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
                case "States":
                    users = users.OrderBy(s => s.State);
                    break;
                case "state_desc":
                    users = users.OrderByDescending(s => s.State);
                    break;
                case "Gender":
                    users = users.OrderBy(s => s.Gender);
                    break;
                case "gender_desc":
                    users = users.OrderByDescending(s => s.Gender);
                    break;
                default:
                    users = users.OrderBy(s => s.FirstName);
                    break;
            }
            return View(users.ToList());
        }

        // GET: Employee/Details/5
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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,IsActive,Address,City,State,Nationality,Gender,Dob,MaritalStatus,NumberOfChildren,EmploymentDay,SchoolAttended,MaximumQulaification,ServiceYear,LastPromoted,YearlySalary,DateCreated,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        public ActionResult Subordinates()
        {
            //Get the ApplicationUser object in one line of code
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            //Check the Position of current logged in employee
            var positionCheck = user.Position;
            var subordinateCount = db.Users.Where(u => u.Position < positionCheck).Count();
            if (subordinateCount.Equals(0))
            {
                ViewBag.Message = "You don't have Subordinates at this time";
                return View(db.Users.Where(u => u.Position < positionCheck).ToList());
            }

            return View(db.Users.Where(u => u.Position < positionCheck).ToList());
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