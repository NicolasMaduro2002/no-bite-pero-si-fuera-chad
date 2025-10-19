using System.IO;

namespace PokemonTextGame
{
    public class SaveManager
    {
        public void Save(Player p)
        {
            using (var w = new StreamWriter("save.txt"))
            {
                w.WriteLine(p.Name);
                foreach (var m in p.Team)
                    w.WriteLine($"{m.Name},{m.HP},{m.Attack},{m.Level},{m.Evolution}");
            }
        }

        public Player Load()
        {
            if (!File.Exists("save.txt")) return null;
            var lines = File.ReadAllLines("save.txt");
            var p = new Player(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                p.Team.Add(new Monster(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), parts[4]));
            }
            return p;
        }
    }
}
