namespace PokemonTextGame
{
    public class Monster
    {
        public string Name;
        public int HP;
        public int Attack;
        public int Level;
        public int XP;
        public string Evolution;

        public Monster(string name, int hp, int atk, int level = 1, string evo = "")
        {
            Name = name;
            HP = hp;
            Attack = atk;
            Level = level;
            XP = 0;
            Evolution = evo;
        }

        public void GanarXP(int cantidad, Evolution evo)
        {
            XP += cantidad;
            if (XP >= Level * 10)
            {
                XP = 0;
                Level++;
                HP += 5;
                Attack += 2;
                evo.IntentarEvolucion(this);
            }
        }
    }
}
