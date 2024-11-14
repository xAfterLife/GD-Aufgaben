using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Statistics
    {
        const string space = "      ";
        public string Name { get; set; }
        public int Level { get; set; }
        public int Round { get; set; }
        public int Gold { get; set; }

        public Statistics(string name, int level, int round, int gold)
        {
            Name = name;
            Level = level;
            Round = round;
            Gold = gold;
        }

        public override string ToString()
        {
            return $"      Name: {Name}\n      Level: {Level}\n      Runde: {Round}\n      Gold: {Gold}";
        }

        public static void ShowStatistics(List<Statistics> statistics)
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
