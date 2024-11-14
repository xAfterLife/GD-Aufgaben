using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class Monster : Character
    {
        //Monster geben nachdem sie besiegt sind, entsprechend Gold und Erfahrung
        public int RewardGold { get; set; }
        public int RewardXP { get; set; }

        //Konstruktor für das Monster
        public Monster(string name, int health, int attackPower, int rewardGold, int rewardXP)
            : base(name, health, attackPower)
        {
            RewardGold = rewardGold;
            RewardXP = rewardXP;
        }

    }
}
