using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Title { get; set; }
        
        [Required]
        public string? Description { get; set; }
        
        [Required]
        public string? Author { get; set; }
        
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
        
        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        
        public string? ImageUrl { get; set; }
        
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [Required]
        public int CoverTypeId { get; set; }

        [ForeignKey("CoverTypeId")]
        public Cover? CoverType { get; set; }
    }
}
