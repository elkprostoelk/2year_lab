namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("Article")]
   public partial class Article
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

      [StringLength(255)]
      [Display(Name = "Видання")]
      public string EditionName { get; set; }

      [StringLength(255)]
      [Display(Name = "Номер")]
      public string Number { get; set; }

      [StringLength(255)]
      [Display(Name = "Випуск")]
      public string Issue { get; set; }

      [StringLength(255)]
      [Display(Name = "Том")]
      public string Tome { get; set; }

      [StringLength(100)]
      [Display(Name = "Місце видання")]
      public string PublishedLocation { get; set; }

      [Display(Name = "Рік видання")]
      public int? PublishedYear { get; set; }

      [StringLength(255)]
      [Display(Name = "Номера сторінок")]
      public string PageNumbers { get; set; }

      [StringLength(100)]
      [Display(Name = "ISSN")]
      public string ISSN { get; set; }

      [StringLength(500)]
      [Display(Name = "URL")]
      public string URL { get; set; }

      [StringLength(255)]
      [Display(Name = "НМБД")]
      public string ScientometricDB { get; set; }

      [Display(Name = "SNIP індекс")]
      public double? SNIPIndex { get; set; }

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
