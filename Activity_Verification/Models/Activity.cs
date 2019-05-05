using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Activity_Verification.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Identifier")]
        [Required]
        [Column(TypeName ="nvarchar(5)")]
        public string Handle { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Category { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        
        public bool Verified { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Notes { get; set;

        }
    }
}
