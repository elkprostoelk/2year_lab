namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;

   [Table("Project")]
   public partial class Project
   {
      public int Id { get; set; }

      [StringLength(128)]
      public string Guid { get; set; }

      [Required]
      [StringLength(128)]
      public string UserId { get; set; }

      [StringLength(512)]
      [Display(Name = "Назва")]
      public string Name { get; set; }

      [StringLength(4000)]
      [Display(Name = "Опис")]
      public string Description { get; set; }

      [StringLength(256)]
      [Required]
      [Display(Name = "Керівник")]
      public string Manager { get; set; }

      [StringLength(4000)]
      [Display(Name = "Учасники")]
      public string Members { get; set; }

      [NotMapped]
      [Display(Name = "Учасники")]
      public List<string> MembersList { get; set; }

      [Column(TypeName = "date")]
      [Display(Name = "Дата створення")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime Date { get; set; }

      [Display(Name = "Роль")]
      public string Role { get; set; }

      public virtual UserProfile UserProfile { get; set; }
   }
}