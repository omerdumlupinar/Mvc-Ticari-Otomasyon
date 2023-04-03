using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Cariler
    {
        [Key]
        public int cariID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 katakter girebilirsiniz!")]
        [Required(ErrorMessage ="Alan Boş Geçilemez!")]
        public String cariAd { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 katakter girebilirsiniz!")]
        [Required(ErrorMessage = "Alan Boş Geçilemez!")]
        public String cariSoyad { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "En fazla 30 katakter girebilirsiniz!")]
        [Required(ErrorMessage = "Alan Boş Geçilemez!")]
        public String cariSehir { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 30 katakter girebilirsiniz!")]
        [Required(ErrorMessage = "Alan Boş Geçilemez!")]
        public String cariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En fazla 20 katakter girebilirsiniz!")]
        [Required(ErrorMessage = "Alan Boş Geçilemez!")]
        public String cariSifre { get; set; }




        public bool cariDurum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }


    }
}