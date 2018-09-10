using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace payback4marvin.Model
{
    public class Vergehen
    {   
        [Key]
        public int VergehenId { get; set; }
        public string Bezeichnung { get; set; }
        [ForeignKey("Verbrecher")]
        public int VerbrecherId { get; set; }
        public DateTimeOffset TatZeitpunkt { get; set; }
        public int Stärke { get; set; }

        public Vergehen(string bezeichnung, int verbrecherId, DateTimeOffset tatZeitpunkt, int stärke) {
            Bezeichnung = bezeichnung;
            VerbrecherId = verbrecherId;
            TatZeitpunkt = tatZeitpunkt;
            Stärke = stärke;
        }
    }
}
