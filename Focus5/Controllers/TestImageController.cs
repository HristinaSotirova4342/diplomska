using Focus5.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Focus5.Controllers
{
    public class TestImageController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestImage
        public ActionResult Index()
        {
            string CurrentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault
                (x => x.Id == CurrentUserId);
            return View(db.TBLImages.ToList().Where(x => x.User == currentUser));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Create(TBLImage tBLImage)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currentUserId);
                tBLImage.User = currentUser;
                string fileName = Path.GetFileNameWithoutExtension(tBLImage.ImageFile.FileName);
                string extension = Path.GetExtension(tBLImage.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                tBLImage.Image = "../Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("../Image/"), fileName);
                tBLImage.ImageFile.SaveAs(fileName);
                db.TBLImages.Add(tBLImage);
                db.SaveChanges();
                ModelState.Clear();
            }
            return RedirectToAction("Index");
        }
    }
}