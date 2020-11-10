using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrepodPortal.Models
{
   public class ScienceReportDissertationDefenseFilters
   {
      public DateTime DissertationDefenseFromDate { get; set; }
      public DateTime DissertationDefenseToDate { get; set; }
      public Enums.DissertationDefensTypes Type { get; set; }
   }
}