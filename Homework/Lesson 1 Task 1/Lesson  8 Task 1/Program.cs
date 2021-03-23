using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson_8_Task_1
{
    class Program
    {
        public static void BucketSort(ref int[] items, int n)
        {
            //Поиск элементов с минимальным и максимальным значением
            int maxValue = items[0];
            int minValue = items[0];

            for (int i = 1; i < items.Length; i++)
            {
                if (items[i] > maxValue)
                    maxValue = items[i];

                if (items[i] < minValue)
                    minValue = items[i];
            }
            //Создаем пустые ведра 
            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }
            //Заносим значения в ведра
            for (int i = 0; i < items.Length; i++)
            {
                bucket[items[i] - minValue].Add(items[i]);
            }

            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        items[position] = bucket[i][j];
                        position++;
                    }
                }
            }
        }
        public static void Main()
        {
            int[] items = new int[] { 1, 25, 11, 53, 68, 4, 39, 9, 12, 33, 11, 94, 43 };
            int n = items.Length;
            BucketSort(ref items, n);
            foreach (int el in items)
            {
                Console.WriteLine(el + "");
            }
        }
    }
}
