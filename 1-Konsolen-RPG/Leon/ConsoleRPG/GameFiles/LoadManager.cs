using System;
using System.IO;
using System.Text.Json;

namespace ConsoleRPG.GameFile
{
    public class LoadManager
    {
        const string space = "      ";
        public static SaveManager LoadGame(string filePath)
        {
            try
            {
                // Prüfen, ob die Datei existiert
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"{space}Kein gespeicherter Spielstand gefunden.");
                    return null;
                }

                // Datei einlesen
                string json = File.ReadAllText(filePath);

                // JSON in SaveManager-Objekt deserialisieren
                SaveManager save = JsonSerializer.Deserialize<SaveManager>(json);

                Console.WriteLine($"{space}Spielstand erfolgreich geladen!");
                return save;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{space}Fehler beim Laden: {ex.Message}");
                return null;
            }
        }
    }
}
