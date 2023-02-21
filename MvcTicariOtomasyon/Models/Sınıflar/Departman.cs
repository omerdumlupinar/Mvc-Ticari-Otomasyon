using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Sınıflar
{
    public class Departman
    {
        [Key]
        public int departmanID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public String departmanAd { get; set; }
        public bool departmanDurum { get; set; }

        public ICollection<Personel> Personels { get; set; }
    }
}