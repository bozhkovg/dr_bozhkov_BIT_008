namespace ArenaGameEngine
{
    public class Arena
    {
        private Hero[] participants; 
        // Масив, който да съдържа всички герои

        private int currentRoundSize;
        // Променлива, която да съдържа оцелелите герои

        private Random rng = new Random();
        // Използвам готовият клас Random, за да разбърквам рада на героите в метод RandomizeParticipants
        public IGameEventListener EventListener { get; set; }

        public Arena(Hero[] heroes) // Конструктор, който да инициализира 
        {
            participants = heroes;
            currentRoundSize = heroes.Length;
        }
        public void SetHeroes(Hero a, Hero b)
        {
            HeroA = a;
            HeroB = b;
        }
        public Hero HeroA { get; private set; }
        // Достъп за четене на двата героя, които участват в двубоя
        public Hero HeroB { get; private set; }

        public Hero Battle()
        {
            // Дават се роли на героите, при началото на двубоя
            Hero attacker = HeroA;
            Hero defender = HeroB;

            while (true)
            {
                int damage = attacker.Attack();

                defender.TakeDamage(damage);

                if (EventListener != null)
                {
                    EventListener.OnGameEvent(new GameEvent(eventType: GameEventType.Round, attacker: attacker, defender: defender, damage: damage));
                }
                if (defender.IsDead)
                {
                    if (EventListener != null)
                    {
                        EventListener.OnGameEvent(new GameEvent(eventType: GameEventType.BattleEnd, winner: attacker, loser: defender));
                    }
                    return attacker;
                }
                (attacker, defender) = (defender, attacker);
            }
        }
        public Hero StartTournament()
        // Основната логика на играта, за провеждане на двубоите
        {
            while (currentRoundSize > 1)
            {
                RandomizeParticipants();
                Hero[] nextRoundWinners = new Hero[currentRoundSize / 2];
                for (int i = 0; i < currentRoundSize; i += 2)
                {
                    SetHeroes(participants[i], participants[i + 1]);
                    nextRoundWinners[i / 2] = Battle();
                }
                participants = nextRoundWinners;
                currentRoundSize /= 2;
            }
            return participants[0];
        }
        private void RandomizeParticipants() 
        // Метод, чиято функция е да разменя героите при всяко пускане на играта
        {
            int n = participants.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (participants[k], participants[n]) = (participants[n], participants[k]);
            }
        }
    }
}