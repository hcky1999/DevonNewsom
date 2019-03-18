namespace OOPContinued
{
    public class Box : IDamageable
    {
        public int Health {get;set;} = 50;
        public string Name {get;set;} = "Box";
        public int TakeDamage(int dmg)
        {
            int reduced = Health -= dmg;
            return reduced;
        }
    }
}