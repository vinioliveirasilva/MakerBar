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
    public class ItensFabricacaoController : Controller
    {
        private makerbarEntities db = new makerbarEntities();

        // GET: ItensFabricacao
        public async Task<ActionResult> Index()
        {
            var itensFabricacao = db.ItensFabricacao.Include(i => i.Fabricacao).Include(i => i.Item);
            return View(await itensFabricacao.ToListAsync());
        }

        // GET: ItensFabricacao/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItensFabricacao itensFabricacao = await db.ItensFabricacao.FindAsync(id);
            if (itensFabricacao == null)
            {
                return HttpNotFound();
            }
            return View(itensFabricacao);
        }

        // GET: ItensFabricacao/Create
        public ActionResult Create()
        {
            ViewBag.IdFabricacao = new SelectList(db.Fabricacao, "Id", "Id");
            ViewBag.IdItem = new SelectList(db.Item, "Id", "Nome");
            return View();
        }

        // POST: ItensFabricacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdItem,IdFabricacao")] ItensFabricacao itensFabricacao)
        {
            if (ModelState.IsValid)
            {
                db.ItensFabricacao.Add(itensFabricacao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdFabricacao = new SelectList(db.Fabricacao, "Id", "Id", itensFabricacao.IdFabricacao);
            ViewBag.IdItem = new SelectList(db.Item, "Id", "Nome", itensFabricacao.IdItem);
            return View(itensFabricacao);
        }

        // GET: ItensFabricacao/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItensFabricacao itensFabricacao = await db.ItensFabricacao.FindAsync(id);
            if (itensFabricacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFabricacao = new SelectList(db.Fabricacao, "Id", "Id", itensFabricacao.IdFabricacao);
            ViewBag.IdItem = new SelectList(db.Item, "Id", "Nome", itensFabricacao.IdItem);
            return View(itensFabricacao);
        }

        // POST: ItensFabricacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdItem,IdFabricacao")] ItensFabricacao itensFabricacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itensFabricacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdFabricacao = new SelectList(db.Fabricacao, "Id", "Id", itensFabricacao.IdFabricacao);
            ViewBag.IdItem = new SelectList(db.Item, "Id", "Nome", itensFabricacao.IdItem);
            return View(itensFabricacao);
        }

        // GET: ItensFabricacao/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItensFabricacao itensFabricacao = await db.ItensFabricacao.FindAsync(id);
            if (itensFabricacao == null)
            {
                return HttpNotFound();
            }
            return View(itensFabricacao);
        }

        // POST: ItensFabricacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ItensFabricacao itensFabricacao = await db.ItensFabricacao.FindAsync(id);
            db.ItensFabricacao.Remove(itensFabricacao);
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
