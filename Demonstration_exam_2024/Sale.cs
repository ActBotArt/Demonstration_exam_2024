//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demonstration_exam_2024
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int PartnerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
    
        public virtual Partner Partner { get; set; }
        public virtual Product Product { get; set; }
    }
}
