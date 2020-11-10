using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrepodPortal.Models
{
   public class ScienceReportMonographFilters
   {
      public Enums.MonographTypes MonographType { get; set; }
      public DateTime MonographFromDate { get; set; }
      public DateTime MonographToDate { get; set; }
   }
}