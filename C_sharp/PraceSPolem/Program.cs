namespace PraceSPolem;

class Program
{
    static void Main(string[] args)
    {
        // 1 ukol
        int[] numbers = {2,5,17,3,42,6,7};

        int max = FindMax(numbers);

        Console.Write("Pole: ");
        Console.WriteLine(string.Join(" ", numbers));

        Console.WriteLine($"Nejvetsi cislo v poli: {max}");

        // 2 ukol
        int[] sorted = MergeSort(numbers);
        Console.Write("Serazene pole: ");
        Console.WriteLine(string.Join(" ", sorted));

        // 3 ukol
        int searchNumber = 3;
        Array.Reverse(sorted);
        int numberPosition = BinarySearch(sorted, searchNumber);
        Console.Write("Reversed: ");
        Console.WriteLine(string.Join(" ", sorted));
        if (numberPosition == -1)
        {
            Console.WriteLine("Cislo neni v poli");
        }
        else
        {
            Console.WriteLine($"{searchNumber} je na pozici {numberPosition}");
        }
    }

    static int FindMax(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        return max;
    }

    static int[] MergeSort(int[] array)
    {
        if (array.Length <= 1)
        {
            return array;
        }
        int mid = array.Length / 2;
        
        int[] left = new int[mid];
        int[] right = new int[array.Length - mid];


        for (int i = 0; i < mid; i++)
        {
            left[i] = array[i];
        }
        
        for (int i = mid; i < array.Length; i++)
        {
            right[i-mid] = array[i];
        }

        left = MergeSort(left);
        right = MergeSort(right);
        return Merge(left,right);
    }

    static int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];
        int i = 0;
        int j = 0;
        int k = 0;
        
        while (left.Length > i && right.Length > j)
        {
          if (left[i] <= right[j])
          {
              result[k] = left[i];
              k++;
              i++;
          }
          else
          {
              result[k] = right[j];
              k++;
              j++;
          }
        }

        // pokud uz dosli z leveho nebo praveho listu
        while (i < left.Length)
        {
            result[k] = left[i];
            k++;
            i++;
        }

        while (j < right.Length)
        {
            result[k] = right[j];
            k++;
            j++;
        }
        
        return result;
    }

    static int BinarySearch(int[] numbers, int searchNumber)
    {
        int lowest = 0;
        int highest = numbers.Length - 1;
        while (lowest <= highest)
        {
            int k = lowest + (highest - lowest) / 2;
            if (numbers[k] == searchNumber)
            {
                return k;
            }
            if (numbers[k] > searchNumber)
            {
                lowest = k + 1;
            }
            else
            {
                highest = k - 1;
            }
        }

        return -1;
    }
}
