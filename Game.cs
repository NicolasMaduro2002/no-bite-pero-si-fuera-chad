using System;
using System.Media;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTextGame
{
    public class Game
    {
        private Player jugador;
        private Map mapa;
        private Economy economia;
        private Dialogue dialogos;
        private Evolution evolucion;
        private SaveManager guardado;
        private List<Monster> monstruosSalvajes;
        private List<Mission> misiones;
        private List<Achievement> logros;

        public async Task StartAsync()
        {
            MostrarBanner();
            if (!ValidarClave()) return;

            await IniciarMusicaAsync();

            dialogos = new Dialogue();
            dialogos.Show("chad/introduccion_chad.txt");

            guardado = new SaveManager();
            jugador = await CargarJugadorAsync();

            mapa = new Map();
            economia = new Economy();
            evolucion = new Evolution();
            monstruosSalvajes = CargarMonstruos();
            misiones = CargarMisiones();
            logros = CargarLogros();


            await BuclePrincipalAsync();
        }
        private void MostrarBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== C# Game By TepidJungle ===");
            Console.ResetColor();
        }

        private bool ValidarClave()
        {
            Console.Write("Ingresa la clave secreta para jugar: ");
            var clave = Console.ReadLine();
            if (clave != "monstruo2025")
            {
                Console.WriteLine("Clave incorrecta. Saliendo...");
                return false;
            }
            return true;
        }

        private async Task IniciarMusicaAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    var player = new System.Media.SoundPlayer("chad/touhou.wav");
                    player.PlayLooping();
                }
                catch
                {
                    Console.WriteLine("No se pudo cargar la música.");
                }
            });
        }

        private async Task<Player> CargarJugadorAsync()
        {
            Console.WriteLine("¿Cargar partida guardada? (s/n)");
            var cargar = Console.ReadLine();
            if (cargar == "s")
            {
                var p = guardado.Load();
                if (p != null) return p;
                Console.WriteLine("No se encontró partida. Creando nuevo jugador...");
            }

            Console.Write("Nombre del jugador: ");
            var nombre = Console.ReadLine();
            return new Player(nombre);
        }

        private List<Monster> CargarMonstruos()
        {
            var lista = new List<Monster>();
            var lineas = System.IO.File.ReadAllLines("chad/monsters.txt");
            foreach (var linea in lineas)
            {
                var partes = linea.Split(',');
                lista.Add(new Monster(partes[0], int.Parse(partes[1]), int.Parse(partes[2]), 1, partes[3]));
            }
            return lista;
        }

        private List<Mission> CargarMisiones()
        {
            return new List<Mission>
            {
                new Mission("Explora el bosque", "Encuentra un monstruo en el bosque."),
                new Mission("Compra una poción", "Visita el mercado y compra una poción."),
                new Mission("Derrota al jefe", "Vence al jefe del gimnasio.")
            };
        }

        private List<Achievement> CargarLogros()
        {
            return new List<Achievement>
            {
                new Achievement("Primer monstruo", "Captura tu primer monstruo."),
                new Achievement("Explorador", "Visita todas las zonas del mapa."),
                new Achievement("Campeón", "Derrota al jefe final."),
                new Achievement("Coleccionista", "Obtén 10 monstruos distintos."),
                new Achievement("Millonario", "Alcanza 500 monedas.")
            };
        }

        private async Task BuclePrincipalAsync()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n1. Moverse");
                Console.WriteLine("2. Ver equipo");
                Console.WriteLine("3. Ver dinero");
                Console.WriteLine("4. Ver mapa");
                Console.WriteLine("5. Ver inventario");
                Console.WriteLine("6. Ver misiones");
                Console.WriteLine("7. Ver logros");
                Console.WriteLine("8. Guardar partida");
                Console.WriteLine("9. Salir");
                Console.WriteLine("10. Chat global (EN CONSTRUCCIÓN)");
                Console.ResetColor();

                var opcion = Console.ReadLine();
                if (opcion == "1") mapa.Mover(jugador, economia, dialogos, monstruosSalvajes, evolucion, misiones, logros);
                else if (opcion == "2") jugador.MostrarEquipo();
                else if (opcion == "3") Console.WriteLine($"Dinero: {economia.Money} monedas");
                else if (opcion == "4") mapa.MostrarMapa();
                else if (opcion == "5") jugador.MostrarInventario();
                else if (opcion == "6") MostrarMisiones();
                else if (opcion == "7") MostrarLogros();
                else if (opcion == "8") guardado.Save(jugador);
                else if (opcion == "9") break;
            }
        }

        private void MostrarMisiones()
        {
            Console.WriteLine("Misiones:");
            foreach (var m in misiones)
            {
                var estado = m.Completed ? "✔" : "✘";
                Console.WriteLine($"{estado} {m.Title} - {m.Description}");
            }
        }

        private void MostrarLogros()
        {
            Console.WriteLine("Logros:");
            foreach (var l in logros)
            {
                var estado = l.Unlocked ? "✔" : "✘";
                Console.WriteLine($"{estado} {l.Title} - {l.Description}");
            }
        }

    }
}
