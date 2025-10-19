using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var juego = new PokemonTextGame.Game();
        await juego.StartAsync();
    }
}
