using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlamaProje.Models
{
    public class Email
    {
        [Key]
        public string email { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }


    }
}
