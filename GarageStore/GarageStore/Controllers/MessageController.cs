using GarageStore.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GarageStore.Controllers
{
    public class MessageController : Controller
    {
        private GarageDBContext db = new GarageDBContext();
        // GET: MessageModel
        public ActionResult Index(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var message = db.Messages.Where(m => m.ProdutoId == id).OrderByDescending(i => i.DateSend).ToList();

            return View(message.ToList());
        }

        // GET: MessageModel/Details/5
       /* public ActionResult Details(int? id,int? idUser)
        {
            if (id==null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var message = db.Messages.Where(m => m.ProdutoID == id).ToList();
            if(idUser!=null){
                message = message.Where(u => u.UserID == idUser).OrderByDescending(i=>i.DateSend).ToList();
            }
                
            return View(message);
        }*/

        // GET: MessageModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageModel/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="MessageID,Messages,DateSend,UserId,UserName,RespostaID,ProdutoId")] Message message, int idResp=1)
        {
            if(ModelState.IsValid)
            {  
                string userLog = User.Identity.GetUserId();
                var user = db.Users.Where(u => u.Login == userLog).FirstOrDefault();
                if (user == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                message.AnswerId = idResp;
                message.UserName = user.Name;
                message.DateSend = DateTime.Now;
                message.UserId = user.UserID;
                db.Messages.Add(message);
                db.SaveChanges();

                return RedirectToAction("Details","Produto",new { id=message.ProdutoId});
            }
  
                return View(message);
        }

        // POST: MessageModel/Delete/5/chamado pelo metodo deleteConfirmed do produto
        [HttpPost]
        public ActionResult Delete(int? idProd)
        {

            if (idProd == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var message = db.Messages.Where(m=>m.ProdutoId==idProd).ToList();
            if (message != null) {
                message.ForEach(a => db.Messages.Remove(a));
                db.SaveChanges();
            }

            return View("Index","User");
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
