using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockTrackingMVC.Models.Entity
{
    public partial class tbl_categories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_categories()
        {
            this.tbl_products = new HashSet<tbl_products>();
        }

        public int ctg_id { get; set; }

        [Required(ErrorMessage = "Kategori adý gereklidir.")]
        [StringLength(50, ErrorMessage = "Kategori adý en fazla 50 karakter olabilir.")]
        public string ctg_name { get; set; }

        public Nullable<bool> ctg_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_products> tbl_products { get; set; }
    }
}
