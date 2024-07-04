using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockTrackingMVC.Models.Entity
{
    public partial class tbl_products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_products()
        {
            this.tbl_sales = new HashSet<tbl_sales>();
        }

        public int prd_id { get; set; }

        [Required(ErrorMessage = "�r�n ad� gereklidir.")]
        [StringLength(50, ErrorMessage = "�r�n ad� en fazla 50 karakter olabilir.")]
        public string prd_name { get; set; }

        [StringLength(50, ErrorMessage = "�r�n markas� en fazla 50 karakter olabilir.")]
        public string prd_brand { get; set; }

        [Range(0, short.MaxValue, ErrorMessage = "Stok miktar� 0'dan k���k olamaz.")]
        public Nullable<short> prd_stock { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Al�� fiyat� 0'dan k���k olamaz.")]
        public Nullable<decimal> prd_purchasePrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Sat�� fiyat� 0'dan k���k olamaz.")]
        public Nullable<decimal> prd_salePrice { get; set; }

        public Nullable<int> prd_ctg_id { get; set; }
        public Nullable<bool> prd_status { get; set; }

        public virtual tbl_categories tbl_categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_sales> tbl_sales { get; set; }
    }
}
