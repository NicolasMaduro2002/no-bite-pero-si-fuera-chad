using System;
using System.Collections.Generic;

namespace PokemonTextGame
{
    public class Map
    {
        string[,] grid = {
            {"Bosque", "Ruta 1", "Ciudad Central"},
            {"Cueva", "Ruta 2", "Gimnasio"},
            {"Lago", "Ruta 3", "Mercado"}
        };

        char[,] visualMap = {
            {'B','1','C'},
            {'V','2','G'},
            {'L','3','M'}
        };

        int x = 0;
        int y = 0;
        Random r = new Random();
        HashSet<string> zonasVisitadas = new HashSet<string>();

        public void Mover(Player p, Economy e, Dialogue d, List<Monster> wilds, Evolution evo, List<Mission> misiones, List<Achievement> logros)
        {
            Console.WriteLine("Mover: w/a/s/d");
            var dir = Console.ReadLine();
            if (dir == "w" && x > 0) x--;
            else if (dir == "s" && x < 2) x++;
            else if (dir == "a" && y > 0) y--;
            else if (dir == "d" && y < 2) y++;
            var loc = grid[x, y];
            Console.WriteLine($"Estás en {loc}");
            zonasVisitadas.Add(loc);

            if (zonasVisitadas.Count == 9) logros.Find(l => l.Title == "Explorador")?.Desbloquear();

            if (loc.Contains("Ruta") || loc == "Bosque" || loc == "Cueva") new Battle().Start(p, wilds, evo, logros);
            if (loc == "Mercado")
            {
                e.Shop(p, d);
                misiones.Find(m => m.Title == "Compra una poción")?.Completar();
            }
            if (loc == "Gimnasio")
            {
                d.Show("chad/gym_chad.txt");
                misiones.Find(m => m.Title == "Derrota al jefe")?.Completar();
            }
            if (loc == "Ciudad Central") d.Show("chad/story.txt");
            if (loc == "Lago" && misiones.TrueForAll(m => m.Completed)) new Battle().BossFight(p, evo, logros);
        }

        public void MostrarMapa()
        {
            Console.WriteLine("MAPA:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == x && j == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[X]");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"[{visualMap[i,j]}]");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
