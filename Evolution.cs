using System;
using System.Collections.Generic;

namespace PokemonTextGame
{
    public class Evolution
    {
        Dictionary<string, string> mapaEvoluciones = new Dictionary<string, string>
        {
            {"Chilindio", "Chileno"},
            {"Veneco", "Maduro"},
            {"Plantín", "Plantón"},
            {"Electrozo", "Electrozón"},
            {"Draguito", "Dragónix"}
        };

        public void IntentarEvolucion(Monster m)
        {
            if (m.Level >= 5 && mapaEvoluciones.ContainsKey(m.Name))
            {
                m.Name = mapaEvoluciones[m.Name];
                m.HP += 10;
                m.Attack += 5;
                m.Evolution = "";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{m.Name} ha evolucionado!");
                Console.ResetColor();
            }
        }
    }
}
