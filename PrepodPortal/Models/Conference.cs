namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("Conference")]
   public partial class Conference
   {
      public int Id { get; set; }

      [Required]
      [StringLength(128)]
      public string UserId { get; set; }

      [Required]
      [StringLength(500)]
      [Display(Name = "Назва")]
      public string Title { get; set; }

      [Column(TypeName = "date")]
      [Display(Name = "Дата проведення")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime? HeldDate { get; set; }

      [Display(Name = "Відбулася")]
      public bool? IsHeld { get; set; }

      [StringLength(100)]
      [Display(Name = "Місце проведення")]
      public string HeldLocation { get; set; }

      [StringLength(100)]
      [Display(Name = "Організатор")]
      public string Organizer { get; set; }

      public virtual UserProfile UserProfile { get; set; }
   }
}
