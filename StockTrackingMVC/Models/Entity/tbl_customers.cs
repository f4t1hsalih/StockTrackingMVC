//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockTrackingMVC.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_customers()
        {
            this.tbl_sales = new HashSet<tbl_sales>();
        }
    
        public int ctm_id { get; set; }

        [Required(ErrorMessage ="Ad Alan� Bo� Ge�ilemez")]
        public string ctm_name { get; set; }

        [Required(ErrorMessage = "Soyad Alan� Bo� Ge�ilemez")]
        public string ctm_surname { get; set; }
        public string ctm_city { get; set; }
        public Nullable<decimal> ctm_balance { get; set; }
        public Nullable<bool> ctm_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_sales> tbl_sales { get; set; }
    }
}
