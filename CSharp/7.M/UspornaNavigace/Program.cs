namespace UspornaNavigace;

class Program
{
    struct Hrana
    {
        public int Cil;
        public int Delka;
        public bool JePlacena;

        public Hrana(int cil, int delka, int placena)
        {
            Cil = cil;
            Delka = delka;
            if (placena == 1)
            {
                JePlacena = true;
            }
            else
            {
                JePlacena = false;
            }
        }
    }

    static void Main(string[] args)
    {
        string? mestaSilniceStr = Console.ReadLine();
        if (mestaSilniceStr == null)
        {
            Console.WriteLine("Neplatný vstup.");
            return;
        }
        string[] parts = mestaSilniceStr.Split();
        if (parts.Length != 2)
        {
            Console.WriteLine("Neplatný vstup.");
            return;
        }
 
        if (!int.TryParse(parts[0], out int pocetMest) || !int.TryParse(parts[1], out int pocetSilnic))
        {
            Console.WriteLine("Neplatný vstup.");
            return;
        }

        if (pocetMest <= 0 || pocetSilnic < 0)
        {
            Console.WriteLine("Neplatný vstup.");
            return;
        }

        
        List<Hrana>[] graf = new List<Hrana>[pocetMest];

        for (int i = 0; i < pocetMest; i++)
        {
            graf[i] = new List<Hrana>();
        }

        for (int i = 0; i < pocetSilnic; i++)
        {
            string? hranaStr = Console.ReadLine();
            if (hranaStr == null)
            {
                Console.WriteLine("Neplatný vstup.");
                return;
            }
            string[] hranaParts = hranaStr.Split();
            if (hranaParts.Length != 4)
            {
                Console.WriteLine("Neplatný vstup.");
                return;
            }
            if (!int.TryParse(hranaParts[0], out int a) ||
                !int.TryParse(hranaParts[1], out int b) ||
                !int.TryParse(hranaParts[2], out int delka) ||
                !int.TryParse(hranaParts[3], out int placena))
            {
                Console.WriteLine("Neplatný vstup.");
                return;
            }

            if (a < 0 || a >= pocetMest || b < 0 || b >= pocetMest || delka <= 0 || (placena != 0 && placena != 1))
            {
                Console.WriteLine("Neplatný vstup.");
                return;
            }

            graf[a].Add(new Hrana(b, delka, placena));
            graf[b].Add(new Hrana(a, delka, placena));
        }

        string? startCilStr = Console.ReadLine();
        if (startCilStr == null)
        {
            Console.WriteLine("Neplatný vstup.");
            return;
        }
        string[] startCilParts = startCilStr.Split();

        if (startCilParts.Length != 2)
        {
            Console.WriteLine("Neplatný vstup.");
            return;
        }

        if (!int.TryParse(startCilParts[0], out int start) || !int.TryParse(startCilParts[1], out int cil))
        {
            Console.WriteLine("Neplatný vstup.");
            return;
        }

        if (start < 0 || start >= pocetMest || cil < 0 || cil >= pocetMest)
        {
            Console.WriteLine("Neplatný vstup.");
            return;
        }

        Dijkstra(graf, start, cil, pocetMest);
    }

    static void Dijkstra(List<Hrana>[] graf, int start, int cil, int pocetMest)
    {
        // ,0 bez pouziti placeni
        // ,1 s placenim
        int[,] vzdalenost = new int[pocetMest,2];
        
        // predchozi mesto, jeho stav 
        (int,int)[,] predchozi = new (int,int)[pocetMest,2];
        for (int i = 0; i < pocetMest; i++)
        {
            vzdalenost[i,0] = int.MaxValue;
            vzdalenost[i,1] = int.MaxValue;
            predchozi[i,0] = (-1,-1);
            predchozi[i,1] = (-1,-1);
        }

        vzdalenost[start,0] = 0;

        // (uzel, placeno), vaha
        PriorityQueue<(int,int), int> pq = new PriorityQueue<(int,int), int>();
        pq.Enqueue((start,0),0);

        while (pq.Count > 0)
        {
            (int uzel, int placeno) = pq.Dequeue();
 
            // delka silnice nemuze byt zaporna, takze muzeme ukoncit po nalezeni cile (?)
            // if (uzel == cil)
            // {
            //     break;
            // }

            foreach (var hrana in graf[uzel])
            {
                int dalsiUzel = hrana.Cil;
                int novePlaceno = placeno;

                if (hrana.JePlacena)
                {
                    if (placeno == 1)
                    {
                        continue;
                    }
                    novePlaceno = 1;
                }

                int novaVzdalenost = vzdalenost[uzel,placeno] + hrana.Delka;

                if (novaVzdalenost < vzdalenost[dalsiUzel, novePlaceno])
                {
                    vzdalenost[dalsiUzel, novePlaceno] = novaVzdalenost;
                    predchozi[dalsiUzel, novePlaceno] = (uzel,placeno);
                    pq.Enqueue((dalsiUzel, novePlaceno), novaVzdalenost);
                }
            }
        }

        int vysledek;
        int stav;
        if (vzdalenost[cil,0] > vzdalenost[cil,1])
        {
            vysledek = vzdalenost[cil,1];
            stav = 1;
        }
        else
        {
            vysledek = vzdalenost[cil,0];
            stav = 0;
        }

        if (vysledek == int.MaxValue)
        {
            Console.WriteLine("Cesta neexistuje.");
            return;
        }

        List<int> cesta = new List<int>();
        int aktualni = cil;
        while (aktualni != -1)
        {
            cesta.Add(aktualni);
            (aktualni, stav) = predchozi[aktualni, stav];
        }

        cesta.Reverse();

        Console.WriteLine();
        Console.WriteLine(string.Join(" -> ", cesta));
        Console.WriteLine($"Vzdálenost: {vysledek}");

    }
}
