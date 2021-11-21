using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Models
{
    [Table("HairCut")]
    public partial class HairCut
    {
        [Key]
        [Column("Haircut_id")]
        public int HaircutId { get; set; }
        [Required]
        [Column("Image_name")]
        public string ImageName { get; set; }
        [Column("Displayed_name")]
        public string DisplayedName { get; set; }
    }
}
