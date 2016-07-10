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
using Microsoft.AspNet.Identity;

namespace AllBusinesLands.Controllers
{
    public class ComentariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comentarios
        public async Task<ActionResult> Index()
        {
            var comentario = db.Comentario.Include(c => c.Bien);
            return View(await comentario.ToListAsync());
        }

        // GET: Comentarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = await db.Comentario.FindAsync(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Comentarios/Create
        public ActionResult Create(int id)
        {
            //ViewBag.BienId = new SelectList(db.Bien, "Id", "Titulo");
            ViewBag.BienId = id;
            return View();
        }

        // POST: Comentarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BienId,Contenido")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.UserId = User.Identity.GetUserId();
                comentario.FechaIngreso = System.DateTime.Now;
                comentario.HoraIngreso =  System.DateTime.Now;
                comentario.Estado = true;
                db.Comentario.Add(comentario);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Bienes", new { id = comentario.BienId });
            }

            ViewBag.BienId = new SelectList(db.Bien, "Id", "Titulo", comentario.BienId);
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = await db.Comentario.FindAsync(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.BienId = new SelectList(db.Bien, "Id", "Titulo", comentario.BienId);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BienId,Contenido,FechaIngreso,HoraIngreso,Estado")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BienId = new SelectList(db.Bien, "Id", "Titulo", comentario.BienId);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = await db.Comentario.FindAsync(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Comentario comentario = await db.Comentario.FindAsync(id);
            db.Comentario.Remove(comentario);
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
