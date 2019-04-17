using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Helpers;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "0,1")]
    public class ClientesController : Controller
    {
        private makerbarEntities db = new makerbarEntities();

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            return PartialView("_Index", await db.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = await db.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Get(string id)
        {
            if (id == null)
            {
                return null;
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return null;
            }
            //return new List<Cliente> { cliente };
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        // GET: Clientes/Create
        [HttpPost]
        public async Task<bool> Create(Cliente cliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Cliente.Add(cliente.RemoveMask());
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
        public async Task<bool> Edit(Cliente cliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cliente).State = EntityState.Modified;
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
        public async Task<bool> Deleta(string id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Cliente cliente = await db.Cliente.FindAsync(id);
                    if(cliente.Pedido.Count > 0)
                    {
                        foreach(var p in cliente.Pedido)
                        {
                            if (p.Item.Count > 0)
                            {
                                db.Item.RemoveRange(p.Item);
                            }

                            if (p.Fabricacao.Count > 0)
                            {
                                db.Fabricacao.RemoveRange(p.Fabricacao);
                            }

                            if (p.Fabricacao.Count > 0)
                            {
                                db.Fabricacao.RemoveRange(p.Fabricacao);
                            }
                        }

                        db.Pedido.RemoveRange(cliente.Pedido);
                    }
                    db.Cliente.Remove(cliente);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Cpf,Endereco,Nome,TelCel,TelRes,Email")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                await db.SaveChangesAsync();
                return PartialView("CreateCliente");
            }

            return View(cliente);
        }
        */
        /*
        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = await db.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = await db.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("DeleteY")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Cliente cliente = await db.Cliente.FindAsync(id);
            db.Cliente.Remove(cliente);
            await db.SaveChangesAsync();
            return null;
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
