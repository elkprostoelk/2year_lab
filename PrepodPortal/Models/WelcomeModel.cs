using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrepodPortal.Models
{
    public class WelcomeModel
    {
        [Required(ErrorMessage = "Уведіть ім'я користувача.")]
        [Display(Name = "Ім'я користувача")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Уведіть пароль.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Не виходити з системи")]
        public bool RememberMe { get; set; }      
    }
}