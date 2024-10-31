# Textbasiertes Rollenspiel in der Konsole
## Hauptaufgabe
Einführung in Klassen, Vererbung, zufällige Ereignisse und Spielschleifen.
In dieser Aufgabe entwickelst du ein einfaches, textbasiertes Rollenspiel, bei dem der Spieler als Held gegen Monster kämpft, seine Fähigkeiten verbessert und Ressourcen sammelt.
Das Spiel ist rundenbasiert und wird über die Konsole gesteuert.
## Grundlegende Spielidee
Der Spieler beginnt als einfacher Held und kann sich durch das Besiegen von Monstern Erfahrungspunkte und Gold verdienen, um seinen Charakter zu verbessern. 
Er kann verschiedene Aktionen wählen, wie Angreifen, Heilen oder Fliehen.
Ziel ist es, stärker zu werden und mächtigere Monster zu besiegen.
## Schritt 1: Grundstruktur und Klassen
1. **Erstelle die Klassenstruktur:**
   - **Klasse `Character`** (Basisklasse für alle Charaktere im Spiel):
     - Eigenschaften: `Name` (string), `Health` (int), `AttackPower` (int)
     - Methoden: `Attack()` (führt einen Angriff durch und gibt den Schaden zurück), `TakeDamage(int damage)` (reduziert die Gesundheit des Charakters um den Schaden)
   - **Klasse `Player`** (abgeleitet von `Character`):
     - Zusätzliche Eigenschaften: `Level` (int), `Experience` (int), `Gold` (int)
     - Methoden: `GainExperience(int xp)`, `LevelUp()` (erhöht die Werte des Spielers bei jedem Levelaufstieg), `Heal()` (stellt eine bestimmte Anzahl an Lebenspunkten wieder her)
   - **Klasse `Monster`** (abgeleitet von `Character`):
     - Zusätzliche Eigenschaften: `RewardGold` (int), `RewardXP` (int)
     - Eine `Monster`-Instanz hat variable Stärke und Schwächen, je nach Level des Spielers.
## Schritt 2: Spielmechanik und grundlegende Funktionalität
1. **Kampfmechanik erstellen:**
   - Erstelle eine Methode `Fight(Player player, Monster monster)`, die einen rundenbasierten Kampf zwischen Spieler und Monster simuliert.
   - Der Spieler kann wählen, ob er angreifen, heilen oder fliehen möchte.
   - Wenn der Spieler angreift, erleidet das Monster Schaden. Wenn das Monster noch lebt, greift es zurück.
   - Bei Sieg: Der Spieler erhält Gold und Erfahrungspunkte entsprechend den Werten des Monsters.
   - Bei Niederlage: Das Spiel wird beendet.
2. **Spieleraktionen implementieren:**
   - Implementiere eine einfache Textschnittstelle für den Spieler mit den Optionen:
     - `1. Kämpfen`: Startet einen Kampf gegen ein zufällig generiertes Monster.
     - `2. Heilen`: Stellt eine bestimmte Menge Lebenspunkte wieder her (Kosten: Gold oder Ressourcen).
     - `3. Inventar anzeigen`: Zeigt den aktuellen Status (Gold, Gesundheit, Level, Erfahrung).
     - `4. Flüchten`: Rennt vor dem aktuellen Gegner weg (Keine Erfahrung, Gold, etc. erhalten).
     - `5. Spiel beenden`
## Beispiel-Menü
> Willkommen zu deinem Abenteuer!
> Wähle eine Aktion:
> 1. Kämpfen
> 2. Heilen ( X Leben für Y Gold )
> 3. Inventar anzeigen
> 4. Flüchten
> 5. Spiel beenden
## Schritt 3: Erweiterte Features
2. **Schwierigkeitsgrad und Fortschritt:**
   - Erhöhe die Schwierigkeit der Monster basierend auf dem Level des Spielers.
   - Zufällige Monster mit variablen Attributen, die stärker werden, wenn der Spieler aufsteigt.
3. **Zufällige Ereignisse:**
   - Füge zufällige Ereignisse hinzu, die gelegentlich während des Spiels auftreten können, z.B. Schatzkisten finden, Gold verlieren, zufällig auf stärkere Monster stoßen.
## Bonusaufgaben
1. **Inventarsystem hinzufügen:**
   - Der Spieler kann zusätzlich Gegenstände wie Heiltränke, Waffen und Rüstungen finden oder kaufen.
   - Erstelle eine `Item`-Klasse mit Unterklassen für verschiedene Arten von Gegenständen.
   - Der Spieler kann Heiltränke verwenden, um im Kampf oder außerhalb des Kampfes Lebenspunkte wiederherzustellen.
2. **Stadtbereich mit Einkaufsmöglichkeiten:**
   - Implementiere eine Option, bei der der Spieler in eine Stadt zurückkehren kann, um Gold gegen Heiltränke, Waffen und Rüstungen zu tauschen.
3. **Speichern und Laden des Spiels:**
   - Implementiere die Möglichkeit, den Spielfortschritt in einer Datei zu speichern und beim Neustart des Programms wieder zu laden.
4. **Verschiedene Monstertypen:**
   - Füge verschiedene Arten von Monstern mit eigenen Fähigkeiten und Angriffsmechanismen hinzu (z.B. Goblins, Drachen, Skelette).
## Zusatz++
1. **Magie und Fähigkeiten:**
   - Erstelle eine `Ability`-Klasse, die der Spieler nutzen kann (z.B. Feuerball, Schild). Fähigkeiten verbrauchen Magiepunkte, die sich nur langsam regenerieren.
   - Welche Fähigkeiten es gibt ist dir überlassen (z.B. Schaden, Heilung, Schild, Gold, Flucht)
   - Der Charakter braucht natürlich nun auch Mana
   - Mana generiert sich langsam nach besiegen eines Gegners oder um einen Fixen Wert durch Tränke / Heilen für Gold
