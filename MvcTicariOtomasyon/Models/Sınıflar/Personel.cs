using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int personelID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String personelAd { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String personelSoyad { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public String personelGorsel { get; set; }




        public ICollection<SatisHareket> SatisHarekets { get; set; }

        public int departmanid { get; set; } 
        public virtual Departman Departman { get; set; }
    }
}