namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("AcademicDegree")]
   public partial class AcademicDegree
   {
      public int Id { get; set; }

      [Required]
      [StringLength(128)]
      public string UserId { get; set; }

      public int Type { get; set; }

      [Column(TypeName = "date")]
      [Display(Name = "Дата отримання диплома")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime? ReceiveDiplomaDate { get; set; }

      [StringLength(255)]
      [Display(Name = "Номер диплома")]
      public string DiplomaNumber { get; set; }

      public virtual UserProfile UserProfile { get; set; }
   }
}
