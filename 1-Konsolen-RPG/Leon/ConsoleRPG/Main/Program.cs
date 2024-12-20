﻿using System;
using ConsoleRPG.Items;
using ConsoleRPG.Characters;
using ConsoleRPG.Shop;
using ConsoleRPG.GameStats;
using ConsoleRPG.Utilities;
using ConsoleRPG.Battle;
using ConsoleRPG.GameFile;
using System.Numerics;


namespace ConsoleRPG.Main
{
    internal class Program
    {
        //Definieren der Einrückung 
        const string space = "      ";
        //Statistiken
        static List<Statistics> statistics = new List<Statistics>();

        static Player player;
        static ItemDataBase itemDatabase = new ItemDataBase();

        static void Main(string[] args)
        {
            //Konsoleneinstellungen:
            Console.Title = "ConsoleRPG";
            Random random = new();
            bool gameStart = true;


            //Test Data, wird später in einer File gespeichert und geladen
            statistics.Add(new Statistics("Leon", 5, 10, 200));
            statistics.Add(new Statistics("Paul", 3, 8, 150));
            statistics.Add(new Statistics("Markus", 7, 12, 300));

            //Starten der Startspielschleife
            while (gameStart)
            {
                Console.Clear();
                //Begrüßung
                DisplayHelper.DrawSeparator();
                Console.WriteLine($"{space}Herzlich Willkommen zu deinem Abenteuer!");

                //Anzeigen des Hauptmenüs
                ShowMainMenu();


                Console.Write($"{space}Bitte wähle einen Punkt aus: ");

                //Abfangen falscher eingaben
                if (int.TryParse(Console.ReadLine(), out int startChoice))
                {
                    DisplayHelper.DrawSeparator();

                    switch (startChoice)
                    {
                        case 1:
                            Console.WriteLine($"{space}Das Spiel wird gestartet..");
                            Thread.Sleep(3000);
                            gameStart = false;
                            GameStart();
                            break;
                        case 2: // Spiel Laden
                            SaveManager save = LoadManager.LoadGame("savegame.json");
                            if (save != null)
                            {
                                player = new Player(save.Name, save.Health, save.AttackPower, save.Level, save.Experience, save.Gold, new List<Item>())
                                {
                                    MaxHealth = save.MaxHealth,
                                    Round = save.Round,
                                    Inventory = save.Inventory
                                        .Select(itemName => itemDatabase.GetItemByName(itemName))
                                        .Where(item => item != null) // Prüfe auf null
                                        .Cast<Item>()
                                        .ToList(),
                                    CurrentWeapon = itemDatabase.GetItemByName(save.CurrentWeapon) as Weapon
                                };

                                Console.WriteLine("Spiel erfolgreich geladen.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            Statistics.ShowStatistics(statistics);
                            Console.ReadKey();
                            break;
                        case 4:
                            break;
                        case 5:
                            Console.WriteLine($"{space}Das Spiel wird beendet..");
                            Thread.Sleep(3000);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{space}Ungültige Eingabe, bitte probiere es erneut.");
                            Console.ResetColor();
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{space}Ungültige Eingabe, bitte gebe eine Zahl 1-6 ein.");
                    Console.ResetColor();
                    Console.ReadKey();
                    DisplayHelper.DrawSeparator();
                }
            }
        }
        //Spieleinstiegspunkt definiert
        static void GameStart()
        {
            ItemDataBase itemDatabase = new ItemDataBase();
            DisplayHelper.DrawSeparator();
            Console.WriteLine($"{space}Das spiel beginnt..");
            DisplayHelper.DrawSeparator();
            Thread.Sleep(3000);
            Console.Clear();

            //Spieler auswahl speichern
            string playerName = GetPlayerName();
            int difficulty = GetDifficultyLevel();

            // Erstelle eine leere Inventar-Liste
            List<Item> inventory = new List<Item>();

            //Standard stats für normal
            player = new Player(playerName, 100, 10, 1, 0, 50, inventory)
            {
                CurrentWeapon = new Weapon("Starter-Schwert", Rarity.Common, 10, 5, 0)
            };
            AdjustPlayerForDifficulty(player, difficulty);
            player.ShowPlayerStats();
            Console.ReadKey();

            bool playing = true;

            while (playing)
            {
                Console.Clear();
                ShowPlayerMenu();


                if (int.TryParse(Console.ReadLine(), out int playerchoice))
                {
                    DisplayHelper.DrawSeparator();

                    switch (playerchoice)
                    {
                        case 1:
                            var battle = new Battle.Battle(player);
                            Thread.Sleep(1000);
                            battle.StartBattle();

                            break;
                        case 2:
                            player.ShowPlayerInventory();
                            Console.ReadKey();
                            break;
                        case 3:
                            var shop = new Shop.Shop(itemDatabase, player.Round);
                            shop.ShowShopItems(player);

                            break;
                        case 4:
                            Console.WriteLine($"{space}Die Taverne hat noch zu.");
                            Console.ReadKey();
                            break;
                        case 5:
                            player.ShowPlayerStats();
                            Console.ReadKey();
                            break;
                        case 6:
                            SaveManager.SaveGame(player, "save.json");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{space}Ungültige Eingabe, bitte probiere es erneut.");
                            Console.ResetColor();
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{space}Ungültige Eingabe, bitte gebe eine Zahl 1-6 ein.");
                    Console.ResetColor();
                    Console.ReadKey();
                    DisplayHelper.DrawSeparator();
                }
            }
        }

        static void ShowPlayerMenu()
        {
            Console.WriteLine($"{space}Spielermenü");
            DisplayHelper.DrawSeparator();
            Console.WriteLine($"{space}1. Kämpfen");
            Console.WriteLine($"{space}2. Inventar");
            Console.WriteLine($"{space}3. Shop");
            Console.WriteLine($"{space}4. Taverne");
            Console.WriteLine($"{space}5. Playerstats");
            Console.WriteLine($"{space}6. Speichern und Beenden");
            DisplayHelper.DrawSeparator();
            Console.Write($"{space}Bitte wähle eine Option: ");
        }
        static void AdjustPlayerForDifficulty(Player player, int difficulty)
        {
            DisplayHelper.DrawSeparator();
            switch (difficulty)
            {
                case 1: //Einfach
                    player.Health += 100;
                    player.MaxHealth = player.Health;
                    player.AttackPower += 5;
                    player.Gold += 50;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{space}Einfacher Modus gewählt. \n{space}Deine Werte wurden angepasst.");
                    Console.ResetColor();
                    break;
                case 2: //Normal
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{space}Normaler Modus gewählt. \n{space}Standardwerte behalten.");
                    Console.ResetColor();
                    break;
                case 3: //Schwer
                    player.Health -= 50;
                    player.AttackPower -= 5;
                    player.Gold -= 50;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{space}Schwerer Modus gewählt. \n{space}Deine Werte wurden angepasst.");
                    Console.ResetColor();
                    break;

            }
            DisplayHelper.DrawSeparator();
            Thread.Sleep(3000);
        }
        static int GetDifficultyLevel()
        {
            int difficulty = 0;
            bool validChoice = false;

            while (!validChoice)
            {
                DisplayHelper.DrawSeparator();
                Console.WriteLine($"{space}Wähle deinen Schwierigkeitsgrad");
                DisplayHelper.DrawSeparator();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{space}1. Einfach");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{space}2. Normal");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{space}3. Schwer");
                Console.ResetColor();

                DisplayHelper.DrawSeparator();

                Console.Write($"{space}Bitte wähle: ");

                if (int.TryParse(Console.ReadLine(), out difficulty) && difficulty >= 1 && difficulty <= 3)
                {
                    validChoice = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ungültige Eingabe, wähle zwischen 1-3: ");
                    Console.ResetColor();
                }
            }
            return difficulty;
        }
        static string GetPlayerName()
        {
            DisplayHelper.DrawSeparator();
            Console.Write($"{space}Bitte gebe deinen Namen ein: ");
            string name = Console.ReadLine();

            DisplayHelper.DrawSeparator();

            Console.WriteLine($"{space}Ah, {name} also."); //Voll Pokémonlike haha
            Thread.Sleep(2000);
            Console.WriteLine($"{space}Nun {name}, ich hoffe du weißt was dich erwartet.");
            Thread.Sleep(3000);
            return name;
        }

        public static void ShowMainMenu()
        {
            DisplayHelper.DrawSeparator();
            Console.WriteLine($"{space}1. Spiel starten");
            Console.WriteLine($"{space}2. Spiel Laden");
            Console.WriteLine($"{space}3. Statistiken");
            Console.WriteLine($"{space}4. Hilfe");
            Console.WriteLine($"{space}5. Spiel beenden");
            DisplayHelper.DrawSeparator();
        }
    }
}
