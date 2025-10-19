using System;
using System.Collections.Generic;

namespace PokemonTextGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<Monster> Team { get; set; }
        public List<Item> Inventory { get; set; }

        public Player(string name)
        {
            Name = name ?? "Jugador";
            Team = new List<Monster>();
            Inventory = new List<Item>();
            Team.Add(new Monster("Chilindio", 50, 7, 1, "Chileno"));
        }

        public void MostrarEquipo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Equipo de {Name}:");
            foreach (var m in Team)
            {
                Console.WriteLine($"{m.Name} - Nivel: {m.Level} - HP: {m.HP} - ATK: {m.Attack}");
            }
            Console.ResetColor();
        }

        public Monster ElegirMonstruo()
        {
            Console.WriteLine("Elige tu monstruo:");
            for (int index = 0; index < Team.Count; index++)
            {
                Console.WriteLine($"{index + 1}. {Team[index].Name}");
            }

            int seleccion;
            while (true)
            {
                Console.Write("Número: ");
                var entrada = Console.ReadLine();
                if (int.TryParse(entrada, out seleccion) && seleccion >= 1 && seleccion <= Team.Count)
                    break;
                Console.WriteLine("Entrada inválida. Intenta de nuevo.");
            }

            return Team[seleccion - 1];
        }

        public void Capturar(Monster m)
        {
            Team.Add(new Monster(m.Name, m.HP + 10, m.Attack + 1, 1, m.Evolution));
            Console.WriteLine($"{m.Name} se unió a tu equipo.");
        }

        public void MostrarInventario()
        {
            Console.WriteLine("Inventario:");
            foreach (var item in Inventory)
            {
                var color = item.IsRare ? ConsoleColor.Magenta : ConsoleColor.Gray;
                Console.ForegroundColor = color;
                Console.WriteLine($"{item.Name} - {item.Effect}");
                Console.ResetColor();
            }
        }
    }
}
