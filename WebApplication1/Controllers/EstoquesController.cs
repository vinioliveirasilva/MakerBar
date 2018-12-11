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
    public class EstoquesController : Controller
    {
        private makerbarEntities db = new makerbarEntities();

        // GET: Estoques
        public async Task<ActionResult> Index()
        {
            var estoque = db.Estoque.Include(e => e.Fabricacao).Include(e => e.Pedido);
            return View(await estoque.ToListAsync());
        }

        // GET: Estoques/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = await db.Estoque.FindAsync(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // GET: Estoques/Create
        public ActionResult Create()
        {
            ViewBag.IdFabricacao = new SelectList(db.Fabricacao, "Id", "Id");
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador");
            return View();
        }

        // POST: Estoques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdFabricacao,IdPedido")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                db.Estoque.Add(estoque);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdFabricacao = new SelectList(db.Fabricacao, "Id", "Id", estoque.IdFabricacao);
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador", estoque.IdPedido);
            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = await db.Estoque.FindAsync(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFabricacao = new SelectList(db.Fabricacao, "Id", "Id", estoque.IdFabricacao);
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador", estoque.IdPedido);
            return View(estoque);
        }

        // POST: Estoques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdFabricacao,IdPedido")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estoque).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdFabricacao = new SelectList(db.Fabricacao, "Id", "Id", estoque.IdFabricacao);
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador", estoque.IdPedido);
            return View(estoque);
        }

        // GET: Estoques/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = await db.Estoque.FindAsync(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Estoque estoque = await db.Estoque.FindAsync(id);
            db.Estoque.Remove(estoque);
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
