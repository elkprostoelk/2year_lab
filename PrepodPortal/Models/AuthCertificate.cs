namespace PrepodPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AuthCertificate")]
    public partial class AuthCertificate
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Укажіть тип наукової праці")]
        [Display(Name = "Тип*")]
        public string WorkType { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Укажіть назву")]
        [Display(Name = "Назва*")]
        public string WorkTitle { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
