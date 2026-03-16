namespace AbecedniPoradi;

class Program
{
    static void Main(string[] args)
    {
        // Usporadani abecedy nemusi byt jednoznacne pro:
        // xyz xz

        // Usporadani neexistuje pro:
        // aa ab ac ca ba


        while (true)
        {
            Console.Write("Vstup: ");
            string? s = Console.ReadLine();
            if (s == null)
            {
                return;
            }
            string[] words = s.Split();

            Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
            Dictionary<char, int> inCount = new Dictionary<char, int>();

            foreach (string word in words)
            {
                foreach (char a in word)
                {
                    if (!inCount.ContainsKey(a))
                    {
                        inCount.Add(a,0);
                        graph.Add(a, new List<char>());
                    }
                }
            }

            for (int i = 0; i < (words.Length - 1); i++)
            {
                string word1 = words[i];
                string word2 = words[i+1];

                int len;
                if (word1.Length > word2.Length)
                {
                    len = word2.Length;
                }
                else
                {
                    len = word1.Length;
                }

                for (int j = 0; j < len; j++)
                {
                    if (word1[j] != word2[j])
                    {
                        char from = word1[j];
                        char to = word2[j];

                        if (!graph[from].Contains(to))
                        {
                            graph[from].Add(to);
                            inCount[to]++;
                        }

                        break;
                    }
                }
            }
            

            Queue<char> queue = new Queue<char>();
            foreach (var item in inCount)
            {
                if (item.Value == 0)
                {
                    queue.Enqueue(item.Key);
                }
            }


            List<char> result = new List<char>();

            while (queue.Count > 0)
            {
                char a = queue.Dequeue();
                result.Add(a);

                if (graph.ContainsKey(a))
                {
                    foreach (char neighbor in graph[a])
                    {
                        inCount[neighbor]--;
                        if (inCount[neighbor] == 0)
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            if (result.Count != inCount.Count)
            {
                Console.WriteLine("Cyklus!!!");
            }
            else 
            {
                Console.WriteLine(string.Join(" -> ", result));
            }

        }
    }
}
