using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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

        [Authorize(Roles = "Administrador, Usuario")]
        // GET: Bienes
        public async Task<ActionResult> Index()
        {
            return View(await db.Bien.ToListAsync());
        }

        [Authorize(Roles = "Administrador, Usuario")]
        // GET: Bienes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var userName = from cu in db.Comentario
                                      join u in db.Users on cu.UserId equals u.Id
                                      select u.UserName;


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

        [Authorize(Roles = "Administrador")]
        // GET: Bienes/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        // POST: Bienes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Titulo,Detalle,Precio,Telefono,Email,FechaIngreso,HoraIngreso,Estado")] Bien bien, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                //var filename = image.FileName;
                //var filePathOriginal = Server.MapPath("/content/uploads/bienes");
                //string savedFileName = Path.Combine(filePathOriginal, filename);
                //bien.image_path = @"/content/uploads/bienes/" + filename;
                db.Bien.Add(bien);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bien);
        }

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
        // POST: Bienes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Titulo,Detalle,Precio,Telefono,Email,FechaIngreso,HoraIngreso,Estado")] Bien bien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bien).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bien);
        }

        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
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
