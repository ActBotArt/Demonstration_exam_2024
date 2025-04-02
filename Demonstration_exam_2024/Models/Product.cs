using System.Collections.Generic;

namespace Demonstration_exam_2024.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public string ArticleNumber { get; set; }
        public decimal MinimumCost { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }

        public Product()
        {
            Sales = new HashSet<Sale>();
        }
    }
}