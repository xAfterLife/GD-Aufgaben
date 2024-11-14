using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    //Erstellen der Player Klasse, Erbt Felder und Funktionen von Character
    public class Player : Character
    {
        //3 Neue Felder zum Player hinzugefügt
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        //Konstruktor des Players, name, health & attackPower müssen hier nicht gleichgesetzt werden, da die Klasse erbt
        public Player(string name, int health, int attackPower, int level, int experience, int gold)
            : base(name, health, attackPower)
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
}
