// 代码生成时间: 2025-07-31 18:39:01
using System;
using System.Collections.Generic;

namespace SortingApp
{
    // 排序算法程序
    public static class SortAlgorithms
    {
        // 冒泡排序
        public static void BubbleSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // 交换元素
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        // 插入排序
        public static void InsertionSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }

        // 快速排序
        public static void QuickSort(int[] array, int left, int right)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    int swapTemp = array[i];
                    array[i] = array[j];
                    array[j] = swapTemp;
                }
            }
            int swapTemp = array[i + 1];
            array[i + 1] = array[right];
            array[right] = swapTemp;
            return i + 1;
        }
    }

    // 程序入口
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 64, 34, 25, 12, 22, 11, 90 };
            Console.WriteLine("Original array: ");
            PrintArray(array);

            SortAlgorithms.BubbleSort(array);
            Console.WriteLine("Sorted array by Bubble Sort: ");
            PrintArray(array);

            int[] array2 = { 64, 34, 25, 12, 22, 11, 90 };
            SortAlgorithms.InsertionSort(array2);
            Console.WriteLine("Sorted array by Insertion Sort: ");
            PrintArray(array2);

            int[] array3 = { 64, 34, 25, 12, 22, 11, 90 };
            SortAlgorithms.QuickSort(array3, 0, array3.Length - 1);
            Console.WriteLine("Sorted array by Quick Sort: ");
            PrintArray(array3);
        }

        private static void PrintArray(int[] array)
        {
            foreach (int value in array)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}