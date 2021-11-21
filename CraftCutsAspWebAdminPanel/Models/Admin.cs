using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Models
{
    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [Column("admin_id")]
        public int AdminId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("login")]
        [StringLength(50)]
        public string Login { get; set; }
        [Required]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
