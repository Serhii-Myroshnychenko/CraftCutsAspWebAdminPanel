using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Models
{
    [Table("BookingList")]
    public partial class BookingList
    {
        [Key]
        [Column("booking_id")]
        public int BookingId { get; set; }
        [Key]
        [Column("service_id")]
        public int ServiceId { get; set; }

        [ForeignKey(nameof(BookingId))]
        [InverseProperty("BookingLists")]
        public virtual Booking Booking { get; set; }
        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("BookingLists")]
        public virtual Service Service { get; set; }
    }
}
