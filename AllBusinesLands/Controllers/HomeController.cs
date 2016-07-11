using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllBusinesLands.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace AllBusinesLands.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Administrador, Usuario")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("josevayac@gmail.com")); // replace with valid value
                message.Bcc.Add(new MailAddress("walheresq@hotmail.com"));
                message.From = new MailAddress("josevaya@hotmail.com"); // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "josevaya@hotmail.com", // replace with valid value
                        Password = "1102790612YACj" // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult EnviarBien()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> EnviarBien(int bienId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string usuarioId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {

                var bien = from bienes in db.Bien
                           where bienId == bienes.Id
                           select bienes;

                var userEmail = from users in db.Users
                                where usuarioId == users.Id
                                select users.Email;

                var body = "<p>Email From: All Business Lands (admin@allbusinesslands.com)</p>" +
                           "<p>Detalles del bien:</p>" +
                           "<p>Titulo: {0}</p>" +
                           "<p>Detalles: {1}</p>" +
                           "<p>Precio: {2}</p>";
                           
                var message = new MailMessage();
                message.To.Add(new MailAddress(userEmail.First())); // replace with valid value
                message.From = new MailAddress("josevaya@hotmail.com"); // replace with valid value
                message.Subject = "Your email subject";

                foreach (var item in bien)
                {
                    message.Body = string.Format(body, item.Titulo, item.Detalle, item.Precio);
                }

                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "josevaya@hotmail.com", // replace with valid value
                        Password = "1102790612YACj" // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View();
        }
    }
}