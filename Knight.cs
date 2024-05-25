namespace ArenaGameEngine
{
    //- Has armor, which reduces the incoming damage between 20 and 60%.
    //- Every 5 hits can cause double damage.
    //  Шансовете специалните способности на героя да се активират са повишени.
    public class Knight : Hero
    {
        public Knight() : this("Sir John") //By default, all knights are named 'Sir John'
        {

        }

        public Knight(string name) : base(name) //A named knight, we supply the name
        {
            hitCount = 0;
        }

        private int hitCount;

        public override int Attack()
        {
            hitCount = hitCount + 1;
            int baseAttack = base.Attack();
            if (hitCount == 5)
            {
                baseAttack = baseAttack * 3;
                hitCount = 0;
            }
            return baseAttack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            int coef = Random.Shared.Next(40, 81);
            incomingDamage = incomingDamage - (coef * incomingDamage) / 100;
            base.TakeDamage(incomingDamage);
        }
    }
}
