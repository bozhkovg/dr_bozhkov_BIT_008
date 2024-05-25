namespace ArenaGameEngine
{   
    public class GameEvent
    {
        public GameEventType EventType { get; }
        public Hero Attacker { get; }
        public Hero Defender { get; }
        public int Damage { get; }
        public Hero Winner { get; }
        public Hero Loser { get; }

        public GameEvent(GameEventType eventType, Hero attacker, Hero defender, int damage)
        {
            EventType = eventType;
            Attacker = attacker;
            Defender = defender;
            Damage = damage;
        }
        public GameEvent(GameEventType eventType, Hero winner, Hero loser)
        {
            EventType = eventType;
            Winner = winner;
            Loser = loser;
        }
    }
    public enum GameEventType
    {
        Round,
        BattleEnd
    }
    public interface IGameEventListener
    {
        void OnGameEvent(GameEvent gameEvent);
    }
    public class GameEventListener : IGameEventListener
    {
        public virtual void OnGameEvent(GameEvent gameEvent)
        {
            // Разширих яснотата за случващото се в двубоя, като добавих оставащото здраве на героят поел щета
            switch (gameEvent.EventType)
            {
                case GameEventType.Round:
                    Console.WriteLine($"{gameEvent.Attacker.Name} hit {gameEvent.Defender.Name} for {gameEvent.Damage} damage!");

                    if (gameEvent.Defender.IsAlive)
                    {
                        Console.WriteLine($"    {gameEvent.Defender.Name} has {gameEvent.Defender.Health} health remaining.");
                    }
                    else
                    {
                        Console.WriteLine($"    {gameEvent.Defender.Name} has been defeated!");
                    }
                    break;

                case GameEventType.BattleEnd:
                    Console.WriteLine($"\nBattle ended. Winner is: {gameEvent.Winner.Name}\n");
                    break;
            }
        }
    }
}
