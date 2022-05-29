namespace Pokedex.Models.Events
{
    internal class EventChangePokemon : Event
    {
        #region Properties

        /// <summary>
        /// The player who changes Pokemon
        /// </summary>
        public Trainer Trainer { get; }

        /// <summary>
        /// The Pokemon index in the Pokemon list
        /// </summary>
        public int PokemonIndex { get; }

        #endregion

        #region Constructor

        public EventChangePokemon(Trainer trainer, int index)
        {
            Trainer = trainer;
            PokemonIndex = index;
        }

        #endregion

        #region Methods

        public override void Apply()
        {
            if (Trainer.Pokemons[PokemonIndex].IsKo)
                return;
            Trainer.ActivePokemon = Trainer.Pokemons[PokemonIndex];
            Console.WriteLine($"Let's go {Trainer.ActivePokemon.Nickname}!");
            Console.WriteLine();
        }

        #endregion
    }
}
