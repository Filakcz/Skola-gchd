using System.Text;

namespace OOP_Arena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Kostka kostka = new Kostka(6);
            Kostka mince = new Kostka(2);

            List<Tym> tymy = new List<Tym>();

            Console.WriteLine("Kolik tymu se dneska bude prát?");
            int pocetTymu = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < pocetTymu; i++)
            {
                Console.WriteLine($"Kolik v tymu {i+1}?");
                int pocet = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Jmeno tymu?");
                string jmenoTymu = Console.ReadLine()!;

                tymy.Add(new Tym(jmenoTymu, pocet));

                for (int j = 0; j < pocet; j++)
                {
                    Console.WriteLine($"Jméno {j + 1}. bojovnika v tymu {i+1}?");
                    string jmeno = Console.ReadLine()!;

                    Console.WriteLine("Typ: 1=bojovnik, 2=carodej, 3=druid, 4=felcar");
                    string volba = Console.ReadLine()!;

                    if (volba == "2")
                    {
                        tymy[i].PridejBojovnika(new Carodej(jmeno, 80, 20, 3, kostka, 40));
                    }
                    else if (volba == "3")
                    {
                        tymy[i].PridejBojovnika(new Druid(jmeno, 90, 15, 5, kostka, 30));
                    }
                    else if (volba == "4")
                    {
                        tymy[i].PridejBojovnika(new Felcar(jmeno, 90, 20, 8, kostka));
                    }
                    else
                    {
                        tymy[i].PridejBojovnika(new Bojovnik(jmeno, 100, 15, 10, kostka));
                    }
                }
            }

            while (tymy.Count() > 1)
            {
                List<Tym> dalsiKolo = new List<Tym>();
                if (tymy.Count() % 2 != 0)
                {
                    Kostka rnd = new Kostka(tymy.Count());
                    int stastlivec = rnd.HodSebou() - 1;
                    dalsiKolo.Add(tymy[stastlivec]);
                    tymy.RemoveAt(stastlivec);
                }
                for (int i = 0; i < tymy.Count; i+=2)
                {
                    Arena arena = new Arena(tymy[i], tymy[i+1], kostka, mince);
                    dalsiKolo.Add(arena.SpustZapas());
                }
                tymy = dalsiKolo;
            }

            Console.WriteLine($"Vitez turnaje je tym {tymy[0]} s cleny {string.Join(",", tymy[0].Bojovnici)}");

        }
    }


}
