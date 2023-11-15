using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLift
{
    internal class Lift
    {
        DateTime idopont;
        int kartyaSorszam;
        int induloSorszam;
        int celSorszam;

        public Lift(string sor)
        {
            string[] tomb = sor.Split(' ');
            this.idopont = DateTime.Parse(tomb[0]);
            this.kartyaSorszam = int.Parse(tomb[1]);
            this.induloSorszam = int.Parse(tomb[2]);
            this.celSorszam = int.Parse(tomb[3]);
        }

        public DateTime Idopont => idopont;
        public int KartyaSorszam  => kartyaSorszam;
        public int InduloSorszam  => induloSorszam;
        public int CelSorszam  => celSorszam;
    }
}
