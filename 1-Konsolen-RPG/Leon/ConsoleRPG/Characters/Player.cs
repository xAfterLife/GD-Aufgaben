using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Items;
using ConsoleRPG.Utilities;

namespace ConsoleRPG.Characters
{
    //Erstellen der Player Klasse, Erbt Felder und Funktionen von Character
    public class Player : Character
    {
        const string space = "      ";
        //3 Neue Felder zum Player hinzugefügt
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public Weapon? CurrentWeapon { get; set; }
        public List<Item> Inventory { get; set; }
        public int Round { get; set; } = 1;
        


        //Konstruktor des Players, name, health & attackPower müssen hier nicht gleichgesetzt werden, da die Klasse erbt
        public Player(string name, int health, int attackPower, int level, int experience, int gold, List<Item> inventory)
            : base(name, health, attackPower)
        {
            Level = level;
            Experience = experience;
            Gold = gold;
            Inventory = inventory;
        }


        public void GainExperience(int xp)
        {
            if (Level * 100 <= Experience)
            {
                LevelUp();
            }
            else
            {
                Experience += xp;
            }
        }
        //Methode die das Level um einen erhöht, wird aufgerufen wenn z.B bei Lvl 1
        //100 XP gesammelt wurden, erhöht außerdem die anderen playerstats um feste Werte
        public void LevelUp()
        {
            Level++;
            AttackPower += 5;
            MaxHealth += 25;
            //Bei einem Levelaufstieg kriegt man immer wieder maximales Leben
            Health = MaxHealth;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{space}Level Up!\n{space}Neues Level: {Level}");
            Console.ResetColor();
            DisplayHelper.DrawSeparator();
            Console.ReadKey();
            //Nach dem Lvlup werden alle gesammelten Erfahrungspunkte auf 0 gesetzt, da
            //Der Spieler eine Stufe aufgestiegen ist und wieder bei 0 beginnt
            Experience = 0;
        }
        public void Heal(int healingAmount)
        {
            if (healingAmount + Health > MaxHealth)
            {
                Health = MaxHealth;
                Console.WriteLine($"{space}{Name} hat sich geheilt.");
                Console.ReadKey();
            }
            else
            {
                Health += healingAmount;
                Console.WriteLine($"{space}{Name} hat sich geheilt.");
                Console.ReadKey();
            }
        }
        //Ich habe die Methode von Character überschrieben, damit nur der Spieler möglichkeit auf 
        //Crits hat, stichwort polymorphismus
        public override int Attack(int damage)
        {
            AttackPower = damage;

            int crit = random.Next(1, 10);
            if (crit > 8)
            {
                damage *= 2;
                Console.WriteLine($"{space}Ein Crit!");
                return damage;
            }
            else
            {
                return damage;
            }
        }
        public void ShowPlayerInventory()
        {
            if (Inventory.Count > 0)
            {
                Console.WriteLine($"{space}Inventar:");
                foreach (Item item in Inventory)
                {
                    if (item is Weapon weapon && weapon == CurrentWeapon)
                    {
                        Console.WriteLine($"{space}{weapon.Name} (ausgerüstet)");
                    }
                    else
                    {
                        Console.WriteLine($"{space}{item.Name}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"{space}Du hast noch keine Items.");
            }
        }


        public void ShowPlayerStats()
        {
            Console.WriteLine($"{space}Deine Stats");
            Console.WriteLine();
            Console.WriteLine($"{space}Name: {Name}");
            Console.WriteLine($"{space}Leben: {Health}/{MaxHealth}");
            Console.WriteLine($"{space}Level: {Level}");

            // Zeige Angriffskraft mit Waffenschaden
            Console.Write($"{space}Angriffskraft: {AttackPower}");
            if (CurrentWeapon != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" (+{CurrentWeapon.AttackPower} {CurrentWeapon.Name})");
                Console.ResetColor();
            }
            Console.WriteLine();

            Console.WriteLine($"{space}Erfahrung: {Experience}/{Level * 100}");

            Console.Write($"{space}Gold: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Gold);
            Console.ResetColor();
            Program.DrawSeperator();
        }
    }
}
