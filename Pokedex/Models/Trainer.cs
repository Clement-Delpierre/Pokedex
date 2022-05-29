using Pokedex.Models.Events;

namespace Pokedex.Models
{
    internal class Trainer
    {
        #region Variables
        private string _name;
        private List<PokeInstance> _pokemons;
        private PokeInstance? _activePokemon;
        private Event? _action;
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

        /// <summary>
        /// Trainer's active Pokemon
        /// </summary>
        public PokeInstance? ActivePokemon
        {
            get { return this._activePokemon; }
            set { this._activePokemon = value; }
        }

        public Event? Action
        {
            get { return this._action; }
            set { this._action = value; }
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
            this._activePokemon = null;
            this._action = null;
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

        /// <summary>
        /// Display all Trainer's Pokemons's information
        /// </summary>
        public void ShowTeamInformation()
        {
            foreach (PokeInstance p in this._pokemons)
            {
                Console.WriteLine($"{p}\n");
                for (int i = 0; p.Moves[i] is not null; i++)
                    Console.WriteLine($"{i}) {p.Moves[i]}\n");
            }
        }

        /// <summary>
        /// Display the Pokemon list of the player
        /// </summary>
        public void ShowPokeList()
        {
            for (int i = 0; i < this.Pokemons.Count; i++)
            {
                Console.Write($"\t{i + 1}/ {this.Pokemons[i].Pokemon.Name}, ");
                Console.WriteLine($"{this.Pokemons[i].Hp}/{this.Pokemons[i].CalcHp()} HP");
            }
        }

        /// <summary>
        /// Send the first Pokemon
        /// </summary>
        public void StartFight()
        {
            this._activePokemon = this._pokemons[0];
        }

        /// <summary>
        /// Perform the trainer's turn
        /// </summary>
        /// <param name="opponent"></param>
        /// <returns>The event which contain the Trainer's action</returns>
        public void PlayerTurn(Trainer opponent)
        {
            // turn begin
            bool stop = false;
            Console.WriteLine($"It's {this.Name}'s turn!\n");
            
            do // continue while Trainer didn't play
            {
                Fight.DisplayMenu();
                
                // user choice between 1 and 5
                int choice;
                Console.Write("Your choice: ");
                while (int.TryParse(Console.ReadLine(), out choice) is false
                    || choice is < 1 or > 5)
                    Console.WriteLine("Invalid input");
                Console.WriteLine();

                // Process the user input
                switch (choice)
                {
                    case 1: // display the active Pokemon
                        this._activePokemon!.ShowPokeFightStat(); break;
                    case 2: // display the Pokemons of the active player
                        this.ShowTeamInformation(); break;
                    case 3: // see opponent's information
                        Console.WriteLine($"The opponent {opponent.Name} has {opponent.Pokemons.Count} pokemons.");
                        Console.Write($"The active pokemon of the opponent is {opponent.ActivePokemon!.Pokemon.Name}");
                        Console.Write($" and it has {opponent.ActivePokemon!.Hp * 100 / (double)opponent.ActivePokemon!.CalcHp():F2}%");
                        Console.WriteLine($" HP.\n");
                        break;
                    case 4: // Pokemon change
                        stop = (Action = PokemonChange()) != null; break;
                    case 5: // trainer's Pokemon use a move
                        stop = (Action = SelectMove()) != null; break;
                }
            } while (stop == false);
        }

        /// <summary>
        /// Select the active Pokemon change
        /// </summary>
        /// <returns>The event which contain the Trainer's action</returns>
        public EventChangePokemon? PokemonChange()
        {
            bool isOkay = true;

            // confirm change only if the active pokemon is alive
            if (!this._activePokemon!.IsKo)
            {
                isOkay = ConfirmChange();
                // if false, back to the menu
                if (!isOkay)
                    return null;
            }

            Console.WriteLine("Which Pokemon do you choose?");

            // show the Pokemon list (name + HP)
            this.ShowPokeList();

            // user choice between 1 and the last Pokemon, the pokemon have to be alive
            int pokemonChoice;
            do
            {
                while (int.TryParse(Console.ReadLine(), out pokemonChoice) is false
                    || pokemonChoice > this.Pokemons.Count
                    || pokemonChoice < 1)
                    Console.WriteLine("Invalid input");
                if (this._pokemons[pokemonChoice - 1]!.IsKo)
                    Console.WriteLine("Chose a Pokemon alive!");
                Console.WriteLine();
            } while (this._pokemons[pokemonChoice - 1]!.IsKo);
            

            // return the event if the pokemon chosen is neither the active pokemon nor KO, send an error message else
            if (this._activePokemon != this._pokemons[pokemonChoice - 1]
                && !this._pokemons[pokemonChoice - 1].IsKo)
            {
                return new EventChangePokemon(this, pokemonChoice - 1);
            }
            Console.WriteLine("You must chose another Pokemon!\n");
            return null;
        }

        /// <summary>
        /// User input to confirm the active Pokemon change
        /// </summary>
        /// <returns>True if okay, overwise false</returns>
        static public bool ConfirmChange()
        {
            Console.WriteLine("Are you sure to want to change pokemon? [y/n]");
            Console.Write("Your choice : ");

            // user choice between 'y' or 'n'
            char isOkay;
            while (char.TryParse(Console.ReadLine(), out isOkay) is false
                || isOkay is not 'y' and not 'n')
                Console.WriteLine("Invalid input");
            Console.WriteLine();

            return isOkay == 'y';
        }

        /// <summary>
        /// User input to chose a Pokemon's move
        /// </summary>
        /// <returns>The event which contain the Trainer's action</returns>
        public EventMove? SelectMove()
        {
            Console.WriteLine("Which move do you choose?");

            // show the move list
            int nbMoves = 0;
            for (int i = 0; this._activePokemon!.Moves[i] is not null; nbMoves++, i++)
            {
                Console.Write($"\t{i + 1}/ {this._activePokemon.Moves[i]!.NameFr}");
                Console.WriteLine($" ({this._activePokemon.Moves[i]!.NameEn})");
            }
            Console.WriteLine("\t0/ Exit\n");

            // user choice between 0 and the last move (0 for exit and back to the menu)
            int moveChoice;
            while (int.TryParse(Console.ReadLine(), out moveChoice) is false
                || moveChoice < 0
                || moveChoice > nbMoves)
                Console.WriteLine("Invalid input");
            Console.WriteLine();

            // record the selected move or exit
            if (moveChoice != 0)
                return new EventMove(this._activePokemon, this._activePokemon.Moves[moveChoice - 1]!);
            return null;
        }
        #endregion
    }
}
