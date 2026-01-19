using System.Text;

namespace PololetniUloha
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] marks = new int[5];

            // (20b) 1. Seřaďte známky ze souboru znamky.txt od 1 do 5 algoritmem s lineární časovou složitostí vzhledem k počtu známek. 
            // Vypište je na řádek a pak vypište i četnosti jednotlivých známek.
            using(StreamReader sr = new StreamReader("znamky.txt")) // otevření souboru pro čtení
            {
                
                while (!sr.EndOfStream) // dokud jsme nedošli na konec souboru
                {
                    int znamka = Convert.ToInt16(sr.ReadLine()); // čteme známky po řádcích a převádíme je na číslo
                    marks[znamka - 1]++;
                }

            }

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < marks[i]; j++)
                {
                    output.Append(i + 1);
                }
            }
            Console.WriteLine(output);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i+1}: {marks[i]}x");
            }

            // => to, co jste pravděpodobně stvořili se nazývá Counting Sort



            // (40b) 2. Ze souboru znamky_prezdivky.csv vytvořte objekty typu Student se správně přiřazenou známkou a přezdívkou.
            // Seřaďte je podle známek (stabilně = dodržte pořadí v souboru) a vypište seřazené dvojice (znamka: přezdívka) - na každý řádek jednu.
            List<Student>[] marksStudents = {
                new List<Student>(), new List<Student>(), new List<Student>(), new List<Student>(), new List<Student>()
            };

            using(StreamReader sr = new StreamReader("znamky_prezdivky.csv"))
            {
                
                while (!sr.EndOfStream)
                {
                    string? lineString = sr.ReadLine();
                    if (lineString == null)
                    {
                        continue;
                    }

                    string[] line = lineString.Split(';');

                    int mark = Convert.ToInt16(line[1]);
                    string name = line[0];

                    marksStudents[mark - 1].Add(new Student(name, mark));
                }                

            }

            for (int i = 0; i < 5; i++)
            {
                foreach (Student actStudent in marksStudents[i])
                {
                    Console.WriteLine($"{actStudent.Prezdivka}: {actStudent.Znamka}");
                }
            }

            // => to, co jste pravděpodobně stvořili se nazývá Bucket Sort (přihrádkové řazení)




            // (10b) 3. Určete časovou a prostorovou složitost algoritmu z 2. úkolu


            Console.WriteLine("Slozitost casova a prostorova je O(n)");


            // (+60b) 4. BONUS: Napište kód, který bude řadit lexikograficky velká čísla v lineárním čase. Využijte dat ze souboru velka_cisla.txt

            List<string> velkaCisla = new List<string>();

            using(StreamReader sr = new StreamReader("velka_cisla.txt"))
            {
                
                while (!sr.EndOfStream)
                {
                    string? s = sr.ReadLine();
                    if (s != null)
                    {
                        velkaCisla.Add(s);
                    }
                }
            }

            List<string> sortedNumbers = StringSort(velkaCisla);
            for (int i = 0; i < sortedNumbers.Count; i++)
            {
                Console.WriteLine(sortedNumbers[i]);
            }
 
        }
        static List<string> StringSort(List<string> list)
        {
            int maxLength = 0;
            foreach (string s in list)
            {
                if (s.Length > maxLength)
                {
                    maxLength = s.Length;
                }
            }

            List<string>[] counts = new List<string>[10];
            for (int i = 0; i < counts.Length; i++)
            {
                counts[i] = new List<string>();
            }

            for (int i = 0; i < maxLength; i++)
            {
                foreach (string s in list)
                {
                    // odzadu (index = 0 -> jednotky)
                    int index = s.Length - 1 - i;
                    int digit;
                    if (index >= 0)
                    {
                        digit = Convert.ToInt16(Convert.ToString(s[index]));
                    }
                    else
                    {
                        digit = 0;
                    }

                    counts[digit].Add(s);
                }

                list.Clear();

                for (int j = 0; j < counts.Length; j++)
                {
                    list.AddRange(counts[j]);
                    counts[j].Clear();
                }
            }

            return list;
        }       

    }


    class Student
    {
        public string Prezdivka { get; } // tím, že je zde pouze get říkáme, že tato vlastnost třídy Student jde mimo třídu pouze číst, nikoli upravovat
        public int Znamka { get; }
        public Student(string prezdivka, int znamka) // konstruktor třídy
        {
            // použitím samotného { get; } také říkáme, že tyto vlastnosti jdou nastavit nejpozději v konstruktoru - tedy v této metodě
            Prezdivka = prezdivka;
            Znamka = znamka;
        }
    }
}
