namespace QuickSort;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("QuickSort: ");
        string[] stringArray = Console.ReadLine()!.Split();
        int[] array = new int[stringArray.Length];
        for (int i = 0; i < stringArray.Length; i++)
        {
            array[i] = Convert.ToInt32(stringArray[i]);
        }

        QuickSort(array, 0, array.Length - 1);
    
        Console.Write("Sorted: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();
    }

    static void QuickSort(int[] array, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        int a = array[left];
        int b = array[right];
        int c = array[(left+right)/2];

        int pivot;
        if ((a >= b && a <= c) || (a <= b && a >= c))
        {
            pivot = a;
        }
        else if ((b >= a && b <= c) || (b <= a && b >= c))
        {
            pivot = b;
        }
        else
        {
            pivot = c;
        }
        
        int i = left;
        int j = right;
        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }
            while (array[j] > pivot)
            {
                j--;
            }

            if (i < j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            if (i <= j)
            {
                i++;
                j--;
            }
        }

        QuickSort(array, left, j);
        QuickSort(array, i, right);
    }
}
