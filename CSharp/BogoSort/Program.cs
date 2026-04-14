namespace BogoSort;

class Program
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        Console.Write("BogoSort: ");
        string[] stringArray = Console.ReadLine()!.Split();
        int[] array = new int[stringArray.Length];
        for (int i = 0; i < stringArray.Length; i++)
        {
            array[i] = Convert.ToInt32(stringArray[i]);
        }

        BogoSort(array);
    
        Console.Write("Sorted: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();
    }

    static void BogoSort(int[] array)
    {
        while (!IsSorted(array))
        {
            Shuffle(array);
        }
    }

    static bool IsSorted(int[] array)
    {
        for (int i = 0; i < (array.Length - 1); i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    static void Shuffle(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int j = random.Next(array.Length);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
