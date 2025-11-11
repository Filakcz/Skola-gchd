namespace RetizekPratelstvi;

class Program
{
    static void Main(string[] args)
    {
        while (true){
            Console.Write("Pocet lidi: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Vztahy: ");
            string? inputPairs = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputPairs)) // kvuli warningu v compileru :(
            {
                Console.WriteLine("Prazdny!");
                return;
            }
            string[] pairs = inputPairs.Split();
            
            int[,] graph = new int[n,n];

            Console.Write("Od koho ke komu: ");
            string? inputPoints = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputPoints))
            {
                Console.WriteLine("Prazdny!");
                return;
            }
            string[] points = inputPoints.Split();

            int start = Convert.ToInt32(points[0]) - 1;
            int end = Convert.ToInt32(points[1]) - 1;

            for (int i = 0; i < pairs.Length; i++)
            {
                string[] split = pairs[i].Split("-");
                int a = Convert.ToInt32(split[0]) - 1;
                int b = Convert.ToInt32(split[1]) - 1;

                graph[a,b] = 1;
                graph[b,a] = 1;
            }
            
            // printeni matice 
            Console.WriteLine("Matice sousednosti: ");
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write(graph[i,j]);
                }        
                Console.WriteLine();
            }

            var path = BFS(graph, start, end, n);

            if (path != null)
            {
                Console.WriteLine("Cesta: " + string.Join(" ", path));
            }
            else
            {
                Console.WriteLine("Cesta neexistuje");
            }

            Console.WriteLine();
        }
    }

    static List<string>? BFS(int[,] graph, int start, int end, int n)
    {
        // lepsi by bylo Queue<int>, coz je rychlejsi na odebrani dle:
        // https://stackoverflow.com/questions/10380692/queuet-vs-listt
        List<int> queue = new List<int>();
        bool[] visited = new bool[n];
        int[] prev = new int[n];
        Array.Fill(prev,-1);

        queue.Add(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue[0];
            queue.RemoveAt(0);

            if (current == end)
            {
                break;
            }

            for (int i = 0; i < n; i++)
            {
                if (graph[current, i] == 1 && !visited[i])
                {
                    visited[i] = true;
                    prev[i] = current;
                    queue.Add(i);
                }
            }
        }

        if (!visited[end])
        {
            return null;
        }
        
        List<string> path = new List<string>();
        for (int i = end; i != -1; i = prev[i])
        {
            path.Add(Convert.ToString(i+1));
        }
        path.Reverse();
        return path;
    }
}
