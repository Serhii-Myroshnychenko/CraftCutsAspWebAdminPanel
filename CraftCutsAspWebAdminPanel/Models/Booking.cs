using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Models
{
    [Table("Booking")]
    public partial class Booking
    {
        public Booking()
        {
            BookingLists = new HashSet<BookingList>();
        }

        [Key]
        [Column("booking_id")]
        public int BookingId { get; set; }
        [Column("barber_id")]
        public int BarberId { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("price", TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("is_paid")]
        public bool IsPaid { get; set; }
        [Column("promocode_id")]
        public int? PromocodeId { get; set; }

        [ForeignKey(nameof(BarberId))]
        [InverseProperty("Bookings")]
        public virtual Barber Barber { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Bookings")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(PromocodeId))]
        [InverseProperty("Bookings")]
        public virtual Promocode Promocode { get; set; }
        [InverseProperty(nameof(BookingList.Booking))]
        public virtual ICollection<BookingList> BookingLists { get; set; }
    }
}
