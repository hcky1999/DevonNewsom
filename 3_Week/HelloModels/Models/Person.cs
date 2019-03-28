using System;
using System.Collections.Generic;

namespace HelloModels.Models
{
    public class Person
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Location {get;set;}
        public DateTime DOB {get;set;}

        public int Age 
        {
            get { return (DateTime.Now - DOB).Days / 365; }
        }
    }
    public class ComplexViewModel
    {
        public List<Person> People {get;set;}
        public Person OnePerson {get;set;}
        public Dog OneDog {get;set;}
        public int[] Numbers {get;set;}
    }

    public class Dog
    {

    }
}