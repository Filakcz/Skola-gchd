using System.Runtime.InteropServices;

namespace uvod
{ 
    internal class Program


    {
        static void Main(string[] args)

        {
            while (true) {
                Console.WriteLine("a → studenti, b→je to prvocislo?, c → rozklad na prvocisla, d→vypnout");
                Console.Write("Volba: ");
                string? hlavni_volba = Console.ReadLine();

                if (hlavni_volba == "a")
                {

                    Console.Write("Pocet studentu: ");
                    int pocet_studentu = Convert.ToInt32(Console.ReadLine());

                    // class Student by byla lepsi
                    List<string> jmena = new List<string>();
                    List<int> veky = new List<int>();
                    List<float> prumery = new List<float>();

                    for (int i = 0; i < pocet_studentu; i++)
                    {
                        Console.Write("Jmeno studenta: ");
                        string? jmeno_studenta = Console.ReadLine();
                        if (jmeno_studenta != null)
                        {
                            jmena.Add(jmeno_studenta);

                        }

                        Console.Write("Vek studenta: ");
                        int vek_studenta = Convert.ToInt32(Console.ReadLine());
                        veky.Add(vek_studenta);

                        Console.Write("Prumerna znamka (pozor na separator): ");
                        float prumerne_znamka_studenta = Convert.ToSingle(Console.ReadLine());
                        prumery.Add(prumerne_znamka_studenta);

                    }

                    Console.WriteLine(" a → vypis studentu, b → vypis studentu s prumerem mene nez 2.0, c→ prumer veku d → vratit se do hlavni volby");

                    bool otazky = true;
                    while (otazky)
                    {
                        Console.Write("Volba: ");
                        string? volba = Console.ReadLine();
                        if (volba == "a")
                        {
                            for (int i = 0; i < pocet_studentu; i++)
                            {
                                Console.WriteLine($"{jmena[i]}({veky[i]}): {prumery[i]}");

                            }
                        }

                        else if (volba == "b")
                        {
                            for (int i = 0; i < pocet_studentu; i++)
                            {
                                if (prumery[i] < 2.0)
                                {
                                    Console.WriteLine($"{jmena[i]}({veky[i]}): {prumery[i]}");
                                }
                            }
                        }

                        else if (volba == "c")
                        {
                            float soucet_vsech = 0.0f;

                            foreach (int i in veky)
                            {
                                soucet_vsech += i;
                            }

                            Console.WriteLine($"{Math.Round(soucet_vsech / pocet_studentu, 2)}");
                        }

                        else if (volba == "d")
                        {
                            otazky = false;
                        }

                        else
                        {
                            Console.WriteLine("Neplatna volba");
                        }
                    }

                }

                else if (hlavni_volba == "b")
                {
                    static bool jePrvocislo(int n)
                    {
                        if (n < 2)
                        {
                            return false;
                        }
                        for (int i = 2; i <= Math.Sqrt(n); i++)
                        {
                            if (n % i == 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }

                    Console.Write("Cislo: ");
                    int x = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(jePrvocislo(x));
                }

                else if (hlavni_volba == "c")
                {
                    static List<int> rozkladNaPrvocilal(int n)
                    {
                        List<int> prvocinitele = new List<int>();
                        int delitel = 2;

                        while (n > 1)
                        {
                            while (n % delitel == 0)
                            {
                                prvocinitele.Add(delitel);
                                n = n / delitel;
                            }
                            delitel++;
                        }
                        return prvocinitele;
                    }

                    Console.Write("Cislo: ");
                    int x = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(string.Join(" * ", rozkladNaPrvocilal(x)));
                    /*
                    List<int> rozklad = rozkladNaPrvocilal(x);
                    foreach (int i in rozklad)
                    {
                        Console.WriteLine(i);
                    }
                    */
                }

                else if (hlavni_volba == "d")
                {
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("Neplatna volba");
                }

            }
        }
    }
}