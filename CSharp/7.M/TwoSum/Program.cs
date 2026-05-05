namespace TwoSum;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Array: ");
        int[] cisla = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Console.Write("Sum: ");
        int sum = Convert.ToInt32(Console.ReadLine());

        (int index1, int index2) = FindSum(cisla, sum);

        if (index1 == -1)
        {
            Console.WriteLine(index1);
        }
        else
        {
            Console.WriteLine($"{index1} {index2}");
        }
    }

    static (int, int) FindSum(int[] cisla, int sum)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < cisla.Length; i++)
        {
            int diff = sum - cisla[i];

            if (dict.ContainsKey(diff))
            {
                return (dict[diff], i);
            }

            if (!dict.ContainsKey(cisla[i]))
            {
                dict.Add(cisla[i], i);
            }
        }

        return (-1, -1);

    }
}
