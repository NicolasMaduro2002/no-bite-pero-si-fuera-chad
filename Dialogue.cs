using System;
using System.IO;

namespace PokemonTextGame
{
    public class Dialogue
    {
        public void Show(string path)
        {
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(line);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }
    }
}
