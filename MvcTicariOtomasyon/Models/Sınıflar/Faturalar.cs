using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int faturaID { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string faturaSeriNo { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string faturaSıraNo { get; set; }


        public DateTime faturaTarih { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string faturaVergiDairesi { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string faturaSaat { get; set; }

        public int faturaToplam { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string faturaTeslimEden { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string faturaTeslimAlan { get; set; }




        public ICollection<FaturaKalem> faturaKalems { get; set; }

    }
}