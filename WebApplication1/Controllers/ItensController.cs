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
    [Authorize(Roles = "0,1")]
    public class ItensController : Controller
    {
        private makerbarEntities db = new makerbarEntities();

        public async Task<ActionResult> Index(int? id)
        {
            if (id != null)
            {
                Pedido pedido = await db.Pedido.FindAsync(id);

                return PartialView("_Index", pedido.Item);
            }

            return PartialView("_Index", new List<Item>());
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return null;
            }
            //return new List<Cliente> { cliente };
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<bool> Create(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Item.Add(item);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> Edit(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(item).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> Deleta(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Item item = db.Item.Find(id);
                    db.Item.Remove(item);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        // GET: Itens/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        /*
        // GET: Itens/Create
        public ActionResult Create()
        {
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador");
            return View();
        }

        // POST: Itens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Qualidade,Resistencia,Arquivo,Quantidade,IdPedido")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Item.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador", item.IdPedido);
            return View(item);
        }

        // GET: Itens/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador", item.IdPedido);
            return View(item);
        }

        // POST: Itens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Qualidade,Resistencia,Arquivo,Quantidade,IdPedido")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdPedido = new SelectList(db.Pedido, "Id", "Identificador", item.IdPedido);
            return View(item);
        }

        // GET: Itens/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Itens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.Item.FindAsync(id);
            db.Item.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        */

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
