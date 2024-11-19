using ConsoleRPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Battle
{
    public static class MonsterFactory
    {
        public static Monster GenerateMonster(int round)
        {
            int monsterHealth = 10 + (round * 2);
            int monsterAttack = 3 + (round / 2);
            int monsterRewardGold = 5 + (round * 2);
            int monsterRewardXP = 10 + (round * 2);

            var monster = new Monster("Random", monsterHealth, monsterAttack, monsterRewardGold, monsterRewardXP);
            monster.Name = GetRandomMonsterName();

            return monster;
        }

        private static string GetRandomMonsterName()
        {
            List<string> names = new List<string>()
    {
        "Schattenspinner", "Dunkelklauer", "Blutfresser", "Frostwächter",
        "Flammenrufer", "Nebelheuler", "Todeskriecher", "Seelenverschlinger",
        "Sturmklauen", "Nachtschleicher", "Knochenbrecher", "Feuerschlund",
        "Schattenmähne", "Blutkriecher", "Eiswyrm", "Giftzahn",
        "Steinriese", "Schreckenswolf", "Wüstenstachel", "Schlammkralle",
        "Dornenbestie", "Donnerhorn", "Aschekrieger", "Lichtbann",
        "Flusswürger", "Felsenschnitter", "Geisterheuler", "Windpeitscher",
        "Dunkelhydra", "Glutdrache", "Seelenschnitter", "Höhlenläufer",
        "Flusswandler", "Knochenschatten", "Schwingenbestie", "Feuerstachel",
        "Eisgolem", "Seelengräber", "Waldphantom", "Sturmbrecher",
        "Finsternisjäger", "Nebelschnitter", "Schattenwolf", "Kriegsoger",
        "Felsenseele", "Todesklaue", "Sumpfhexe", "Flammenwandler",
        "Nachtgreif", "Blutpeitscher", "Sturmhexe", "Wellenklaue",
        "Höllenwyrm", "Ascheschleicher", "Kristallläufer", "Schreckenswyrm",
        "Frostklaue", "Geisterbestie", "Todesrufer", "Eisriese",
        "Schattenwyrm", "Waldwüter", "Donnerdrache", "Blutschlund",
        "Steinläufer", "Wüstenkralle", "Flammenklaue", "Schattenschnitter",
        "Nebelgeist", "Dornenklaue", "Sumpfbestie", "Höhlendämon",
        "Schattengreif", "Gluthydra", "Feuerhexe", "Kristallgolem",
        "Lichtjäger", "Aschenrufer", "Nebelgänger", "Seelenpeitscher",
        "Knochenwyrm", "Nachtdämon", "Felsenschatten", "Sturmschnitter",
        "Eisdrache", "Donnerläufer", "Schreckensschnitter", "Todesmähne",
        "Geisterwolf", "Schattenläufer", "Blutwyrm", "Dornenrufer",
        "Kristallhexe", "Waldseele", "Höllenschreiter", "Schlammspalter"
    };

            Random random = new Random();
            return names[random.Next(names.Count)];
        }

    }

}
