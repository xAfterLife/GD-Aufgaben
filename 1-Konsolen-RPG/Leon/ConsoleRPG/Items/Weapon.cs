using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Items
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


        public Weapon(string name, Rarity rarity, int value, int attackPower, int critChance)
        {
            Name = name;
            WeaponRarity = rarity;
            Value = value;
            AttackPower = attackPower;
            CritChance = critChance;
        }
    }
}
