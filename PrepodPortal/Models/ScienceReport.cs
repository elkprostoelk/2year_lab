using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrepodPortal.Models
{
   public class ScienceReport
   {
      public Enums.ReportTypes ReportType { get; set; }

      //Articles
      public List<Article> ArticlesWoSOrScopusSNIPIndexHigher04 { get; set; }
      public List<Article> ArticlesWoSOrScopusSNIPIndexLess04 { get; set; }
      public List<Article> ArticlesPrintedInScienceMagazineWithImpactFactor { get; set; }
      public List<Article> ArticlesPrintedInUkraineScienceEditionAndHasISSN { get; set; }
      public List<Article> ArticlesPrintedInOtherUkraineEditions { get; set; }

      //Monographs
      public List<Monograph> MonographPublishedInForeignEditions { get; set; }
      public List<Monograph> MonographPublishedInDomesticEditions { get; set; }
      public List<Monograph> MonographSectionsPublishedInDomesticEditions { get; set; }

      //SchoolBooks
      public List<SchoolBook> SchoolBookGryphMOHOfUkraine { get; set; }
      public List<SchoolBook> SchoolBookRecommendedByAcademicCouncilOfKSU { get; set; }
      public List<SchoolBook> SchoolBookOthers { get; set; }

      //Guidelines
      public List<SchoolBook> Guidelines { get; set; }

      //Tutorials
      public List<SchoolBook> TutorialGryphMOHOfUkraine { get; set; }
      public List<SchoolBook> TutorialRecommendedByAcademicCouncilOfKSU { get; set; }
      public List<SchoolBook> TutorialOthers { get; set; }

      //Lecture Thes
      public List<LectureThes> LectureTheses { get; set; }

      //Conference
      public List<Conference> Conference { get; set; }

      //Patens
      public List<Patent> Patents { get; set; }

      //Copyrights 
      public List<Copyright> Copyrights { get; set; }

      public List<ScientometricDbProfile> ScientometricDbProfiles { get; set; }

      public List<AcademicDegree> AcademicDegreeGainsAssitProf { get; set; }

      public List<AcademicDegree> AcademicDegreeGainsProf { get; set; }

      public List<DissertationDefens> DissertationDefensesPHD { get; set; }

      public List<DissertationDefens> DissertationDefensesPH_D { get; set; }

      public List<QualificationIncrease> QualificationIncreases { get; set; }
   }
}