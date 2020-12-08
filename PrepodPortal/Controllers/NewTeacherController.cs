using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using PrepodPortal.Models;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace PrepodPortal.Controllers
{
   public class NewTeacherController : Controller
   {
      [HttpGet]
      [Authorize(Roles = "profiles creator, admin")]
      public ActionResult Index()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize(Roles = "profiles creator, admin")]
      public async Task<ActionResult> Index(NewTeacherModel m)
      {
         if (ModelState.IsValid)
         {
            var password = System.Web.Security.Membership.GeneratePassword(10, 5);
            var newUser = new ApplicationUser { UserName = m.Email, Email = m.Email };
            var result = await C.UserManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
               PrepodPortalDbContext db = new PrepodPortalDbContext();
               db.UserProfiles.Add(new UserProfile() { UserId = newUser.Id, Name = m.Name, AvatarImg = "/Images/no-avatar.png" });
               await db.SaveChangesAsync();
               C.UserManager.AddToRole(newUser.Id, "user");
               Directory.CreateDirectory(Server.MapPath("/Users/" + m.Email));
               Directory.CreateDirectory(Server.MapPath("/Users/" + m.Email + "/avatar"));
               sendEmail(m.Name, m.Email, password);
               TempData["UserCreated"] = true;
               TempData["UserId"] = newUser.Id;
               return RedirectToAction("Index");
            }
            AddErrors(result);
         }
         return View(m);
      }

      private void sendEmail(string name, string email, string password)
      {
         SmtpClient smtpClient = new SmtpClient();
         smtpClient.Host = "smtp.gmail.com";
         smtpClient.Port = 587;
         smtpClient.UseDefaultCredentials = false;
         smtpClient.EnableSsl = true;
         smtpClient.Credentials = new System.Net.NetworkCredential(C.GetMailUsername(), C.GetMailPassword());
         smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

         MailMessage mail = new MailMessage() { From = new MailAddress("mpoltorackiy@gmail.com") };
         mail.To.Add(new MailAddress(email));
         mail.Subject = "Ласкаво просимо на еНауковаДекларація " + name;
         mail.Body = string.Format("Вітаємо, {0}. Вас зареєстрував на еНауковаДекларація працівник кафедри. Ваші дані для входу : 1)Ім'я користувача: {1} ; 2)Пароль: {2} http://pn.sadlogic.com", name, email, password);
         try
         {
            smtpClient.Send(mail);
         }
         catch (Exception ex)
         {
            string errorMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            TempData["EmailSendError"] = errorMsg;
         }
      }

      private void AddErrors(IdentityResult result)
      {
         foreach (var error in result.Errors)
         {
            ModelState.AddModelError("", error);
         }
      }

   }
}
