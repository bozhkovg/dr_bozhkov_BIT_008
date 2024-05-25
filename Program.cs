using ArenaGameEngine;
namespace ArenaGameConsole
{
    class ConsoleGameEventListener : GameEventListener
    {
        public override void OnGameEvent(GameEvent gameEvent)
        // Извиквам готовият метод, който принтира резултатите от битката
        {
            base.OnGameEvent(gameEvent);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Даваме имена на героите
            Hero[] heroes = {
                new Knight("Sir John"),
                new Rogue("Slim Shady"),
                new Magician("Magician Lucian"),
                new Orc("Orc Ragnaroc")
            };

            // Създавам нова инстанция на Arena и подавам масива heroes като параметър
            Arena arena = new Arena(heroes);

            // Създавам нова инстанция на ConsoleGameEventListener, чиято цел е дава яснота за случващото се в двубоя.
            arena.EventListener = new ConsoleGameEventListener();

            // Извиквам метод StartTournament на обект arena. ОСНОВА за провеждане на двубоите.
            Hero champion = arena.StartTournament();

            // Конзолата изписва шампионът.
            Console.WriteLine($"{champion.Name} is the champion!");

            /* Попречва на конзолата да се затвори автоматично, 
            ако потребителя е избрал конзолата автоматично да се затваря след debug */
            Console.ReadLine();
        }
    }
}