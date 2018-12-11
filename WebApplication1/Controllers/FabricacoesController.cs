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
    public class FabricacoesController : Controller
    {
        private makerbarEntities db = new makerbarEntities();

        // GET: Fabricacoes
        public async Task<ActionResult> Index()
        {
            var fabricacao = db.Fabricacao.Include(f => f.Maquina).Include(f => f.Pedido).Include(f => f.Suprimento);
            return View(await fabricacao.ToListAsync());
        }

        // GET: Fabricacoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricacao fabricacao = await db.Fabricacao.FindAsync(id);
            if (fabricacao == null)
            {
                return HttpNotFound();
            }
            return View(fabricacao);
        }

        // GET: Fabricacoes/Create
        public ActionResult Create()
        {
            ViewBag.IdMaquina = new SelectList(db.Maquina, "Id", "Nome");
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador");
            ViewBag.IdSuprimento = new SelectList(db.Suprimento, "Id", "Nome");
            return View();
        }

        // POST: Fabricacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdMaquina,IdPedido,IdSuprimento")] Fabricacao fabricacao)
        {
            if (ModelState.IsValid)
            {
                db.Fabricacao.Add(fabricacao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdMaquina = new SelectList(db.Maquina, "Id", "Nome", fabricacao.IdMaquina);
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador", fabricacao.IdPedido);
            ViewBag.IdSuprimento = new SelectList(db.Suprimento, "Id", "Nome", fabricacao.IdSuprimento);
            return View(fabricacao);
        }

        // GET: Fabricacoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricacao fabricacao = await db.Fabricacao.FindAsync(id);
            if (fabricacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMaquina = new SelectList(db.Maquina, "Id", "Nome", fabricacao.IdMaquina);
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador", fabricacao.IdPedido);
            ViewBag.IdSuprimento = new SelectList(db.Suprimento, "Id", "Nome", fabricacao.IdSuprimento);
            return View(fabricacao);
        }

        // POST: Fabricacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdMaquina,IdPedido,IdSuprimento")] Fabricacao fabricacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabricacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdMaquina = new SelectList(db.Maquina, "Id", "Nome", fabricacao.IdMaquina);
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador", fabricacao.IdPedido);
            ViewBag.IdSuprimento = new SelectList(db.Suprimento, "Id", "Nome", fabricacao.IdSuprimento);
            return View(fabricacao);
        }

        // GET: Fabricacoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricacao fabricacao = await db.Fabricacao.FindAsync(id);
            if (fabricacao == null)
            {
                return HttpNotFound();
            }
            return View(fabricacao);
        }

        // POST: Fabricacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fabricacao fabricacao = await db.Fabricacao.FindAsync(id);
            db.Fabricacao.Remove(fabricacao);
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
