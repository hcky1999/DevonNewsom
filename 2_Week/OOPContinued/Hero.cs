using System;
using System.Collections.Generic;

namespace OOPContinued.Heroes
{
    public abstract class Hero : IDamageable
    {
        public int Health {get; set;}
        public string Name {get;set;}
      
        public Hero(string name)
        {
            Name = name;
            Health = 100;
        }

        // Signature
        public abstract void Greeting();

        public virtual int TakeDamage(int dmg)
        {
            int newHealth = Health -= dmg;
            return newHealth;
        }

        public void Attack(IDamageable target, int amount)
        {
            Greeting();
            int reducedTo = target.TakeDamage(amount); 
            Console.WriteLine($"Target health reduced to {reducedTo}");
        }
    
    }

    

}