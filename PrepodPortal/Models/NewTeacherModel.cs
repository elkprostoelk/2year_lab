using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrepodPortal.Models
{
    public class NewTeacherModel
    {
        [Required(ErrorMessage = "Уведіть ПІБ викладача.")]
        [Display(Name = "ПІБ викладача")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Уведіть адресу ел. пошти викладача.")]
        [EmailAddress(ErrorMessage = "Будь ласка, введіть коректну адресу ел.пошти.")]
        [Display(Name = "Адреса ел. пошти викладача")]
        public string Email { get; set; }
    }
}