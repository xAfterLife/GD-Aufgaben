using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Battle
    {
        private Player player;
        private Monster monster;
        private int counter;
        private int round;

        public Battle(Player player, int round)
        {
            this.player = player;
            this.counter = 0;
            this.round = round;

            //Generiere ein Monster basierend auf der Runde
            this.monster = GenerateMonster(round);

            //Starte kampf
            StartBattle();
        }

        private Monster GenerateMonster(int round)
        {
            int monsterHealth = 10 + (round * 3);
            int monsterAttack = 5 + (round * 2);
            int monsterRewardGold = 5 + (round * 3);
            int monsterRewardXP = 10 + (round * 3);

            Monster monster = new Monster("Random", monsterHealth, monsterAttack, monsterRewardGold, monsterRewardXP);
            monster.Name = GetRandomMonsterName();

            return monster;
        }

        private string GetRandomMonsterName()
        {
            List<string> names = new List<string>()
            {
                "Schattenspinne", "Dunkelklaue", "Blutfresser", "Frostwächter", "Knochenbrecher",
                "Schattenwolf", "Nachtkriecher", "Flammengeist", "Schreckensbestie", "Giftklaue",
                "Sturmreiter", "Felsbiss", "Eisenkrieger", "Dornenschreiter", "Donnersturm",
                "Seelenjäger", "Felsbrecher", "Nebelkriecher", "Todeskriecher", "Zornklaue",
                "Schattengräber", "Geisterwolf", "Bluttrinker", "Düsterhorn", "Dämonenschwinge",
                "Klingenhund", "Flammenkralle", "Knochenhund", "Schattenschwinge", "Dunkelzahn"
            };

            Random random = new Random();
            int randomIndex = random.Next(names.Count);

            return names[randomIndex];
        }

        private void StartBattle()
        {
            bool fighting = true;

            Console.WriteLine($"Ein {monster.Name} taucht auf!\nRunde {round} beginnt!");
            
            while (fighting)
            {

            }
        }
    }
}
