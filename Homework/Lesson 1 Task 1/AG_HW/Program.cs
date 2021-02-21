using System;

namespace AG_HW
{ 
 class Program
{ 
    
        public static string OddCheck(int n)
    {
        string result;
        var d = 0;
        var i = 2;
        while (i < n)
        {
            if (n % i == 0)
            {
                d++;
                i++;
            }
            else
            {
                i++;
            }
        }
        if (d == 0)
        {
            result = "Простое";
        }
        else
        {
            result = "Не простое";
        }
        return result;
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
            input = 1,
            expected = "Простое"
        };

        testData[1] = new TestCase()
        {
            input = 3,
            expected = "Простое"
        };

        testData[2] = new TestCase()
        {
            input = 141,
            expected = "Не простое"
        };
        ;
        testData[3] = new TestCase()
        {
            input = 19,
            expected = "Простое"
        };

        testData[4] = new TestCase()
        {
            input = 6,
            expected = "Не простое"
        };


        foreach (var TestCase in testData)
        {
            var result = OddCheck(TestCase.input);
            Console.WriteLine($"{TestCase.input} Actual {result}, Expected {TestCase.expected}");
        }


    }
}
}

