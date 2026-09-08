namespace OpakovaniSyntaxe;

class Program
{
    static void Main(string[] args)
    {
        Film vezeni = new Film("The Shawshank Redemption", "Frank", "Darabont", 1994);
        Film duna2 = new Film("Dune: Part Two", "Denis", "Villeneuve", 2024);
        Film inception = new Film("Inception", "Christopher", "Nolan", 2010);

        List<Film> filmy = new List<Film>();
        filmy.Add(vezeni);
        filmy.Add(duna2);
        filmy.Add(inception);

        Random rnd = new Random();
        for (int i = 0; i < filmy.Count; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                filmy[i].PridaniHodnoceni(rnd.Next(0,6));
            }
        }

        float nejlepsiHodnoceni = -1;
        string nejlepsi = "";
        int nejdelsiDelka = -1;
        string nejdelsi = "";

        foreach (Film film in filmy)
        {
            Console.WriteLine(film);
            if (film.Hodnoceni < 3)
            {
                Console.WriteLine($"{film.Nazev} je odpad! Má hodnocení jen {Math.Round(film.Hodnoceni,2)}.");
            }
            if (film.Hodnoceni > nejlepsiHodnoceni)
            {
                nejlepsiHodnoceni = film.Hodnoceni;
                nejlepsi = film.Nazev; 
            }
            if (film.Nazev.Length > nejdelsiDelka)
            {
                nejdelsiDelka = film.Nazev.Length;
                nejdelsi = film.Nazev;
            }

        }

        if (nejlepsiHodnoceni != -1)
        {
            Console.WriteLine($"Nejlepší film je {nejlepsi} s hodnocením {Math.Round(nejlepsiHodnoceni,2)}.");
            Console.WriteLine($"Nejdelší film je {nejdelsi} s délkou {nejdelsiDelka}.");
        }
    }

    class Film
    {
        public string Nazev = "";
        public string JmenoRezisera = "";
        public string PrijmeniRezisera = "";
        public int RokVzniku;
        public float Hodnoceni;
        private float SoucetHodnoceni = 0;
        private float PocetHodnoceni = 0;

        public Film(string nazev, string jmenoRezisera, string prijmeniRezisera, int rokVzniku)
        {
            Nazev = nazev;
            JmenoRezisera = jmenoRezisera;
            PrijmeniRezisera = prijmeniRezisera;
            RokVzniku = rokVzniku;
            Hodnoceni = 0;
        }

        public void PridaniHodnoceni(int hodnoceni)
        {
            SoucetHodnoceni += hodnoceni;
            PocetHodnoceni++;
            Hodnoceni = SoucetHodnoceni / PocetHodnoceni;
        }

        public override string ToString()
        {
            return string.Format($"{Nazev} ({RokVzniku}; {PrijmeniRezisera}, {JmenoRezisera[0]}): {Math.Round(Hodnoceni,2)} ⭐");
        }

    }
}
