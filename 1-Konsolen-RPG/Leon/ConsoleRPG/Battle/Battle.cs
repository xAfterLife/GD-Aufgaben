using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Characters;

namespace ConsoleRPG.Battle
{

    internal class Battle
    {
        const string space = "      ";
        private Player player;
        private Monster monster;
        public Battle(Player player)
        {
            this.player = player;

            //Generiere ein Monster basierend auf der Runde
            monster = GenerateMonster(player.Round);

            //Starte kampf
            StartBattle();
        }

        private Monster GenerateMonster(int round)
        {
            int monsterHealth = 10 + round * 2;
            int monsterAttack = 3 + round / 2;
            int monsterRewardGold = 5 + round * 2;
            int monsterRewardXP = 10 + round * 2;

            Monster monster = new Monster("Random", monsterHealth, monsterAttack, monsterRewardGold, monsterRewardXP);
            monster.Name = GetRandomMonsterName();

            return monster;
        }

        private string GetRandomMonsterName()
        {
            List<string> names = new List<string>()
            {
                "Schattenspinner", "Dunkelklauer", "Blutfresser", "Frostwächter", "Knochenbrecher",
                "Schattenwolf", "Nachtkriecher", "Flammengeist", "Schreckensbestie", "Giftklauer",
                "Sturmreiter", "Felsbiss", "Eisenkrieger", "Dornenschreiter", "Donnersturm",
                "Seelenjäger", "Felsbrecher", "Nebelkriecher", "Todeskriecher", "Zornklauer",
                "Schattengräber", "Geisterwolf", "Bluttrinker", "Düsterhorn", "Dämonenschwinger",
                "Klingenhund", "Flammenkralle", "Knochenhund", "Schattenschwinger", "Dunkelzahn"
            };

            Random random = new Random();
            int randomIndex = random.Next(names.Count);

            return names[randomIndex];
        }

        public void StartBattle()
        {
            Console.Clear();
            bool fighting = true;
            int times = 0;

            while (fighting)
            {
                Console.Clear();
                if (times < 1)
                {
                    DrawSeperator();
                    Console.WriteLine($"{space}Ein {monster.Name} taucht auf!\n{space}Runde {player.Round} beginnt!");
                    times++;
                    Thread.Sleep(2000);
                }

                ShowPlayerMenu();
                Console.Write($"{space}Bitte wähle: ");
                if (int.TryParse(Console.ReadLine(), out int playerchoice))
                {
                    switch (playerchoice)
                    {
                        case 1:
                            DrawSeperator();
                            PlayerAttack(player.AttackPower);
                            DrawSeperator();
                            Thread.Sleep(1000);
                            break;
                        case 2:
                            player.Heal(10 * player.Round);
                            break;
                        case 3:
                            player.ShowPlayerInventory();
                            break;
                        case 4:
                            AttemptEscape(ref fighting);
                            if (!fighting) return;  // Sofortiges Beenden der Methode, wenn die Flucht erfolgreich ist
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
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{space}Du bekommst {monster.RewardGold} Gold.");
                        Console.ResetColor();
                        DrawSeperator();

                        player.GainExperience(monster.RewardXP);
                        player.Gold += monster.RewardGold;
                        player.Round++;

                        Console.ReadKey();
                        times = 0;
                        monster = GenerateMonster(player.Round);
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
                    else if (fighting)
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
            Console.WriteLine($"{space}Runde: {player.Round}");
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
            int totalDamage = damage;

            // Wenn der Spieler eine Waffe hat, füge deren Angriffskraft zur Berechnung hinzu
            if (player.CurrentWeapon != null)
            {
                totalDamage += player.CurrentWeapon.AttackPower;
            }

            totalDamage = player.Attack(totalDamage);
            monster.Health -= totalDamage;


            if (player.CurrentWeapon != null)
            {
                Console.WriteLine($"{space}{player.Name} greift {monster.Name}");
                Console.WriteLine($"{space}mit {player.CurrentWeapon.Name} und verursacht {totalDamage} Schaden!");
            }
            else
            {
                Console.WriteLine($"{space}{player.Name} greift {monster.Name} an ");
                Console.WriteLine($"{space}und verursacht {totalDamage} Schaden!");
            }
        }


        private void MonsterAttack(int damage)
        {
            int totalDamage = monster.Attack(damage);
            player.Health -= totalDamage;
            Console.WriteLine($"{space}{monster.Name} greift {player.Name} an \n{space}und verursacht {totalDamage} Schaden!");
            DrawSeperator();
        }
        private void AttemptEscape(ref bool fighting)
        {
            Random random = new Random();
            int chance = random.Next(1, 101);

            if (chance > 20)  // 80% Fluchtchance
            {
                Console.WriteLine($"{space}Du bist erfolgreich geflohen.");
                fighting = false;  // Setzt fighting sofort auf false
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"{space}Die Flucht ist gescheitert.");
            }
        }



    }
}
