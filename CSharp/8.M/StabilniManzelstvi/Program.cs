namespace StabilniManzelstvi;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] preferenceZen = new int[n,n];
        int[,] prefenceMuzu = new int[n,n];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0)
                {
                    Console.Write("Preference zen: ");
                }
                else
                {
                    Console.Write("Preference muzu: ");
                }

                string[] radek = Console.ReadLine()!.Split();

                for (int k = 0; k < n; k++)
                {
                    if (i == 0)
                    {
                        preferenceZen[j,k] = Convert.ToInt32(radek[k]) - 1;
                    }
                    else
                    {
                        prefenceMuzu[j,k] = Convert.ToInt32(radek[k]) - 1;
                    }
                }
            }
        }

        int[] partnerZen = new int[n];
        int[] partnerMuzu = new int[n];
        int[,] poradiZeny = new int[n,n]; // index zeny u muzu
        
        for (int i = 0; i < n; i++)
        {
            partnerZen[i] = -1;
            partnerMuzu[i] = -1;

            for (int j = 0; j < n; j++)
            {
                poradiZeny[i, prefenceMuzu[i,j]] = j;
            }
        }

        int[] dalsiNavrh = new int[n];

        Queue<int> volnyZeny = new Queue<int>();

        for (int i = 0; i < n; i++)
        {
            volnyZeny.Enqueue(i);
        }

        while (volnyZeny.Count > 0)
        {
            int zena = volnyZeny.Dequeue();
            int muz = preferenceZen[zena, dalsiNavrh[zena]];
            dalsiNavrh[zena]++;

            if (partnerMuzu[muz] == -1)
            {
                partnerMuzu[muz] = zena;
                partnerZen[zena] = muz;
            }
            else
            {
                int soucasnaZena = partnerMuzu[muz];

                if (poradiZeny[muz, zena] < poradiZeny[muz, soucasnaZena])
                {
                    partnerZen[soucasnaZena] = -1;
                    volnyZeny.Enqueue(soucasnaZena);

                    partnerMuzu[muz] = zena;
                    partnerZen[zena] = muz;
                }
                else
                {
                    volnyZeny.Enqueue(zena);
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Z{i + 1} + M{partnerZen[i] + 1} = laska");
        }
    }
}
