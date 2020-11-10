namespace PrepodPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Guideline")]
    public partial class Guideline
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(500)]
        public string AuthorNames { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(500)]
        public string ISBN { get; set; }

        [StringLength(100)]
        public string PublishedLocation { get; set; }

        [StringLength(500)]
        public string PublisherName { get; set; }

        [StringLength(100)]
        public string PublishedYear { get; set; }

        public int? NumPagesTotal { get; set; }

        public int? NumPagesByAuthor { get; set; }

        public int? NumPrintedPagesTotal { get; set; }

        public int? NumPrintedPagesByAuthor { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
