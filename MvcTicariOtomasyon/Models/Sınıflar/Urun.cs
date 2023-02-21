using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int urunID { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public String urunAd { get; set; }



        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string urunmarka { get; set; }


        public short urunStok { get; set; }
        public decimal urunAlisFiyat { get; set; }
        public decimal urunSatisFiyat { get; set; }
        public bool urunDurum { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string urunGorsel { get; set; }
        public int  kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}