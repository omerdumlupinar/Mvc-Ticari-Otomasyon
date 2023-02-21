using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int faturaKalemID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public String faturaKalemAciklama { get; set; }


        public int faturaKalemMiktar { get; set; }
        public decimal faturaKalemBirimFiyat { get; set; }
        public decimal faturaKalemTurat { get; set; }

        public int faturaid { get; set; } 
        public virtual Faturalar faturalar { get; set; }

    }
}