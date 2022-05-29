// https://www.pokemon.com/us/pokedex/294

using Pokedex.Models.Moves.Normal;
using Pokedex.Models.Moves.Fire;
using Pokedex.Models.Moves.Ice;
using Pokedex.Models.Moves.Electric;
using Pokedex.Models.Moves.Dark;
using Pokedex.Models.Moves.Grass;
using Pokedex.Models.Moves.Ground;
using Pokedex.Models.Moves.Rock;
using Pokedex.Models.Moves.Fighting;
using Pokedex.Models.Moves.Ghost;
using Pokedex.Models.Moves.Water;
using Pokedex.Models.Moves.Psy;
using Pokedex.Models.Types;

namespace Pokedex.Models.Pokemons.Normal
{
    internal class Loudred : Pokemon
    {
        #region Variables
        private static Pokemon? _instance = null;
        #endregion

        #region Getters + Setters
        public static Pokemon Instance
        {
            get { return _instance ?? (_instance = new Loudred()); }
        }
        #endregion
        
        #region Constructors
        private Loudred()
            : base(
                294,
                "Loudred",
                "Ramboum",
                TypeNormal.Instance,
                10,
                405,
                "Big Voice Pokémon",
                "Pokémon Grosse Voix",
                "The force of this Pokémon’s loud voice isn’t just the sound—it’s also the wave of air pressure that blows opponents away and damages them.",
                "Ses hurlements n’affectent pas seulement l’ouïe ; ils provoquent aussi une onde de choc qui balaie les ennemis et leur inflige des dégâts.",
                84,
                71,
                43,
                71,
                43,
                48
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
            this._moveList.Add(Pound.Instance);
            this._moveList.Add(MegaPunch.Instance);
            this._moveList.Add(FirePunch.Instance);
            this._moveList.Add(IcePunch.Instance);
            this._moveList.Add(ThunderPunch.Instance);
            this._moveList.Add(Stomp.Instance);
            this._moveList.Add(MegaKick.Instance);
            this._moveList.Add(Headbutt.Instance);
            this._moveList.Add(BodySlam.Instance);
            this._moveList.Add(DoubleEdge.Instance);
            this._moveList.Add(Bite.Instance);
            this._moveList.Add(Flamethrower.Instance);
            this._moveList.Add(IceBeam.Instance);
            this._moveList.Add(Blizzard.Instance);
            this._moveList.Add(Strength.Instance);
            this._moveList.Add(SolarBeam.Instance);
            this._moveList.Add(Earthquake.Instance);
            this._moveList.Add(FireBlast.Instance);
            this._moveList.Add(RockSlide.Instance);
            this._moveList.Add(Snore.Instance);
            this._moveList.Add(MudSlap.Instance);
            this._moveList.Add(IcyWind.Instance);
            this._moveList.Add(Rollout.Instance);
            this._moveList.Add(DynamicPunch.Instance);
            this._moveList.Add(HiddenPower.Instance);
            this._moveList.Add(ShadowBall.Instance);
            this._moveList.Add(RockSmash.Instance);
            this._moveList.Add(Uproar.Instance);
            this._moveList.Add(Facade.Instance);
            this._moveList.Add(BrickBreak.Instance);
            this._moveList.Add(SecretPower.Instance);
            this._moveList.Add(HyperVoice.Instance);
            this._moveList.Add(Astonish.Instance);
            this._moveList.Add(Overheat.Instance);
            this._moveList.Add(RockTomb.Instance);
            this._moveList.Add(WaterPulse.Instance);
            this._moveList.Add(ZenHeadbutt.Instance);
            this._moveList.Add(SmackDown.Instance);
            this._moveList.Add(Synchronoise.Instance);
            this._moveList.Add(Round.Instance);
            this._moveList.Add(EchoedVoice.Instance);
            this._moveList.Add(Incinerate.Instance);
            this._moveList.Add(Retaliate.Instance);
            this._moveList.Add(Bulldoze.Instance);
            this._moveList.Add(PowerUpPunch.Instance);
            this._moveList.Add(StompingTantrum.Instance);
        }
        #endregion
    }
}