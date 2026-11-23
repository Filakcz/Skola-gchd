using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Arena
{
    public class Kostka
    {
        private int pocetSten;
        private Random rnd;
        public Kostka(int pocetSten)
        {
            this.pocetSten = pocetSten;
            rnd = new Random();
        }
        public int HodSebou()
        {
            return rnd.Next(1, pocetSten + 1);
        }
        // public void ZmenPocetSten(int PocetSten)
        // {
        //     pocetSten = PocetSten;
        // }
    }
}
