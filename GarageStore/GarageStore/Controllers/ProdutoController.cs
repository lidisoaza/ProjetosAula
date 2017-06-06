
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

namespace GarageStore.Controllers
{
    public class ProdutoController : Controller
    {
        private GarageDBContext db = new GarageDBContext();

        // GET: Produto
         public ViewResult Index(string searchString,  string sortOrder, int? SelectedCategory, string searchCity, string searchState)
         {
            var categ = db.Categories.OrderBy(s => s.Name).ToList();
            ViewBag.SelectedCategory = new SelectList(categ, "CategoryID", "Name", SelectedCategory);
            int categId = SelectedCategory.GetValueOrDefault();

            var item = db.Produtos.Where(i => !SelectedCategory.HasValue || i.CategoryID == categId);

            if (!String.IsNullOrEmpty(searchState))
            {
                item = item.Where(s => s.Users.State.Contains(searchState));
            }
            if (!String.IsNullOrEmpty(searchCity))
            {
                item = item.Where(s => s.Users.City.Contains(searchCity));
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                item = item.Where(s => s.TitleProduct.Contains(searchString) || s.Description.Contains(searchString));
               
            }
            ViewBag.NameSortParm = sortOrder == "Price" ? "dateLast" : "Price";
            switch (sortOrder) {
                case "Price":
                    item=item.OrderBy(i=>i.Price);
                    break;
                case "dateLast":
                    item = item.OrderByDescending(i => i.DateInput);
                    break;

            }

            return View(item.ToList());
       
        }

 
        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            return this.View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ProdutoID,TitleProduct,Description,Price,DateInput,StatusVenda,CategoryID,UserID")] Produto produto, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var userCode = User.Identity.GetUserId();
                var user = db.Users.Where(u => u.Login == userCode).FirstOrDefault();
                if (user==null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (image != null)
                {
                    produto.ImageMimeType = image.ContentType;
                    produto.ImageFile = new byte[image.ContentLength];
                    image.InputStream.Read(produto.ImageFile, 0, image.ContentLength);

                }
                produto.StatusVenda = "Venda";
                produto.DateInput = DateTime.Now;
                produto.UserID = user.UserID;
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
                

            }


            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", produto.CategoryID);

            return this.View(produto);
        }

        // GET: Produto/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {

            Produto item = this.db.Produtos.Find(id);
            if (item == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", item.CategoryID);
            return this.View(item);

        }

        // POST: Produto/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID, TitleProduct, Description, Price, DateInput, StatusVenda, CategoryID, UserID")] Produto produto,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null) {
                    produto.ImageMimeType = image.ContentType;
                    produto.ImageFile = new byte[image.ContentLength];
                    image.InputStream.Read(produto.ImageFile, 0, image.ContentLength);
                }
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", produto.CategoryID);
            return this.View(produto);
          

            }

        // GET: Produto/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = this.db.Produtos.Find(id);
            if (produto == null )
            {
                return HttpNotFound();
            }
            return this.View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Delete","Message",new { idProd=id});
        }



        public ActionResult GetImage(int id)
        {
            Produto item = db.Produtos.Find(id);
            if (item != null && item.ImageFile != null)
            {
              
               return File(item.ImageFile, item.ImageMimeType);
            }
            else
            {
                return new FilePathResult("~/Images/nao-disponivel.jpg", "image/jpeg");
            }

          }

        public ActionResult OrderCateg( int idCat) {

            var categProd = db.Produtos.Where(c=>c.CategoryID== idCat).ToList();

            return View("Index", new { categProd});
        }

        [ChildActionOnly]
        public ActionResult MenuCateg()
        {
            var menu = db.Categories
                .OrderByDescending(c => c.Produtos.Count)
                .Take(6).ToList();
            return this.PartialView(menu);
        }

       
        public ActionResult MenuSearch()
        {
           
            
            return View();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult StatusVenda(int? idProd) {
            Produto prod = new Produto();
            if (idProd != null)
            {
                prod = db.Produtos.Find(idProd);
            }
            if (prod != null) {
                prod.StatusVenda = "Negocio";
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View("Datails",new { prod});
        }
    }
}
