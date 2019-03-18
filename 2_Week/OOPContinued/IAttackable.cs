namespace OOPContinued
{
    public interface IDamageable
    {
        // what must damageable things contain?

        // hp!
        // some notion of taking damage

        int Health {get;set;}
        string Name {get;set;}
        int TakeDamage(int dmg);
    }
}