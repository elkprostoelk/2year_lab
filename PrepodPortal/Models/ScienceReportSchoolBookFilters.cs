using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrepodPortal.Models
{
   public class ScienceReportSchoolBookFilters
   {
      public Enums.SchoolBookTypes SchoolBookType { get; set; }
      public DateTime SchoolBookFromDate { get; set; }
      public DateTime SchoolBookToDate { get; set; }
   }
}