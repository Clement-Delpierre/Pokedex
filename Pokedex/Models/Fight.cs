using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Pokedex.Models.Events;
using Pokedex.Models.Weathers;

namespace Pokedex.Models
{
	/// <summary>
	/// Represents a Pokemon Fight between two Trainers
	/// </summary>
	/// <see cref="Trainer"/>
    class Fight
    {
        #region Variables
        private Trainer _playerA;
        private Trainer _playerB;

        private Weather _weather;
        #endregion

        #region Getters + Setters
		/// <summary>
		/// The first player
		/// </summary>
        public Trainer PlayerA
        { get { return this._playerA; } }
        
		/// <summary>
		/// The second player
		/// </summary>
		/// <value></value>
		public Trainer PlayerB
        { get { return this._playerB; } }

		/// <summary>
		/// The current weather effect active
		/// </summary>
        public Weather Weather
        {
            get { return this._weather; }
            set
			{ 
				this._weather.OnExit();
				this._weather = value;
				this._weather.OnEnter();
			}
        }
        #endregion

        #region Constructors
        /// <summary>
		/// The default constructor
		/// </summary>
		/// <param name="playerA">The first player</param>
		/// <param name="playerB">The second player</param>
		public Fight
        (
            Trainer playerA,
            Trainer playerB
        )
        {
            this._playerA = playerA;
            this._playerB = playerB;
            
            this._weather = WeatherClear.Instance;
        }
		
		/// <summary>
		/// Superseeds the default constructor with a Weather paramater
		/// </summary>
		/// <param name="weather"></param>
		/// <inheritdoc cref="Fight(Trainer, Trainer)"/>
		public Fight
		(
			Trainer playerA,
			Trainer playerB,
			Weather weather
		) : this(playerA, playerB)
		{
			this._weather = weather;
		}
        #endregion

        #region Methods
		/// <summary>
		/// Handles the general outline of a fight
		/// </summary>
		/// <returns>The winning player</returns>
        public Trainer DoCombat()
        {
            int turn = 1;

            // Trainers send their first Pokemon on the ground
            _playerA.StartFight();
            _playerB.StartFight();

			// While both players can still fight
            while (this._playerA.CanFight
				   && this._playerB.CanFight)
            {
                this.DoTurn();
                
                turn++;
            }

            return this._playerA.CanFight
                   ? this._playerA
                   : this._playerB;
            
            /* cond ? if_true : if_false */
            
            /* if (this._playerA.CanFight)
             *     return this._playerA;
             * return this._playerB;
             */
        }

		/// <summary>
		/// Handles the finer workings of a singular turn
		/// </summary>
		/// <see cref="DamageHandler.CalcDamage(PokeInstance, PokeInstance, PokeMove, Weather)"/>
		/// <see cref="Trainer.CanFight"/>
		/// <see cref="PokeInstance.TakeDamage(int)"/>
		/// <see cref="Fight.Weather"/>
        private void DoTurn()
        {
			// this._weather.OnTurnStart(this);

            #region Task
            // Code to implement for project
            // To calc damage, use DamageHandler.CalcDamage(attacker, defender, move, this._weather);
            // To apply damage, use pokemonInstance.TakeDamage(damage)
            // To get trainer pokemons, use trainer.Pokemons
            // To check if a trainer has at least on pokemon fit for combat, use trainer.CanFight

            // You can simulate each trainer turn, or develop a simple AI to simulate the second trainer's turn
            // (simple means not like Arthur, okay ?)

            // Change the weather:
            // this.Weather = newWeather.Instance;
            #endregion

            this._playerA.PlayerTurn(_playerB);
            this._playerB.PlayerTurn(_playerA);

            // Pokemon Change First
            if (IsPokemonChange(_playerA))
                this._playerA.Action!.Apply();
            if (IsPokemonChange(_playerB))
                this._playerB.Action!.Apply();

            // Seek the faster Pokemon
            if (_playerA.ActivePokemon!.Pokemon.StatSpeed > _playerB.ActivePokemon!.Pokemon.StatSpeed)
            {
                // Apply the dammage if not pokemon change
                if (!IsPokemonChange(_playerA))
                    ApplyDamage(_playerA, _playerB);
                // Verify if the PokemonB is Alive
                if (!IsDead(_playerB) && !IsPokemonChange(_playerB))
                    ApplyDamage(_playerB, _playerA);
                // Verify if the PokemonB is Alive
                IsDead(_playerA);
            }
            else
            {
                // Apply the dammage if not pokemon change
                if (!IsPokemonChange(_playerB))
                    ApplyDamage(_playerB, _playerA);
                // Verify if the PokemonA is Alive
                if (!IsDead(_playerA) && !IsPokemonChange(_playerA))
                    ApplyDamage(_playerA, _playerB);
                // Verify if the PokemonA is Alive
                IsDead(_playerB);
            }
            // this._weather.OnTurnEnd(this);
        }

        /// <summary>
        /// Display the fight menu
        /// </summary>
        static public void DisplayMenu()
        {
            Console.WriteLine("What do you want to do :");
            Console.WriteLine("1/ See your active Pokemon");
            Console.WriteLine("2/ See information on your Pokemons");
            Console.WriteLine("3/ See the opponent");
            Console.WriteLine("4/ Change Pokemon");
            Console.WriteLine("5/ Use a move");
            Console.WriteLine();
        }

        /// <summary>
        /// Verify if the Trainer performed a Pokemon change
        /// </summary>
        /// <param name="trainer"></param>
        /// <returns></returns>
        public bool IsPokemonChange(Trainer trainer)
        {
            return trainer.Action!.GetType() == typeof(EventChangePokemon);
        }
        #endregion

        /// <summary>
        /// Apply the moves effects and display them
        /// </summary>
        /// <param name="trainer"></param>
        /// <param name="opponent"></param>
        public void ApplyDamage(Trainer trainer, Trainer opponent)
        {
            // Calc damage
            int damage = DamageHandler.CalcDamage(trainer.ActivePokemon!, opponent.ActivePokemon!,
                                                (trainer.Action as EventMove)!.MoveUsed);

            // Change Target's HP
            opponent.ActivePokemon!.TakeDamage(damage);

            // Display the fight
            trainer.Action.Apply();
            Console.Write($"{trainer.ActivePokemon!.Nickname} inflict {damage} ");
            Console.WriteLine($"damages at {opponent.ActivePokemon!.Nickname}");
            Console.WriteLine();
        }

        /// <summary>
        /// Verify if the Trainer's Pokemon is dead and Pokemon change if true
        /// </summary>
        /// <returns>True if dead, false overwise</returns>
        public bool IsDead(Trainer trainer)
        {
            if (!trainer.ActivePokemon!.IsKo)
                return false;
            Console.WriteLine($"Oh, {trainer.ActivePokemon!.Nickname} is dead! You must Pokemon change.");
            Console.WriteLine();

            // Verify that the Trainer has has still a Pokemon alive
            if(!trainer.CanFight)
            {
                Console.WriteLine("Oh no, all Pokemons are KO!");
                return true;
            }
            trainer.Action = trainer.PokemonChange();
            trainer.Action!.Apply();
            return true;
        }
    }
}