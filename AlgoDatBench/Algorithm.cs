// ----------------------------------------------------------------------- 
// <copyright file="Algorithm.cs" company="FHWN"> 
// Copyright (c) FHWN. All rights reserved. 
// </copyright> 
// <summary>This program operates with different sorting algorithm.</summary> 
// <author>Wolfgang Ofner.</author> 
// -----------------------------------------------------------------------

namespace AlgoDatBench
{
    /// <summary>
    /// Static class with algorithm.
    /// </summary>
    public static class Algorithm
    {
        /// <summary>
        /// Bubble sort.
        /// </summary>
        /// <param name="myList">List for sorting.</param>
        public static void BubbleSort(MyList myList)
        {
            int temp;

            // Compares the numbers and moves the higher number to the right.
            for (int i = 0; i < myList.Count; i++)
            {
                Node node = myList.RootNode;

                for (int j = 0; j < myList.Count - 1; j++)
                {
                    if (node.Next != null && node.Value > node.Next.Value)
                    {
                        temp = node.Next.Value;
                        node.Next.Value = node.Value;
                        node.Value = temp;
                    }

                    node = node.Next;
                }
            }
        }

        /// <summary>
        /// Insertion sort.
        /// </summary>
        /// <param name="myList">List for sorting.</param>
        public static void InsertionSort(MyList myList)
        {            
            int j, temp;
            Node node = myList.GetNode(1);

            if (node != null)
            {
                // Starts with second element and moves it to the left until a smaller number is found. Then takes the third number and so on.
                for (int i = 0; i < myList.Count; i++)
                {
                    temp = node.Value;
                    j = i;

                    while (j > 0 && node.Previous.Value >= temp)
                    {
                        node.Value = node.Previous.Value;
                        j--;
                        node = node.Previous;
                    }

                    node.Value = temp;

                    // Goes to the next node.                
                    node = myList.GetNode(i + 1);
                }
            }
            
            //// for (int i = 1; i < list.Count; i++)
            //// {
            ////    temp = list[i];
            ////    j = i;

            ////    while (j > 0 && list[j - 1] >= temp)
            ////    {
            ////        list[j] = list[j - 1];
            ////        j--;
            ////    }

            ////    list[j] = temp;
            //// }
        }

        /// <summary>
        /// Merge sort.
        /// </summary>
        /// <param name="myList">List for sorting.</param>
        /// <param name="left">Left border.</param>
        /// <param name="right">Right border.</param>
        public static void MergeSort(MyList myList, int left, int right)
        {
            //// 1. Divide the unsorted list into n sublists, each containing 1 element(a list of 1 element is considered sorted).
            //// 2. Repeatedly merge sublists to produce new sorted sublists until there is only 1 sublist remaining. This will be the sorted list.

            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(myList, left, mid);
                MergeSort(myList, mid + 1, right);

                DoMerge(myList, left, mid + 1, right);
            }
        }

        /// <summary>
        /// Merge sort method.
        /// </summary>
        /// <param name="myList">List for sorting.</param>
        /// <param name="left">Left border.</param>
        /// <param name="mid">Mid of the list.</param>
        /// <param name="right">Right border.</param>
        public static void DoMerge(MyList myList, int left, int mid, int right)
        {
            int[] temp = new int[myList.Count];
            int i, left_end, num_elements, tmp_pos;

            left_end = mid - 1;
            tmp_pos = left;
            num_elements = right - left + 1;

            while ((left <= left_end) && (mid <= right))
            {
                if (myList.GetNode(left).Value <= myList.GetNode(mid).Value)
                {
                    temp[tmp_pos++] = myList.GetNode(left).Value;
                    left++;
                }
                else
                {
                    temp[tmp_pos++] = myList.GetNode(mid).Value;
                    mid++;
                }
            }

            while (left <= left_end)
            {
                temp[tmp_pos++] = myList.GetNode(left).Value;
                left++;
            }

            while (mid <= right)
            {
                temp[tmp_pos++] = myList.GetNode(mid).Value;
                mid++;
            }

            for (i = 0; i < num_elements; i++)
            {
                myList.GetNode(right).Value = temp[right];
                right--;
            }
        }

        /// <summary>
        /// Quick sort.
        /// </summary>
        /// <param name="myList">List for sorting.</param>
        /// <param name="left">Left border.</param>
        /// <param name="right">Right border.</param>
        public static void QuickSort(MyList myList, int left, int right)
        {
            // For Recusrion
            if (left < right)
            {
                int pivot = Partition(myList, left, right);

                if (pivot > 1)
                {
                    QuickSort(myList, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    QuickSort(myList, pivot + 1, right);
                }
            }
        }

        /// <summary>
        /// Quick sort sorting.
        /// </summary>
        /// <param name="myList">List for sorting.</param>
        /// <param name="left">Left border.</param>
        /// <param name="right">Right border.</param>
        /// <returns>Returns new border.</returns>
        public static int Partition(MyList myList, int left, int right)
        {
            //// 1. Pick an element, called a pivot, from the array.
            //// 2. Reorder the array so that all elements with values less than the pivot come before the pivot, while all elements with values greater than the pivot come after it 
            //// (equal values can go either way). After this partitioning, the pivot is in its final position.This is called the partition operation.
            //// 3. Recursively apply the above steps to the sub-array of elements with smaller values and separately to the sub-array of elements with greater values.
            //// The base case of the recursion is arrays of size zero or one, which never need to be sorted.

            Node nodeLeft = myList.GetNode(left);
            Node nodeRight = myList.GetNode(right);

            int pivot = nodeLeft.Value;

            while (true)
            {
                while (nodeLeft.Value < pivot)
                {
                    nodeLeft = nodeLeft.Next;
                    left++;
                }

                while (nodeRight.Value > pivot)
                {
                    nodeRight = nodeRight.Previous;
                    right--;
                }

                if (nodeRight.Value == pivot && nodeLeft.Value == pivot)
                {
                    nodeLeft = nodeLeft.Next;
                    left++;
                }

                if (left < right)
                {
                    int temp = nodeRight.Value;
                    nodeRight.Value = nodeLeft.Value;
                    nodeLeft.Value = temp;
                }
                else
                {
                    return right;
                }

                //// int pivot = list[left];

                //// while (true)
                //// {
                ////    while (list[left] < pivot)
                ////    {
                ////        left++;
                ////    }

                ////    while (list[right] > pivot)
                ////    {
                ////        right--;
                ////    }

                ////    if (left < right)
                ////    {
                ////        int temp = list[right];
                ////        list[right] = list[left];
                ////        list[left] = temp;
                ////    }
                ////    else
                ////    {
                ////        return right;
                ////    }
                //// }
            }
        }

        /// <summary>
        /// Selection sort.
        /// </summary>
        /// <param name="myList">List for sorting.</param>
        public static void SelectionSort(MyList myList)
        {
            // Iterate through all numbers.
            for (int i = 0; i < myList.Count; i++)
            {
                // Min will contain the smallest number starting at the index i.
                int min = i;

                // Get next node.                
                Node node = myList.GetNode(i + 1);
                Node mind = myList.GetNode(i);

                for (int j = i + 1; j < myList.Count; j++)
                {
                    // Find the smallest number.
                    if (node.Value < mind.Value)
                    {
                        min = j;
                        mind = myList.GetNode(min);
                    }

                    node = node.Next;
                }

                node = myList.GetNode(i);
                mind = myList.GetNode(min);

                // Change index i with the smallest number.
                int tmp = mind.Value;
                mind.Value = node.Value;
                node.Value = tmp;

                // 64 25 12 22 11 // this is the initial, starting state of the array
                // 11 25 12 22 64 // sorted sublist = {11}
                // 11 12 25 22 64 // sorted sublist = {11, 12}
                // 11 12 22 25 64 // sorted sublist = {11, 12, 22}
                // 11 12 22 25 64 // sorted sublist = {11, 12, 22, 25}
                // 11 12 22 25 64 // sorted sublist = {11, 12, 22, 25, 64}

                //// for (int i = 0; i < feld.Count; i++)
                //// {
                ////    // Min will contain the smallest number starting at the index i.
                ////    int min = i;

                ////    for (int j = i + 1; j < feld.Count; j++)
                ////    {
                ////        if (feld[j] < feld[min])
                ////        {
                ////            min = j;
                ////        }
                ////    }

                ////    // Change index i with the smallest number.
                ////    int tmp = feld[min];
                ////    feld[min] = feld[i];
                ////    feld[i] = tmp;
                //// }
            }
        }

        /// <summary>
        /// Shell sort.
        /// </summary>
        /// <param name="myList">List for sorting.</param>
        public static void ShellSort(MyList myList)
        {
            //// This is the most efficient of the O(n2) class of sorting algorithms.It is also the most complex amoung them. Known as the comb sort, it makes multiple passes through the 
            //// list, and each time sorts a number of equally sized sets using the insertion sort.The size of the set to be sorted gets larger with each pass through the list, until the set 
            //// consists of the entire list. It is efficient for medium size lists, but somewhat compelx.It is also not nearly as efficient as the merge, heap, and quick sorts.

            int i, j, increment, temp;
            increment = myList.Count / 3;

            while (increment > 0)
            {
                for (i = 0; i < myList.Count; i++)
                {
                    j = i;
                    temp = myList.GetNode(i).Value;

                    while ((j >= increment) && (myList.GetNode(j - increment).Value > temp))
                    {
                        myList.GetNode(j).Value = myList.GetNode(j - increment).Value;
                        j = j - increment;
                    }

                    myList.GetNode(j).Value = temp;
                }

                if (increment / 2 != 0)
                {
                    increment = increment / 2;
                }
                else if (increment == 1)
                {
                    increment = 0;
                }
                else
                {
                    increment = 1;
                }
            }

            //// The method starts by sorting pairs of elements far apart from each other, then progressively reducing the gap between elements to be compared

            //// int i, j, increment, temp;
            //// increment = 3;

            //// while (increment > 0)
            //// {
            ////    for (i = 0; i < numbers.Count; i++)
            ////    {
            ////        j = i;
            ////        temp = numbers[i];

            ////        while ((j >= increment) && (numbers[j - increment] > temp))
            ////        {
            ////            numbers[j] = numbers[j - increment];
            ////            j = j - increment;
            ////        }

            ////        numbers[j] = temp;
            ////    }

            ////    if (increment / 2 != 0)
            ////    {
            ////        increment = increment / 2;
            ////    }
            ////    else if (increment == 1)
            ////    {
            ////        increment = 0;
            ////    }
            ////    else
            ////    {
            ////        increment = 1;
            ////    }
            //// }
        }

        /// <summary>
        /// Tree sort.
        /// </summary>
        /// <param name="myList">List for sorting.</param>
        /// <returns>Sorted list.</returns>
        public static MyList TreeSort(MyList myList)
        {
            Tree tree = new Tree(myList);
            MyList output = new MyList(myList.Name);
            tree.Sort(tree.Root, output);

            return output;
        }
    }
}