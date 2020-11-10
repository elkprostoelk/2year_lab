namespace PrepodPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Conversation")]
    public partial class Conversation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(500)]
        [Display(Name = "Назва*")]
        [Required(ErrorMessage = "Укажіть назву")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateHeld { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Укажітьь організатора")]
        [Display(Name = "Організатор*")]
        public string Organizer { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Укажіть місце проведення")]
        [Display(Name = "Місце проведення*")]
        public string WhereHeld { get; set; }

        [Display(Name = "Відбулася")]
        public bool IsHeld { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
