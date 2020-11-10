using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrepodPortal.Startup))]
namespace PrepodPortal
{
   public partial class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         ConfigureAuth(app);
      }
   }
}
