using System.Collections.Generic;

namespace Demonstration_exam_2024.Models
{
    public class Partner
    {
        public int PartnerId { get; set; }
        public string CompanyType { get; set; }
        public string CompanyName { get; set; }
        public string DirectorName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public decimal? Rating { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public Partner()
        {
            Sales = new HashSet<Sale>();
        }
    }
}