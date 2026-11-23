using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Arena
{
    class Arena
    {
        private Tym tym1;
        private Tym tym2;
        private Kostka kostka;
        private Kostka mince;

        public Arena(Tym tym1, Tym tym2, Kostka kostka, Kostka mince)
        {
            this.tym1 = tym1;
            this.tym2 = tym2;
            this.kostka = kostka;
            this.mince = mince;
        }
        private void VykresliArenu()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");

            Console.WriteLine("Zdraví (a mana) bojovníků: \n");
            Console.WriteLine("Tym1:");
            foreach (Bojovnik bojovnik1 in tym1.Bojovnici)
            {
                bojovnik1.PeknyVypis();
            }

            Console.WriteLine("Tym2:");
            foreach (Bojovnik bojovnik2 in tym2.Bojovnici)
            {
                bojovnik2.PeknyVypis();
            }
        }

        private void VypisZpravu(string zprava)
        {
            Console.WriteLine(zprava);
            Thread.Sleep(500);
        }
        public Tym SpustZapas()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");
            Console.WriteLine("Vítejte v aréně!");
            Console.WriteLine($"Dnes se utkají {tym1} a {tym2}! \n");
            Console.WriteLine("Zápas může začít...");
            Console.ReadKey();

            Bojovnik bojovnik1 = tym1.Nahodny();
            Bojovnik bojovnik2 = tym2.Nahodny();

            if (mince.HodSebou() == 1)
            {
                bojovnik2.Utoc(bojovnik1, tym2);
                VykresliArenu();
                VypisZpravu(bojovnik2.Zprava); // zpráva o útoku
                VypisZpravu(bojovnik1.Zprava); // zpráva o obraně
                Console.WriteLine();
                bojovnik1.VymazZpravu();
                bojovnik2.VymazZpravu();
            }


            while (tym1.JeNekdoNazivu() && tym2.JeNekdoNazivu())
            {
                bojovnik1 = tym1.Nahodny();
                bojovnik2 = tym2.Nahodny();

                bojovnik1.Utoc(bojovnik2, tym1);
                VykresliArenu();
                VypisZpravu(bojovnik1.Zprava); // zpráva o útoku
                VypisZpravu(bojovnik2.Zprava); // zpráva o obraně
                bojovnik1.VymazZpravu();
                bojovnik2.VymazZpravu();

                if (tym2.JeNekdoNazivu())
                {
                    bojovnik1 = tym1.Nahodny();
                    bojovnik2 = tym2.Nahodny();

                    bojovnik2.Utoc(bojovnik1, tym2);
                    VykresliArenu();
                    VypisZpravu(bojovnik2.Zprava); // zpráva o útoku
                    VypisZpravu(bojovnik1.Zprava); // zpráva o obraně
                    bojovnik1.VymazZpravu();
                    bojovnik2.VymazZpravu();
                }
                Console.WriteLine();
            }

            if (tym1.JeNekdoNazivu())
            {
                tym1.Reset();
                return tym1;
            }
            else
            {
                tym2.Reset();
                return tym2;
            }
        }
    }


}
