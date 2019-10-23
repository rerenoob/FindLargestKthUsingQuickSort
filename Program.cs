using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10] {9, 4, 1, 6, 3, 2, 8, 12, 7, 19};
            Print(array);
            int[] sortedArray = (int[])array.Clone();
            QuickSort(sortedArray, 0, array.Length - 1);
            Print(array);
            Console.WriteLine("Find Kth largest element:");
            string input = Console.ReadLine();
            while(input != "exit"){
                Console.WriteLine("With sorted array: ");
                Console.WriteLine(FindLargestKth((int[])sortedArray.Clone(), Convert.ToInt32(input)));
                Console.WriteLine("With unsorted array: ");
                Console.WriteLine(FindLargestKth((int[])array.Clone(), Convert.ToInt32(input)));
                Console.WriteLine("Find Kth largest element:");
                input = Console.ReadLine();
            }
        }

        static void Print(int[] array){
            foreach(var element in array){
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        static void QuickSort(int[] array, int low, int high){
            if (low < high){
                int pivot = Partition(array, low, high);

                QuickSort(array, low, pivot - 1);
                QuickSort(array, pivot + 1, high);
            }
        }

        static int Partition(int[] array, int low, int high){
            Console.WriteLine("Low: {0}, High: {1}", low, high);
            int pivot = array[high];
            int i = (low -1);

            for (int j=low; j <= high; j++){
                if (array[j] > pivot){
                    i++;
                    Swap(array, j, i);
                }
            }
            Swap(array, i + 1, high);
            return i+1;
        }

        static void Swap(int[] array, int x, int y){
            int temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }

        static int FindLargestKth(int[] array, int k){
            return QuickSelect(array, 0, array.Length - 1, k);
        }

        static int QuickSelect(int[] array, int low, int high, int k){
            if (low < high){
                int pivot = Partition(array, low, high);
                if (pivot + 1 == k){
                    return array[pivot];
                }
                if (pivot + 1 > k){
                    return QuickSelect(array, low, pivot - 1, k);
                }
                else{
                    return QuickSelect(array, pivot + 1, high, k);
                }
            } else if (low == high && low + 1 == k){
                return array[low];
            }
            return -1;
        }
    }
}
