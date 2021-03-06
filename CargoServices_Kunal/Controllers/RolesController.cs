using CargoServices_Kunal.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoServices_Kunal.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult RoleList()
        {
            var roleList = db.Roles.ToList();
            return View(roleList);
        }

        public ActionResult CreateRole()
        {
            var role = new IdentityRole();
            return View(role);
        }
        [HttpPost]
        public ActionResult CreateRole(IdentityRole identity)
        {
            db.Roles.Add(identity);
            db.SaveChanges();
            return RedirectToAction("RoleList");
        }
    }
}