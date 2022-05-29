using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
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
        private Trainer _activePlayer;
        private Trainer _opponent;
        private PokeInstance _activePokemon;
        private PokeInstance _onGroundPokemonA;
        private PokeInstance _onGroundPokemonB;

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
            this._activePlayer = this._playerA = playerA;
            this._opponent = this._playerB = playerB;
            this._onGroundPokemonA = this.PlayerA.Pokemons[0];
            this._onGroundPokemonB = this.PlayerB.Pokemons[0];

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
			this._weather.OnTurnStart(this);

            // Code to implement for project
            // To calc damage, use DamageHandler.CalcDamage(attacker, defender, move, this._weather);
            // To apply damage, use pokemonInstance.TakeDamage(damage)
            // To get trainer pokemons, use trainer.Pokemons
            // To check if a trainer has at least on pokemon fit for combat, use trainer.CanFight

            // You can simulate each trainer turn, or develop a simple AI to simulate the second trainer's turn
            // (simple means not like Arthur, okay ?)

            // Change the weather:
            // this.Weather = newWeather.Instance;

            // turn begin
            Console.WriteLine($"It's {this._activePlayer}'s turn !");

            // display menu
            DisplayMenu();

            // user choice between 1 and 5
            int choice;
            Console.Write("Your choice : ");
            while (int.TryParse(Console.ReadLine(), out choice) is false || choice < 1 || choice > 5)
            { Console.WriteLine("Invalid input"); }

            // Process the user input
            switch (choice)
            {
                case 1:
                    this._activePlayer.ShowPokeFightStat(this._onGroundPokemonA); break; // display the active pokemon
                case 2:
                    this._activePlayer.ShowAllPokemons(); break; // display the pokemons of the active player
                case 3:
                    Console.WriteLine($"The opponent {this._opponent.Name} has {this._opponent.Pokemons.Count()} pokemons.");
                    Console.Write($"The active pokemon of the opponent is {this._onGroundPokemonB.Pokemon.Name}");
                    Console.Write($"and it has {this._onGroundPokemonB.Hp * 100 / (double)this._onGroundPokemonB.CalcHp():F2}%");
                    Console.WriteLine($" hp."); break; // see opponent's information
                case 4:
                    PokemonChange(); break; // pokemon change
                case 5:
                    SelectMove(); break; // trainer use a move
            }
            // appel à la méthode de precision : HasTouch ou autres
            // appel à calcDamage
            // effectuer les changements // appliquer dommages et effet

            this._weather.OnTurnEnd(this);
        }

        // swap the active player and the opponent
        public void changePlayer()
        {
            Trainer tmp = new Trainer("tmp");
            tmp = this._activePlayer;
            this._activePlayer = this._opponent;
            this._opponent = tmp;
            ChangeActivePokemon();
        }

        // update the active pokemon
        public void ChangeActivePokemon()
        {
            if (this._activePlayer == _playerA)
                this._activePokemon = this._onGroundPokemonA;
            else
                this._activePokemon = this._onGroundPokemonB;
        }
        public void DisplayMenu()
        {
            Console.WriteLine("What do you want to do :");
            Console.WriteLine("1/ See your active pokemon");
            Console.WriteLine("2/ See information on your pokemons");
            Console.WriteLine("3/ See the opponent");
            Console.WriteLine("4/ Change pokemon");
            Console.WriteLine("5/ Use a move");
        }

        // performs the pokemon change
        public bool PokemonChange()
        {
            bool isOkay = ConfirmChange();
            // next step to change if isOkay is true, else back to the menu
            if (isOkay)
            {
                Console.WriteLine("Which pokemon do you choose ?");

                // show the pokemon list (name + hp)
                this.PlayerA.ShowPokeList(PlayerA);

                // user choice between 1 and the last pokemon
                int pokemonChoice = 0;
                while (int.TryParse(Console.ReadLine(), out pokemonChoice) is false
                    || pokemonChoice > this.PlayerA.Pokemons.Count() || pokemonChoice < 1)
                { Console.WriteLine("Invalid input"); }
                Console.WriteLine();

                // pokemon change if the pokemon chosen is not the active pokemon, error message else
                if (this._onGroundPokemonA != this.PlayerA.Pokemons[pokemonChoice - 1])
                {
                    this._onGroundPokemonA = this.PlayerA.Pokemons[pokemonChoice - 1];
                    Console.WriteLine($"Let's go {this._onGroundPokemonA.Pokemon.Name}!\n");
                    return true;
                }
                Console.WriteLine("You must chose another pokemon!\n");
                return false;
            }
            return false;
        }

        // user input to confirm or not the pokemon change
        public bool ConfirmChange()
        {
            Console.WriteLine("Are you sure to want to change pokemon ? [y/n]");
            Console.Write("Your choice : ");

            // user choice between 'y' or 'n'
            char isOkay;
            while (char.TryParse(Console.ReadLine(), out isOkay) is false || isOkay != 'y' && isOkay != 'n')
            { Console.WriteLine("Invalid input"); }

            return isOkay == 'y';
        }

        // user input to chose a move then record it
        public void SelectMove()
        {
            Console.WriteLine("Which move do you choose?");

            // show the move list
            int nbMoves = 0;
            for (int i = 0; this._onGroundPokemonA.Moves[i] is not null; nbMoves++, i++)
            {
                Console.WriteLine($"\t{i + 1}/ {this._onGroundPokemonA.Moves[i]!.NameFr}");
                Console.WriteLine($"{this._onGroundPokemonA.Moves[i]!.NameEn})");
            }
            Console.WriteLine("\t0/ Exit\n");

            // user choice between 0 and the last move (0 for exit and back to the menu)
            int moveChoice;
            while (int.TryParse(Console.ReadLine(), out moveChoice) is false || moveChoice < 0
                || moveChoice > nbMoves)
            { Console.WriteLine("Invalid input"); }
            Console.WriteLine();

            // record the selected move or exit
            if (moveChoice != 0)
            {  }
        }

        #endregion
    }
}