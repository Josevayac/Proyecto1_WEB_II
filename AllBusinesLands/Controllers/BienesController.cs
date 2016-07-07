using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AllBusinesLands.Models;

namespace AllBusinesLands.Controllers
{
    public class BienesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bienes
        public async Task<ActionResult> Index()
        {
            return View(await db.Bien.ToListAsync());
        }

        // GET: Bienes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = await db.Bien.FindAsync(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // GET: Bienes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bienes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Titulo,Detalle,Precio,Telefono,Email,FechaIngreso,HoraIngreso")] Bien bien)
        {
            if (ModelState.IsValid)
            {
                db.Bien.Add(bien);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bien);
        }

        // GET: Bienes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = await db.Bien.FindAsync(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // POST: Bienes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Titulo,Detalle,Precio,Telefono,Email,FechaIngreso,HoraIngreso")] Bien bien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bien).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bien);
        }

        // GET: Bienes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bien bien = await db.Bien.FindAsync(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // POST: Bienes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bien bien = await db.Bien.FindAsync(id);
            db.Bien.Remove(bien);
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
