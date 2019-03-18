using System;

namespace OOPContinued.Heroes
{
    public class Rouge : Hero
    {
        public Rouge(string name) : base(name) {}
        public override void Greeting()
        {
            Console.WriteLine("Now you see me, now you don't");
        }
        // Area of Effect attack
        public void AttackMany(IDamageable[] targets)
        {
            Greeting();
            foreach(var t in targets)
            {
                int reduced = t.TakeDamage(10);
                Console.WriteLine($"{t.Name} reduced to {reduced}");
            }
        }
    }
}