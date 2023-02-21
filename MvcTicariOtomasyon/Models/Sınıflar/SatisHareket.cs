using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int satisHateketID { get; set; }
        //Ürün
        //Cari
        //Personel
        public DateTime satisHateketTarih { get; set; }
        public int satisHateketAdet { get; set; }
        public decimal satisHateketFiyat { get; set; }
        public decimal satisHateketToplamTutar { get; set; }

        public int urunid { get; set; }
        public int cariid { get; set; }
        public int personelid { get; set; }



        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
    }
}