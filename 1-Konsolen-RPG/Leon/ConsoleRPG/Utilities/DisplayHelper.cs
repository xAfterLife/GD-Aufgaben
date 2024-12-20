﻿using ConsoleRPG.Characters;
using ConsoleRPG.Items;
using ConsoleRPG.Battle;
using ConsoleRPG.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRPG.Utilities
{
    public static class DisplayHelper
    {
        public static void DrawSeparator()
        {
            Console.Write("+");
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");
        }

        public static void ShowWeaponWithColor(int index, Weapon weapon, int cost)
        {
            Console.Write($"{index}. {weapon.Name.PadRight(20)} - Seltenheit: ");

            switch (weapon.WeaponRarity)
            {
                case Rarity.Common:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case Rarity.Uncommon:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case Rarity.Rare:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Rarity.Epic:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case Rarity.Legendary:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
            }
            Console.Write($"{weapon.WeaponRarity.ToString().PadRight(10)}");
            Console.ResetColor();

            Console.Write(" - Kosten: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{cost} Gold".PadRight(12));
            Console.ResetColor();

            Console.Write(" - Angriffskraft: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{weapon.AttackPower}");
            Console.ResetColor();

            Console.WriteLine();
        }

        public static void ShowBattleStatus(Player player, Monster monster, int round)
        {
            const string space = "      ";
            DrawSeparator();
            Console.WriteLine($"{space}Runde: {round}");
            Console.WriteLine($"{space}{player.Name}: {player.Health}/{player.MaxHealth} HP | {monster.Name}: {monster.Health} HP");
        }
    }
}
