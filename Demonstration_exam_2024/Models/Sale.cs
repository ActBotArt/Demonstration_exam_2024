using System;

namespace Demonstration_exam_2024.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int PartnerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime SaleDate { get; set; }

        public virtual Partner Partner { get; set; }
        public virtual Product Product { get; set; }
    }
}