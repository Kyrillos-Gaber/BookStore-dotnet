using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Dispaly Name")]
        [Range(1, 100, ErrorMessage = "between 1 - 100")]
        public int DisplayOrders { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
