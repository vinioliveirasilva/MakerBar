using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SuprimentosController : Controller
    {
        private EngSoftEntities1 db = new EngSoftEntities1();

        // GET: Suprimentos
        public async Task<ActionResult> Index()
        {
            return View(await db.Suprimento.ToListAsync());
        }

        // GET: Suprimentos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suprimento suprimento = await db.Suprimento.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,PesoInicial,PesoAtual,Status")] Suprimento suprimento)
        {
            if (ModelState.IsValid)
            {
                db.Suprimento.Add(suprimento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(suprimento);
        }

        // GET: Suprimentos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suprimento suprimento = await db.Suprimento.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,PesoInicial,PesoAtual,Status")] Suprimento suprimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suprimento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(suprimento);
        }

        // GET: Suprimentos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suprimento suprimento = await db.Suprimento.FindAsync(id);
            if (suprimento == null)
            {
                return HttpNotFound();
            }
            return View(suprimento);
        }

        // POST: Suprimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Suprimento suprimento = await db.Suprimento.FindAsync(id);
            db.Suprimento.Remove(suprimento);
            await db.SaveChangesAsync();
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
