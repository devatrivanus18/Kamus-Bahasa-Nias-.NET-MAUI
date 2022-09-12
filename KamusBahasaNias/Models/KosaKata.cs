using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamusBahasaNias.Models
{
    public class KosaKata
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string KataAsal { get; set; } 
        public string KataTerjemahan { get; set; } 
        public string PenulisanKata { get; set; } 
        public string Gambar { get; set; }
    }
}
