using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demonstration_exam_2024.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public int PartnerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        // Навигационные свойства
        [ForeignKey("PartnerId")]
        public virtual Partner Partner { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}