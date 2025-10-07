// 代码生成时间: 2025-10-08 00:00:31
/// <summary>
//  A class to demonstrate sorting algorithms in C# using ASP.NET.
// </summary>
public class SortingAlgorithm
{
    /// <summary>
    /// Sorts an array of integers using the Bubble Sort algorithm.
    /// </summary>
    /// <param name="array">The array of integers to sort.</param>
    public static void BubbleSort(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("Array must not be null or empty.");
        }

        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap the elements
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    /// <summary>
    /// Sorts an array of integers using the Quick Sort algorithm.
    /// </summary>
    /// <param name="array">The array of integers to sort.</param>
    public static void QuickSort(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("Array must not be null or empty.");
        }

        if (array.Length <= 1)
        {
            return; // No need to sort an array of length 1 or less
        }

        QuickSortRecursive(array, 0, array.Length - 1);
    }

    private static void QuickSortRecursive(int[] array, int start, int end)
    {
        if (start < end)
        {
            int pivotIndex = Partition(array, start, end);
            QuickSortRecursive(array, start, pivotIndex - 1);
            QuickSortRecursive(array, pivotIndex + 1, end);
        }
    }

    private static int Partition(int[] array, int start, int end)
    {
        int pivot = array[end];
        int i = start - 1;
        for (int j = start; j < end; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        int temp = array[i + 1];
        array[i + 1] = array[end];
        array[end] = temp;
        return i + 1;
    }
}
