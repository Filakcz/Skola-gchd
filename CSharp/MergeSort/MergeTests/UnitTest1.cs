namespace MergeTests;
using MergeSort;

public class UnitTest1
{
    [Fact]  // Tím označujeme, že jde o testovací metodu      
    public void Merge_EqualLengthArrays_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
    {
        // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
        int[] array = { 1, 3, 5, 2, 3, 6 };
        int[] expectedArray = { 1, 2, 3, 3, 5, 6};
        int left = 0;
        int right = array.Length-1;
        int middle = left + (right - left) / 2;

        // Act - zavoláme testovanou funkci
        MergeSortClass.Merge(array, left, middle, right);

        // Assert - zkontrolujeme to, co nám funkce vrátila
        Assert.Equal(expectedArray, array);
    }

    [Fact]  // Tím označujeme, že jde o testovací metodu      
    public void Merge_Duplicates_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
    {
        // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
        int[] array = { 1, 3, 5, 5, 2, 2, 3, 6 };
        int[] expectedArray = { 1, 2, 2, 3, 3, 5, 5, 6};
        int left = 0;
        int right = array.Length-1;
        int middle = left + (right - left) / 2;

        // Act - zavoláme testovanou funkci
        MergeSortClass.Merge(array, left, middle, right);

        // Assert - zkontrolujeme to, co nám funkce vrátila
        Assert.Equal(expectedArray, array);
    }

    [Fact]  // Tím označujeme, že jde o testovací metodu      
    public void Merge_DifferentLengthArrays_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
    {
        // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
        int[] array = { 1, 3, 5, 7, 2, 3, 6 };
        int[] expectedArray = { 1, 2, 3, 3, 5, 6, 7};
        int left = 0;
        int right = array.Length-1;
        int middle = left + (right - left) / 2;

        // Act - zavoláme testovanou funkci
        MergeSortClass.Merge(array, left, middle, right);

        // Assert - zkontrolujeme to, co nám funkce vrátila
        Assert.Equal(expectedArray, array);
    }

    [Fact]  // Tím označujeme, že jde o testovací metodu      
    public void Merge_NotMiddle_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
    {
        // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
        int[] array = { 1, 3, 5, 7, 8, 2, 3, 6 };
        int[] expectedArray = { 1, 2, 3, 3, 5, 6, 7, 8};
        int left = 0;
        int right = array.Length-1;
        int middle = 4;

        // Act - zavoláme testovanou funkci
        MergeSortClass.Merge(array, left, middle, right);

        // Assert - zkontrolujeme to, co nám funkce vrátila
        Assert.Equal(expectedArray, array);
    }

    [Fact]  // Tím označujeme, že jde o testovací metodu      
    public void Merge_NegativeNumbers_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
    {
        // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
        int[] array = { -1, 3, 5, -2, 3, 6 };
        int[] expectedArray = { -2, -1, 3, 3, 5, 6};
        int left = 0;
        int right = array.Length-1;
        int middle = left + (right - left) / 2;

        // Act - zavoláme testovanou funkci
        MergeSortClass.Merge(array, left, middle, right);

        // Assert - zkontrolujeme to, co nám funkce vrátila
        Assert.Equal(expectedArray, array);
    }

}
