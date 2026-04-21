namespace Trojuhelnik;

class Program
{
    static void Main(string[] args)
    {
        bool stop = false;
        while (true)
        {
            int[][] triangle = new int[3][];
            for (int i=0; i < 3; i++)
            {
                Console.Write($"{i+1}. vrchol x: ");
                string? x_str = Console.ReadLine();
                if (x_str == "q")
                {
                    stop = true;
                    break;
                }
                int x = Convert.ToInt32(x_str);
                
                Console.Write($"{i+1}. vrchol y: ");
                string? y_str = Console.ReadLine();
                if (y_str == "q")
                {
                    stop = true;
                    break;
                }
                int y = Convert.ToInt32(y_str);

                // Console.WriteLine($"{x} {y}");
                triangle[i] = [x,y];
            }
            
            if (stop)
            {
                break;
            }

            double a = Distance(triangle[0], triangle[1]);
            double b = Distance(triangle[1], triangle[2]);
            double c = Distance(triangle[2], triangle[0]);

            if ((a+b)>c && (b+c)>a && (a+c)>b)
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine("Tyto tri body netvori trojuhelnik.");
            }
        }

    }

    static double Distance(int[] a, int[] b)
    {
        double x = Math.Abs(a[0]-b[0]);
        double y = Math.Abs(a[1]-b[1]);

        double distance = Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2));

        return distance;
    }
}
