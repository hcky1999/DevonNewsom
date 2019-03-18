using System;

namespace OOPContinued.Heroes
{
    public class Tank : Hero
    {
        public Tank(string name) : base(name)
        {
            Health = 150;
        }

        public override void Greeting()
        {
            Console.WriteLine("Grr, I am STRONG!");
        }

        public override int TakeDamage(int dmg)
        {
            // tank takes 5 units of damgage less
            Console.WriteLine("I am a tank, taking damage");
            dmg -= 5;
            int damgageRecuction = Health -= dmg;
            return damgageRecuction;
        }


    }

}