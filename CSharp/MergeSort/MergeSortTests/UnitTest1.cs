namespace MergeSortTests;
using MergeSort;

public class UnitTest1
{
    [Fact]
    public void Sort_RandomArray()
    {
        int[] array = {5,2,8,1,3};
        int[] expectedArray = {1,2,3,5,8};

        MergeSortClass.Sort(array);

        Assert.Equal(expectedArray, array);
    }

    [Fact]
    public void Sort_AlreadySorted()
    {
        int[] array = {1,2,3,4,5};
        int[] expectedArray = {1,2,3,4,5};

        MergeSortClass.Sort(array);

        Assert.Equal(expectedArray, array);

    }

    [Fact]
    public void Sort_WithDuplicates()
    {
        int[] array = {4,1,3,1,2};
        int[] expectedArray = {1,1,2,3,4};

        MergeSortClass.Sort(array);

        Assert.Equal(expectedArray, array);


    }

   }
