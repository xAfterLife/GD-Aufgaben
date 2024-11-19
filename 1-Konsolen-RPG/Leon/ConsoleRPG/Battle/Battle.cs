using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Characters;
using ConsoleRPG.Utilities;

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
            this.monster = MonsterFactory.GenerateMonster(player.Round);
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
                    DisplayHelper.DrawSeparator();
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
                            PlayerAttack(player.AttackPower);
                            DisplayHelper.DrawSeparator();
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
                            if (!fighting)
                            {
                                Thread.Sleep(1000);
                                return; // Beende die Methode
                            }
                            break;

                        case 5:
                            Console.WriteLine($"{space}Wird gespeichert..");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine($"{space}Ungültige Eingabe..");
                            break;
                    }

                    // Monster besiegen
                    if (monster.Health <= 0)
                    {
                        DisplayHelper.DrawSeparator();
                        Console.WriteLine($"{space}Du hast {monster.Name} besiegt!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{space}Du bekommst {monster.RewardXP} Erfahrung.");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{space}Du bekommst {monster.RewardGold} Gold.");
                        Console.ResetColor();
                        DisplayHelper.DrawSeparator();

                        player.GainExperience(monster.RewardXP);
                        player.Gold += monster.RewardGold;
                        player.Round++;

                        Console.ReadKey();
                        times = 0;
                        monster = MonsterFactory.GenerateMonster(player.Round);
                    }
                    // Spieler stirbt
                    else if (player.Health <= 0)
                    {
                        Console.WriteLine($"{space}Du wurdest von {monster.Name} besiegt.");
                        Console.WriteLine($"{space}Das Spiel ist vorbei.");
                        DisplayHelper.DrawSeparator();
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    // Monster greift an
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
            DisplayHelper.ShowBattleStatus(player, monster, player.Round);
            DisplayHelper.DrawSeparator();
            Console.WriteLine($"{space}1. Angreifen");
            Console.WriteLine($"{space}2. Heilen");
            Console.WriteLine($"{space}3. Inventar");
            Console.WriteLine($"{space}4. Fliehen");
            Console.WriteLine($"{space}5. Speichern und Beenden");
            DisplayHelper.DrawSeparator();
        }
        private void PlayerAttack(int baseDamage)
        {
            int totalDamage = baseDamage;

            // Wenn der Spieler eine Waffe hat, füge deren Angriffskraft nur temporär hinzu
            if (player.CurrentWeapon != null)
            {
                totalDamage += player.CurrentWeapon.AttackPower;
            }

            // Angriff ausführen und den Schaden anwenden
            totalDamage = player.Attack(totalDamage);
            monster.Health -= totalDamage;

            // Ausgabe des Angriffs
            DisplayHelper.DrawSeparator();
            if (player.CurrentWeapon != null)
            {
                Console.WriteLine($"{space}{player.Name} greift {monster.Name}");
                Console.WriteLine($"{space}mit {player.CurrentWeapon.Name} an und verursacht {totalDamage} Schaden!");
            }
            else
            {
                Console.WriteLine($"{space}{player.Name} greift {monster.Name} an");
                Console.WriteLine($"{space}und verursacht {totalDamage} Schaden!");
            }
        }
        private void MonsterAttack(int damage)
        {
            int totalDamage = monster.Attack(damage);
            player.Health -= totalDamage;
            Console.WriteLine($"{space}{monster.Name} greift {player.Name} an \n{space}und verursacht {totalDamage} Schaden!");
            DisplayHelper.DrawSeparator();
        }
        private void AttemptEscape(ref bool fighting)
        {
            Random random = new Random();
            int chance = random.Next(1, 101);

            if (chance > 10)  // 90% Fluchtchance
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
