namespace ArenaGameEngine
{
    // Оркът започва с повишени стойности за здраве и сила.
    // Когато здравето му е по-малко от 1/3 от първоначалното му, той се ядосва.
    // Когато се ядоса силата му се удвоява.
    public class Orc : Hero
    {
        private int initialHealth;
        public bool isEnraged { get; private set; } = false;

        public Orc(string name) : base(name)
        {
            Health = 810;
            initialHealth = Health;
            Strength = 100;
        }

        public override void TakeDamage(int incomingDamage)
        {
            base.TakeDamage(incomingDamage);
            if (!isEnraged && Health <= initialHealth / 2)
            {
                Console.WriteLine($"{Name} becomes enraged!");
                isEnraged = true;
            }
        }
        public void BloodlustStrike()
        {
            if (isEnraged)
            {
                int damage = Strength * 2;
            }
        }
    }
}