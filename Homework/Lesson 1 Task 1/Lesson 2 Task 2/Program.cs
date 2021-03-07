using System;

namespace Lesson_2_Task_2
{
    class Program
    {
        public static int BinarySearch(int[] inputArray, int searchValue, int first)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
        public class TestCase
        {
            public int input { get; set; }
            public string expected { get; set; }
        }
        //сложность алгоритма O(log n) Если массив отсортирован, 
        //мы можем проверить, есть ли в нём какое-то конкретное значение, 
        //методом деления пополам. Проверим средний элемент, если он больше искомого, 
        //то отбросим вторую половину массива — там его точно нет. Если же меньше, то наоборот — отбросим начальную половину. 
        //И так будем продолжать делить пополам, в итоге проверим log n элементов.
        static void Main(string[] args)
            {
            var arr = new int[5] { 3, 100, 19, 20, 1 };
            Array.Sort(arr);
            var searchvalue = 100;
            var searchResult = BinarySearch(arr, searchvalue, arr.Length - 1);
            Console.WriteLine($"{searchResult}, {searchvalue}");
        }
        }
    }

