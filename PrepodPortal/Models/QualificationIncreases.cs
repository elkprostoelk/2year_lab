namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("QualificationIncreases")]
   public partial class QualificationIncrease
   {
      public int Id { get; set; }

      [Required]
      [StringLength(128)]
      public string UserId { get; set; }

      public int Type { get; set; }

      [Display(Name = "Номер наказу")]
      [StringLength(255)]
      public string OrderNumber { get; set; }

      [Display(Name = "Тема стажування")]
      [StringLength(255)]
      public string InternshipTheme { get; set; }

      [Display(Name = "Організація")]
      [StringLength(255)]
      public string Organisation { get; set; }

      [Column(TypeName = "date")]
      [Display(Name = "Дата початку стажування")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime? StartDate { get; set; }

      [Column(TypeName = "date")]
      [Display(Name = "Дата завершення стажування")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime? EndDate { get; set; }

      public virtual UserProfile UserProfile { get; set; }
   }
}
