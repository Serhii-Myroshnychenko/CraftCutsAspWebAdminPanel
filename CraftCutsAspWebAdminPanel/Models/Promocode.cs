using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Models
{
    [Table("Promocode")]
    public partial class Promocode
    {
        public Promocode()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        [Column("promocode_id")]
        public int PromocodeId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("sale_percent")]
        public int SalePercent { get; set; }
        [Column("time", TypeName = "datetime")]
        public DateTime Time { get; set; }

        [InverseProperty(nameof(Booking.Promocode))]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
