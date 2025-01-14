using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Rezerwacja
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int KlientId { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataZwrotu { get; set; }
    }

}
