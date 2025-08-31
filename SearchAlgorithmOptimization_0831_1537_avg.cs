// 代码生成时间: 2025-08-31 15:37:21
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchAlgorithmOptimization
{
    // Represents a search algorithm service
    public class SearchService
    {
        /// <summary>
        /// Searches for an element in the given list using a specified search algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to search within.</param>
        /// <param name="target">The value to search for.</param>
        /// <param name="algorithm">The search algorithm to use.</param>
        /// <returns>The index of the target value if found, otherwise -1.</returns>
        public int Search<T>(List<T> list, T target, SearchAlgorithm algorithm)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (algorithm == SearchAlgorithm.Linear)
            {
                return LinearSearch(list, target);
            }
            else if (algorithm == SearchAlgorithm.Binary)
            {
                return BinarySearch(list, target);
            }
            else
            {
                throw new ArgumentException("Unsupported search algorithm.", nameof(algorithm));
            }
        }

        private int LinearSearch<T>(List<T> list, T target) where T : IComparable<T>
        {
            // Perform a linear search on the list
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(target) == 0)
                {
                    return i;
                }
            }
            return -1; // Target not found
        }

        private int BinarySearch<T>(List<T> list, T target) where T : IComparable<T>
        {
            // Perform a binary search on the list
            int left = 0;
            int right = list.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = list[mid].CompareTo(target);
                if (comparison == 0) return mid;
                if (comparison < 0) left = mid + 1;
                else right = mid - 1;
            }
            return -1; // Target not found
        }
    }

    // Enum to represent different search algorithms
    public enum SearchAlgorithm
    {
        Linear,
        Binary
    }
}
