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
    public class PedidosController : Controller
    {
        private makerbarEntities db = new makerbarEntities();


        public async Task<ActionResult> Index(string id)
        {
            if(id != null)
            { 
                Cliente cli = await db.Cliente.FindAsync(id);

                return PartialView("_Index", cli.Pedido);
            }

            return PartialView("_Index", new List<Pedido>());
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return null;
            }
            //return new List<Cliente> { cliente };
            return Json(pedido, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<bool> Create(Pedido pedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Pedido.Add(pedido);
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
        public async Task<bool> Edit(Pedido pedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(pedido).State = EntityState.Modified;
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
                    Pedido pedido = db.Pedido.Find(id);
                    db.Pedido.Remove(pedido);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        // GET: Pedidos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = await db.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        /*
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "Cpf", "Endereco");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

    
        // GET: Pedidos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = await db.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "Cpf", "Endereco", pedido.IdCliente);
            return View(pedido);
        }

       
        // GET: Pedidos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = await db.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pedido pedido = await db.Pedido.FindAsync(id);
            db.Pedido.Remove(pedido);
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
