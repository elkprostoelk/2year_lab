namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("Patent")]
   public partial class Patent
   {
      [DatabaseGenerated(DatabaseGeneratedOption.None)]
      public int Id { get; set; }

      [Required]
      [StringLength(128)]
      public string UserId { get; set; }

      [StringLength(500)]
      [Display(Name = "Автори")]
      public string AuthorNames { get; set; }

      [Required]
      [Display(Name = "Автори")]
      [NotMapped]
      public List<string> AuthorNameList { get; set; }

      [Required]
      [StringLength(255)]
      [Display(Name = "Назва")]
      public string Title { get; set; }

      [StringLength(255)]
      [Display(Name = "Власник")]
      public string Owner { get; set; }

      [Column(TypeName = "date")]
      [Display(Name = "Дата публікації")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime? PublishDate { get; set; }

      [StringLength(255)]
      [Display(Name = "Номер")]
      public string Number { get; set; }

      [StringLength(255)]
      [Display(Name = "Номер заявки")]
      public string ApplicationNum { get; set; }

      public virtual SecurityDocument SecurityDocument { get; set; }
   }
}
