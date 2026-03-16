namespace RozkladScitance;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        
        Stack<(int, int[])> stack = new Stack<(int, int[])>();
        List<int[]> answers = new List<int[]>();

        stack.Push((n, new int[0]));

        while (stack.Count() > 0)
        {
            (int a, int[] path) = stack.Pop();

            if (a == 0)
            {
                answers.Add(path);
                continue;
            }

            int start;
            if (path.Length == 0)
            {
                start = 1;
            }
            else
            {
                start = path.Last();
            }

            for (int i = start; i <= a; i++)
            {
                int[] newPath = new int[path.Length +1];
                for (int j = 0; j < path.Length; j++)
                {
                    newPath[j] = path[j];
                }
                newPath[path.Length] = i;
                stack.Push((a - i, newPath));
            }

        }

        answers.Reverse();

        foreach (int[] ans in answers)
        {
            Console.WriteLine(string.Join(" + ", ans));
        }
        
    }
}
