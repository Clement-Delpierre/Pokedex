namespace Pokedex.Models.Events
{
    internal class EventMove : Event
    {
        #region Properties

        /// <summary>
        /// The Pokemon which moves
        /// </summary>
        public PokeInstance Pokemon { get; }

        /// <summary>
        /// The move used by the Pokemon
        /// </summary>
        public PokeMove MoveUsed { get; }

        #endregion

        #region Constructor

        public EventMove(PokeInstance pokemon, PokeMove move)
        {
            this.Pokemon = pokemon;
            this.MoveUsed = move;
        }

        #endregion

        #region Methods

        public override void Apply()
        {
            if (Pokemon.IsKo)
                return;

            Console.WriteLine($"{Pokemon.Nickname} uses {MoveUsed.NameFr}!");
        }

        #endregion
    }
}
