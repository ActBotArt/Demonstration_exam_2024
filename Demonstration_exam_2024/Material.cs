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
    
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.Warehouses = new HashSet<Warehouse>();
        }
    
        public int material_id { get; set; }
        public int supplier_id { get; set; }
        public string material_name { get; set; }
        public string material_type { get; set; }
        public string unit { get; set; }
        public Nullable<decimal> package_quantity { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<decimal> current_quantity { get; set; }
        public Nullable<decimal> min_quantity { get; set; }
    
        public virtual Supplier Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
