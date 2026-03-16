namespace Sort;

class Program
{
    static void Main(string[] args)
    {
        int[] intArray = {8,1,4,9,2,5,3,7};
        
        intArray = BubbleSort(intArray);
        
        PrintIntArray(intArray);

    }

    static int[] BubbleSort(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n; i++)
        {
            bool swapped = false;
            for (int j = 0; j < (n - 1); j++)
            {
                if (array[j] > array[j+1])
                {
                    int actNumber = array[j];
                    array[j] = array[j+1];
                    array[j+1] = actNumber;
                    swapped = true;
                }
            }
            if (swapped == false)
            {
                break;
            }
        }

        return array;
    }

    static void PrintIntArray(int[] array)
    {
        foreach(int i in array)
        {
            Console.Write(i);
        }

        Console.WriteLine();

    }
}
