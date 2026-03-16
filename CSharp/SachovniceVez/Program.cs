namespace SachovniceVez;

class Program
{
    static void Main(string[] args)
    {
        char[,] board = new char[8,8];
        int[] start = new int[2];
        
        for (int i = 0; i < 8; i++)
        {
            Console.Write($"Radek {i+1}: ");
            string? a = Console.ReadLine();
            for (int j = 0; j < 8; j++)
            {
                if (a != null)
                {
                    board[i,j] = a[j];
                    if (a[j] == 'v')
                    {
                        start[0] = i;
                        start[1] = j;
                    }
                }
            }
        }

        int steps = BFS(board, start);
        if (steps == -1)
        {
            Console.WriteLine("Cesta neexistuje");
        }
        else 
        {
            Console.WriteLine($"Pocet kroku: {steps}");
        }
    }

    static int BFS(char[,] board, int[] start)
    {
        Queue<int[]> queue = new Queue<int[]>();
        bool[,] visited = new bool[8,8];

        queue.Enqueue([start[0],start[1],0]);
        visited[start[0],start[1]] = true;

        int[][] directions = new int[4][];
        directions[0] = [0,1];
        directions[1] = [0,-1];
        directions[2] = [1,0];
        directions[3] = [-1,0];
        

        while (queue.Count > 0)
        {
            int[] current = queue.Dequeue();
            int cx = current[0];
            int cy = current[1];
            int steps = current[2];
            if (board[cx,cy] == 'c')
            {
                return steps;
            }

            foreach (var d in directions)
            {
                int x = cx + d[0];
                int y = cy + d[1];

                while (x >= 0 && x < 8 && y >= 0 && y < 8 && board[x,y] != 'x')
                {
                    if (board[x,y] == 'c')
                    {
                        return steps + 1;
                    }

                    if (!visited[x,y])
                    {
                        visited[x,y] = true;
                        queue.Enqueue([x,y,steps+1]);
                    }
                    
                    x += d[0];
                    y += d[1];
                }
            }
        }

        return -1;

    }
}
