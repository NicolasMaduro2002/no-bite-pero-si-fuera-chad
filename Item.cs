namespace PokemonTextGame
{
    public class Item
    {
        public string Name;
        public string Effect;
        public bool IsRare;

        public Item(string name, string effect, bool rare)
        {
            Name = name;
            Effect = effect;
            IsRare = rare;
        }
    }
}
