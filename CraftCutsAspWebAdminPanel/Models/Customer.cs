using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
        }

        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("phone")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column("birthday", TypeName = "datetime")]
        public DateTime? Birthday { get; set; }

        [InverseProperty(nameof(Booking.Customer))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(Review.Customer))]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
