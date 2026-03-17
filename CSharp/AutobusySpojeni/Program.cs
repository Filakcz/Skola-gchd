namespace AutobusySpojeni;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            int towns = Convert.ToInt32(Console.ReadLine());

            List<int>[] graph = new List<int>[towns];

            for (int i = 0; i < towns; i++)
            {
                graph[i] = new List<int>();
            }

            string[] a = Console.ReadLine().Split();
            while (a.Length == 2)
            {
                int from = Convert.ToInt32(a[0]) - 1;
                int to = Convert.ToInt32(a[1]) - 1;

                graph[from].Add(to);
                graph[to].Add(from);
            
                a = Console.ReadLine().Split();
            }
            
            int start = Convert.ToInt32(a[0]) - 1;
            int end = Convert.ToInt32(Console.ReadLine()) - 1;

            BFS(towns, graph, start, end);
        }
    }

    static void BFS(int towns, List<int>[] graph, int start, int end)
    {
        Queue<int> queue = new Queue<int>();

        bool[] visited = new bool[towns];
        int[] previous = new int[towns];
        
        for (int i = 0; i < towns; i++)
        {
            previous[i] = -1;
        }

        queue.Enqueue(start);

        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == end)
            {
                break;
            }

            foreach (int next in graph[current])
            {
                if (!visited[next])
                {
                    previous[next] = current;
                    visited[next] = true;
                    queue.Enqueue(next);

                }
            }
        }

        if (!visited[end])
        {
            Console.WriteLine("-> neexistuje");
            return;
        }

        else
        {
            List<int> path = new List<int>();
            
            for (int i = end; i != -1; i = previous[i])
            {
                path.Add(i+1);
            }

            path.Reverse();
    
            Console.Write("-> ");

            for (int i = 0; i < path.Count; i++)
            {
                Console.Write($"{path[i]} ");
            }

            Console.WriteLine();
        }
    }
        
}
