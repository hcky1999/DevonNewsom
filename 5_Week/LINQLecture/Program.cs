using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {834,2,-23,2,103,-5,42,-1,27};

            int sumOfNums = numbers.Sum();

            List<string> names = new List<string>
            {
                "Sharon", // 6
                "Charlie", // 7
                "Barbara", // 7
                "Molly",
                "Ashton",
                "Marcellus",
                "Molly",
                "Zeleg",
                "Yvonne",
                "Yoda",
                "Bob"
            };

            int[] oddNumbers = numbers.Where(num => num % 2 != 0).ToArray();

            // .Min() .Max() .Sum()
            int minNum = numbers.Min();

            // can overload with selector lambda
            int minNameLength = names.Min(name => name.Length); // 3

            // how might i get Bob?
            string bob = names.FirstOrDefault(name => name.Length == minNameLength);

            List<City> Cities = Place.GetCities();
            List<State> States = Place.GetStates();



            // Washington Cities
            List<City> WashingtonCities = Cities.Where(c => c.StateCode == "WA").ToList();
            int populationOfWashington = WashingtonCities.Sum(c => c.Population);


            // Most populated Washington City
            int highestPopulation = WashingtonCities.Max(c => c.Population);
            City largestWaCity = WashingtonCities.FirstOrDefault(c => c.Population == highestPopulation);

            // Most populated state?
            int highestStatePop = States.Max(s => s.Cities.Sum(c => c.Population));
            State largestState = States.FirstOrDefault(s => s.Cities.Sum(c => c.Population) == highestStatePop);
        }
    }
}
