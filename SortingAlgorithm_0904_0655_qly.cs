// 代码生成时间: 2025-09-04 06:55:55
using System;
using System.Collections.Generic;

namespace SortingAlgorithmDemo
{
    /// <summary>
    /// A class containing various sorting algorithms.
    /// </summary>
    public class SortingAlgorithm
    {
        /// <summary>
        /// Sorts an array using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public static void BubbleSort(int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            // Bubble Sort Algorithm
            bool swapped;
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
# 增强安全性
                        // Swap the elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }

                // If no two elements were swapped by inner loop, then break
                if (!swapped)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Sorts an array using the Quick Sort algorithm.
# NOTE: 重要实现细节
        /// </summary>
# 扩展功能模块
        /// <param name="array">The array to be sorted.</param>
        public static void QuickSort(int[] array, int low, int high)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (low < 0 || high >= array.Length) throw new ArgumentOutOfRangeException();
# 改进用户体验

            if (low < high)
            {
                int pi = Partition(array, low, high);

                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }

        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
# FIXME: 处理边界情况
            int i = (low - 1);

            for (int j = low; j < high; j++)
# TODO: 优化性能
            {
                if (array[j] < pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
# 添加错误处理
                    array[j] = temp;
                }
            }

            int temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;
# 优化算法效率

            return i + 1;
# FIXME: 处理边界情况
        }

        /// <summary>
        /// Sorts an array using the Merge Sort algorithm.
        /// </summary>
# NOTE: 重要实现细节
        /// <param name="array">The array to be sorted.</param>
        public static void MergeSort(int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            if (array.Length > 1)
# 优化算法效率
            {
                int mid = array.Length / 2;
                int[] left = new int[mid];
# FIXME: 处理边界情况
                int[] right = new int[array.Length - mid];

                // Copy data to temp arrays
# FIXME: 处理边界情况
                for (int i = 0; i < mid; i++)
                    left[i] = array[i];
                for (int j = 0; j < array.Length - mid; j++)
                    right[j] = array[mid + j];
# 增强安全性

                // Sort the first half
                MergeSort(left);
# 扩展功能模块

                // Sort the second half
                MergeSort(right);

                // Merge the sorted halves
                Merge(array, left, right);
            }
        }

        private static void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    array[k] = left[i];
                    i++;
# 扩展功能模块
                }
# 改进用户体验
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements of left, if any
            while (i < left.Length)
            {
                array[k] = left[i];
                i++;
                k++;
            }

            // Copy remaining elements of right, if any
            while (j < right.Length)
            {
                array[k] = right[j];
# FIXME: 处理边界情况
                j++;
                k++;
            }
        }

        /// <summary>
        /// This method demonstrates how to use the sorting algorithms.
        /// </summary>
        public static void Main()
# NOTE: 重要实现细节
        {
# TODO: 优化性能
            int[] array = { 64, 34, 25, 12, 22, 11, 90 };

            Console.WriteLine("Original array: " + string.Join(", ", array));

            // Bubble Sort
            BubbleSort(array);
            Console.WriteLine("Sorted array (Bubble Sort): " + string.Join(", ", array));

            // Reset the array for next sorting
            array = new int[] { 64, 34, 25, 12, 22, 11, 90 };

            // Quick Sort
            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine("Sorted array (Quick Sort): " + string.Join(", ", array));

            // Reset the array for next sorting
            array = new int[] { 64, 34, 25, 12, 22, 11, 90 };

            // Merge Sort
            MergeSort(array);
            Console.WriteLine("Sorted array (Merge Sort): " + string.Join(", ", array));
        }
    }
# 扩展功能模块
}