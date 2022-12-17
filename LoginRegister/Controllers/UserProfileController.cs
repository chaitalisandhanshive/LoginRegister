using LoginRegister.Migrations;
using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace LoginRegister.Controllers
{
    public class UserProfileController : Controller
    {
        private DB_Entities _db = new DB_Entities();

        // GET: UserProfile
        public ActionResult UserProfile()
        {
            return View(_db.Users.ToList());
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = _db.Users.SingleOrDefault(e => e.UserId == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User us)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(User).State = EntityState.Modified;
                _db.Users.Add(us);
                _db.SaveChanges();
                return RedirectToAction("Index","UserProfile");
            }

            return View();
        }


    }
    
}