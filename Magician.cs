namespace ArenaGameEngine
{
    // За да направя магьосникът по интересен и запомнящ се добавих точки мана специално за него.
    // Способностите му се базират на нея като му дават двойна атака при наличие на 30 мана в продължение на два хода.
    // Ако маната е по-малко от 30, тогава магьосникът я презарежда със 15 при всеки ход, докато отново не свърши.
    // Магьосниците могат и да създават щитове, но имплементацията на щит щеше да бъде прекалено близка до рицаря.
    public class Magician : Hero
    {
        public int Mana { get; private set; } = 100;
        public bool IsEmpowered { get; private set; } = false;
        public int EmpoweredTurns { get; private set; } = 0;

        public Magician(string name) : base(name) { }

        public override int Attack()
        {
            if (IsEmpowered)
            {
                EmpoweredTurns--;
                if (EmpoweredTurns == 0)
                    IsEmpowered = false;
                return base.Attack() * 2;
            }

            if (Mana >= 30)
            {
                Mana -= 30;
                IsEmpowered = true;
                EmpoweredTurns = 2;
                return base.Attack();
            }
            else
            {
                Mana += 15;
                return base.Attack();
            }
        }
        public override void TakeDamage(int incomingDamage)
        {
            base.TakeDamage(incomingDamage);
        }
    }
}