using System;

namespace Lesson_1_Task_3
{
    class Program
    {
        static int FibRec(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return FibRec(n - 1) + FibRec(n - 2);
            }
        }

        static int FibCycle(int n)
        {
            int a = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < n; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }

            return a;
        }

        public class TestCase
        {
            public int input { get; set; }
            public string expected { get; set; }
        }
        static void Main(string[] args)
        {
            var testData = new TestCase[5];
            testData[0] = new TestCase()
            {
                input = 7,
                expected = "13"
            };

            testData[1] = new TestCase()
            {
                input = 9,
                expected = "34"
            };

            testData[2] = new TestCase()
            {
                input = 4,
                expected = "3"
            };
            ;
            testData[3] = new TestCase()
            {
                input = 10,
                expected = "55"
            };

            testData[4] = new TestCase()
            {
                input = 1,
                expected = "1"
            };
            foreach (var TestCase in testData)
            {
                var result = FibRec(TestCase.input);
                Console.WriteLine($"{TestCase.input} Actual {result}, Expected {TestCase.expected}\n");
            }
            foreach (var TestCase in testData)
            {
                var result = FibCycle(TestCase.input);
                Console.WriteLine($"{TestCase.input} Actual {result}, Expected {TestCase.expected}\n");
            }
        }
    }
}