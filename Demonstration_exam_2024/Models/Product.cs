using System.Collections.Generic;

namespace Demonstration_exam_2024.Models
{
    public class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}