using AllBusinesLands.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AllBusinesLands.Controllers
{
    public class UsuariosController : Controller
    {
        public UsuariosController()
        {
        }

        public UsuariosController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize(Roles = "Administrador")]
        // GET: /Usuarios/
        public async Task<ActionResult> Index()
        {
            return View(await UserManager.Users.ToListAsync());
        }

        [Authorize(Roles = "Administrador")]
        // GET: /Usarios/Detalles/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);

            return View(user);
        }

        [Authorize(Roles = "Administrador")]
        // GET: /Usuarios/Edit/1
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Estado = user.Estado
            });
        }

        [Authorize(Roles = "Administrador")]
        // POST: /Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,UserName,Estado")] EditUserViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                user.Email = editUser.Email;
                user.UserName = editUser.UserName;
                user.Estado = editUser.Estado;

                IdentityResult result = await UserManager.UpdateAsync(user);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something failed.");
            
            return View();
        }
    }
}