using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Focus5.Models;

namespace Focus5.Controllers
{
    public class UserImage1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserImage1
        public ActionResult Index()
        {

            return View(db.UserImage1s.ToList());
        }

        // GET: UserImage1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserImage1 userImage1 = db.UserImage1s.Find(id);
            if (userImage1 == null)
            {
                return HttpNotFound();
            }
            return View(userImage1);
        }

        // GET: UserImage1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserImage1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserImage1 img, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/images/")
                                                          + file.FileName);
                    img.ImagePath = file.FileName;
                }

                db.UserImage1s.Add(img);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(img);
        }
     

        // GET: UserImage1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserImage1 userImage1 = db.UserImage1s.Find(id);
            if (userImage1 == null)
            {
                return HttpNotFound();
            }
            return View(userImage1);
        }

        // POST: UserImage1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImagePath")] UserImage1 userImage1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userImage1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userImage1);
        }

        // GET: UserImage1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserImage1 userImage1 = db.UserImage1s.Find(id);
            if (userImage1 == null)
            {
                return HttpNotFound();
            }
            return View(userImage1);
        }

        // POST: UserImage1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserImage1 userImage1 = db.UserImage1s.Find(id);
            db.UserImage1s.Remove(userImage1);
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
