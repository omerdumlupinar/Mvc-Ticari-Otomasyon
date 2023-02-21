using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Kategori
    {

        [Key]
        public int kategoriID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string kategoriAd { get; set; }


        public ICollection<Urun> Uruns { get; set; }
    }
}