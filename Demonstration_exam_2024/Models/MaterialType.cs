using System.Collections.Generic;

namespace Demonstration_exam_2024.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public decimal ProductTypeCoefficient { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public ProductType()
        {
            Products = new HashSet<Product>();
        }
    }
}