namespace Pokedex.Models
{
    internal class Trainer
    {
        #region Variables
        private String _name;
        private List<PokeInstance> _pokemons;
        #endregion

        #region Getters + Setters
        /// <summary>
        /// Trainer's has at least one pokemon not KO
        /// </summary>
        public bool CanFight
        {
            get
            {
                bool canFight = false;
                foreach (PokeInstance pokemon in this._pokemons)
                {
                    if (!pokemon.IsKo)
                        canFight = true;
                }
                return canFight;

                // Same query with LINQ
                /* return this._pokemons
                 *     .Any(pokemon => !pokemon.IsKo);
				 */
            }
        }

        /// <summary>
        /// Trainer's name
        /// </summary>
        public String Name
        {
            get { return this._name; }
        }

        /// <summary>
        /// Trainer's Pokemon
        /// </summary>
        public List<PokeInstance> Pokemons
        {
            get { return this._pokemons; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">Trainer's name</param>
        public Trainer(
            String name
        )
        {
            this._name = name;

            // Init pokemon list
            this._pokemons = new List<PokeInstance>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add pokemon to inventory
        /// </summary>
        /// <param name="pokemon">Pokemon to add</param>
        /// <returns>True if okay, otherwise false</returns>
        public bool AddPokemon(PokeInstance pokemon)
        {
            // If there are less than 6 pokemons, it's possible to add one more
            if (this._pokemons.Count < 6)
            {
                this._pokemons.Add(pokemon);

                return true;
            }
            return false;
        }

        public void ShowAllPokemons()
        {
            foreach (PokeInstance p in this._pokemons)
            {
                Console.WriteLine($"{p.ToString()}\n");
                for (int i = 0; p.Moves[i] is not null; i++)
                { Console.WriteLine($"{i}) {p.Moves[i]}\n"); }
            }
        }

        public void ShowPokeFightStat(PokeInstance pokemon)
        {
            Console.WriteLine($"{pokemon.Pokemon.Name}, {pokemon.Hp}/{pokemon.CalcHp()} HP\n");
            for (int i = 0; pokemon.Moves[i] is not null; i++)
            { Console.WriteLine($"{i + 1}) {pokemon.Moves[i]}\n"); }
        }

        public void ShowPokeList(Trainer player)
        {
            for (int i = 0; i < player.Pokemons.Count; i++)
                Console.WriteLine($"\t{i + 1}/ {player.Pokemons[i].Pokemon.Name}, " +
                    $"{player.Pokemons[i].Hp}/{player.Pokemons[i].CalcHp()} HP");
        }

        #endregion
    }
}
