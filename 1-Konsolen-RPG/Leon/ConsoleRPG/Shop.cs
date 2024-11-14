using ConsoleRPG;
using System;
using System.Collections.Generic;

namespace ConsoleRPG
{

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }

    public class Weapon : Item
    {
        public string Name { get; set; }
        public Rarity WeaponRarity { get; set; }
        public int Value { get; set; }
        public int AttackPower { get; set; }
        public int CritChance { get; set; }


        public Weapon(string name, Rarity rarity,int value,  int attackPower, int critChance)
        {
            Name = name;
            WeaponRarity = rarity;
            Value = value;
            AttackPower = attackPower;
            CritChance = critChance;
        }
    }

    public class ItemDataBase
    {
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

        public ItemDataBase()
        {
            // Common
            Weapons.Add(new Weapon("Rostiges Schwert", Rarity.Common, 10, 5, 1));
            Weapons.Add(new Weapon("Alter Dolch", Rarity.Common, 8, 3, 1));
            Weapons.Add(new Weapon("Holzkeule", Rarity.Common, 15, 6, 0));
            Weapons.Add(new Weapon("Steinschleuder", Rarity.Common, 12, 4, 2));
            Weapons.Add(new Weapon("Stumpfe Axt", Rarity.Common, 18, 7, 1));
            Weapons.Add(new Weapon("Rostiger Speer", Rarity.Common, 14, 5, 1));
            Weapons.Add(new Weapon("Einfacher Bogen", Rarity.Common, 20, 6, 2));
            Weapons.Add(new Weapon("Schwerer Knüppel", Rarity.Common, 15, 7, 0));
            Weapons.Add(new Weapon("Alte Armbrust", Rarity.Common, 17, 6, 2));
            Weapons.Add(new Weapon("Gebrauchtes Langschwert", Rarity.Common, 22, 8, 1));
            Weapons.Add(new Weapon("Einfacher Dolch", Rarity.Common, 9, 4, 3));
            Weapons.Add(new Weapon("Verbogene Klinge", Rarity.Common, 11, 4, 1));
            Weapons.Add(new Weapon("Abgenutzte Peitsche", Rarity.Common, 13, 5, 2));
            Weapons.Add(new Weapon("Steinkeule", Rarity.Common, 10, 4, 0));
            Weapons.Add(new Weapon("Einfacher Hammer", Rarity.Common, 12, 5, 1));
            Weapons.Add(new Weapon("Spitzer Stock", Rarity.Common, 6, 2, 1));
            Weapons.Add(new Weapon("Krummes Schwert", Rarity.Common, 16, 5, 1));
            Weapons.Add(new Weapon("Krummer Speer", Rarity.Common, 18, 6, 0));
            Weapons.Add(new Weapon("Kleiner Dolch", Rarity.Common, 5, 3, 2));
            Weapons.Add(new Weapon("Einfaches Messer", Rarity.Common, 7, 3, 2));

            // Uncommon
            Weapons.Add(new Weapon("Geschärftes Schwert", Rarity.Uncommon, 25, 10, 3));
            Weapons.Add(new Weapon("Bronzene Klinge", Rarity.Uncommon, 30, 12, 2));
            Weapons.Add(new Weapon("Jägerbogen", Rarity.Uncommon, 27, 10, 4));
            Weapons.Add(new Weapon("Verstärkter Dolch", Rarity.Uncommon, 20, 9, 5));
            Weapons.Add(new Weapon("Scharfe Axt", Rarity.Uncommon, 28, 11, 3));
            Weapons.Add(new Weapon("Leichte Armbrust", Rarity.Uncommon, 32, 13, 4));
            Weapons.Add(new Weapon("Eisenkeule", Rarity.Uncommon, 35, 15, 2));
            Weapons.Add(new Weapon("Schwerer Streitkolben", Rarity.Uncommon, 40, 16, 3));
            Weapons.Add(new Weapon("Doppelschneidige Klinge", Rarity.Uncommon, 30, 12, 4));
            Weapons.Add(new Weapon("Langdolch", Rarity.Uncommon, 23, 10, 6));
            Weapons.Add(new Weapon("Verstärkte Peitsche", Rarity.Uncommon, 22, 8, 4));
            Weapons.Add(new Weapon("Verzierte Klinge", Rarity.Uncommon, 28, 11, 3));
            Weapons.Add(new Weapon("Bronzeschwert", Rarity.Uncommon, 25, 10, 2));
            Weapons.Add(new Weapon("Eiserner Speer", Rarity.Uncommon, 30, 13, 3));
            Weapons.Add(new Weapon("Schneller Dolch", Rarity.Uncommon, 19, 9, 6));
            Weapons.Add(new Weapon("Leichte Streitaxt", Rarity.Uncommon, 32, 14, 2));
            Weapons.Add(new Weapon("Kriegshammer", Rarity.Uncommon, 35, 15, 2));
            Weapons.Add(new Weapon("Eisenlangschwert", Rarity.Uncommon, 38, 14, 2));
            Weapons.Add(new Weapon("Geflügelter Speer", Rarity.Uncommon, 31, 13, 3));
            Weapons.Add(new Weapon("Verzierte Axt", Rarity.Uncommon, 33, 12, 3));

            // Rare
            Weapons.Add(new Weapon("Klinge des Ruhms", Rarity.Rare, 50, 20, 5));
            Weapons.Add(new Weapon("Knochenschwert", Rarity.Rare, 55, 22, 4));
            Weapons.Add(new Weapon("Bogen des Jägers", Rarity.Rare, 45, 18, 6));
            Weapons.Add(new Weapon("Dunkeldolch", Rarity.Rare, 40, 17, 8));
            Weapons.Add(new Weapon("Schicksalsaxt", Rarity.Rare, 60, 25, 5));
            Weapons.Add(new Weapon("Kriegsschleuder", Rarity.Rare, 48, 19, 6));
            Weapons.Add(new Weapon("Runenschwert", Rarity.Rare, 53, 21, 5));
            Weapons.Add(new Weapon("Stahlkeule", Rarity.Rare, 57, 23, 3));
            Weapons.Add(new Weapon("Zauberbogen", Rarity.Rare, 52, 21, 5));
            Weapons.Add(new Weapon("Doppelaxt", Rarity.Rare, 60, 24, 4));
            Weapons.Add(new Weapon("Schlachtschwert", Rarity.Rare, 58, 23, 5));
            Weapons.Add(new Weapon("Kristallspeer", Rarity.Rare, 62, 25, 5));
            Weapons.Add(new Weapon("Kraftklinge", Rarity.Rare, 54, 22, 6));
            Weapons.Add(new Weapon("Drachenzahn", Rarity.Rare, 63, 26, 5));
            Weapons.Add(new Weapon("Schleuder der Verdammnis", Rarity.Rare, 50, 20, 6));
            Weapons.Add(new Weapon("Schwert der Tapferkeit", Rarity.Rare, 56, 22, 5));
            Weapons.Add(new Weapon("Hammer der Stärke", Rarity.Rare, 60, 24, 4));
            Weapons.Add(new Weapon("Schattenklinge", Rarity.Rare, 52, 21, 6));
            Weapons.Add(new Weapon("Phantomdolch", Rarity.Rare, 46, 18, 8));
            Weapons.Add(new Weapon("Schwert der Gerechtigkeit", Rarity.Rare, 58, 23, 5));

            // Epic
            Weapons.Add(new Weapon("Flammenschwert", Rarity.Epic, 80, 30, 7));
            Weapons.Add(new Weapon("Donnerhammer", Rarity.Epic, 85, 33, 5));
            Weapons.Add(new Weapon("Bogen des Schicksals", Rarity.Epic, 75, 28, 8));
            Weapons.Add(new Weapon("Lichtdolch", Rarity.Epic, 70, 27, 10));
            Weapons.Add(new Weapon("Axt des Sturms", Rarity.Epic, 88, 35, 6));
            Weapons.Add(new Weapon("Magisches Schwert", Rarity.Epic, 82, 32, 7));
            Weapons.Add(new Weapon("Verfluchte Klinge", Rarity.Epic, 78, 31, 8));
            Weapons.Add(new Weapon("Drachentöter", Rarity.Epic, 90, 36, 6));
            Weapons.Add(new Weapon("Schattenbogen", Rarity.Epic, 76, 29, 9));
            Weapons.Add(new Weapon("Bannhammer", Rarity.Epic, 84, 34, 5));
            Weapons.Add(new Weapon("Zauberspeer", Rarity.Epic, 87, 35, 6));
            Weapons.Add(new Weapon("Knochenbrecher", Rarity.Epic, 79, 31, 7));
            Weapons.Add(new Weapon("Klingen des Chaos", Rarity.Epic, 81, 32, 7));
            Weapons.Add(new Weapon("Phönixfeder", Rarity.Epic, 77, 30, 8));
            Weapons.Add(new Weapon("Schwert der Ewigkeit", Rarity.Epic, 83, 33, 7));
            Weapons.Add(new Weapon("Dunkelschwert", Rarity.Epic, 85, 33, 8));
            Weapons.Add(new Weapon("Höllenfeuer", Rarity.Epic, 89, 36, 7));
            Weapons.Add(new Weapon("Nachtklinge", Rarity.Epic, 78, 31, 8));
            Weapons.Add(new Weapon("Sternenbrecher", Rarity.Epic, 84, 34, 7));
            Weapons.Add(new Weapon("Axt des Verderbens", Rarity.Epic, 86, 34, 7));

            // Legendary
            Weapons.Add(new Weapon("Excalibur", Rarity.Legendary, 150, 50, 15));
            Weapons.Add(new Weapon("Himmelsbrecher", Rarity.Legendary, 145, 48, 14));
            Weapons.Add(new Weapon("Götterschwert", Rarity.Legendary, 140, 46, 13));
            Weapons.Add(new Weapon("Schicksalsklinge", Rarity.Legendary, 138, 45, 14));
            Weapons.Add(new Weapon("Zorn der Titanen", Rarity.Legendary, 155, 52, 12));
            Weapons.Add(new Weapon("Phantomstreitkolben", Rarity.Legendary, 142, 47, 13));
            Weapons.Add(new Weapon("Lichtbogen", Rarity.Legendary, 135, 44, 15));
            Weapons.Add(new Weapon("Seelenbrecher", Rarity.Legendary, 150, 50, 12));
            Weapons.Add(new Weapon("Auge des Drachen", Rarity.Legendary, 160, 54, 14));
            Weapons.Add(new Weapon("Göttliche Klinge", Rarity.Legendary, 148, 49, 15));
            Weapons.Add(new Weapon("Klinge der Unendlichkeit", Rarity.Legendary, 155, 52, 14));
            Weapons.Add(new Weapon("Hammer des Schicksals", Rarity.Legendary, 150, 50, 12));
            Weapons.Add(new Weapon("Speer der Macht", Rarity.Legendary, 145, 48, 13));
            Weapons.Add(new Weapon("Höllenbote", Rarity.Legendary, 153, 51, 12));
            Weapons.Add(new Weapon("Erzmagierstab", Rarity.Legendary, 140, 46, 15));
            Weapons.Add(new Weapon("Götterhammer", Rarity.Legendary, 160, 54, 13));
            Weapons.Add(new Weapon("Ewiger Schildbrecher", Rarity.Legendary, 157, 53, 14));
            Weapons.Add(new Weapon("Klinge der Titanen", Rarity.Legendary, 149, 49, 15));
            Weapons.Add(new Weapon("Königsbogen", Rarity.Legendary, 135, 44, 15));
            Weapons.Add(new Weapon("Drachenschwinge", Rarity.Legendary, 150, 50, 13));
        }

    }
}

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
            DrawSeperator();
            Console.WriteLine("Willkommen im Shop! Folgende Waffen sind verfügbar:");
            DrawSeperator();
            ShowWeaponWithColor(1, Waffe_1, Waffe_1Kosten);
            ShowWeaponWithColor(2, Waffe_2, Waffe_2Kosten);
            ShowWeaponWithColor(3, Waffe_3, Waffe_3Kosten);
            DrawSeperator();

            Console.Write($"Dein Gold: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player.Gold} Gold");
            Console.ResetColor();
            DrawSeperator();

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



    // Hilfsmethode, um die Waffe mit der entsprechenden Farbe und dem Attack-Wert anzuzeigen
    private void ShowWeaponWithColor(int index, Weapon weapon, int cost)
    {
        Console.Write($"{index}. {weapon.Name.PadRight(20)} - Seltenheit: ");

        // Raritätenfarbe setzen
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

        Console.ResetColor(); // Setzt die Farbe zurück für den nächsten Abschnitt
        Console.Write(" - Kosten: ");

        // Goldfarbe setzen
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{cost} Gold".PadRight(12));
        Console.ResetColor();

        // Zeige den AttackPower-Wert an
        Console.Write(" - Angriffskraft: ");
        Console.ForegroundColor = ConsoleColor.Red; // Farbe für Angriffskraft
        Console.Write($"{weapon.AttackPower}");
        Console.ResetColor();

        Console.WriteLine(); // Neue Zeile nach der Waffe
    }

    public static void DrawSeperator()
    {
        Console.Write("+");
        for (int i = 0; i < 100; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine("+");
    }
}

