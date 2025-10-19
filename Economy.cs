using System;

namespace PokemonTextGame
{
    public class Economy
    {
        public int Money = 100;
        public int Potions = 0;

        public void Shop(Player p, Dialogue d)
        {
            d.Show("chad/mercado_chad.txt");
            Console.WriteLine("1. Comprar poción (20 monedas)\n2. Comprar piedra rara (100 monedas)\n3. Salir");
            var o = Console.ReadLine();
            if (o == "1" && Money >= 20)
            {
                Money -= 20;
                Potions++;
                Console.WriteLine("Compraste una poción.");
            }
            else if (o == "2" && Money >= 100)
            {
                Money -= 100;
                p.Inventory.Add(new Item("Piedra Rara", "Permite evolución especial", true));
                Console.WriteLine("Obtienes una Piedra Rara.");
            }
            else if (o == "1" || o == "2") Console.WriteLine("No tienes suficiente dinero.");

            if (Money >= 500) Console.WriteLine("¡Logro desbloqueado: Millonario!");
        }
    }
}
