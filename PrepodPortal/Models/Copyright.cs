namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("Copyright")]
   public partial class Copyright
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

      [Display(Name = "Вид")]
      [StringLength(255)]
      public string Type { get; set; }

      [Column(TypeName = "date")]
      [Display(Name = "Дата реєстрації")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime? RegisteredDate { get; set; }

      [StringLength(255)]
      [Display(Name = "Номер реєстрації")]
      public string RegistrationNum { get; set; }

      public virtual SecurityDocument SecurityDocument { get; set; }
   }
}
