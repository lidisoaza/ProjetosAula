using GarageStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageStore.Controllers
{
    public class AdminController : Controller
    {
        private GarageDBContext db = new GarageDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult RelSellGeral(int id)
        {
            var user = db.Users.Find(id);

            var rel = from users in db.Users
                      select new RelalSeller()
                      {
                          SellerName = user.Name,
                          ProdutoCount = user.Produtos.Count(),
                          QuestCount = user.Produtos.Sum(s=>s.Messages.Count()),
                          ProdSellCount=user.Produtos.Where(s=>s.StatusVenda=="Vendido").Count(),
                          ValProdOfert =user.Produtos.Sum(s => s.Price ),
                          ValProdSell=user.Produtos.Where(s=>s.StatusVenda=="Vendido").Sum(s=>s.Price), 
                          Reput=0,
                          DoaCount=user.Produtos.Where(s=>s.StatusVenda=="Doacao").Count()
                       };
            return View(rel);
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
