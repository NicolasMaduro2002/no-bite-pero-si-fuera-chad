using System;
using System.Collections.Generic;

namespace PokemonTextGame
{
    public class Battle
    {
        Random r = new Random();

        public void Start(Player p, List<Monster> wilds, Evolution evo, List<Achievement> logros)
        {
            var m = wilds[r.Next(wilds.Count)];
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"¡Un {m.Name} salvaje apareció!");
            Console.ResetColor();
            Console.WriteLine("1. Luchar\n2. Huir");
            var o = Console.ReadLine();
            if (o == "1") Pelea(p, m, evo, logros);
        }

        public void BossFight(Player p, Evolution evo, List<Achievement> logros)
        {
            var boss = new Monster("Zerokron", 120, 20, 10, "");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("¡El jefe final Zerokron aparece!");
            Console.ResetColor();
            Pelea(p, boss, evo, logros);
            logros.Find(l => l.Title == "Campeón")?.Desbloquear();
        }

        void Pelea(Player p, Monster m, Evolution evo, List<Achievement> logros)
        {
            var my = p.ElegirMonstruo();
            while (m.HP > 0 && my.HP > 0)
            {
                m.HP -= my.Attack;
                if (m.HP <= 0) break;
                my.HP -= m.Attack;
            }
            if (my.HP <= 0) Console.WriteLine($"{my.Name} fue derrotado.");
            else
            {
                Console.WriteLine($"¡{m.Name} fue vencido!");
                my.GanarXP(10, evo);
                Console.WriteLine("¿Capturarlo? (s/n)");
                var c = Console.ReadLine();
                if (c == "s")
                {
                    p.Capturar(m);
                    logros.Find(l => l.Title == "Primer monstruo")?.Desbloquear();
                    if (p.Team.Count >= 10) logros.Find(l => l.Title == "Coleccionista")?.Desbloquear();
                }
            }
        }
    }
}
