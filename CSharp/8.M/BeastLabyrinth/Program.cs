namespace BeastLabyrinth;

using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Bludiste bludiste = new Bludiste();

        for (int i = 1; i < 21; i++)
        {
            bludiste.Tah();
            Console.WriteLine($"{i}. krok");
            Console.WriteLine(bludiste);
        }
    }

    class Bludiste
    {
        public char[,] Mrizka;
        public int Sirka;
        public int Vyska;
        public List<Beast> Prisery = new List<Beast>();


        public Bludiste()
        {
            Console.Write("Sirka: ");
            Sirka = Convert.ToInt32(Console.ReadLine());

            Console.Write("Vyska: ");
            Vyska = Convert.ToInt32(Console.ReadLine());

            Mrizka = new char[Sirka,Vyska];
            for (int i = 0; i < Vyska; i++)
            {
                Console.Write($"Radek {i+1}: ");
                string? aktRadek = Console.ReadLine();
                for (int j = 0; j < Sirka; j++)
                {
                    if (aktRadek != null)
                    {
                        char aktChar = aktRadek[j];
                        Mrizka[j,i] = aktChar;

                        int smer = Array.IndexOf(Beast.Chary, aktChar);
                        if (smer != -1)
                        {
                            Prisery.Add(new Beast(j, i, smer, this));
                        }
                    }
                }
            }
        }

        public void Tah()
        {
            foreach (Beast b in Prisery)
            {
                b.Tah();
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Vyska; i++)
            {
                for (int j = 0; j < Sirka; j++)
                {
                    sb.Append(Mrizka[j,i]);
                }

                sb.Append("\n");
            }
            return sb.ToString();
        }

    }

    class Beast
    {        
        public static readonly char[] Chary = ['>', 'v', '<', '^'];
        public static readonly int[][] Kroky = [[1,0], [0,1], [-1,0], [0,-1]];

        public int X;
        public int Y;
        public int AktIndex = -1;
        public char SchovanejZnak = '.';
        public bool PosledniOtoceni = false;
        private Bludiste bludiste;

        public Beast(int x, int y, int aktIndex, Bludiste b)
        {
            X = x;
            Y = y;
            AktIndex = aktIndex;
            bludiste = b;
        }

        public void Tah()
        {
            if (PosledniOtoceni)
            {
                Posunuti();
                PosledniOtoceni = false;
                return;
            }

            if (VolnoVpravo())
            {
                OtocitDoprava();
                PosledniOtoceni = true;
                return;
            }

            if (VolnoPred())
            {
                Posunuti();
                return;
            }

            OtocitDoleva();

        }

        public void Posunuti()
        {
            bludiste.Mrizka[X, Y] = SchovanejZnak;

            X += Kroky[AktIndex][0];
            Y += Kroky[AktIndex][1];

            SchovanejZnak = bludiste.Mrizka[X, Y];
            bludiste.Mrizka[X, Y] = Chary[AktIndex];
        }

        public void OtocitDoleva()
        {
            AktIndex--;
            AktIndex += Chary.Length;
            AktIndex = AktIndex % Chary.Length;

            bludiste.Mrizka[X, Y] = Chary[AktIndex];
        }

        public void OtocitDoprava()
        {
            AktIndex++;
            AktIndex = AktIndex % Chary.Length;

            bludiste.Mrizka[X, Y] = Chary[AktIndex];
        }

        public bool VolnoPred()
        {
            return VolnoSmeru(AktIndex);
        }

        public bool VolnoVpravo()
        {
            return VolnoSmeru((AktIndex + 1) % Chary.Length);
        }

        public bool VolnoSmeru(int smer)
        {
            int x = X + Kroky[smer][0];
            int y = Y + Kroky[smer][1];

            if (x < 0 || x >= bludiste.Sirka || y < 0 || y >= bludiste.Vyska)
            {
                return false;
            }

            if (bludiste.Mrizka[x, y] == '.')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
