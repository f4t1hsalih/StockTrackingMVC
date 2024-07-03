using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockTrackingMVC.Models.Entity
{
    public partial class tbl_staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_staff()
        {
            this.tbl_sales = new HashSet<tbl_sales>();
        }

        public int stf_id { get; set; }

        [Required(ErrorMessage = "Personel adý zorunludur.")]
        [StringLength(30, ErrorMessage = "Personel adý en fazla 30 karakter olabilir.")]
        public string stf_name { get; set; }

        [Required(ErrorMessage = "Personel soyadý zorunludur.")]
        [StringLength(30, ErrorMessage = "Personel soyadý en fazla 30 karakter olabilir.")]
        public string stf_surname { get; set; }

        [StringLength(30, ErrorMessage = "Departman adý en fazla 30 karakter olabilir.")]
        public string stf_department { get; set; }

        public Nullable<bool> stf_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_sales> tbl_sales { get; set; }
    }
}
