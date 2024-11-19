using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Characters;

namespace ConsoleRPG
{

    public class Character
    {
        //Initialisieren/Deklarieren der Random Klasse
        public Random random = new Random();
        //Erstellen der Felder/Eigenschaften von Character
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int MaxHealth { get; set; }


        //Konstruktor für die Characterklasse
        public Character(string name, int health, int attackPower)
        {
            //Parametern den Feldern gleichsetzen
            Name = name;
            Health = health;
            AttackPower = attackPower;
            MaxHealth = Health;
        }

        //Allgemeine Attack Methode, die von allen ausgeführt werden kann
        public virtual int Attack(int damage)
        {
            AttackPower = damage;
            //Methode evt. für den Player überschreiben damit nur er crits machen kann
            //Crit Chance 20% für doppelten Schaden
            return damage;
        }
        //Nimmt damage als Parameter und zieht es dem Leben der Character Instanz ab.
        public int TakeDamage(int damage)
        {
            if (damage > 0)
            {
                Health -= damage;
                return Health;
            }
            else
            {
                return Health;
            }
        }
    }
}
