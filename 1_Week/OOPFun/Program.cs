using System;
using OOPFun.CustomClasses;

namespace OOPFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Person newPerson = new Person("Devon", "Newsom", 100);
            Person otherPerson = new Person("Sally", "Sanderson", 39);

            Person bill = new Person(); 



            newPerson.SayHi();
            newPerson.SayHi("Yo");

        }
    }
}
