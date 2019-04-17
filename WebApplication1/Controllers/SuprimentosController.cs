using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "0,1")]
    public class SuprimentosController : Controller
    {
        private makerbarEntities db = new makerbarEntities();

        // GET: Suprimentos
        public ActionResult Index()
        {
            return View(db.Suprimento.ToList());
        }

        // GET: Suprimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suprimento suprimento = db.Suprimento.Find(id);
            if (suprimento == null)
            {
                return HttpNotFound();
            }
            return View(suprimento);
        }

        // GET: Suprimentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suprimentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,PesoInicial,PesoAtual,Tipo,Cor,Status")] Suprimento suprimento)
        {
            if (ModelState.IsValid)
            {
                db.Suprimento.Add(suprimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suprimento);
        }

        // GET: Suprimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suprimento suprimento = db.Suprimento.Find(id);
            if (suprimento == null)
            {
                return HttpNotFound();
            }
            return View(suprimento);
        }

        // POST: Suprimentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,PesoInicial,PesoAtual,Tipo,Cor,Status")] Suprimento suprimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suprimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suprimento);
        }

        // GET: Suprimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suprimento suprimento = db.Suprimento.Find(id);
            if (suprimento == null)
            {
                return HttpNotFound();
            }
            return View(suprimento);
        }

        // POST: Suprimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suprimento suprimento = db.Suprimento.Find(id);
            db.Suprimento.Remove(suprimento);
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
