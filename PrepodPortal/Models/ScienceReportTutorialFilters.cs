using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrepodPortal.Models
{
   public class ScienceReportTutorialFilters
   {
      public Enums.SchoolBookTypes TutorialType { get; set; }
      public DateTime TutorialFromDate { get; set; }
      public DateTime TutorialToDate { get; set; }
   }
}