namespace PokemonTextGame
{
    public class Achievement
    {
        public string Title;
        public string Description;
        public bool Unlocked;

        public Achievement(string title, string desc)
        {
            Title = title;
            Description = desc;
            Unlocked = false;
        }

        public void Desbloquear()
        {
            if (!Unlocked)
            {
                Unlocked = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"¡Logro desbloqueado: {Title}!");
                Console.ResetColor();
            }
        }
    }
}
