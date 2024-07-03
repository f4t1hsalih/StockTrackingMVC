using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockTrackingMVC.Models.Entity
{
    public partial class tbl_customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_customers()
        {
            this.tbl_sales = new HashSet<tbl_sales>();
        }

        public int ctm_id { get; set; }

        [Required(ErrorMessage = "M��teri ad� zorunludur.")]
        [StringLength(30, ErrorMessage = "M��teri ad� en fazla 30 karakter olabilir.")]
        public string ctm_name { get; set; }

        [Required(ErrorMessage = "M��teri soyad� zorunludur.")]
        [StringLength(30, ErrorMessage = "M��teri soyad� en fazla 30 karakter olabilir.")]
        public string ctm_surname { get; set; }

        [StringLength(15, ErrorMessage = "�ehir ad� en fazla 15 karakter olabilir.")]
        public string ctm_city { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Bakiye negatif olamaz.")]
        public Nullable<decimal> ctm_balance { get; set; }

        public Nullable<bool> ctm_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_sales> tbl_sales { get; set; }
    }
}
