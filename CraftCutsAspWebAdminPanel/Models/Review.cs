using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Models
{
    [Table("Review")]
    public partial class Review
    {
        [Key]
        [Column("review_id")]
        public int ReviewId { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Required]
        [Column("feedback")]
        [StringLength(255)]
        public string Feedback { get; set; }
        [Column("stars")]
        public int Stars { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Reviews")]
        public virtual Customer Customer { get; set; }
    }
}
