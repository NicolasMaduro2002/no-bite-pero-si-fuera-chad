namespace PokemonTextGame
{
    public class Mission
    {
        public string Title;
        public string Description;
        public bool Completed;

        public Mission(string title, string desc)
        {
            Title = title;
            Description = desc;
            Completed = false;
        }

        public void Completar()
        {
            Completed = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"¡Misión completada: {Title}!");
            Console.ResetColor();
        }
    }
}
