using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;

namespace Lesson_3_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
        
    }
    public struct PointStruct
    {
        public float X;
        public float Y;
    }
    public struct DoublePointStruct
    {
        public double X;
        public double Y;
    }
    public class PointClass
    {
        public float X;
        public float Y;
    }
    
    public class BechmarkClass
    {
        
        public double[] Doublearray()
        {
            double[] doubleArray = new double[10];
            {
                Random rnd = new Random(100);
                for (int i = 0; i < doubleArray.Length; i++)
                {
                    doubleArray[i] = rnd.Next(0, 100);
                }
                return doubleArray;
            }
        }
        static DoublePointStruct PointA = new DoublePointStruct() { X = 43.4343, Y = 42.4343 };
        static DoublePointStruct PointB = new DoublePointStruct() { X = 33.1232, Y = 21.343432 };

        static PointStruct FloatPointA = new PointStruct() { X = 423.4354543f, Y = 142.4343f };
        static PointStruct FloatPointB = new PointStruct() { X = 332.1232f, Y = 221.34345432f };

        static PointClass ClassPointA = new PointClass() { X = 423.4354543f, Y = 142.4343f };
        static PointClass ClassPointB = new PointClass() { X = 332.1232f, Y = 221.34345432f };

        public static float PointDistanceFloatStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public void TestDistanceFloatStruct()
        {
            PointDistanceFloatStruct(FloatPointA, FloatPointB);

        }
        public static double PointDistanceDoubleStruct(DoublePointStruct pointOne, DoublePointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public void TestDistanceDoubleStruct()
        {
                PointDistanceDoubleStruct(PointA, PointB);
                
        }
        public static float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
        [Benchmark]
        public void TestDistanceShort()
        {
            PointDistanceShort(FloatPointA, FloatPointB);

        }

        public static float PointDistanceFloatClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public void TestDistanceFloatClass()
        {
            PointDistanceFloatClass(ClassPointA, ClassPointB);

        }
    }
}

