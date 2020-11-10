using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrepodPortal
{
   public class Enums
   {

      public enum PublicationTypes : int
      {
         [Display(Name = "Монография")]
         Monograph = 1,
         [Display(Name = "Учебник")]
         SchoolBook,
         [Display(Name = "Пособие")]
         Tutorial,
         [Display(Name = "Методич. рекомендация")]
         Guideline,
         [Display(Name = "Статья")]
         Article,
         [Display(Name = "Тезисы докладов")]
         LectureTheses
      }

      public enum SecurityDocTypes : int
      {
         [Display(Name = "Патент")]
         Patent = 1,
         [Display(Name = "Док. на авторское право")]
         Copyright
      }

      public enum MonographTypes : int
      {
         [Display(Name = "Опубліковані в закордонних виданнях офіційними мовами Європейського Союзу")]
         PublishedInForeignEditions = 1,
         [Display(Name = "Опубліковані у вітчизняних виданнях")]
         PublishedInDomesticEditions,
         [Display(Name = "Розділи монографій, що опубліковані у вітчизняних виданнях")]
         SectionsPublishedInDomesticEditions
      }

      public enum SchoolBookTypes : int
      {
         [Display(Name = "З грифом МОН України")]
         GryphMOHOfUkraine = 1,
         [Display(Name = "Рекомендовано вченою радою ХДУ")]
         RecommendedByAcademicCouncilOfKSU,
         [Display(Name = "Інші")]
         Other
      }

      public enum MOHGryphTypes : int
      {
         [Display(Name = "Затверджено МОН України")]
         ApprovedByMOHOfUkraine = 1,
         [Display(Name = "Рекомендовано МОН України")]
         RecommendedByMOHOfUkraine,
         [Display(Name = "Схвалено для використання в навчальних закладах та ін.")]
         ApprovedForEducationalInstitutions
      }

      public enum ArticleTypes : int
      {
         [Display(Name = "Входять до науково-метричних баз даних WoS та/або Scopus з індексом SNIP ≥ 0,4 ")]
         WoSOrScopusSNIPIndexHigher04 = 1,
         [Display(Name = "Входять до науково-метричних баз даних WoS та/або Scopus з індексом SNIP ≤ 0,4")]
         WoSOrScopusSNIPIndexLess04,
         [Display(Name = "Надруковані в наукових журналах з імпакт-фактором ")]
         PrintedInScienceMagazineWithImpactFactor,
         [Display(Name = "Надруковані у наукових фахових виданнях України, що мають ISSN")]
         PrintedInUkraineScienceEditionAndHasISSN,
         [Display(Name = "Надруковані в інших виданнях України")]
         PrintedInOtherUkraineEditions
      }

      public enum ReportTypes : int
      {
         [Display(Name = "Личный")]
         Personal = 1,
         [Display(Name = "Общий")]
         Global
      }

      public enum QualificationIncreaseTypes : int
      {
         [Display(Name = "Стажування у ВНЗ України")]
         InternshipInUkranianUniversity = 1,
         [Display(Name = "Стажування за кордоном")]
         InternshipOverseas,
         [Display(Name = "Курси підвищення кваліфікації")]
         QualificationIncreaseCourses,
         [Display(Name = "Творчі відпустки")]
         CreativeVacations
      }

      public enum DissertationDefensTypes : int
      {
         [Display(Name = "Доктор наук")]
         PH_D = 1,
         [Display(Name = "Кандидат наук")]
         PHD
      }

      public enum AcademicDegreeGainTypes : int
      {
         [Display(Name = "Доцент")]
         AssistantProfessor = 1,
         [Display(Name = "Профессор")]
         Professor
      }
   }
}