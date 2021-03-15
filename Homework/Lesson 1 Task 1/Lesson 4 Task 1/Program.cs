using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;

namespace Lesson_4_Task_1
{
    class Program
    { 
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class BenchTest
    {
        public static HashSet<string> hashSet = new HashSet<string>();
        public static string[] RandomArr = FillArray(10000, hashSet);

        public static string[] FillArray(int count, HashSet<string> hashSet)
        {
            string[] rndArray = new string[count];
            for (int i = 0; i < rndArray.Length; i++)
            {
                string randomString = GetRandomString(11);
                rndArray[i] = randomString;
                hashSet.Add(randomString);
            }
            return rndArray;
        }
        [Benchmark]
        public void SearchStringInArray()
        {
            string searchString = "HelloWorld";
            for (int i = 0; i < RandomArr.Length; i++)
            {
                if (RandomArr[i] == searchString)
                {
                    return;
                }
            }
        }
        [Benchmark]
        public void SearchStringInHashSet()
        {
            string searchString = "HelloWorld";
                if (hashSet.Contains(searchString))
                {
                    return;
                } 
        }
        public static string GetRandomString(int lenghtString)
        {
            string randomString = "";
            Random rnd = new Random();
            for (int i = 0; i < lenghtString; i++)
            {
                char tmpChar = (char)rnd.Next(0, 255);
                randomString += tmpChar;
            }
            return randomString;
        }
    }
}
