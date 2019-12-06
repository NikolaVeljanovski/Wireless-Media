using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Proizvod
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public String Naziv { get; set; }

        [Required]
        public String Opis { get; set; }

        [Required]
        public String Kategorija { get; set; }

        [Required]
        public String Proizvodjac { get; set; }

        [Required]
        public String Dobavljac { get; set; }

        [Required]
        public int Cena { get; set; }
    }
}