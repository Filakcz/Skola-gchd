namespace RetizekPratelstvi;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Pocet lidi: ");
        int n = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Vztahy: ");
        string[] pairs = Console.ReadLine().Split();
        
        int[,] graph = new int[n,n];
        
        Console.Write("Od koho ke komu: ");
        string[] points = Console.ReadLine().Split();
        int start = Convert.ToInt32(points[0]);
        int end = Convert.ToInt32(points[1]);

        for (int i = 0; i < pairs.Length; i++)
        {
            string[] split = pairs[i].Split("-");
            int a = Convert.ToInt32(split[0]) - 1;
            int b = Convert.ToInt32(split[1]) - 1;

            graph[a,b] = 1;
            graph[b,a] = 1;
        }

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            for (int j = 0; j < graph.GetLength(1); j++)
            {
                Console.Write(graph[i,j]);
            }        
            Console.WriteLine();
        }
    }
}
