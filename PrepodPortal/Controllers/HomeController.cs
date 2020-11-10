using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrepodPortal.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.IO;
using System.Web.Security;
using System.Net;

namespace PrepodPortal.Controllers
{
   public class HomeController : Controller
   {

      PrepodPortalDbContext db = new PrepodPortalDbContext();

      [HttpGet]
      public ActionResult Index(string id)
      {
         if (id == null)
         {
            if (User.Identity.IsAuthenticated)
            {
               return RedirectToAction("Index", new { id = C.GetMyId(User) });
            }
            else
            {
               return RedirectToAction("Index", "Welcome");
            }
         }

         UserProfile userProfile = db.UserProfiles.Find(id);
         if (userProfile == null)
         {
            return HttpNotFound();
         }

         return View(userProfile);
      }

      public ActionResult DeleteAvatar(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         System.IO.File.Delete(Server.MapPath(userProfile.AvatarImg));
         userProfile.AvatarImg = "/Images/no-avatar.png";
         db.SaveChanges();
         return RedirectToAction("Index", new { id = model.UserId });
      }

      [ValidateAntiForgeryToken]
      [Authorize]
      [HttpPost]
      public ActionResult ChangeAvatar(HttpPostedFileBase avatarImageFile, UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);

         var supportImageTypes = new[] { "jpg", "png", "jpeg" };
         var fileExt = Path.GetExtension(avatarImageFile.FileName).Substring(1).ToLower();
         string userFolderPath = "/Users/" + C.GetAppUser(userProfile.UserId).UserName + "/avatar/";
         DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(userFolderPath));

         if (avatarImageFile.ContentLength > 0)
         {
            if (avatarImageFile.ContentLength < 153600)
            {
               if (supportImageTypes.Contains(fileExt))
               {

                  foreach (FileInfo img in dirInfo.GetFiles())
                  {
                     img.Delete();
                  }

                  avatarImageFile.SaveAs(Server.MapPath(userFolderPath) + avatarImageFile.FileName);
                  userProfile.AvatarImg = userFolderPath + avatarImageFile.FileName;
                  db.SaveChanges();
               }
            }
            else
            {
               TempData["AvatarImg_IncorrectSize"] = "flag";
            }
         }
         else
         {
            TempData["AvatarImg_Corrupted"] = "flag";
         }
         return RedirectToAction("Index", new { id = model.UserId });
      }

      [HttpGet]
      public PartialViewResult RetrieveMainInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         return PartialView("_MainInfoPartial", userProfile);
      }

      [HttpGet]
      public PartialViewResult RetrieveScienceWorkInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         return PartialView("_ScienceWorkInfoPartial", userProfile);
      }

      [HttpGet]
      public PartialViewResult RetrieveReportsInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         return PartialView("_ScienceReportsPartial", new ScienceReportFilters() { UserId = userProfile.UserId });
      }

      [HttpGet]
      public PartialViewResult RetrieveProjectsInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         return PartialView("_ProjectsPartial", userProfile);
      }

      /*Filering*/

      [HttpGet]
      public PartialViewResult FilterPublications(UserProfile model, string filterBy)
      {

         try
         {
            UserProfile userProfile = db.UserProfiles.Find(model.UserId);

            TempData["CurrentFilterPublication"] = filterBy;

            switch (filterBy)
            {
               case "All": return PartialView("_PublicationsPartial", userProfile.Publications);
               case "Books": return PartialView("_PublicationsPartial", userProfile.Publications.Where(m => m.Type == (int)Enums.PublicationTypes.SchoolBook));
               case "Monographs": return PartialView("_PublicationsPartial", userProfile.Publications.Where(m => m.Type == (int)Enums.PublicationTypes.Monograph));
               case "Guidelines": return PartialView("_PublicationsPartial", userProfile.Publications.Where(m => m.Type == (int)Enums.PublicationTypes.Guideline));
               case "Aids": return PartialView("_PublicationsPartial", userProfile.Publications.Where(m => m.Type == (int)Enums.PublicationTypes.Tutorial));
               case "Article": return PartialView("_PublicationsPartial", userProfile.Publications.Where(m => m.Type == (int)Enums.PublicationTypes.Article));
               case "LectureTheses": return PartialView("_PublicationsPartial", userProfile.Publications.Where(m => m.Type == (int)Enums.PublicationTypes.LectureTheses));
               default: return PartialView("_PublicationsPartial", userProfile.Publications);
            }
         }
         catch (Exception ex)
         {
            return null;
         }
      }

      [HttpGet]
      public PartialViewResult FilterIncreaseQualInfo(UserProfile model, string filterBy)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         switch (filterBy)
         {
            case "All": return PartialView("_QualificationIncreasePartial", userProfile.QualificationIncreases);
            default: return PartialView("_QualificationIncreasePartial", userProfile.QualificationIncreases);
         }
      }

      [HttpGet]
      public PartialViewResult GetDissertationDefenseInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         return PartialView("_DissertationDefensePartial", userProfile.DissertationDefenses);
      }

      [HttpGet]
      public PartialViewResult GetAcademicDegreeInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         return PartialView("_AcademicDegreePartial", userProfile.AcademicDegrees);
      }

      [HttpGet]
      public PartialViewResult GetEducationInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         return PartialView("_EducationPartial", userProfile.Educations);
      }

      [HttpGet]
      public PartialViewResult GetScientometricDbProfileInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         return PartialView("_ScientometricDbProfilePartial", userProfile.ScientometricDbProfiles);
      }

      [HttpGet]
      public PartialViewResult FilterConferences(UserProfile model, string filterBy)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         TempData["CurrentFilterConferences"] = filterBy;

         switch (filterBy)
         {
            case "All": return PartialView("_ConferencesPartial", userProfile.Conferences);
            case "Helded": return PartialView("_ConferencesPartial", userProfile.Conferences.Where(m => m.IsHeld.Value));
            case "UnHelded": return PartialView("_ConferencesPartial", userProfile.Conferences.Where(m => !m.IsHeld.Value));
            case "DateUp": return PartialView("_ConferencesPartial", userProfile.Conferences.Where(m => m.HeldDate.HasValue).OrderBy(m => -m.HeldDate.Value.Ticks));
            case "DateDown": return PartialView("_ConferencesPartial", userProfile.Conferences.Where(m => m.HeldDate.HasValue).OrderBy(m => m.HeldDate.Value.Ticks));
            default: return PartialView("_ConferencesPartial", userProfile.Conferences);
         }
      }

      [HttpGet]
      public PartialViewResult FilterSecurityDocuments(UserProfile model, string filterBy)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);

         TempData["CurrentFilterSecurityDocs"] = filterBy;

         switch (filterBy)
         {
            case "All": return PartialView("_SecurityDocumentsPartial", userProfile.SecurityDocuments);
            case "1": return PartialView("_SecurityDocumentsPartial", userProfile.SecurityDocuments.Where(m => m.Type == (int)Enums.SecurityDocTypes.Patent));
            case "2": return PartialView("_SecurityDocumentsPartial", userProfile.SecurityDocuments.Where(m => m.Type == (int)Enums.SecurityDocTypes.Copyright));
            default: return PartialView("_SecurityDocumentsPartial", userProfile.SecurityDocuments);
         }
      }







      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public ActionResult LogOff()
      {
         HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
         return RedirectToAction("Index");
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> AddPublication(Publication model)
      {
         //if (Request.Files.Count > 0)
         //{
         //   var art_file = Request.Files["File"];
         //   string userFolderPath = string.Format("/Users/{0}/", User.Identity.Name.TrimEnd());
         //   art_file.SaveAs(Server.MapPath(userFolderPath) + art_file.FileName);
         //   //model.Article.AR_FilePath = userFolderPath + art_file.FileName;
         //}

         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         model.UserProfile = userProfile;
         model.Guid = Guid.NewGuid().ToString();

         switch ((Enums.PublicationTypes)model.Type)
         {
            case Enums.PublicationTypes.Article:
               model.Article.UserId = model.UserId;

               model.Article.AuthorNameList.Remove(userProfile.Name);
               model.Article.AuthorNameList.Add(userProfile.Name);
               model.Article.AuthorNames = string.Join(",", model.Article.AuthorNameList);

               foreach (string Author in model.Article.AuthorNameList)
               {
                  UserProfile up = db.UserProfiles.Where(u => u.Name == Author).FirstOrDefault();
                  model.UserProfile = up;
                  model.Article.UserId = up.UserId;
                  db.Articles.Add(model.Article);
                  db.Publications.Add(model);
                  await db.SaveChangesAsync();
               }
               break;

            case Enums.PublicationTypes.SchoolBook:
            case Enums.PublicationTypes.Tutorial:
            case Enums.PublicationTypes.Guideline:
               model.SchoolBook.UserId = model.UserId;

               model.SchoolBook.AuthorNameList.Remove(userProfile.Name);
               model.SchoolBook.AuthorNameList.Add(userProfile.Name);
               model.SchoolBook.AuthorNames = string.Join(",", model.SchoolBook.AuthorNameList);

               foreach (string Author in model.SchoolBook.AuthorNameList)
               {
                  UserProfile up = db.UserProfiles.Where(u => u.Name == Author).FirstOrDefault();
                  model.UserProfile = up;
                  model.SchoolBook.UserId = up.UserId;
                  db.SchoolBooks.Add(model.SchoolBook);
                  db.Publications.Add(model);
                  await db.SaveChangesAsync();
               }
               break;
            case Enums.PublicationTypes.Monograph:

               model.Monograph.UserId = model.UserId;

               model.Monograph.AuthorNameList.Remove(userProfile.Name);
               model.Monograph.AuthorNameList.Add(userProfile.Name);
               model.Monograph.AuthorNames = string.Join(",", model.Monograph.AuthorNameList);

               foreach (string Author in model.Monograph.AuthorNameList)
               {
                  UserProfile up = db.UserProfiles.Where(u => u.Name == Author).FirstOrDefault();
                  model.UserProfile = up;
                  model.Monograph.UserId = up.UserId;
                  db.Monographs.Add(model.Monograph);
                  db.Publications.Add(model);
                  await db.SaveChangesAsync();
               }

               break;
            case Enums.PublicationTypes.LectureTheses:

               model.LectureThes.UserId = model.UserId;

               model.LectureThes.AuthorNameList.Remove(userProfile.Name);
               model.LectureThes.AuthorNameList.Add(userProfile.Name);
               model.LectureThes.AuthorNames = string.Join(",", model.LectureThes.AuthorNameList);

               foreach (string Author in model.LectureThes.AuthorNameList)
               {
                  UserProfile up = db.UserProfiles.Where(u => u.Name == Author).FirstOrDefault();
                  model.UserProfile = up;
                  model.LectureThes.UserId = up.UserId;
                  db.LectureTheses.Add(model.LectureThes);
                  db.Publications.Add(model);
                  await db.SaveChangesAsync();
               }

               break;
         }

         //int x = await db.SaveChangesAsync();

         TempData["closeForm"] = "lol";
         return FilterPublications(userProfile, TempData["CurrentFilterPublication"].ToString());
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> AddSecurityDocument(SecurityDocument model)
      {

         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         model.UserProfile = userProfile;
         model.Guid = Guid.NewGuid().ToString();

         switch ((Enums.SecurityDocTypes)model.Type)
         {
            case Enums.SecurityDocTypes.Patent:

               model.Patent.UserId = model.UserId;

               model.Patent.AuthorNameList.Remove(userProfile.Name);
               model.Patent.AuthorNameList.Add(userProfile.Name);
               model.Patent.AuthorNames = string.Join(",", model.Patent.AuthorNameList);

               foreach (string Author in model.Patent.AuthorNameList)
               {
                  UserProfile up = db.UserProfiles.Where(u => u.Name == Author).FirstOrDefault();
                  model.UserProfile = up;
                  model.Patent.UserId = up.UserId;
                  db.Patents.Add(model.Patent);
                  db.SecurityDocuments.Add(model);
                  await db.SaveChangesAsync();
               }

               break;
            case Enums.SecurityDocTypes.Copyright:

               model.Copyright.UserId = model.UserId;

               model.Copyright.AuthorNameList.Remove(userProfile.Name);
               model.Copyright.AuthorNameList.Add(userProfile.Name);
               model.Copyright.AuthorNames = string.Join(",", model.Copyright.AuthorNameList);

               foreach (string Author in model.Copyright.AuthorNameList)
               {
                  UserProfile up = db.UserProfiles.Where(u => u.Name == Author).FirstOrDefault();
                  model.UserProfile = up;
                  model.Copyright.UserId = up.UserId;
                  db.Copyrights.Add(model.Copyright);
                  db.SecurityDocuments.Add(model);
                  await db.SaveChangesAsync();
               }

               break;
         }

         TempData["closeForm"] = "lol";
         return FilterSecurityDocuments(userProfile, TempData["CurrentFilterSecurityDocs"].ToString());
      }

      [HttpDelete]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> DeletePublication(Publication model)
      {
         Publication publ = db.Publications.Find(model.Id);
         UserProfile userProfile = publ.UserProfile;

         switch ((Enums.PublicationTypes)model.Type)
         {
            case Enums.PublicationTypes.Article:
               db.Articles.Remove(publ.Article);
               break;
            case Enums.PublicationTypes.Guideline:
            case Enums.PublicationTypes.SchoolBook:
            case Enums.PublicationTypes.Tutorial:
               db.SchoolBooks.Remove(publ.SchoolBook);
               break;
            case Enums.PublicationTypes.Monograph:
               db.Monographs.Remove(publ.Monograph);
               break;
            case Enums.PublicationTypes.LectureTheses:
               db.LectureTheses.Remove(publ.LectureThes);
               break;
         }

         db.Publications.Remove(publ);
         await db.SaveChangesAsync();

         return FilterPublications(userProfile, TempData["CurrentFilterPublication"].ToString());

      }

      [HttpDelete]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> DeleteSecurityDocument(SecurityDocument model)
      {
         SecurityDocument securityDocument = db.SecurityDocuments.Find(model.Id);
         UserProfile userProfile = securityDocument.UserProfile;

         switch ((Enums.SecurityDocTypes)model.Type)
         {
            case Enums.SecurityDocTypes.Patent:
               db.Patents.Remove(securityDocument.Patent);
               break;
            case Enums.SecurityDocTypes.Copyright:
               db.Copyrights.Remove(securityDocument.Copyright);
               break;
         }

         db.SecurityDocuments.Remove(securityDocument);
         await db.SaveChangesAsync();

         return FilterSecurityDocuments(userProfile, TempData["CurrentFilterSecurityDocs"].ToString());

      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> AddQualificationIncrease(QualificationIncrease model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         model.UserProfile = userProfile;
         db.QualificationIncreases.Add(model);
         int x = await db.SaveChangesAsync();
         TempData["closeForm"] = "lol";
         return FilterIncreaseQualInfo(userProfile, "All");
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> AddDissertationDefens(DissertationDefens model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         model.UserProfile = userProfile;
         db.DissertationDefenses.Add(model);
         int x = await db.SaveChangesAsync();
         TempData["closeForm"] = "lol";
         return GetDissertationDefenseInfo(userProfile);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> AddAcademicDegree(AcademicDegree model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         model.UserProfile = userProfile;
         db.AcademicDegrees.Add(model);
         int x = await db.SaveChangesAsync();
         TempData["closeForm"] = "lol";
         return GetAcademicDegreeInfo(userProfile);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> AddEducation(Education model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         model.UserProfile = userProfile;
         db.Educations.Add(model);
         int x = await db.SaveChangesAsync();
         TempData["closeForm"] = "lol";
         return GetEducationInfo(userProfile);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> AddScientometricDbProfile(ScientometricDbProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         model.UserProfile = userProfile;
         db.ScientometricDbProfiles.Add(model);
         int x = await db.SaveChangesAsync();
         TempData["closeForm"] = "lol";
         return GetScientometricDbProfileInfo(userProfile);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize(Roles = "admin")]
      public async Task<ActionResult> AddProject(Project model)
      {
         UserProfile userProfile = db.UserProfiles.FirstOrDefault(u => u.Name == model.Manager);
         model.UserProfile = userProfile;
         model.Guid = Guid.NewGuid().ToString();
         model.UserId = userProfile.UserId;
         if (model.MembersList != null)
         {
            model.Members = string.Join(",", model.MembersList);
         }
         model.Role = "Керівник";
         db.Projects.Add(model);
         await db.SaveChangesAsync();

         //Add record for each member
         if (model.MembersList != null && model.MembersList.Count > 0)
         {
            foreach (string member in model.MembersList)
            {
               UserProfile profile = db.UserProfiles.FirstOrDefault(u => u.Name == member);
               model.Role = "Учасник";
               model.UserId = profile.UserId;
               model.UserProfile = profile;
               db.Projects.Add(model);
               await db.SaveChangesAsync();
            }
         }

         TempData["closeForm"] = "lol";
         TempData["projAdded"] = true;
         return RetrieveProjectsInfo(db.UserProfiles.Find(User.Identity.GetUserId()));
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> EditProject(Project model)
      {

         //Removing record for each member
         IEnumerable<Project> existingRecords = db.Projects.Where(p => p.Guid == model.Guid);
         db.Projects.RemoveRange(existingRecords);

         //Update record for manager
         UserProfile userProfile = db.UserProfiles.FirstOrDefault(u => u.Name == model.Manager);

         if (User.IsInRole("admin") == false && User.Identity.GetUserId() != userProfile.UserId) return null;

         model.UserProfile = userProfile;
         model.UserId = userProfile.UserId;
         model.Role = "Керівник";
         if (model.MembersList != null)
         {
            model.Members = string.Join(",", model.MembersList);
         }
         db.Projects.Add(model);
         await db.SaveChangesAsync();

         //Add record for each member
         if (model.MembersList != null && model.MembersList.Count > 0)
         {
            foreach (string member in model.MembersList)
            {
               UserProfile profile = db.UserProfiles.FirstOrDefault(u => u.Name == member);
               model.Role = "Учасник";
               model.UserId = profile.UserId;
               model.UserProfile = profile;
               db.Projects.Add(model);
               await db.SaveChangesAsync();
            }
         }

         TempData["closeForm"] = "lol";
         TempData["projEdited"] = true;
         return RetrieveProjectsInfo(db.UserProfiles.Find(User.Identity.GetUserId()));
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> AddConference(Conference model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         model.UserProfile = userProfile;
         db.Conferences.Add(model);
         int x = await db.SaveChangesAsync();
         TempData["closeForm"] = "lol";
         return FilterConferences(userProfile, TempData["CurrentFilterConferences"].ToString());
      }

      [HttpDelete]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> DeleteConference(Conference model)
      {
         Conference conv = db.Conferences.Find(model.Id);
         UserProfile userProfile = conv.UserProfile;
         db.Conferences.Remove(conv);
         await db.SaveChangesAsync();

         return FilterConferences(userProfile, TempData["CurrentFilterConferences"].ToString());
      }

      [HttpDelete]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> DeleteDissertationDeffense(DissertationDefens model)
      {
         DissertationDefens dissertationDefens = db.DissertationDefenses.Find(model.Id);
         UserProfile userProfile = dissertationDefens.UserProfile;
         db.DissertationDefenses.Remove(dissertationDefens);
         await db.SaveChangesAsync();

         return GetDissertationDefenseInfo(userProfile);
      }

      [HttpDelete]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> DeleteEducation(Education model)
      {
         Education education = db.Educations.Find(model.Id);
         UserProfile userProfile = education.UserProfile;
         db.Educations.Remove(education);
         await db.SaveChangesAsync();

         return GetEducationInfo(userProfile);
      }

      [HttpDelete]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> DeleteScientometricDbProfile(ScientometricDbProfile model)
      {
         ScientometricDbProfile scientometricDbProfile = db.ScientometricDbProfiles.Find(model.Id);
         UserProfile userProfile = scientometricDbProfile.UserProfile;
         db.ScientometricDbProfiles.Remove(scientometricDbProfile);
         await db.SaveChangesAsync();

         return GetScientometricDbProfileInfo(userProfile);
      }

      [HttpDelete]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> DeleteAcademicDegree(AcademicDegree model)
      {
         AcademicDegree academicDegree = db.AcademicDegrees.Find(model.Id);
         UserProfile userProfile = academicDegree.UserProfile;
         db.AcademicDegrees.Remove(academicDegree);
         await db.SaveChangesAsync();

         return GetAcademicDegreeInfo(userProfile);
      }

      [HttpDelete]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> DeleteProject(Project model)
      {
         Project proj = db.Projects.Find(model.Id);
         UserProfile userProfile = proj.UserProfile;
         //Removing record for each member
         IEnumerable<Project> existingRecords = db.Projects.Where(p => p.Guid == proj.Guid);
         db.Projects.RemoveRange(existingRecords);
         await db.SaveChangesAsync();

         return RetrieveProjectsInfo(userProfile);
      }

      [HttpDelete]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> DeleteIncreaseQual(QualificationIncrease model)
      {
         QualificationIncrease qualIncrease = db.QualificationIncreases.Find(model.Id);
         UserProfile userProfile = qualIncrease.UserProfile;
         db.QualificationIncreases.Remove(qualIncrease);
         await db.SaveChangesAsync();

         return FilterIncreaseQualInfo(userProfile, "All");
      }







      /* Edit Profile */

      [HttpGet]
      [Authorize]
      public ActionResult EditProfile(string id)
      {
         if (id == null)
         {
            id = User.Identity.GetUserId();
         }
         UserProfile userProfile = db.UserProfiles.Find(id);
         return View(userProfile);
      }

      [HttpPut]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> EditMainInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         userProfile.Name = model.Name;
         userProfile.HomeTown = model.HomeTown;
         userProfile.Town = model.Town;
         userProfile.Gender = model.Gender;
         userProfile.BirthDate = model.BirthDate;
         userProfile.AcademicTitle = model.AcademicTitle;
         userProfile.ScienceDegree = model.ScienceDegree;

         await db.SaveChangesAsync();
         return Content(@"
            <script>               
                  $('#changeMainAlert').css('visibility', 'visible');
                  $('#changeMainAlert').css('opacity', '1');
                  setTimeout(function() { $('#changeMainAlert').css('opacity', '0'); 
                  $('#changeMainAlert').css('visibility', 'hidden'); }, 5000);
            </script>");
      }

      [HttpPut]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> EditCareerInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         userProfile.WorkPlaceMain = model.WorkPlaceMain;
         userProfile.WorkPlacePosition = model.WorkPlacePosition;
         await db.SaveChangesAsync();
         return Content(@"
            <script>               
                  $('#changeCareerAlert').css('visibility', 'visible');
                  $('#changeCareerAlert').css('opacity', '1');
                  setTimeout(function() { $('#changeCareerAlert').css('opacity', '0'); 
                  $('#changeCareerAlert').css('visibility', 'hidden'); }, 5000);
            </script>");
      }

      [HttpPut]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> EditEduInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         userProfile.InstDone = model.InstDone;
         userProfile.InstDoneQual = model.InstDoneQual;
         userProfile.InstDoneSpec = model.InstDoneSpec;
         userProfile.InstDoneWhen = model.InstDoneWhen;
         await db.SaveChangesAsync();
         return Content(@"
            <script>               
                  $('#changeEduAlert').css('visibility', 'visible');
                  $('#changeEduAlert').css('opacity', '1');
                  setTimeout(function() { $('#changeEduAlert').css('opacity', '0'); 
                  $('#changeEduAlert').css('visibility', 'hidden'); }, 5000);
            </script>");
      }

      [HttpPut]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> EditIncrQualInfo(UserProfile model)
      {
         /*UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         userProfile.IncrQualDocTheme = model.IncrQualDocTheme;
         userProfile.IncrQualDocType = model.IncrQualDocType;
         userProfile.IncrQualInst = model.IncrQualInst;
         userProfile.IncrQualRecieveDate = model.IncrQualRecieveDate;*/
         await db.SaveChangesAsync();
         return Content(@"
            <script>               
                  $('#changeIncrQualAlert').css('visibility', 'visible');
                  $('#changeIncrQualAlert').css('opacity', '1');
                  setTimeout(function() { $('#changeIncrQualAlert').css('opacity', '0'); 
                  $('#changeIncrQualAlert').css('visibility', 'hidden'); }, 5000);
            </script>");
      }

      [HttpPut]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> EditScienceInfo(UserProfile model)
      {
         UserProfile userProfile = db.UserProfiles.Find(model.UserId);
         userProfile.ResearchStage = model.ResearchStage;
         userProfile.CipherTtlResearchSpec = model.CipherTtlResearchSpec;
         userProfile.DissertTheme = model.DissertTheme;
         userProfile.WhrAssigned = model.WhrAssigned;
         userProfile.AcdmTtl = model.AcdmTtl;
         await db.SaveChangesAsync();
         return Content(@"
            <script>               
                  $('#changeScienceAlert').css('visibility', 'visible');
                  $('#changeScienceAlert').css('opacity', '1');
                  setTimeout(function() { $('#changeScienceAlert').css('opacity', '0'); 
                  $('#changeScienceAlert').css('visibility', 'hidden'); }, 5000);
            </script>");
      }

      [HttpPut]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> EditSubjectsInfo(string UserId, string[] subj, string[] subjH)
      {
         UserProfile userProfile = db.UserProfiles.Find(UserId);
         System.Text.StringBuilder subjects = new System.Text.StringBuilder();

         if (subj == null) subj = new string[] { };

         for (int i = 0; i < subj.Length; i++)
         {
            var _subj = subj[i];
            var _subjH = subjH[i];

            if (_subj.Length > 0 && _subjH.Length > 0)
            {
               subjects.AppendFormat("{0}-{1}ч,", _subj, _subjH);
            }
         }

         userProfile.Subjects = subjects.ToString().TrimEnd(new char[] { ',' });

         await db.SaveChangesAsync();

         return Content(@"
            <script>               
                  $('#changeSubjectsAlert').css('visibility', 'visible');
                  $('#changeSubjectsAlert').css('opacity', '1');
                  setTimeout(function() { $('#changeSubjectsAlert').css('opacity', '0'); 
                  $('#changeSubjectsAlert').css('visibility', 'hidden'); }, 5000);
            </script>");
      }

      /* Manage profile */
      
      [HttpGet]
      [Authorize]
      public ActionResult Manage()
      {
         UserProfile userProfile = db.UserProfiles.Find(C.GetMyId(User));
         return View(userProfile);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> ChangeEmail(ChangeEmailModel model, string userId)
      {
         var _userManager = C.UserManager;
         var user = await _userManager.FindByNameAsync(model.CurrentEmail);
         user.UserName = model.NewEmail;
         await _userManager.UpdateAsync(user);
         model.CurrentEmail = model.NewEmail;
         if (userId == C.GetMyId(User)) //normal request
         {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index");
         }
         else //ajax request
         {
            return Content(string.Format(@"
                                       <script>   
                                          $('#currEmail').html('{0}');$('#ChEmlErrCont').css('display','none');
                                          $('#ChEmlResetForm').trigger('click');
                                          $('#changeEmailAlert').css('visibility', 'visible');
                                          $('#changeEmailAlert').css('opacity', '1');
                                          setTimeout(function() {{ $('#changeEmailAlert').css('opacity', '0'); 
                                          $('#changeEmailAlert').css('visibility', 'hidden'); }}, 5000);
                                       </script>"), model.NewEmail);
         }
      }

      [HttpPut]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> ChangeUserPermissions(ChangeUserPermissions model, string userId)
      {
         try
         {
            if (model.AllowAddUsers == true)
            {
               await C.UserManager.AddToRoleAsync(userId, "profiles creator");
            }
            else
            {
               await C.UserManager.RemoveFromRoleAsync(userId, "profiles creator");
            }

            return Content(string.Format(@"
                        <script>   
                           $('#changeUserPermissionsAlert').css('visibility', 'visible');
                           $('#changeUserPermissionsAlert').css('opacity', '1');
                           setTimeout(function() {{ $('#changeUserPermissionsAlert').css('opacity', '0'); 
                           $('#changeUserPermissionsAlert').css('visibility', 'hidden'); }}, 5000);
                        </script>"));
         }
         catch (Exception ex)
         {
            return Content("<script>alert(" + ex.Message + ")</script>");
         }
      }


      [HttpPut]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> ChangePassword(ChangePasswordModel model, string userId)
      {
         var _userManager = C.UserManager;
         IdentityResult result;

         if (User.Identity.GetUserId() != userId)
         {
            var user = _userManager.FindById(userId);
            string token = _userManager.GeneratePasswordResetToken(user.Id);
            result = await _userManager.ResetPasswordAsync(user.Id, token, model.NewPassword);
         }
         else
         {
            result = await _userManager.ChangePasswordAsync(userId, model.CurrentPassword, model.NewPassword);
         }

         if (result.Succeeded)
         {
            return Content(@"
                  <script>               
                     $('#ChPErrCont').css('display','none');
                     $('#ChPResetForm').trigger('click');
                     $('#changePasswordAlert').css('visibility', 'visible');
                     $('#changePasswordAlert').css('opacity', '1');
                     setTimeout(function() { $('#changePasswordAlert').css('opacity', '0'); 
                     $('#changePasswordAlert').css('visibility', 'hidden'); }, 5000);
                  </script>");
         }
         else
         {
            return Content("<script>alert(" + result.Errors.First() + ")</script>");
         }
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<ActionResult> DeleteProfile(string id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         var userManager = C.UserManager;
         var user = await userManager.FindByIdAsync(id);
         var logins = user.Logins;
         var rolesForUser = await userManager.GetRolesAsync(id);
         UserProfile userProfile = await db.UserProfiles.FindAsync(id);

         using (var transaction = db.Database.BeginTransaction())
         {
            foreach (var login in logins.ToList())
            {
               await userManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            }

            if (rolesForUser.Count() > 0)
            {
               foreach (var item in rolesForUser.ToList())
               {
                  // item should be the name of the role
                  var result = await userManager.RemoveFromRoleAsync(user.Id, item);
               }
            }

            await userManager.DeleteAsync(user);

            db.UserProfiles.Remove(userProfile);

            transaction.Commit();
         }

         await db.SaveChangesAsync();

         if (id == User.Identity.GetUserId()) HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

         return RedirectToAction("Index");

      }

      [HttpGet]
      public ActionResult PrepodsList()
      {
         return View(db.UserProfiles);
      }

      [HttpGet]
      public ActionResult Reports()
      {
         return View(db.UserProfiles);
      }





      [HttpGet]
      public PartialViewResult GenerateScienceReport(ScienceReportFilters sReportFilters)
      {

         List<Publication> Publications = new List<Publication>();
         List<Conference> Conference = new List<Conference>();
         List<SecurityDocument> SecurityDocuments = new List<SecurityDocument>();
         List<DissertationDefens> DissertationDefenses = new List<DissertationDefens>();
         List<AcademicDegree> AcademicDegreeGains = new List<AcademicDegree>();
         List<QualificationIncrease> QualificationIncreases = new List<QualificationIncrease>();
         List<ScientometricDbProfile> ScientometricDbProfiles = new List<ScientometricDbProfile>();

         switch (sReportFilters.ReportType)
         {
            case Enums.ReportTypes.Global:
               Publications.AddRange(db.Publications);
               Conference.AddRange(db.Conferences);
               SecurityDocuments.AddRange(db.SecurityDocuments);
               AcademicDegreeGains.AddRange(db.AcademicDegrees);
               QualificationIncreases.AddRange(db.QualificationIncreases);
               DissertationDefenses.AddRange(db.DissertationDefenses);
               ScientometricDbProfiles.AddRange(db.ScientometricDbProfiles);
               break;
            case Enums.ReportTypes.Personal:
            default:

               UserProfile userProfile = db.UserProfiles.Find(sReportFilters.UserId);
               Publications.AddRange(userProfile.Publications);
               Conference.AddRange(userProfile.Conferences);
               SecurityDocuments.AddRange(userProfile.SecurityDocuments);
               AcademicDegreeGains.AddRange(userProfile.AcademicDegrees);
               QualificationIncreases.AddRange(userProfile.QualificationIncreases);
               DissertationDefenses.AddRange(userProfile.DissertationDefenses);
               ScientometricDbProfiles.AddRange(userProfile.ScientometricDbProfiles);
               break;

         }

         //Qualification Increase Filters
         if (sReportFilters.QualificationIncreaseFilters.QualificationIncreaseFromDate != null && sReportFilters.QualificationIncreaseFilters.QualificationIncreaseFromDate != DateTime.MinValue)
         {
            if (sReportFilters.QualificationIncreaseFilters.QualificationIncreaseToDate != null && sReportFilters.QualificationIncreaseFilters.QualificationIncreaseToDate != DateTime.MinValue)
            {
               QualificationIncreases.RemoveAll(p => p.StartDate < sReportFilters.QualificationIncreaseFilters.QualificationIncreaseFromDate || p.EndDate > sReportFilters.QualificationIncreaseFilters.QualificationIncreaseToDate);
            }
            else
            {
               QualificationIncreases.RemoveAll(p => p.StartDate < sReportFilters.QualificationIncreaseFilters.QualificationIncreaseFromDate);
            }
         }

         //Academic Degree Gain Filters
         if (sReportFilters.AcademicDegreeGainFilters.AcademicDegreeGainFromDate != null && sReportFilters.AcademicDegreeGainFilters.AcademicDegreeGainFromDate != DateTime.MinValue)
         {
            if (sReportFilters.AcademicDegreeGainFilters.AcademicDegreeGainToDate != null && sReportFilters.AcademicDegreeGainFilters.AcademicDegreeGainToDate != DateTime.MinValue)
            {
               AcademicDegreeGains.RemoveAll(p => p.ReceiveDiplomaDate < sReportFilters.AcademicDegreeGainFilters.AcademicDegreeGainFromDate || p.ReceiveDiplomaDate > sReportFilters.AcademicDegreeGainFilters.AcademicDegreeGainToDate);
            }
            else
            {
               AcademicDegreeGains.RemoveAll(p => p.ReceiveDiplomaDate < sReportFilters.AcademicDegreeGainFilters.AcademicDegreeGainFromDate);
            }
         }

         //Dissertation Deffense Filters
         if (sReportFilters.DissertationDefenseFilters.DissertationDefenseFromDate != null && sReportFilters.DissertationDefenseFilters.DissertationDefenseFromDate != DateTime.MinValue)
         {
            if (sReportFilters.DissertationDefenseFilters.DissertationDefenseToDate != null && sReportFilters.DissertationDefenseFilters.DissertationDefenseToDate != DateTime.MinValue)
            {
               DissertationDefenses.RemoveAll(p => p.DefenseDate < sReportFilters.DissertationDefenseFilters.DissertationDefenseFromDate || p.DefenseDate > sReportFilters.DissertationDefenseFilters.DissertationDefenseToDate);
            }
            else
            {
               DissertationDefenses.RemoveAll(p => p.DefenseDate < sReportFilters.DissertationDefenseFilters.DissertationDefenseFromDate);
            }
         }

         // Articles
         if (sReportFilters.ArticleFilters.ArticlesFromDate != null && sReportFilters.ArticleFilters.ArticlesFromDate != DateTime.MinValue)
         {
            if (sReportFilters.ArticleFilters.ArticlesToDate != null && sReportFilters.ArticleFilters.ArticlesToDate != DateTime.MinValue)
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Article && p.Article.PublishedYear < sReportFilters.ArticleFilters.ArticlesFromDate.Year || p.Type == (int)Enums.PublicationTypes.Article && p.Article.PublishedYear > sReportFilters.ArticleFilters.ArticlesToDate.Year);
            }
            else
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Article && p.Article.PublishedYear < sReportFilters.ArticleFilters.ArticlesFromDate.Year);
            }
         }
         if (sReportFilters.ArticleFilters.ArticleType != 0)
         {
            Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Article && p.Article.Type != (int)sReportFilters.ArticleFilters.ArticleType);
         }
         if (sReportFilters.ArticleFilters.SNIPIndexFrom.HasValue == true)
         {
            if (sReportFilters.ArticleFilters.SNIPIndexTo.HasValue == true)
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Article && p.Article.SNIPIndex < sReportFilters.ArticleFilters.SNIPIndexFrom.Value || p.Type == (int)Enums.PublicationTypes.Article && p.Article.SNIPIndex > sReportFilters.ArticleFilters.SNIPIndexTo.Value);
            }
            else
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Article && p.Article.SNIPIndex < sReportFilters.ArticleFilters.SNIPIndexFrom.Value);
            }
         }

         //Monoraphs
         if (sReportFilters.MonographFilters.MonographFromDate != null && sReportFilters.MonographFilters.MonographFromDate != DateTime.MinValue)
         {
            if (sReportFilters.MonographFilters.MonographToDate != null && sReportFilters.MonographFilters.MonographToDate != DateTime.MinValue)
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Monograph && p.Monograph.PublishedYear < sReportFilters.MonographFilters.MonographFromDate.Year || p.Type == (int)Enums.PublicationTypes.Monograph && p.Monograph.PublishedYear > sReportFilters.MonographFilters.MonographToDate.Year);
            }
            else
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Monograph && p.Monograph.PublishedYear < sReportFilters.MonographFilters.MonographFromDate.Year);
            }
         }
         if (sReportFilters.MonographFilters.MonographType != 0)
         {
            Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Monograph && p.Monograph.Type != (int)sReportFilters.MonographFilters.MonographType);
         }

         //SchoolBooks
         if (sReportFilters.SchoolBookFilters.SchoolBookFromDate != null && sReportFilters.SchoolBookFilters.SchoolBookFromDate != DateTime.MinValue)
         {
            if (sReportFilters.SchoolBookFilters.SchoolBookToDate != null && sReportFilters.SchoolBookFilters.SchoolBookToDate != DateTime.MinValue)
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.SchoolBook && p.SchoolBook.PublishedYear < sReportFilters.SchoolBookFilters.SchoolBookFromDate.Year || p.Type == (int)Enums.PublicationTypes.SchoolBook && p.SchoolBook.PublishedYear > sReportFilters.SchoolBookFilters.SchoolBookToDate.Year);
            }
            else
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.SchoolBook && p.SchoolBook.PublishedYear < sReportFilters.SchoolBookFilters.SchoolBookFromDate.Year);
            }
         }
         if (sReportFilters.SchoolBookFilters.SchoolBookType != 0)
         {
            Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.SchoolBook && p.SchoolBook.Type != (int)sReportFilters.SchoolBookFilters.SchoolBookType);
         }

         //Guidelines
         if (sReportFilters.GuidelineFilters.GuidelineFromDate != null && sReportFilters.GuidelineFilters.GuidelineFromDate != DateTime.MinValue)
         {
            if (sReportFilters.GuidelineFilters.GuidelineToDate != null && sReportFilters.GuidelineFilters.GuidelineToDate != DateTime.MinValue)
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Guideline && p.SchoolBook.PublishedYear < sReportFilters.GuidelineFilters.GuidelineFromDate.Year || p.Type == (int)Enums.PublicationTypes.Guideline && p.SchoolBook.PublishedYear > sReportFilters.GuidelineFilters.GuidelineToDate.Year);
            }
            else
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Guideline && p.SchoolBook.PublishedYear < sReportFilters.GuidelineFilters.GuidelineFromDate.Year);
            }
         }

         //Tutorial
         if (sReportFilters.TutorialFilters.TutorialFromDate != null && sReportFilters.TutorialFilters.TutorialFromDate != DateTime.MinValue)
         {
            if (sReportFilters.TutorialFilters.TutorialToDate != null && sReportFilters.TutorialFilters.TutorialToDate != DateTime.MinValue)
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Tutorial && p.SchoolBook.PublishedYear < sReportFilters.TutorialFilters.TutorialFromDate.Year || p.Type == (int)Enums.PublicationTypes.Tutorial && p.SchoolBook.PublishedYear > sReportFilters.TutorialFilters.TutorialToDate.Year);
            }
            else
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Tutorial && p.SchoolBook.PublishedYear < sReportFilters.TutorialFilters.TutorialFromDate.Year);
            }
         }
         if (sReportFilters.TutorialFilters.TutorialType != 0)
         {
            Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.Tutorial && p.SchoolBook.Type != (int)sReportFilters.TutorialFilters.TutorialType);
         }

         //Lecture Theses
         if (sReportFilters.LectureThesFilters.LectureThesFromDate != null && sReportFilters.LectureThesFilters.LectureThesFromDate != DateTime.MinValue)
         {
            if (sReportFilters.LectureThesFilters.LectureThesToDate != null && sReportFilters.LectureThesFilters.LectureThesToDate != DateTime.MinValue)
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.LectureTheses && p.LectureThes.PublishedYear < sReportFilters.LectureThesFilters.LectureThesFromDate.Year || p.Type == (int)Enums.PublicationTypes.LectureTheses && p.LectureThes.PublishedYear > sReportFilters.LectureThesFilters.LectureThesToDate.Year);
            }
            else
            {
               Publications.RemoveAll(p => p.Type == (int)Enums.PublicationTypes.LectureTheses && p.LectureThes.PublishedYear < sReportFilters.LectureThesFilters.LectureThesFromDate.Year);
            }
         }

         //Conference
         if (sReportFilters.ConferenceFilters.ConferenceFromDate != null && sReportFilters.ConferenceFilters.ConferenceFromDate != DateTime.MinValue)
         {
            if (sReportFilters.ConferenceFilters.ConferenceToDate != null && sReportFilters.ConferenceFilters.ConferenceToDate != DateTime.MinValue)
            {
               Conference.RemoveAll(c => c.HeldDate < sReportFilters.ConferenceFilters.ConferenceFromDate || c.HeldDate > sReportFilters.ConferenceFilters.ConferenceToDate);
            }
            else
            {
               Conference.RemoveAll(c => c.HeldDate < sReportFilters.ConferenceFilters.ConferenceFromDate);
            }
         }

         //Patents
         if (sReportFilters.PatentFilters.PatentFromDate != null && sReportFilters.PatentFilters.PatentFromDate != DateTime.MinValue)
         {
            if (sReportFilters.PatentFilters.PatentToDate != null && sReportFilters.PatentFilters.PatentToDate != DateTime.MinValue)
            {
               SecurityDocuments.RemoveAll(s => s.Type == (int)Enums.SecurityDocTypes.Patent && s.Patent.PublishDate < sReportFilters.PatentFilters.PatentFromDate || s.Type == (int)Enums.SecurityDocTypes.Patent && s.Patent.PublishDate > sReportFilters.PatentFilters.PatentToDate);
            }
            else
            {
               SecurityDocuments.RemoveAll(s => s.Type == (int)Enums.SecurityDocTypes.Patent && s.Patent.PublishDate < sReportFilters.PatentFilters.PatentFromDate);
            }
         }

         //Copyrights
         if (sReportFilters.CopyrightFilters.CopyrightFromDate != null && sReportFilters.CopyrightFilters.CopyrightFromDate != DateTime.MinValue)
         {
            if (sReportFilters.CopyrightFilters.CopyrightToDate != null && sReportFilters.CopyrightFilters.CopyrightToDate != DateTime.MinValue)
            {
               SecurityDocuments.RemoveAll(s => s.Type == (int)Enums.SecurityDocTypes.Copyright && s.Copyright.RegisteredDate < sReportFilters.CopyrightFilters.CopyrightFromDate || s.Type == (int)Enums.SecurityDocTypes.Copyright && s.Copyright.RegisteredDate > sReportFilters.CopyrightFilters.CopyrightToDate);
            }
            else
            {
               SecurityDocuments.RemoveAll(s => s.Type == (int)Enums.SecurityDocTypes.Copyright && s.Copyright.RegisteredDate < sReportFilters.CopyrightFilters.CopyrightFromDate);
            }
         }



         ScienceReport sReport = new ScienceReport();

         sReport.ArticlesWoSOrScopusSNIPIndexHigher04 = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Article && p.Article.Type == (int)Enums.ArticleTypes.WoSOrScopusSNIPIndexHigher04).Select(p => p.Article).ToList();
         sReport.ArticlesWoSOrScopusSNIPIndexLess04 = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Article && p.Article.Type == (int)Enums.ArticleTypes.WoSOrScopusSNIPIndexLess04).Select(p => p.Article).ToList();
         sReport.ArticlesPrintedInUkraineScienceEditionAndHasISSN = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Article && p.Article.Type == (int)Enums.ArticleTypes.PrintedInUkraineScienceEditionAndHasISSN).Select(p => p.Article).ToList();
         sReport.ArticlesPrintedInScienceMagazineWithImpactFactor = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Article && p.Article.Type == (int)Enums.ArticleTypes.PrintedInScienceMagazineWithImpactFactor).Select(p => p.Article).ToList();
         sReport.ArticlesPrintedInOtherUkraineEditions = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Article && p.Article.Type == (int)Enums.ArticleTypes.PrintedInOtherUkraineEditions).Select(p => p.Article).ToList();

         sReport.MonographPublishedInDomesticEditions = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Monograph && p.Monograph.Type == (int)Enums.MonographTypes.PublishedInDomesticEditions).Select(p => p.Monograph).ToList();
         sReport.MonographPublishedInForeignEditions = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Monograph && p.Monograph.Type == (int)Enums.MonographTypes.PublishedInForeignEditions).Select(p => p.Monograph).ToList();
         sReport.MonographSectionsPublishedInDomesticEditions = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Monograph && p.Monograph.Type == (int)Enums.MonographTypes.SectionsPublishedInDomesticEditions).Select(p => p.Monograph).ToList();

         sReport.SchoolBookRecommendedByAcademicCouncilOfKSU = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.SchoolBook && p.SchoolBook.Type == (int)Enums.SchoolBookTypes.RecommendedByAcademicCouncilOfKSU).Select(p => p.SchoolBook).ToList();
         sReport.SchoolBookGryphMOHOfUkraine = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.SchoolBook && p.SchoolBook.Type == (int)Enums.SchoolBookTypes.GryphMOHOfUkraine).Select(p => p.SchoolBook).ToList();
         sReport.SchoolBookOthers = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.SchoolBook && p.SchoolBook.Type == (int)Enums.SchoolBookTypes.Other).Select(p => p.SchoolBook).ToList();

         sReport.Guidelines = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Guideline).Select(p => p.SchoolBook).ToList();

         sReport.TutorialRecommendedByAcademicCouncilOfKSU = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Tutorial && p.SchoolBook.Type == (int)Enums.SchoolBookTypes.RecommendedByAcademicCouncilOfKSU).Select(p => p.SchoolBook).ToList();
         sReport.TutorialGryphMOHOfUkraine = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Tutorial && p.SchoolBook.Type == (int)Enums.SchoolBookTypes.GryphMOHOfUkraine).Select(p => p.SchoolBook).ToList();
         sReport.TutorialOthers = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.Tutorial && p.SchoolBook.Type == (int)Enums.SchoolBookTypes.Other).Select(p => p.SchoolBook).ToList();

         sReport.LectureTheses = Publications.Where(p => p.Type == (int)Enums.PublicationTypes.LectureTheses).Select(p => p.LectureThes).ToList();

         sReport.Conference = Conference.ToList();

         sReport.Copyrights = SecurityDocuments.Where(s => s.Type == (int)Enums.SecurityDocTypes.Copyright).Select(s => s.Copyright).ToList();

         sReport.Patents = SecurityDocuments.Where(s => s.Type == (int)Enums.SecurityDocTypes.Patent).Select(s => s.Patent).ToList();

         sReport.AcademicDegreeGainsAssitProf = AcademicDegreeGains.Where(a => a.Type == (int)Enums.AcademicDegreeGainTypes.AssistantProfessor).ToList();

         sReport.AcademicDegreeGainsProf = AcademicDegreeGains.Where(a => a.Type == (int)Enums.AcademicDegreeGainTypes.Professor).ToList();

         sReport.DissertationDefensesPHD = DissertationDefenses.Where(d => d.Type == (int)Enums.DissertationDefensTypes.PHD).ToList();

         sReport.DissertationDefensesPH_D = DissertationDefenses.Where(d => d.Type == (int)Enums.DissertationDefensTypes.PH_D).ToList();

         sReport.QualificationIncreases = QualificationIncreases.ToList();

         sReport.ScientometricDbProfiles = ScientometricDbProfiles.ToList();

         return PartialView("_ScienceReportPartial", sReport);
      }
   }
}
