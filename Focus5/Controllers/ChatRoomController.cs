using Focus5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Focus5.Controllers
{
    public class ChatRoomController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChatRoom
        public ActionResult Index()
        {
            var comments = db.Comments.Include(x => x.Replies).OrderBy(x => x.CreatedOn).ToList();
            return View(comments);
        }
        // Post: ChatRoom/PostReply
        [HttpPost]
        public ActionResult PostReply(ReplyVM obj)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currentUserId);
                Reply r = new Reply();
                r.Text = obj.Reply;
                r.CommentId = obj.CID;
                r.User = currentUser;
                db.Replies.Add(r);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        // Post: ChatRoom/PostComment
        [HttpPost]
        public ActionResult PostComment(string CommentText)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault
                    (x => x.Id == currentUserId);
                Comment c = new Comment();
                c.Text = CommentText;
                c.CreatedOn = DateTime.Now;
                c.User = currentUser;
                db.Comments.Add(c);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        public ActionResult GetRoles()
        {
            var userRoles = new List<Comment>();
            var context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            //Get all the usernames
            foreach (var user in userStore.Users)
            {
                var r = new Comment
                {
                    UserName = user.UserName
                };
                userRoles.Add(r);
            }
            //Get all the Roles for our users


            return RedirectToAction("Index");
        }
    }
}