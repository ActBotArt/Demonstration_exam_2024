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
    
    public partial class PartnerSale
    {
        public int partner_sales_id { get; set; }
        public int partner_id { get; set; }
        public int product_id { get; set; }
        public System.DateTime sale_date { get; set; }
        public int quantity { get; set; }
        public Nullable<decimal> discount { get; set; }
    
        public virtual Partner Partner { get; set; }
        public virtual Product Product { get; set; }
    }
}
