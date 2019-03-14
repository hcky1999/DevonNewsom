
using System;

namespace OOPFun.CustomClasses
{
    class Person
    {
        private string firstName;
        private string lastName;
        public int age {get;set;}

        // constructor
        public Person(string _firstName, string _lastName, int _age)
        {
            firstName = _firstName;
            lastName = _lastName;
            age = _age;
        }

        public Person()
        {
            firstName = "Bill";
            lastName = "Gates";
            age = 75;
        }

        // Property
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                // newPerson.FirstName = "LOL"
                // value => "LOL"
                if(value != "Moose")
                    firstName = value;
            }
        }

        public string FullName
        {
            get
            {
                return $"{firstName} {lastName}";
            }
        }

        public void SayHi()
        {
            Console.WriteLine($"Hi, my name is {FullName}");
        }

        public void SayHi(string greeting)
        {
            Console.WriteLine($"{greeting}, my name is {FullName}");
        }
    }

    class Programmer : Person
    {
        // all Progammers are named Bill Gates
        public int TypingSpeed;
        public Programmer(int speed, string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            TypingSpeed = speed;
        }
    }
}