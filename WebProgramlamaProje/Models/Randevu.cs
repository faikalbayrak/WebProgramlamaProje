using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }
        public string İstekleriniz { get; set; }
        [Required]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public DateTime Tarih { get; set; }
        [Required]
        public int KategoriId { get; set; }
        public Kategori Kategorim { get; set; }
    }
}
