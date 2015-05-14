using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twtter.Application.Controllers
{
    using Twitter.Data;

    public class UsersController : BaseController
    {
        public UsersController()
            : this(new TwitterData(new TwitterDbContext()))
        {

        }

        public UsersController(ITwitterData data)
            : base(data)
        {

        }
        // GET: User
        public ActionResult Profile(string username)
        {
            var user = this.Data.Users.All().Where(u => u.UserName == username).FirstOrDefault();
            return this.View(user);
        }

        public ActionResult GetFile()
        {
            var pers = new { 
                name = "Goshko",
                age = 12
            };
            return Json(pers, JsonRequestBehavior.AllowGet);
        }
    }
}