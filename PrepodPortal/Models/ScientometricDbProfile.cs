namespace PrepodPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ScientometricDbProfile
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name="Назва наукометрич. бази даних")]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name="Покликання на профіль")]
        public string ProfileLink { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
