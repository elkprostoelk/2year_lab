namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("DissertationDefenses")]
   public partial class DissertationDefens
   {
      public int Id { get; set; }

      [Required]
      [StringLength(128)]
      public string UserId { get; set; }

      public int Type { get; set; }

      [StringLength(255)]
      [Display(Name = "Тема дисертації")]
      public string Theme { get; set; }

      [StringLength(500)]
      [Display(Name = "Шифр и назва спец.")]
      public string CipherAndSpecialty { get; set; }

      [Column(TypeName = "date")]
      [Display(Name = "Дата захисту")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime? DefenseDate { get; set; }

      [Column(TypeName = "date")]
      [Display(Name = "Дата отримання диплома")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime? ReceiveDiplomaDate { get; set; }

      [StringLength(255)]
      [Display(Name = "Номер диплома")]
      public string DiplomaNumber { get; set; }

      [StringLength(500)]
      [Display(Name = "Де захищено/Ким призначено")]
      public string DefenseLocationAndWhoAssignedBy { get; set; }

      [StringLength(255)]
      [Display(Name = "Науковий керівник")]
      public string ScientificDirector { get; set; }

      public virtual UserProfile UserProfile { get; set; }
   }
}
