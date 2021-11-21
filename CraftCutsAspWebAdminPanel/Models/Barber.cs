using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Models
{
    [Table("Barber")]
    public partial class Barber
    {
        public Barber()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        [Column("barber_id")]
        public int BarberId { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [Column("photo_name")]
        public string PhotoName { get; set; }

        [InverseProperty(nameof(Booking.Barber))]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
