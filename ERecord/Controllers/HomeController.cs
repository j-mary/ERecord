using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERecord.Models;

namespace ERecord.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // GET The Total Employees, Unapproved and Approved
            ApplicationDbContext context = new ApplicationDbContext();
            int UnApprovedEmployeesCount = context.Users.Where(e => e.IsActive == false).Count();
            // GET All Approved Employees minus one Seeded Admin and one test Users
            int ApprovedEmployeesCount = context.Users.Where(e => e.IsActive == true).Count() - 2;
            //Return Total Number of Employees
            int AllEmployeesCount = (UnApprovedEmployeesCount + ApprovedEmployeesCount);
            ViewBag.UnApprovedEmployeesCount = UnApprovedEmployeesCount;
            ViewBag.ApprovedEmployeesCount = ApprovedEmployeesCount;
            ViewBag.AllEmployeesCount = AllEmployeesCount;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Employee Management System";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Help us serve you better";

            return View();
        }
    }
}