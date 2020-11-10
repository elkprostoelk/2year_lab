namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("SchoolBook")]
   public partial class SchoolBook
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
      [StringLength(500)]
      [Display(Name = "Назва")]
      public string Title { get; set; }

      public int Type { get; set; }

      [Display(Name = "Тип грифу")]
      public int? GryphType { get; set; }

      [StringLength(500)]
      [Display(Name = "ISBN")]
      public string ISBN { get; set; }

      [StringLength(200)]
      [Display(Name = "Номер наказу")]
      public string OrderNum { get; set; }

      [Column(TypeName = "date")]
      [Display(Name = "Дата наказу")]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime? OrderDate { get; set; }

      [StringLength(100)]
      [Display(Name = "Місце видання")]
      public string PublishedLocation { get; set; }

      [StringLength(500)]
      [Display(Name = "Назва видання")]
      public string PublisherName { get; set; }

      [Display(Name = "Рік видання")]
      public int? PublishedYear { get; set; }

      [Display(Name = "Загальна к-сть сторінок")]
      public int? NumPagesTotal { get; set; }

      [Display(Name = "К-сть сторінок написано автором")]
      public int? NumPagesByAuthor { get; set; }

      [Display(Name = "Загальна к-сть друкованих сторінок")]
      public int? NumPrintedPagesTotal { get; set; }

      [Display(Name = "К-сть друкованих сторінок написано автором")]
      public int? NumPrintedPagesByAuthor { get; set; }

      public virtual Publication Publication { get; set; }
   }
}
