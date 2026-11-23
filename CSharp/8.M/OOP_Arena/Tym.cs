namespace OOP_Arena
{
    class Tym
    {
        public string Nazev {get;}
        public List<Bojovnik> Bojovnici {get; set;}

        private Kostka _kostka;

        public Tym(string nazev, int pocetBojovniku)
        {
            Nazev = nazev;
            Bojovnici = new List<Bojovnik>();

            _kostka = new Kostka(pocetBojovniku);
        }

        public override string ToString()
        {
            return Nazev;
        }

        public void PridejBojovnika(Bojovnik bojovnik)
        {
            Bojovnici.Add(bojovnik);
        }

        public bool JeNekdoNazivu()
        {
            foreach (Bojovnik bojovnik in Bojovnici)
            {
                if (bojovnik.JeNazivu())
                {
                    return true;
                }
            }

            return false;
        }

        public void Reset()
        {
            foreach (Bojovnik bojovnik in Bojovnici)
            {
                bojovnik.Reset();
            }
        }

        public Bojovnik Nahodny()
        {
            while (true)
            {
                Bojovnik rndBojovnik = Bojovnici[_kostka.HodSebou() - 1];
                if (rndBojovnik.JeNazivu())
                {
                    return rndBojovnik;
                }
            }
        }
    }
}
