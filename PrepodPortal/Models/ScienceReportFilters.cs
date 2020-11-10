using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrepodPortal.Models
{
   public class ScienceReportFilters
   {
      public string UserId { get; set; }
      public Enums.ReportTypes ReportType { get; set; }
      public ScienceReportArticleFilters ArticleFilters { get; set; }
      public ScienceReportMonographFilters MonographFilters { get; set; }
      public ScienceReportLectureThesFilters LectureThesFilters { get; set; }
      public ScienceReportGuidelineFilters GuidelineFilters { get; set; }
      public ScienceReportTutorialFilters TutorialFilters { get; set; }
      public ScienceReportSchoolBookFilters SchoolBookFilters { get; set; }
      public ScienceReportPatentFilters PatentFilters { get; set; }
      public ScienceReportCopyrightFilters CopyrightFilters { get; set; }
      public ScienceReportConferenceFilters ConferenceFilters { get; set; }
      public ScienceReportAcademicDegreeGainFilters AcademicDegreeGainFilters { get; set; }
      public ScienceReportQualificationIncreaseFilters QualificationIncreaseFilters { get; set; }
      public ScienceReportDissertationDefenseFilters DissertationDefenseFilters { get; set; }
   }
}