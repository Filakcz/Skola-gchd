using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Arena
{
    class Arena
    {
        private Bojovnik bojovnik1;
        private Bojovnik bojovnik2;
        private Kostka kostka;
        private Kostka mince;

        public Arena(Bojovnik bojovnik1, Bojovnik bojovnik2, Kostka kostka, Kostka mince)
        {
            this.bojovnik1 = bojovnik1;
            this.bojovnik2 = bojovnik2;
            this.kostka = kostka;
            this.mince = mince;
        }
        private void VykresliArenu()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");

            Console.WriteLine("Zdraví (a mana) bojovníků: \n");
            Console.WriteLine("{0} {1}", bojovnik1, bojovnik1.VratGrafickyPekneZivoty());
            if (bojovnik1 is Carodej carodej1)
            {
                Console.WriteLine("{0} {1}", carodej1, carodej1.VratGrafickyPekneManu());
            }


            Console.WriteLine("{0} {1}", bojovnik2, bojovnik2.VratGrafickyPekneZivoty());
            if (bojovnik2 is Carodej carodej2)
            {
                Console.WriteLine("{0} {1}", carodej2, carodej2.VratGrafickyPekneManu());
            }
        }

        private void VypisZpravu(string zprava)
        {
            Console.WriteLine(zprava);
            Thread.Sleep(500);
        }
        public Bojovnik SpustZapas()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");
            Console.WriteLine("Vítejte v aréně!");
            Console.WriteLine($"Dnes se utkají {bojovnik1} a {bojovnik2}! \n");
            Console.WriteLine("Zápas může začít...");
            Console.ReadKey();

            if (mince.HodSebou() == 1)
            {
                bojovnik2.Utoc(bojovnik1);
                VykresliArenu();
                VypisZpravu(bojovnik2.Zprava); // zpráva o útoku
                VypisZpravu(bojovnik1.Zprava); // zpráva o obraně
                Console.WriteLine();

            }
            // cyklus s bojem
            while (bojovnik1.JeNazivu() && bojovnik2.JeNazivu())
            { 
                bojovnik1.Utoc(bojovnik2);
                VykresliArenu();
                VypisZpravu(bojovnik1.Zprava); // zpráva o útoku
                VypisZpravu(bojovnik2.Zprava); // zpráva o obraně
                
                if (bojovnik2.JeNazivu())
                {
                    bojovnik2.Utoc(bojovnik1);
                    VykresliArenu();
                    VypisZpravu(bojovnik2.Zprava); // zpráva o útoku
                    VypisZpravu(bojovnik1.Zprava); // zpráva o obraně
                }
                Console.WriteLine();
            }

            if (bojovnik1.JeNazivu())
            {
                bojovnik1.Heal();
                return bojovnik1;
            }
            else
            {
                bojovnik2.Heal();
                return bojovnik2;
            }
        }
    }


}
