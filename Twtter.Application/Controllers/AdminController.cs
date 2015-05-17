using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twtter.Application.Controllers
{
    using System.Web.Security;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Twitter.Data;
    using Twitter.Models;
    [Authorize(Roles = "Administrator")]
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            var role = new RoleManager<IdentityRole>(
               new RoleStore<IdentityRole>(new TwitterDbContext()));
            role.Create(new IdentityRole("user"));

            var userManager = this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            this.Data.Users.Add(new User
            {
                UserName = "admin@admin.a",
                Email = "admin@admin.a"
            });
            var adminId = this.Data.Users.All().First(x => x.UserName == "admin@admin.a").Id;
            userManager.AddToRole(adminId, "Administrator");

            return View();
        }

        // GET: User
        public ActionResult Profile(string username)
        {
            var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
            return this.View(user);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Asmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
