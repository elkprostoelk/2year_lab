using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrepodPortal.Models
{
   public class ScienceReportArticleFilters
   {
      public Enums.ArticleTypes ArticleType { get; set; }
      public DateTime ArticlesFromDate { get; set; }
      public DateTime ArticlesToDate { get; set; }
      public double? SNIPIndexFrom { get; set; }
      public double? SNIPIndexTo { get; set; }

   }
}