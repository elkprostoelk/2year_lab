namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("Education")]
   public partial class Education
   {
      public int Id { get; set; }

      [Required]
      [StringLength(128)]
      public string UserId { get; set; }

      [StringLength(255)]
      [Display(Name = "Заклад")]
      public string Institution { get; set; }

      [StringLength(10)]
      [Display(Name = "Рік початку")]
      public string StartYear { get; set; }

      [StringLength(10)]
      [Display(Name = "Рік завершення")]
      public string EndYear { get; set; }

      [StringLength(255)]
      [Display(Name = "Кваліфікація за дипломом")]
      public string QualificationByDiploma { get; set; }

      [StringLength(10)]
      [Display(Name = "Спеціальність")]
      public string Specialty { get; set; }

      public virtual UserProfile UserProfile { get; set; }
   }
}
