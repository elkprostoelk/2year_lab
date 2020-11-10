namespace PrepodPortal.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("SecurityDocument")]
   public partial class SecurityDocument
   {
      public int Id { get; set; }

      [Required]
      [StringLength(128)]
      public string UserId { get; set; }

      public int Type { get; set; }

      [Required]
      [StringLength(128)]
      public string Guid { get; set; }

      public virtual Copyright Copyright { get; set; }

      public virtual Patent Patent { get; set; }

      public virtual UserProfile UserProfile { get; set; }
   }
}
