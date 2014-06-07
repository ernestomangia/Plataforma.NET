using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo;
using AccesoDatos;

namespace WebMVC.Controllers
{
    public class FactorController : Controller
    {
        private Contexto db = new Contexto();

        // GET: /Factor/
        public ActionResult Index()
        {
            return View(db.Factores.ToList());
        }

        // GET: /Factor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FactorModelo factormodelo = db.Factores.Find(id);
            if (factormodelo == null)
            {
                return HttpNotFound();
            }
            return View(factormodelo);
        }

        // GET: /Factor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Factor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Codigo,Nombre")] FactorModelo factormodelo)
        {
            if (ModelState.IsValid)
            {
                db.Factores.Add(factormodelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factormodelo);
        }

        // GET: /Factor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FactorModelo factormodelo = db.Factores.Find(id);
            if (factormodelo == null)
            {
                return HttpNotFound();
            }
            return View(factormodelo);
        }

        // POST: /Factor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Codigo,Nombre")] FactorModelo factormodelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factormodelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factormodelo);
        }

        // GET: /Factor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FactorModelo factormodelo = db.Factores.Find(id);
            if (factormodelo == null)
            {
                return HttpNotFound();
            }
            return View(factormodelo);
        }

        // POST: /Factor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FactorModelo factormodelo = db.Factores.Find(id);
            db.Factores.Remove(factormodelo);
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
