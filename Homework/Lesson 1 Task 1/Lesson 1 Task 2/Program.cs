using System;

namespace Lesson_1_Task_2
{
    class Program
    {
        public static int StrangeSum(int[] inputArray) //O(1)
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++) //O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) //O(N)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y; //O(1) Стоит ли считать за O(1)???
                    }
                }
            }

            return sum;
        }
        //Итоговая сложность алгоритма равна O(N^3)

        static void Main(string[] args)
        {
            var result = StrangeSum(new int[] { 2, 2 });
            Console.WriteLine(result);

        }
    }
}