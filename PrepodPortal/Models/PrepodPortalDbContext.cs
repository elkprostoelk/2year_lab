namespace PrepodPortal.Models
{
   using System;
   using System.Data.Entity;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Linq;

   public partial class PrepodPortalDbContext : DbContext
   {
      public PrepodPortalDbContext()
          : base("name=PrepodPortalDbContext")
      {
      }

      public virtual DbSet<AcademicDegree> AcademicDegrees { get; set; }
      public virtual DbSet<Article> Articles { get; set; }
      public virtual DbSet<Conference> Conferences { get; set; }
      public virtual DbSet<Copyright> Copyrights { get; set; }
      public virtual DbSet<DissertationDefens> DissertationDefenses { get; set; }
      public virtual DbSet<Education> Educations { get; set; }
      public virtual DbSet<LectureThes> LectureTheses { get; set; }
      public virtual DbSet<Monograph> Monographs { get; set; }
      public virtual DbSet<Patent> Patents { get; set; }
      public virtual DbSet<Publication> Publications { get; set; }
      public virtual DbSet<QualificationIncrease> QualificationIncreases { get; set; }
      public virtual DbSet<SchoolBook> SchoolBooks { get; set; }
      public virtual DbSet<ScientometricDbProfile> ScientometricDbProfiles { get; set; }
      public virtual DbSet<SecurityDocument> SecurityDocuments { get; set; }
      public virtual DbSet<UserProfile> UserProfiles { get; set; }
      public virtual DbSet<Project> Projects { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Copyright>()
             .Property(e => e.Type)
             .IsUnicode(false);

         modelBuilder.Entity<Education>()
             .Property(e => e.Specialty)
             .IsFixedLength();

         modelBuilder.Entity<Publication>()
             .HasOptional(e => e.Article)
             .WithRequired(e => e.Publication);

         modelBuilder.Entity<Publication>()
             .HasOptional(e => e.LectureThes)
             .WithRequired(e => e.Publication);

         modelBuilder.Entity<Publication>()
             .HasOptional(e => e.Monograph)
             .WithRequired(e => e.Publication);

         modelBuilder.Entity<Publication>()
             .HasOptional(e => e.SchoolBook)
             .WithRequired(e => e.Publication);

         modelBuilder.Entity<SecurityDocument>()
             .HasOptional(e => e.Copyright)
             .WithRequired(e => e.SecurityDocument);

         modelBuilder.Entity<SecurityDocument>()
             .HasOptional(e => e.Patent)
             .WithRequired(e => e.SecurityDocument);

         modelBuilder.Entity<UserProfile>()
             .HasMany(e => e.AcademicDegrees)
             .WithRequired(e => e.UserProfile)
             .WillCascadeOnDelete(false);

         modelBuilder.Entity<UserProfile>()
             .HasMany(e => e.Conferences)
             .WithRequired(e => e.UserProfile)
             .WillCascadeOnDelete(false);

         modelBuilder.Entity<UserProfile>()
             .HasMany(e => e.DissertationDefenses)
             .WithRequired(e => e.UserProfile)
             .WillCascadeOnDelete(false);

         modelBuilder.Entity<UserProfile>()
             .HasMany(e => e.Educations)
             .WithRequired(e => e.UserProfile)
             .WillCascadeOnDelete(false);

         modelBuilder.Entity<UserProfile>()
             .HasMany(e => e.Publications)
             .WithRequired(e => e.UserProfile)
             .WillCascadeOnDelete(false);

         modelBuilder.Entity<UserProfile>()
             .HasMany(e => e.QualificationIncreases)
             .WithRequired(e => e.UserProfile)
             .WillCascadeOnDelete(false);

         modelBuilder.Entity<UserProfile>()
             .HasMany(e => e.SecurityDocuments)
             .WithRequired(e => e.UserProfile)
             .WillCascadeOnDelete(false);
         modelBuilder.Entity<UserProfile>()
             .HasMany(e => e.Projects)
             .WithRequired(e => e.UserProfile)
             .WillCascadeOnDelete(false);
      }
   }
}
