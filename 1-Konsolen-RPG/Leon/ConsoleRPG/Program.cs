using System;

namespace ConsoleRPG
{
    internal class Program
    {
        //Definieren der Einrückung 
        const string space = "      ";
        //Statistiken
        static List<Statistics> statistics = new List<Statistics>();

        static void Main(string[] args)
        {
            //Konsoleneinstellungen:
            Console.Title = "ConsoleRPG";
            Random random = new();
            bool gameStart = true;
            int firstTimeCounter = 0;

            //Test Data, wird später in einer File gespeichert und geladen
            statistics.Add(new Statistics("Leon", 5, 10, 200));
            statistics.Add(new Statistics("Paul", 3, 8, 150));
            statistics.Add(new Statistics("Markus", 7, 12, 300));

            //Starten der Startspielschleife
            while (gameStart)
            {
                Console.Clear();
                //Begrüßung
                DrawSeperator();
                Console.WriteLine($"{space}Herzlich Willkommen zu deinem Abenteuer!");

                //Anzeigen des Hauptmenüs
                ShowMainMenu();


                Console.Write($"{space}Bitte wähle einen Punkt aus: ");

                //Abfangen falscher eingaben
                if (int.TryParse( Console.ReadLine(), out int startChoice)) 
                {
                    DrawSeperator();

                    switch (startChoice)
                    {
                        case 1:
                            Console.WriteLine($"{space}Das Spiel wird gestartet..");
                            Thread.Sleep(3000);
                            gameStart = false;
                            GameStart();
                            break;
                        case 2:
                            break;
                        case 3:
                            ShowStatistics(statistics);
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
                    DrawSeperator();
                }
            }
        }
        //Spieleinstiegspunkt definiert
        static void GameStart()
        {

            DrawSeperator();
            Console.WriteLine($"{space}Das spiel beginnt..");
            DrawSeperator();
            Thread.Sleep(3000);
            Console.Clear();

            //Spieler auswahl speichern
            string playerName = GetPlayerName();
            int difficulty = GetDifficultyLevel();

            //Standard stats für normal
            Player player = new Player(playerName, 100, 25, 1, 0, 50);
            AdjustPlayerForDifficulty(player, difficulty);
            ShowPlayerStats(player);

            bool playing = true;

            while (playing)
            {
                ShowPlayerMenu();
                

            }
    
        }

        static void ShowPlayerMenu()
        {
            //1. Kämpfen(muss ich noch adden)
            //2. Inventar (muss ich noch adden)
            //3. Shop(muss ich noch adden)
            //4. Taverne(muss ich noch adden)
            //5. Playerstats(muss ich noch adden)
            //6. Speichern & Beenden(muss ich noch adden)
        }
        static void AdjustPlayerForDifficulty(Player player, int difficulty)
        {
            DrawSeperator();
            switch (difficulty)
            {
                case 1: //Einfach
                    player.Health += 100;
                    player.AttackPower += 15;
                    player.Gold += 50;
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine($"{space}Einfacher Modus gewählt. Deine Werte wurden angepasst.");
                    Console.ResetColor();
                    break;
                case 2: //Normal
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{space}Normaler Modus gewählt. Standardwerte behalten.");
                    Console.ResetColor();
                    break;
                case 3: //Schwer
                    player.Health -= 50;
                    player.AttackPower -= 10;
                    player.Gold -= 50;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{space}Schwerer Modus gewählt. Deine Werte wurden angepasst.");
                    Console.ResetColor();
                    break;

            }
            DrawSeperator();
            Thread.Sleep(3000);
        }

        static void ShowPlayerStats(Player player)
        {
            Console.WriteLine($"{space}Deine Stats");
            Console.WriteLine();
            Console.WriteLine($"{space}Name: {player.Name}");
            Console.WriteLine($"{space}Leben: {player.Health}");
            Console.WriteLine($"{space}Level: {player.Level}");
            Console.WriteLine($"{space}Angriffskraft: {player.AttackPower}");
            Console.WriteLine($"{space}Erfahrung: {player.Experience}/{(player.Level * 100)}");
            Console.WriteLine($"{space}Gold: {player.Gold}");
            DrawSeperator();
            Console.ReadKey();
        }

        static int GetDifficultyLevel()
        {
            int difficulty = 0;
            bool validChoice = false;

            while (!validChoice)
            {
                DrawSeperator();
                Console.WriteLine($"{space}Als nächstes musst du dich für einen\n{space}Schwierigkeitsgrad entscheiden.");
                Console.WriteLine($"{space}Basierend auf der Schwierigkeit werden\n{space}alle Stats im Spiel angepasst.");

                DrawSeperator();

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

                DrawSeperator();

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
            DrawSeperator();
            Console.Write($"{space}Bitte gebe deinen Namen ein: ");
            string name = Console.ReadLine();

            DrawSeperator();

            Console.WriteLine($"{space}Ah, {name} also."); //Voll Pokémonlike haha
            Thread.Sleep(2000);
            Console.WriteLine($"{space}Nun {name}, ich hoffe du weißt was dich erwartet.");
            Thread.Sleep(3000);
            return name;
        }
        public static void ShowStatistics(List <Statistics> statistics)
        {
            //Nach dem ein Spieldurchgang vorbei ist, werden einige Variablen gespeichert
            //Und in die Statistiken eingetragen, mit der Auswahl für case 3 werden
            //diese dann ausgegeben und man sieht vorherig absolvierte Spieldurchläufe
            //Daten wie: Name, Runde, Gold, Lvl etc.

            Console.WriteLine($"{space}Vergangene Spieldurchläufe: ");
            if (statistics.Count == 0)
            {
                Console.WriteLine($"{space}Es gibt leider noch keine Statistiken.");
            }
            else
            {
                DrawSeperator();
                foreach (var stat in statistics)
                {
                    Console.WriteLine(stat.ToString());
                    DrawSeperator();
                }
                
            }
        }
        public static void ShowMainMenu()
        {
            DrawSeperator();
            Console.WriteLine($"{space}1. Spiel starten");
            Console.WriteLine($"{space}2. Spiel Laden");
            Console.WriteLine($"{space}3. Statistiken");
            Console.WriteLine($"{space}4. Hilfe");
            Console.WriteLine($"{space}5. Spiel beenden");
            DrawSeperator();
        }

        public static void DrawSeperator()
        {
            Console.Write("+");
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");
        }
    }
}
