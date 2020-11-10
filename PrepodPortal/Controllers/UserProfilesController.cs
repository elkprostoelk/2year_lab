using PrepodPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PrepodPortal.Controllers
{
   public class UserProfilesController : ApiController
   {
      PrepodPortalDbContext db = new PrepodPortalDbContext();

      // GET api/<controller>
      public string Get()
      {
         return Newtonsoft.Json.JsonConvert.SerializeObject(db.UserProfiles.ToList(), new Newtonsoft.Json.JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
      }

      // GET api/<controller>/5
      public string Get(string id)
      {
         UserProfile profile = db.UserProfiles.Where(p => p.Name.Trim() == id.Trim()).FirstOrDefault();
         if (profile != null)
         {
            return Newtonsoft.Json.JsonConvert.SerializeObject(profile, new Newtonsoft.Json.JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
         }
         else
         {
            return "-1";
         }
      }

      // POST api/<controller>
      public void Post([FromBody]string value)
      {
      }

      // PUT api/<controller>/5
      public void Put(int id, [FromBody]string value)
      {
      }

      // DELETE api/<controller>/5
      public void Delete(int id)
      {
      }
   }
}