using ConsoleRPG.Characters;
using ConsoleRPG.Items;
using ConsoleRPG.Utilities;
using System;
using System.Collections.Generic;

namespace ConsoleRPG.Shop
{
    public class Shop
    {
        const string space = "      ";
        public Weapon Waffe_1 { get; private set; }
        public int Waffe_1Kosten { get; private set; }
        public Weapon Waffe_2 { get; private set; }
        public int Waffe_2Kosten { get; private set; }
        public Weapon Waffe_3 { get; private set; }
        public int Waffe_3Kosten { get; private set; }
        private Random random = new Random();

        public Shop(ItemDataBase itemDatabase, int round)
        {
            // Auswahl der Waffen basierend auf der Runde
            Waffe_1 = GetRandomWeapon(itemDatabase, round);
            Waffe_1Kosten = CalculateCost(Waffe_1);

            Waffe_2 = GetRandomWeapon(itemDatabase, round);
            Waffe_2Kosten = CalculateCost(Waffe_2);

            Waffe_3 = GetRandomWeapon(itemDatabase, round);
            Waffe_3Kosten = CalculateCost(Waffe_3);
        }

        private Weapon GetRandomWeapon(ItemDataBase itemDatabase, int round)
        {
            Rarity rarity = DetermineRarity(round);
            List<Weapon> filteredWeapons = itemDatabase.Weapons.FindAll(w => w.WeaponRarity == rarity);
            return filteredWeapons[random.Next(filteredWeapons.Count)];
        }

        private Rarity DetermineRarity(int round)
        {
            int chance = random.Next(1, 101); // Zufallszahl zwischen 1 und 100

            if (round > 10 && chance > 80)
                return Rarity.Legendary;
            else if (round > 5 && chance > 60)
                return Rarity.Epic;
            else if (chance > 40)
                return Rarity.Rare;
            else if (chance > 20)
                return Rarity.Uncommon;
            else
                return Rarity.Common;
        }

        private int CalculateCost(Weapon weapon)
        {
            switch (weapon.WeaponRarity)
            {
                case Rarity.Common:
                    return 50;
                case Rarity.Uncommon:
                    return 100;
                case Rarity.Rare:
                    return 250;
                case Rarity.Epic:
                    return 500;
                case Rarity.Legendary:
                    return 1000;
                default:
                    return 0;
            }
        }

        public void ShowShopItems(Player player)
        {
            bool inShop = true;
            while (inShop)
            {
                Console.Clear();
                DisplayHelper.DrawSeparator();
                Console.WriteLine("Willkommen im Shop! Folgende Waffen sind verfügbar:");
                DisplayHelper.DrawSeparator();
                DisplayHelper.ShowWeaponWithColor(1, Waffe_1, Waffe_1Kosten);
                DisplayHelper.ShowWeaponWithColor(2, Waffe_2, Waffe_2Kosten);
                DisplayHelper.ShowWeaponWithColor(3, Waffe_3, Waffe_3Kosten);
                DisplayHelper.DrawSeparator();

                Console.Write($"Dein Gold: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{player.Gold} Gold");
                Console.ResetColor();
                DisplayHelper.DrawSeparator();

                // Verkaufsoption anzeigen, wenn der Spieler eine aktuelle Waffe hat
                if (player.CurrentWeapon != null)
                {
                    Console.WriteLine("Möchtest du deine aktuelle Waffe verkaufen?");
                    Console.Write($"Aktuelle Waffe: {player.CurrentWeapon.Name} - Verkaufspreis: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{player.CurrentWeapon.Value / 2} Gold");
                    Console.ResetColor();
                    Console.Write("Zum Verkaufen drücke V, oder drücke eine Zahl für den Kauf (1-3), 0 zum Abbrechen: ");
                }
                else
                {
                    Console.Write("Wähle eine Waffe zum Kaufen (1-3) oder 0 zum Abbrechen: ");
                }

                string input = Console.ReadLine().ToLower();

                if (input == "v" && player.CurrentWeapon != null)
                {
                    int salePrice = player.CurrentWeapon.Value / 2;
                    player.Gold += salePrice;
                    Console.WriteLine($"Du hast {player.CurrentWeapon.Name} für {salePrice} Gold verkauft.");
                    player.Inventory.Remove(player.CurrentWeapon);
                    player.CurrentWeapon = null;
                    Console.ReadKey();
                }
                else if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)
                {
                    Weapon selectedWeapon = choice switch
                    {
                        1 => Waffe_1,
                        2 => Waffe_2,
                        3 => Waffe_3,
                        _ => null
                    };

                    int cost = choice switch
                    {
                        1 => Waffe_1Kosten,
                        2 => Waffe_2Kosten,
                        3 => Waffe_3Kosten,
                        _ => 0
                    };

                    if (selectedWeapon != null && player.Gold >= cost)
                    {
                        if (player.CurrentWeapon != null)
                        {
                            player.Inventory.Remove(player.CurrentWeapon);
                        }

                        player.Gold -= cost;
                        player.CurrentWeapon = selectedWeapon;
                        player.Inventory.Add(selectedWeapon);
                        Console.WriteLine($"Du hast {selectedWeapon.Name} für {cost} Gold gekauft!");
                    }
                    else
                    {
                        Console.WriteLine("Nicht genügend Gold für diesen Kauf.");
                    }
                    Console.ReadKey();
                }
                else if (input == "0")
                {
                    inShop = false;
                    Console.WriteLine("Du verlässt den Shop.");
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe.");
                    Console.ReadKey();
                }
            }
        }
    }
}

