using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace PrepodPortal.Models
{
   public class ChangePasswordModel
   {
      [Required]
      public string UserId { get; set; }

      [DataType(DataType.Password)]
      [Required(ErrorMessage = "Укажіть поточний пароль")]
      [Display(Name = "Поточний пароль : ")]
      public string CurrentPassword { get; set; }

      [Required(ErrorMessage = "Укажіть новий пароль")]
      [DataType(DataType.Password)]
      [Display(Name = "Новий пароль : ")]
      public string NewPassword { get; set; }

      [Required(ErrorMessage = "Укажіть підтверджений новий пароль")]
      [Compare("NewPassword", ErrorMessage = "Новий пароль підтверждено неврно")]
      [DataType(DataType.Password)]
      [Display(Name = "Підтверждення н. пароль : ")]
      public string ConfirmNewPassword { get; set; }
   }

   public class ChangeEmailModel
   {
      [Required]
      public string UserId { get; set; }

      [Display(Name = "Поточна адреса ел. пошти : ")]
      public string CurrentEmail { get; set; }

      [DataType(DataType.EmailAddress)]
      [Required(ErrorMessage = "Укажіть нову адресу електронної пошти")]
      [Display(Name = "Нова адреса ел. пошти : ")]
      public string NewEmail { get; set; }
   }

   public class ChangeUserPermissions
   {
      [Required]
      public string UserId { get; set; }
      [Display(Name = "Дозволити реєструвати користувачів")]
      public Boolean AllowAddUsers { get; set; }
   }
}