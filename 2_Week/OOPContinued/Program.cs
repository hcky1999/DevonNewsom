using System;
using System.Collections.Generic;

using OOPContinued.Heroes;

namespace OOPContinued
{
    class Program
    {
        static void Main(string[] args)
        {
            Rouge mainHero = new Rouge("Sally");  
            Tank enemy = new Tank("Evil");

            Box b = new Box();
            Box b2 = new Box();

            mainHero.Attack(enemy, 20);
            mainHero.Attack(b, 20);

            IDamageable[] bout2getblasted = new IDamageable[]
            {
                enemy, b, b2
            };

            mainHero.AttackMany(bout2getblasted);

            // IEnumerbale stuff

            int[] numbers = new int[] {23, 25462, 2346};
            List<int> numberList = new List<int>() { 24, 56, 5456, 45};

            LoopThings(numberList);
            LoopThings(numbers);

        }

        static void LoopThings(IEnumerable<int> things)
        {
            foreach(var thing in things)
            {
                Console.WriteLine(thing);
            }
        }
       

    }
}
