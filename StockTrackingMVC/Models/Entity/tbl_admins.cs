using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockTrackingMVC.Models.Entity
{
    public partial class tbl_admins
    {
        public int adm_id { get; set; }

        [Required(ErrorMessage = "Kullan�c� ad� gereklidir.")]
        [StringLength(20, ErrorMessage = "Kullan�c� ad� en fazla 20 karakter olabilir.")]
        public string adm_username { get; set; }

        [Required(ErrorMessage = "�ifre gereklidir.")]
        [StringLength(20, ErrorMessage = "�ifre en fazla 20 karakter olabilir.")]
        public string adm_password { get; set; }

        public Nullable<bool> adm_status { get; set; }
    }
}
