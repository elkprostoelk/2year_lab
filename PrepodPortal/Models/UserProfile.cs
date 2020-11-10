namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("UserProfile")]
   public partial class UserProfile
   {
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
      public UserProfile()
      {
         AcademicDegrees = new HashSet<AcademicDegree>();
         Conferences = new HashSet<Conference>();
         DissertationDefenses = new HashSet<DissertationDefens>();
         Educations = new HashSet<Education>();
         Publications = new HashSet<Publication>();
         QualificationIncreases = new HashSet<QualificationIncrease>();
         ScientometricDbProfiles = new HashSet<ScientometricDbProfile>();
         SecurityDocuments = new HashSet<SecurityDocument>();
         Projects = new HashSet<Project>();
      }

      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      [Key]
      public string UserId { get; set; }

      [StringLength(100)]
      public string Name { get; set; }

      [StringLength(100)]
      public string Town { get; set; }

      [StringLength(100)]
      public string Gender { get; set; }

      [Column(TypeName = "date")]
      public DateTime? BirthDate { get; set; }

      [StringLength(100)]
      public string AcademicTitle { get; set; }

      [StringLength(100)]
      public string ScienceDegree { get; set; }

      [StringLength(100)]
      public string WorkPlacePosition { get; set; }

      [StringLength(100)]
      public string WorkPlaceMain { get; set; }

      [StringLength(100)]
      public string InstDone { get; set; }

      [StringLength(100)]
      public string InstDoneWhen { get; set; }

      [StringLength(100)]
      public string InstDoneSpec { get; set; }

      [StringLength(100)]
      public string InstDoneQual { get; set; }

      [StringLength(100)]
      public string IncrQualInst { get; set; }

      [StringLength(100)]
      public string IncrQualDocType { get; set; }

      [StringLength(100)]
      public string IncrQualDocTheme { get; set; }

      [Column(TypeName = "date")]
      public DateTime? IncrQualRecieveDate { get; set; }

      [StringLength(100)]
      public string ResearchStage { get; set; }

      [StringLength(100)]
      public string CipherTtlResearchSpec { get; set; }

      [StringLength(100)]
      public string AcdmTtl { get; set; }

      [StringLength(100)]
      public string WhrAssigned { get; set; }

      [StringLength(100)]
      public string DissertTheme { get; set; }

      [StringLength(1000)]
      public string Subjects { get; set; }

      [StringLength(100)]
      public string MainPublics { get; set; }

      [StringLength(100)]
      public string ScienceWorks { get; set; }

      [StringLength(100)]
      public string PartInConvs { get; set; }

      [StringLength(100)]
      public string WorkWithGradts { get; set; }

      [StringLength(100)]
      public string RunStudScienceWork { get; set; }

      [DefaultValue("/Images/no-avatar.png")]
      [StringLength(200)]
      public string AvatarImg { get; set; }

      [StringLength(100)]
      public string HomeTown { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      public virtual ICollection<AcademicDegree> AcademicDegrees { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      public virtual ICollection<Conference> Conferences { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      public virtual ICollection<DissertationDefens> DissertationDefenses { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      public virtual ICollection<Education> Educations { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      public virtual ICollection<Publication> Publications { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      public virtual ICollection<QualificationIncrease> QualificationIncreases { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      public virtual ICollection<ScientometricDbProfile> ScientometricDbProfiles { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      public virtual ICollection<SecurityDocument> SecurityDocuments { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      public virtual ICollection<Project> Projects { get; set; }
   }
}
