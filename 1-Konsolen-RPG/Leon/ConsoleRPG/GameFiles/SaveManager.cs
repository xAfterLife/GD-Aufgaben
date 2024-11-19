using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ConsoleRPG.Characters;
using ConsoleRPG.Items;

namespace ConsoleRPG.GameFile
{
    public class SaveManager
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int MaxHealth { get; set; }
        public int Round { get; set; }
        public List<string> Inventory { get; set; }
        public string CurrentWeapon { get; set; }

        public static void SaveGame(Player player, string filePath)
        {
            try
            {
                // Spieler-Daten in ein SaveManager-Objekt umwandeln
                var save = new SaveManager
                {
                    Name = player.Name,
                    Level = player.Level,
                    Experience = player.Experience,
                    Gold = player.Gold,
                    Health = player.Health,
                    AttackPower = player.AttackPower,
                    MaxHealth = player.MaxHealth,
                    Round = player.Round,
                    Inventory = player.Inventory.Select(i => i.Name).ToList(),
                    CurrentWeapon = player.CurrentWeapon?.Name
                };

                // Serialisieren in JSON
                string json = JsonSerializer.Serialize(save, new JsonSerializerOptions { WriteIndented = true });

                // Schreiben in die Datei
                File.WriteAllText(filePath, json);
                Console.WriteLine("Spielstand erfolgreich gespeichert!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
            }
        }
    }
}
