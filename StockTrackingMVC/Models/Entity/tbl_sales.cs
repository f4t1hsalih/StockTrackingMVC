using System;
using System.ComponentModel.DataAnnotations;

namespace StockTrackingMVC.Models.Entity
{
    public partial class tbl_sales
    {
        public int sal_id { get; set; }

        public int sal_prd_id { get; set; }

        public int sal_stf_id { get; set; }

        public int sal_ctm_id { get; set; }

        [Required(ErrorMessage = "Sat�� fiyat� zorunludur")]
        [Range(0, double.MaxValue, ErrorMessage = "Sat�� fiyat� s�f�rdan b�y�k olmal�d�r")]
        public decimal sal_salePrice { get; set; }

        [Required(ErrorMessage = "Sat�� tarihi zorunludur")]
        public DateTime sal_date { get; set; }

        public virtual tbl_customers tbl_customers { get; set; }

        public virtual tbl_products tbl_products { get; set; }

        public virtual tbl_staff tbl_staff { get; set; }
    }
}
