using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{

    internal class Battle
    {
        const string space = "      ";
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
            int monsterHealth = 10 + (round * 2);
            int monsterAttack = 3 + (round / 2);
            int monsterRewardGold = 5 + (round * 2);
            int monsterRewardXP = 10 + (round * 2);

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

        public void StartBattle()
        {
            bool fighting = true;
            
            
            while (fighting)
            {
                Console.Clear();
                DrawSeperator();
                Console.WriteLine($"{space}Ein {monster.Name} taucht auf!\n{space}Runde {round} beginnt!");
                Thread.Sleep(2000);
                ShowPlayerMenu();

                Console.Write($"{space}Bitte wähle: ");
                if (int.TryParse(Console.ReadLine(), out int playerchoice))
                {
                    switch (playerchoice)
                    {
                        case 1:
                            DrawSeperator();
                            PlayerAttack(player.AttackPower);
                            Thread.Sleep(1000);
                            break;
                        case 2:
                            player.Heal(10 * round);
                            break;
                        case 3:
                            player.ShowPlayerInventory(player);
                            break;
                        case 4:
                            AttemptEscape(ref fighting);
                            break;
                        case 5:
                            Console.WriteLine($"{space}Wird gespeichert..");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine($"{space}Ungültige Eingabe..");
                            break;
                    }
                    if (monster.Health <= 0)
                    {
                        DrawSeperator();
                        Console.WriteLine($"{space}Du hast {monster.Name} besiegt!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{space}Du bekommst {monster.RewardXP} Erfahrung.");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{space}Du bekommst {monster.RewardGold} Gold.");
                        Console.ResetColor();
                        DrawSeperator();
                        player.GainExperience(monster.RewardXP);
                        player.Gold += monster.RewardGold;
                        round++;

                        Console.ReadKey();

                        monster = GenerateMonster(round);
                        
                    }
                    else if (player.Health <= 0)
                    {
                        DrawSeperator();
                        Console.WriteLine($"{space}Du wurdest von {monster.Name} besiegt.");
                        Console.WriteLine($"{space}Das Spiel ist vorbei.");
                        DrawSeperator();
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else
                    {
                        MonsterAttack(monster.AttackPower);
                        Thread.Sleep(2000);
                    }
                }
            }
        }

        private void ShowPlayerMenu()
        {
            DrawSeperator();
            ShowBattleStatus();
            DrawSeperator();
            Console.WriteLine($"{space}1. Angreifen");
            Console.WriteLine($"{space}2. Heilen");
            Console.WriteLine($"{space}3. Inventar");
            Console.WriteLine($"{space}4. Fliehen");
            Console.WriteLine($"{space}5. Speichern und Beenden");
            DrawSeperator();

        }

        private void ShowBattleStatus()
        {
            Console.WriteLine($"{space}Runde: {round}");
            Console.WriteLine($"{space}{player.Name}: {player.Health}/{player.MaxHealth}HP | {monster.Name}: {monster.Health}HP");
            Thread.Sleep(2000);
        }

        private void DrawSeperator()
        {
            Console.Write("+");
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");
        }
        private void PlayerAttack(int damage)
        {
            int totalDamage = player.Attack(damage);
            monster.Health -= totalDamage;
            Console.WriteLine($"{space}{player.Name} greift {monster.Name} an \n{space}und verursacht {totalDamage} Schaden!");
        }
        private void MonsterAttack(int damage)
        {
            int totalDamage = monster.Attack(damage);
            player.Health -= totalDamage;
            Console.WriteLine($"{space}{monster.Name} greift {player.Name} an und verursacht {totalDamage} Schaden!");
        }
        private void AttemptEscape(ref bool fighting)
        {

            Random random = new Random();

            int chance = random.Next(1, 101);

            if ( chance > 50 )
            {
                Console.WriteLine($"{space}Du bist geflohen.");
                fighting = false;
                
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{space}Die Flucht ist gescheitert.");
            }
        }
        

    }
}
