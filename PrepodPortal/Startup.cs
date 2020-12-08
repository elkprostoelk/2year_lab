using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using PrepodPortal.Models;

[assembly: OwinStartupAttribute(typeof(PrepodPortal.Startup))]
namespace PrepodPortal
{
   public partial class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         ConfigureAuth(app);
            //await C.RoleManager.CreateAsync(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("superuser"));
        }
   }
}
