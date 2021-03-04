using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson_3_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    

    public struct DoublePointStruct
    {
        public double X;
        public double Y;
    }
    public struct FloatPointStruct
    {
        public float X;
        public float Y;
    }
    public class FloatPointClass
    {
        public float X;
        public float Y;
    }
    
    public class BechmarkClass
    {
        public void FloatArray()
        {
            float[] floatArray = new float[50];
            Random rand = new Random(100);
            for (int i = 0; i < floatArray.Length; i++)
            {
                floatArray[i] = rand.Next();
            }
        }
        public double[] DoubleArray()
        {
            double[] doubleArray = new double[50];
            Random rand = new Random(100);
            for(int i = 0; i <doubleArray.Length; i++)
            {
                doubleArray[i] = rand.Next();
            }
            return doubleArray;
        }
        public int SumValueType(int value)
        {
            return 9 + value;
        }

        public int SumRefType(object value)
        {
            return 9 + (int)value;
        }


        public void TestSum()
        {
            SumValueType(99);
        }


        public void TestSumBoxing()
        {
            object x = 99;
            SumRefType(x);
        }

        static int GetRandom()
        {
            Random rnd = new Random(245);

            int value = rnd.Next();

            return value;
        }


        public static float PointDistanceFloatStruct(FloatPointStruct pointOne, FloatPointStruct pointTwo)
        {
            Random rnd = new Random(245);
            pointOne.X = rnd.Next();
            pointTwo.X = rnd.Next();
            pointOne.Y = rnd.Next();
            pointTwo.Y = rnd.Next();
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }


        public static double PointDistanceDoubleStruct(DoublePointStruct pointOne, DoublePointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public void TestDistanceDoubleStruct(DoublePointStruct pointOne, DoublePointStruct pointTwo)
        {
            for (int i = 0; i <= 5; i++)
            {
                var pointOneDouble = new DoublePointStruct() { X = DoubleArray(), Y = DoubleArray() };
                var pointTwoDouble = new DoublePointStruct() { X = DoubleArray(), Y = DoubleArray() };
                var res = PointDistanceDoubleStruct(pointOneDouble, pointTwoDouble);
                Console.WriteLine($"{res}");
            }
        }


        public static float PointDistanceShort(FloatPointStruct pointOne, FloatPointStruct pointTwo)
        {
            Random rnd = new Random(245);
            pointOne.X = rnd.Next();
            pointTwo.X = rnd.Next();
            pointOne.Y = rnd.Next();
            pointTwo.Y = rnd.Next();
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public static float PointDistanceFloatClass(FloatPointClass pointOne, FloatPointClass pointTwo)
        {
            Random rnd = new Random(245);
            pointOne.X = rnd.Next();
            pointTwo.X = rnd.Next();
            pointOne.Y = rnd.Next();
            pointTwo.Y = rnd.Next();
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        


    }

}

