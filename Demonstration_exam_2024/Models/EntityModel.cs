using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demonstration_exam_2024.Models
{
    [Table("Partner")]
    public class Partner
    {
        [Key]
        public int PartnerID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int TypeID { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(150)]
        public string DirectorFullName { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Column(TypeName = "decimal")]
        public decimal TotalSalesAmount { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Discount { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("TypeID")]
        public virtual PartnerType PartnerType { get; set; }
    }

    [Table("PartnerType")]
    public class PartnerType
    {
        [Key]
        public int TypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }
    }

    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ArticleNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal")]
        public decimal MinPrice { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    [Table("SalesHistory")]
    public class SalesHistory
    {
        [Key]
        public int SaleID { get; set; }

        public int PartnerID { get; set; }

        public int ProductID { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public DateTime SaleDate { get; set; }

        [Column(TypeName = "decimal")]
        public decimal TotalAmount { get; set; }

        [ForeignKey("PartnerID")]
        public virtual Partner Partner { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }

    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; }
    }
}