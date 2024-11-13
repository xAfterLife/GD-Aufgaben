using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Statistics
    {
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
    }
}
