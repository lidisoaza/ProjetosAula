using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarageStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace GarageStore.Controllers
{  [Authorize]
    public class UserController : Controller
    {
        private GarageDBContext db = new GarageDBContext();

        // GET: User
        public ActionResult Index()
        {
            var userLog = User.Identity.GetUserId();
            if (userLog == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User users = db.Users.Where(u => u.Login==userLog).FirstOrDefault();
            if (users == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            return this.View(users);
        }

       [AllowAnonymous]
        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            
            if ( id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
            }
           
           User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);

        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Name,Email,Cpf,Street,Number_House,District,City,State,Telephone,Login")] User user , HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                
                if (image != null)
                {
                    user.ImageMimeType = image.ContentType;
                    user.ImageUser = new byte[image.ContentLength];
                    image.InputStream.Read(user.ImageUser, 0, image.ContentLength);
                }
                user.Login = User.Identity.GetUserId();                
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,Email,Cpf,Street,Number_House,District,City,State,Telephone,Login")] User user, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                user.ImageMimeType = image.ContentType;
                user.ImageUser = new byte[image.ContentLength];
                image.InputStream.Read(user.ImageUser, 0, image.ContentLength);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","User",new { id=user.UserID});
            }

         
             return View(user);
        }
        // GET: Users/Delete/5
        [Authorize(Users = "lidi_anne88@yahoo.com.br")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "lidi_anne88@yahoo.com.br")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetImage(int? id)
        {
            User user = new User();

            if (id == null)
            {
                var userLog = User.Identity.GetUserId();
                user = db.Users.Where(u => u.Login == userLog).FirstOrDefault();
            }
            else
            {
                user = db.Users.Find(id);
            }
            if (user != null && user.ImageUser != null)
            {

                return File(user.ImageUser, user.ImageMimeType);
            }
            else
            {
                return new FilePathResult("~/Images/Profile.png", "image/png");
            }

        }
        public ActionResult Anouccements(string orderBy,int? id) {
            var userLog = User.Identity.GetUserId();
            if (userLog == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produtos = db.Produtos.Where(u => u.Users.Login == userLog);
            ViewBag.NameSortParm = orderBy== "Desc"? "Asc" : "Desc";
            switch (orderBy) {
                case "Desc":
                    produtos=produtos.OrderByDescending(p=>p.DateInput);
                    break;
                case "Asc":
                    produtos = produtos.OrderBy(p => p.DateInput);
                    break;
            }
            if (id != null) {
                produtos = db.Produtos.Where(u=> u.UserID==id);
            }
            return this.View(produtos.ToList());

        }

      /*  public ActionResult Aval(int? idUs) {
            if(idUs == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(idUs);
            if (user != null ) {
                double aval = user.Aval / user.AvalCount;
            }
            return View();
        }*/

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
