// https://www.pokemon.com/us/pokedex/159

using Pokedex.Models.Moves.Normal;
using Pokedex.Models.Moves.Ice;
using Pokedex.Models.Moves.Dark;
using Pokedex.Models.Moves.Water;
using Pokedex.Models.Moves.Ground;
using Pokedex.Models.Moves.Rock;
using Pokedex.Models.Moves.Bug;
using Pokedex.Models.Moves.Fighting;
using Pokedex.Models.Moves.Steel;
using Pokedex.Models.Moves.Dragon;
using Pokedex.Models.Moves.Ghost;
using Pokedex.Models.Types;

namespace Pokedex.Models.Pokemons.Water
{
    internal class Croconaw : Pokemon
    {
        #region Variables
        private static Pokemon? _instance = null;
        #endregion

        #region Getters + Setters
        public static Pokemon Instance
        {
            get { return _instance ?? (_instance = new Croconaw()); }
        }
        #endregion
        
        #region Constructors
        private Croconaw()
            : base(
                159,
                "Croconaw",
                "Crocrodil",
                TypeWater.Instance,
                11,
                250,
                "Big Jaw Pokémon",
                "Pokémon Mâchoire",
                "Once Croconaw has clamped its jaws on its foe, it will absolutely not let go. Because the tips of its fangs are forked back like barbed fishhooks, they become impossible to remove when they have sunk in.",
                "Une fois que Crocrodil a refermé sa mâchoire sur son ennemi, il est impossible de le faire lâcher prise. Ses crocs sont recourbés comme des hameçons et ne peuvent pas être retirés une fois enfoncés.",
                65,
                80,
                80,
                59,
                63,
                58
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
            this._moveList.Add(MegaPunch.Instance);
            this._moveList.Add(IcePunch.Instance);
            this._moveList.Add(Scratch.Instance);
            this._moveList.Add(Cut.Instance);
            this._moveList.Add(MegaKick.Instance);
            this._moveList.Add(Headbutt.Instance);
            this._moveList.Add(BodySlam.Instance);
            this._moveList.Add(Thrash.Instance);
            this._moveList.Add(DoubleEdge.Instance);
            this._moveList.Add(Bite.Instance);
            this._moveList.Add(WaterGun.Instance);
            this._moveList.Add(HydroPump.Instance);
            this._moveList.Add(Surf.Instance);
            this._moveList.Add(IceBeam.Instance);
            this._moveList.Add(Blizzard.Instance);
            this._moveList.Add(Strength.Instance);
            this._moveList.Add(Dig.Instance);
            this._moveList.Add(Rage.Instance);
            this._moveList.Add(Waterfall.Instance);
            this._moveList.Add(RockSlide.Instance);
            this._moveList.Add(Slash.Instance);
            this._moveList.Add(Snore.Instance);
            this._moveList.Add(MudSlap.Instance);
            this._moveList.Add(IcyWind.Instance);
            this._moveList.Add(FuryCutter.Instance);
            this._moveList.Add(DynamicPunch.Instance);
            this._moveList.Add(IronTail.Instance);
            this._moveList.Add(HiddenPower.Instance);
            this._moveList.Add(Crunch.Instance);
            this._moveList.Add(AncientPower.Instance);
            this._moveList.Add(RockSmash.Instance);
            this._moveList.Add(Whirlpool.Instance);
            this._moveList.Add(Uproar.Instance);
            this._moveList.Add(Facade.Instance);
            this._moveList.Add(FocusPunch.Instance);
            this._moveList.Add(Superpower.Instance);
            this._moveList.Add(BrickBreak.Instance);
            this._moveList.Add(SecretPower.Instance);
            this._moveList.Add(Dive.Instance);
            this._moveList.Add(RockTomb.Instance);
            this._moveList.Add(DragonClaw.Instance);
            this._moveList.Add(WaterPulse.Instance);
            this._moveList.Add(AquaTail.Instance);
            this._moveList.Add(ShadowClaw.Instance);
            this._moveList.Add(IceFang.Instance);
            this._moveList.Add(Round.Instance);
            this._moveList.Add(ChipAway.Instance);
            this._moveList.Add(Scald.Instance);
            this._moveList.Add(WaterPledge.Instance);
            this._moveList.Add(PowerUpPunch.Instance);
        }
        #endregion
    }
}