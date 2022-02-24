using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCRUD.Models
{
    public class MvcCalisanModel
    {
        public int CalisanID { get; set; }

        [Required(ErrorMessage = "Ad ve Soyadı girmeniz gerekmektedir.")]
        public string AdSoyad { get; set; }
        public string Pozisyonu { get; set; }
        public Nullable<int> Yasi { get; set; }
        public Nullable<int> Maas { get; set; }

    }
}