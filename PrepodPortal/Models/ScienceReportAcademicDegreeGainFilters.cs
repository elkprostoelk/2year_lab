using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrepodPortal.Models
{
   public class ScienceReportAcademicDegreeGainFilters
   {
      public DateTime AcademicDegreeGainFromDate { get; set; }
      public DateTime AcademicDegreeGainToDate { get; set; }
      public Enums.AcademicDegreeGainTypes Type { get; set; }
   }
}