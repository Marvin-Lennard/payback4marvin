using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace payback4marvin.Model
{
    public class Verbrecher
    {   [Key]
        public int VerbrecherId { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtstag { get; set; }

        public ICollection<Vergehen> Vergehen { get; set; }
    }
}
