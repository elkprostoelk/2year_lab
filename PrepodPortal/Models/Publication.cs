namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("Publication")]
   public partial class Publication
   {
      public int Id { get; set; }

      [Required]
      [StringLength(128)]
      public string UserId { get; set; }

      public int Type { get; set; }

      [StringLength(128)]
      public string Guid { get; set; }

      public virtual Article Article { get; set; }

      public virtual LectureThes LectureThes { get; set; }

      public virtual Monograph Monograph { get; set; }

      public virtual UserProfile UserProfile { get; set; }

      public virtual SchoolBook SchoolBook { get; set; }

      //public Publication CreateCopy()
      //{
      //   Publication copy = new Publication();
      //   copy.UserId = UserId;
      //   copy.Type = Type;

      //   if (Article != null)
      //   {
      //      copy.Article = new Article();
      //      copy.Article.Id = Article.Id;
      //      copy.Article.AuthorNameList = Article.AuthorNameList;
      //      copy.Article.AuthorNames = Article.AuthorNames;
      //      copy.Article.EditionName = Article.EditionName;
      //      copy.Article.Issue = Article.Issue;
      //      copy.Article.Number = Article.Number;
      //      copy.Article.NumPagesByAuthor = Article.NumPagesByAuthor;
      //      copy.Article.NumPagesTotal = Article.NumPagesTotal;
      //      copy.Article.NumPrintedPagesByAuthor = Article.NumPrintedPagesByAuthor;
      //      copy.Article.NumPrintedPagesTotal = Article.NumPrintedPagesTotal;
      //      copy.Article.PageNumbers = Article.PageNumbers;
      //      copy.Article.PublishedLocation = Article.PublishedLocation;
      //      copy.Article.PublishedYear = Article.PublishedYear;
      //      copy.Article.ScientometricDB = Article.ScientometricDB;
      //   }
      //}

   }
}
