using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PrepodPortal;
using PrepodPortal.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Summary description for C
/// </summary>
public static class C
{

   public static UserManager<ApplicationUser> UserManager
   {
      get
      {
         AccountDbContext context = new AccountDbContext();
         var userStore = new UserStore<ApplicationUser>(context);
         var userManager = new UserManager<ApplicationUser>(userStore);
         var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Prepod Portal");
         userManager.UserTokenProvider = userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("PasswordReset"));
         return userManager;
      }
   }

   public static RoleManager<IdentityRole> RoleManager
   {
      get
      {
         AccountDbContext context = new AccountDbContext();
         var roleStore = new RoleStore<IdentityRole>(context);
         var roleManager = new RoleManager<IdentityRole>(roleStore);
         return roleManager;
      }
   }

   public static ApplicationUser GetAppUser(string UserId)
   {
      return UserManager.FindById(UserId);
   }

   public static string GetMyId(System.Security.Principal.IPrincipal User)
   {
      var claimsIdentity = User.Identity as ClaimsIdentity;
      var userIdValue = "";
      if (claimsIdentity != null)
      {
         // the principal identity is a claims identity.
         // now we need to find the NameIdentifier claim
         var userIdClaim = claimsIdentity.Claims
             .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

         if (userIdClaim != null)
         {
            userIdValue = userIdClaim.Value;
         }
      }
      return userIdValue;
   }

   public static string GetMailUsername()
   {
      return "KSU.PrepodPortal@gmail.com";
   }
   public static string GetMailPassword()
   {
      return "whitenblack";
   }

   public static string getGender(string gender)
   {
      if (gender == "M")
      {
         return "Чоловіча";
      }
      else
      {
         return "Жіноча";
      }
   }

   public static PrepodPortalDbContext Database
   {
      get
      {
         return new PrepodPortalDbContext();
      }
   }

   public static List<string> GetPrepodNameList()
   {
      return Database.UserProfiles.Select(u => u.Name).ToList();
   }

}
