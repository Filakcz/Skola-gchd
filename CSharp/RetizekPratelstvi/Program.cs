namespace RetizekPratelstvi;

class Program
{
    static void Main(string[] args)
    {
        // casova slozitost O(n+m)
        // pametova slozitost O(n+m)
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
            
            List<List<int>> graph = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < pairs.Length; i++)
            {
                string[] split = pairs[i].Split("-");
                int a = Convert.ToInt32(split[0]) - 1;
                int b = Convert.ToInt32(split[1]) - 1;

                graph[a].Add(b);
                graph[b].Add(a);
            }
            
            var path = BFS(graph, start, end);

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

    static List<string>? BFS(List<List<int>> graph, int start, int end)
    {
        // lepsi je Queue<int>, coz je rychlejsi na odebrani dle:
        // https://stackoverflow.com/questions/10380692/queuet-vs-listt
        int n = graph.Count;
        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[n];
        int[] prev = new int[n];
        Array.Fill(prev,-1);

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == end)
            {
                break;
            }

            foreach (int i in graph[current])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    prev[i] = current;
                    queue.Enqueue(i);
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
