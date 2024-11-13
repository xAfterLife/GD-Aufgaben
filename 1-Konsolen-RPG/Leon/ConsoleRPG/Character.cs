using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Attack(int damage)
        {
            AttackPower = damage;
            //Methode evt. für den Player überschreiben damit nur er crits machen kann
            //Crit Chance 20% für doppelten Schaden
            int crit = random.Next(1, 10);
            if (crit > 8)
            {
                damage *= 2;
                return damage;
            }
            else
            {
                return damage;
            }     
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
    //Erstellen der Player Klasse, Erbt Felder und Funktionen von Character
    public class Player : Character
    {
        //3 Neue Felder zum Player hinzugefügt
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        //Konstruktor des Players, name, health & attackPower müssen hier nicht gleichgesetzt werden, da die Klasse erbt
        public Player(string name, int health, int attackPower, int level, int experience, int gold)
            :base (name, health, attackPower)
        {
            Level = level;
            Experience = experience;
            Gold = gold;
        }
        //Fügt dem Spieler Erfahrung hinzu, wenn der Spieler Level 3 ist, werden 300 XP benötigt 
        //Um LevelUp zu kommen usw. 
        //Wenn Experience mehr als Level * 100 dann kriegt der Spieler einen Levelup und wenn
        //nicht, dann kriegt er nur die Erfahrungspunkte hinzu addiert
        public void GainExperience(int xp)
        {
            if ((Level * 100) <= Experience)
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

            //Nach dem Lvlup werden alle gesammelten Erfahrungspunkte auf 0 gesetzt, da
            //Der Spieler eine Stufe aufgestiegen ist und wieder bei 0 beginnt
            Experience = 0;
        }
        //Methode zum heilen, wenn die höhe der Heilung und das aktuelle Leben über Maxhealth
        //hinaus geht, dann wird das aktuelle Leben einfach auf MaxHealth gesetzt
        //Wenn nicht dann füge healingamount dem Leben zu
        public void Heal(int healingAmount)
        {
            if ((healingAmount + Health) > MaxHealth)
            {
                Health = MaxHealth;
            }
            else
            {
                Health += healingAmount;
            }
        }
    }
    //Erstellen der Monster Klasse die von Character erbt
    public class Monster : Character
    {
        //Monster geben nachdem sie besiegt sind, entsprechend Gold und Erfahrung
        public int RewardGold { get; set; }
        public int RewardXP { get; set; }

        //Konstruktor für das Monster
        public Monster(string name, int health, int attackPower, int rewardGold, int rewardXP)
            : base (name, health, attackPower)
        {
            RewardGold = rewardGold;
            RewardXP = rewardXP;
        }
    }
}
