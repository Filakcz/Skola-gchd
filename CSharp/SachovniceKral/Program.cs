namespace SachovniceKral;

class Program
{
    static void Main(string[] args)
    {
        int[,] board = new int[8,8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board[i,j] = -2;
            }
        }

        Console.Write("Pocet prekazek: ");
        int n = Convert.ToInt32(Console.ReadLine());
        
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Prekazka {i+1}: ");
            string? obstacleInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(obstacleInput))
            {
                Console.WriteLine("Prazdny!");
                return;
            }
            string[] obstacle = obstacleInput.Split();
            board[Convert.ToInt32(obstacle[0]),Convert.ToInt32(obstacle[1])] = -1;
        }

        Console.Write("Start: ");
        string? startInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(startInput))
        {
            Console.WriteLine("Prazdny!");
            return;
        }
        string[] startParts = startInput.Split();
        int[] start = new int[2];
        start[0] = Convert.ToInt32(startParts[0]);
        start[1] = Convert.ToInt32(startParts[1]);

        Console.Write("End: ");
        string? endInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(endInput))
        {
            Console.WriteLine("Prazdny!");
            return;
        }
        string[] endParts = endInput.Split();
        int[] end = new int[2];
        end[0] = Convert.ToInt32(endParts[0]);
        end[1] = Convert.ToInt32(endParts[1]);

        int steps = BFS(board, start, end);
        if (steps == -1)
        {
            Console.WriteLine("Cesta neexistuje");
        }
        else 
        {
            Console.WriteLine($"Pocet kroku: {steps}");
        }
        board[end[0],end[1]] = -3;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int a = board[i,j];
                if (a == -1)
                {
                    Console.Write(" X ");
                }
                else if (a == -2)
                {
                    Console.Write(" . ");
                }
                else if (a == -3)
                {
                    Console.Write(" C ");
                }
                else
                {
                Console.Write($"{a,2} ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine(". neprosly, X stena, C cil");
    }

    static int BFS(int[,] board, int[] start, int[] end)
    {
        
        Queue<int[]> queue = new Queue<int[]>();

        queue.Enqueue(start);
        board[start[0], start[1]] = 0;

        while (queue.Count > 0)
        {
            int[] current = queue.Dequeue();

            if (current[0] == end[0] && current[1] == end[1])
            {
                return board[current[0],current[1]];
            }

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    int x = current[0] + i;
                    int y = current[1] + j;
                    if ((x > 7 || y > 7) || (x < 0 || y < 0 ))
                    {
                        continue;
                    }
                    if (board[x, y] == -2)
                    {
                        if (x == end[0] && y == end[1])
                        {
                            return board[current[0],current[1]]+1; 
                        }

                        board[x,y] = board[current[0],current[1]]+1;
                        queue.Enqueue([x,y]);
                    }
                }
            }
        }

        return -1;

    }
}
