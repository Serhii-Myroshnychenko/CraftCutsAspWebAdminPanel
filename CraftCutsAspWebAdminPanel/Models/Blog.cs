using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CraftCutsAspWebAdminPanel.Models
{
    [Table("Blog")]
    public partial class Blog
    {
        [Key]
        [Column("blog_id")]
        public int BlogId { get; set; }
        [Column("time_step", TypeName = "datetime")]
        public DateTime TimeStep { get; set; }
        [Required]
        [Column("title")]
        [StringLength(100)]
        public string Title { get; set; }
        [Column("blog_content")]
        public string BlogContent { get; set; }
        [Required]
        [Column("picture_url")]
        public string PictureUrl { get; set; }
    }
}
