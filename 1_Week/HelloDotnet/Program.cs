using System;
using System.Collections.Generic;

namespace HelloDotnet
{
    class Program
    {
        // Entry Point
        static void Main(string[] args)
        {
            int number = 5;
            int num = 10;

            string name = "dojo";

            // array of ints
            int[] numbers = new int[10];
            int[] otherNumbers = new int[] { 13, 24, -1, 2499, 19 };

            // List
            List<string> names = new List<string>() { "Alex", "Deepika", "Yale" };
            names.Add("Devon");
            names.Add("Todd");


            // whats inside of names??
            for(int i = 0; i < names.Count; i++)
            {
                // numbers[10]
                Console.WriteLine(names[i]);
            }

            double result = AverageArray(otherNumbers);
            
        }

        // TODO: Average array values
        static double AverageArray(int[] array)
        {
            double avg = 0;
            // TODO: find sum of array values
            int sum = 0;

            // TODO: loop through array
            foreach(int num in array)
            {
                sum += num;
            }

            avg = sum / (double)array.Length;

            return avg;
        }
    }
}
