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

            List<Bojovnik> ucastnici = new List<Bojovnik>();

            Console.WriteLine("Kolik bojovniku se dneska bude prát?");
            int pocet = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < pocet; i++)
            {
                Console.WriteLine($"Jméno {i + 1}. bojovnika?");
                string jmeno = Console.ReadLine()!;

                Console.WriteLine("Typ: 1=bojovnik nebo 2=carodej");
                string volba = Console.ReadLine()!;

                if (volba == "2")
                {
                    ucastnici.Add(new Carodej(jmeno, 80, 20, 3, kostka, 40));
                }
                else
                {
                    ucastnici.Add(new Bojovnik(jmeno, 100, 15, 10, kostka));
                }
            }

            while (ucastnici.Count() > 1)
            {
                List<Bojovnik> dalsiKolo = new List<Bojovnik>();
                if (ucastnici.Count() % 2 != 0)
                {
                    Kostka rnd = new Kostka(ucastnici.Count());
                    int stastlivec = rnd.HodSebou() - 1;
                    dalsiKolo.Add(ucastnici[stastlivec]);
                    ucastnici.RemoveAt(stastlivec);
                }
                for (int i = 0; i < ucastnici.Count; i+=2)
                {
                    Arena arena = new Arena(ucastnici[i], ucastnici[i+1], kostka, mince);
                    dalsiKolo.Add(arena.SpustZapas());
                }
                ucastnici = dalsiKolo;
            }

            Console.WriteLine($"Vitez turnaje je {ucastnici[0]}");

        }
    }


}
