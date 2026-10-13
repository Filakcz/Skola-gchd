namespace OOPPractice;

class Program
{
    static void Main(string[] args)
    {
        BankovniUcet ucet1 = new BankovniUcet("67420/0800", new PostovniAdresa("Zborovska", 163, "Masecin", 15220), 3471);
        BankovniUcet ucet2 = new BankovniUcet("11111/0420", new PostovniAdresa("Podskalska", 43, "Cernosice", 23732));

        ucet1.Vlozit(3000.67f);
        ucet2.Vlozit(100);

        ucet2.Vybrat(500);
        ucet1.Vybrat(200.34f);

        Console.WriteLine(ucet1);
        Console.WriteLine(ucet2);

        BankovniUcet.ZobrazitPocetAktivnichUctu();
    }

    public struct PostovniAdresa
    {
        public string Ulice {get; set; }
        public int CisloPopisne {get; set; }
        public string Mesto {get; set; }
        public int PSC {get; set; }

        public PostovniAdresa(string ulice, int cisloPopisne, string mesto, int psc)
        {
            Ulice = ulice;
            CisloPopisne = cisloPopisne;
            Mesto = mesto;
            PSC = psc;
        }
    }

    public class BankovniUcet
    {
        private string _cisloUctu;
        private float _zustatek;
        private PostovniAdresa _adresaMajitele;

        public string CisloUctu 
        {
            get {return _cisloUctu; }
        }

        public float Zustatek
        {
            get {return _zustatek; }
            private set {}
        }

        private float _urokovaSazba;
        public float UrokovaSazba
        {
            get {return _urokovaSazba; }
            private set
            {
                if (value < 0 || value > 15)
                {
                    _urokovaSazba = 0;
                    Console.WriteLine("Spatna urokova sazba. Nastaveno na 0!");
                }
                else
                {
                    _urokovaSazba = value;
                }
            }
        }

        private static int _celkovyPocetUctu;

        public BankovniUcet(string cisloUctu, PostovniAdresa adresaMajitele, int pocatecniVklad)
        {
            _cisloUctu = cisloUctu;
            _adresaMajitele = adresaMajitele;
            if (pocatecniVklad < 0)
            {
                _zustatek = 0;
            }
            else
            {
                _zustatek = pocatecniVklad;
            }

            _celkovyPocetUctu++;
        }

        public BankovniUcet(string cisloUctu, PostovniAdresa adresaMajitele) : this(cisloUctu, adresaMajitele, 0)
        {

        }

        public void Vlozit(float castka)
        {
            if (castka > 0)
            {
                _zustatek += castka;
                Console.WriteLine($"Vlozeno {castka}");
            }
            else
            {
                Console.WriteLine("Neplatna castka :(");
            }
        }

        public bool Vybrat(float castka)
        {
            if (castka <= _zustatek)
            {
                _zustatek -= castka;
                Console.WriteLine($"Vybrano {castka}");
                return true;
            }
            else
            {
                Console.WriteLine("Skill issue bez prachu");
                return false;
            }
        }

        public static void ZobrazitPocetAktivnichUctu()
        {
            Console.WriteLine($"Celkovy pocet uctu je {_celkovyPocetUctu}");
        }

        public override string ToString()
        {
            return $"Ucet {_cisloUctu} | Mesto: {_adresaMajitele.Mesto} | Zustatek: {_zustatek} Kc";
        }
    }
}
