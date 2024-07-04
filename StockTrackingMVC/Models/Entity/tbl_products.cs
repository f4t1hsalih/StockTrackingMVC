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

        [Required(ErrorMessage = "Ürün adý gereklidir.")]
        [StringLength(50, ErrorMessage = "Ürün adý en fazla 50 karakter olabilir.")]
        public string prd_name { get; set; }

        [StringLength(50, ErrorMessage = "Ürün markasý en fazla 50 karakter olabilir.")]
        public string prd_brand { get; set; }

        [Range(0, short.MaxValue, ErrorMessage = "Stok miktarý 0'dan küçük olamaz.")]
        public Nullable<short> prd_stock { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Alýþ fiyatý 0'dan küçük olamaz.")]
        public Nullable<decimal> prd_purchasePrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Satýþ fiyatý 0'dan küçük olamaz.")]
        public Nullable<decimal> prd_salePrice { get; set; }

        public Nullable<int> prd_ctg_id { get; set; }
        public Nullable<bool> prd_status { get; set; }

        public virtual tbl_categories tbl_categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_sales> tbl_sales { get; set; }
    }
}
