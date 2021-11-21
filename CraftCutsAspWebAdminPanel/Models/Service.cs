using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Models
{
    [Table("Service")]
    public partial class Service
    {
        public Service()
        {
            BookingLists = new HashSet<BookingList>();
        }

        [Key]
        [Column("service_id")]
        public int ServiceId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(10)]
        public string Name { get; set; }
        [Column("price", TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }

        [InverseProperty(nameof(BookingList.Service))]
        public virtual ICollection<BookingList> BookingLists { get; set; }
    }
}
