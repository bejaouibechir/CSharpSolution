using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ProduitsController : Controller
    {
        private BusinessDBEntities db = new BusinessDBEntities();

        // GET: Produits
        public ActionResult Index()
        {
            var produits = db.Produits.Include(p => p.Category).Include(p => p.Client).Include(p => p.Employee);
            return View(produits.ToList());
        }

        // GET: Produits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: Produits/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Label");
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Nom");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Nom");
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Label,Prix,ClientId,EmployeeId,CategorieId")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Produits.Add(produit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Label", produit.CategorieId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Nom", produit.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Nom", produit.EmployeeId);
            return View(produit);
        }

        // GET: Produits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Label", produit.CategorieId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Nom", produit.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Nom", produit.EmployeeId);
            return View(produit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Label,Prix,ClientId,EmployeeId,CategorieId")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Label", produit.CategorieId);
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Nom", produit.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Nom", produit.EmployeeId);
            return View(produit);
        }

        // GET: Produits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produit produit = db.Produits.Find(id);
            db.Produits.Remove(produit);
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
