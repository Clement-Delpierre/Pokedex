// https://www.pokemon.com/us/pokedex/543

using Pokedex.Models.Moves.Normal;
using Pokedex.Models.Moves.Poison;
using Pokedex.Models.Moves.Bug;
using Pokedex.Models.Moves.Dark;
using Pokedex.Models.Moves.Grass;
using Pokedex.Models.Moves.Rock;
using Pokedex.Models.Moves.Fighting;
using Pokedex.Models.Moves.Ghost;
using Pokedex.Models.Moves.Steel;
using Pokedex.Models.Types;

namespace Pokedex.Models.Pokemons.Bug
{
    internal class Venipede : Pokemon
    {
        #region Variables
        private static Pokemon? _instance = null;
        #endregion

        #region Getters + Setters
        public static Pokemon Instance
        {
            get { return _instance ?? (_instance = new Venipede()); }
        }
        #endregion
        
        #region Constructors
        private Venipede()
            : base(
                543,
                "Venipede",
                "Venipatte",
                TypeBug.Instance,
                TypePoison.Instance,
                4,
                53,
                "Centipede Pokémon",
                "Pokémon Chilopode",
                "Its fangs are highly venomous. If this Pokémon finds prey it thinks it can eat, it leaps for them without any thought of how things might turn out.",
                "Ses crocs sont extrêmement venimeux. Dès qu’il voit une proie à son goût, il bondit sur elle sans penser aux conséquences.",
                30,
                45,
                59,
                30,
                39,
                57
            )
        { }
        #endregion

        #region Methods
        /// <summary>
        /// Implementation of the parent method
        /// </summary>
        /// <seealso cref="Pokemon.InitMoveList"/>
        public override void InitMoveList()
        {
            this._moveList = new List<PokeMove>();
            this._moveList.Add(TakeDown.Instance);
            this._moveList.Add(DoubleEdge.Instance);
            this._moveList.Add(PoisonSting.Instance);
            this._moveList.Add(Twineedle.Instance);
            this._moveList.Add(PinMissile.Instance);
            this._moveList.Add(Bite.Instance);
            this._moveList.Add(SolarBeam.Instance);
            this._moveList.Add(Snore.Instance);
            this._moveList.Add(SludgeBomb.Instance);
            this._moveList.Add(Rollout.Instance);
            this._moveList.Add(FuryCutter.Instance);
            this._moveList.Add(Pursuit.Instance);
            this._moveList.Add(HiddenPower.Instance);
            this._moveList.Add(RockSmash.Instance);
            this._moveList.Add(Facade.Instance);
            this._moveList.Add(SecretPower.Instance);
            this._moveList.Add(SignalBeam.Instance);
            this._moveList.Add(PoisonTail.Instance);
            this._moveList.Add(Payback.Instance);
            this._moveList.Add(PoisonJab.Instance);
            this._moveList.Add(RockClimb.Instance);
            this._moveList.Add(BugBite.Instance);
            this._moveList.Add(Venoshock.Instance);
            this._moveList.Add(Round.Instance);
            this._moveList.Add(Hex.Instance);
            this._moveList.Add(StruggleBug.Instance);
            this._moveList.Add(Steamroller.Instance);
            this._moveList.Add(Infestation.Instance);
            this._moveList.Add(SteelRoller.Instance);
            this._moveList.Add(SkitterSmack.Instance);
        }
        #endregion
    }
}