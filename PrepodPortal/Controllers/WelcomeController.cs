using Microsoft.AspNet.Identity.Owin;
using PrepodPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PrepodPortal.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(WelcomeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            
            var result = await HttpContext.GetOwinContext().Get<ApplicationSignInManager>().PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            var user = await C.UserManager.FindByNameAsync(model.UserName);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index","Home", new { id = user.Id });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Виникла помилка при спробі авторизації.");
                    return View(model);
            }
        }
    }
}
