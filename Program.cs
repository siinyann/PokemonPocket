using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPocket
{
    class Program
    {
        public void DisplayMenu()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Welcome to Pokemon Pocket App");
            Console.WriteLine("*****************************");
            Console.WriteLine("(1). Add pokemon to my pocket");
            Console.WriteLine("(2). List pokemon(s) in my pocket");
            Console.WriteLine("(3). Check if I can evolve pokemon");
            Console.WriteLine("(4). Evolve pokemon");
            Console.WriteLine("(5). Remove pokemon from my pocket");
            Console.Write("Please only enter [1,2,3,4,5] or Q to quit: ");
        }

        static void Main(string[] args)
        {
            //PokemonMaster list for checking pokemon evolution availability.
            List<PokemonMaster> pokemonMasters = new List<PokemonMaster>()
            {
                new PokemonMaster("Pikachu", 2, "Raichu"),
                new PokemonMaster("Eevee", 3, "Flareon"),
                new PokemonMaster("Charmander", 1, "Charmeleon")
            };

            //Use "Environment.Exit(0);" if you want to implement an exit of the console program
            //Start your assignment 1 requirements below.
            List<Pokemon> PokemonList = new List<Pokemon>();

            int pokemonCount = 0;
            int pikachuCount = 0;
            int charmanderCount = 0;
            int eeveeCount = 0;
            string pokemonId = "0";

            while (true)
            {
                Program program = new Program();
                program.DisplayMenu();
                string input = Console.ReadLine();

                if (input == "1")
                {

                    if (pokemonCount < 10)
                    {
                        Console.Write("Enter Pokemon's Name: ");
                        string pokemonName = Console.ReadLine();
                        pokemonName = pokemonName.ToLower();

                        if (pokemonName != "pikachu" && pokemonName != "charmander" && pokemonName != "eevee")
                        {
                            Console.WriteLine("Invalid input. Please key in pikachu, charmander or eevee.");
                            continue;
                        }

                        try
                        {
                            Console.Write("Enter Pokemon's HP: ");
                            int pokemonHp = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Pokemon's Exp: ");
                            int pokemonExp = Convert.ToInt32(Console.ReadLine());

                            if (pokemonName == "charmander")
                            {
                                charmanderCount++;
                                pokemonId = "C" + Convert.ToString(charmanderCount);
                                    Charmander charmander =new Charmander(pokemonName,pokemonHp,pokemonExp,pokemonId);
                                PokemonList.Add (charmander);
                            }

                            else if (pokemonName == "eevee")
                            {
                                eeveeCount++;
                                pokemonId = "E" + Convert.ToString(eeveeCount);
                                Eevee eevee = new Eevee(pokemonName,pokemonHp,pokemonExp,pokemonId);
                                PokemonList.Add(eevee);
                            }

                            else if (pokemonName == "pikachu")
                            {
                                pikachuCount++;
                                pokemonId = "P" + Convert.ToString(pikachuCount);
                                Pokemon pikachu =new Pikachu(pokemonName,pokemonHp,pokemonExp,pokemonId);
                                PokemonList.Add (pikachu);
                            }

                            pokemonCount++;
                            // Console.WriteLine(pokemonCount);
                        }

                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("String cannot be converted to Int. Please key in an integer.");
                        }

                    }

                    else 
                    {
                        Console.WriteLine("You have reach the maximum of 10 pokemons in your pokemon pocket. Please do not add any pokemons in your pokemon pocket.");
                    }
                }

                else if (input == "2")
                {
                    if (pokemonCount > 0)
                    {
                        PokemonList = PokemonList.OrderBy(x => x.Hp).ToList();

                        foreach (var pokemon in PokemonList)
                        {
                            Console.WriteLine("----------------------------");
                            Console.WriteLine($"Name: {pokemon.Name}");
                            Console.WriteLine($"Hp: {pokemon.Hp}");
                            Console.WriteLine($"Exp: {pokemon.Exp}");
                            pokemon.Skill();
                            Console.WriteLine("----------------------------");
                        }
                    }

                    else
                    {
                        Console.WriteLine("You have 0 pokemons in your pokemon pocket. Please add pokemons to your pokemon pocket.");
                    }

                }

                else if (input == "3")
                {

                    foreach (var pokemon in PokemonList)
                    {

                        if (pokemon.Name == "charmander")
                        {
                            if (charmanderCount % 1 == 0)
                            {
                                Console.WriteLine("Charmander --> Charmeleon");
                            }
                        }

                        else if (pokemon.Name == "eevee")
                        {
                            if (eeveeCount % 3 == 0)
                            {
                                Console.WriteLine("Eevee --> Flareon");
                            }
                        }

                        else if (pokemon.Name == "pikachu")
                        {
                            if (pikachuCount % 2 == 0)
                            {
                                Console.WriteLine("Pikachu --> Raichu");
                            }
                        }

                    }

                }

                else if (input == "4")
                {
                    
                    foreach (var pokemon in PokemonList)
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine($"Id: {pokemon.Id}");
                        Console.WriteLine($"Name: {pokemon.Name}");
                        Console.WriteLine($"Hp: {pokemon.Hp}");
                        Console.WriteLine($"Exp: {pokemon.Exp}");
                        pokemon.Skill();
                        Console.WriteLine("------------------------------");
                    }

                    Console.Write("Enter the pokemon Id of the pokemon that you would like to evolve: ");
                    string evolveInput = Console.ReadLine();
                    evolveInput = evolveInput.ToUpper();

                    foreach (var pokemon in PokemonList)
                    {
                        if (pokemon.Id == evolveInput)
                        {
                            if (pokemon.Name == "pikachu" && pokemon.Id == evolveInput)
                            {
                                if (pikachuCount % 2 == 0)
                                {
                                    pokemon.Name = "Raichu";
                                    pokemon.Hp = 0;
                                    pokemon.Exp = 0;
                                }
                            }
                            else if (pokemon.Name == "charmander" && pokemon.Id == evolveInput)
                            {
                                if (charmanderCount % 1 == 0)
                                {
                                    pokemon.Name = "Charmeleon";
                                    pokemon.Hp = 0;
                                    pokemon.Exp = 0;
                                }
                            }
                            else if (pokemon.Name == "eevee" && pokemon.Id == evolveInput)
                            {
                                if (eeveeCount % 3 == 0)
                                {
                                    pokemon.Name = "Flareon";
                                    pokemon.Hp = 0;
                                    pokemon.Exp = 0;
                                }
                            }
                        }

                        Console.WriteLine("------------------------------");    
                        Console.WriteLine($"Name: {pokemon.Name}");
                        Console.WriteLine($"Hp: {pokemon.Hp}");
                        Console.WriteLine($"Exp: {pokemon.Exp}");
                        pokemon.Skill();
                        Console.WriteLine("------------------------------");
                    }

                }
                    
                else if (input == "5")
                {

                    foreach (var pokemon in PokemonList)
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine($"Id: {pokemon.Id}");
                        Console.WriteLine($"Name: {pokemon.Name}");
                        Console.WriteLine($"Hp: {pokemon.Hp}");
                        Console.WriteLine($"Exp: {pokemon.Exp}");
                        pokemon.Skill();
                        Console.WriteLine("------------------------------");
                    }

                    Console.Write("Enter the pokemon Id of the pokemon that you would like to delete: ");
                    string deleteInput = Console.ReadLine();
                    deleteInput = deleteInput.ToUpper();
                    var item = PokemonList.SingleOrDefault(x => x.Id == deleteInput);

                    if (item != null)
                    {
                        PokemonList.Remove(item); 
                        pokemonCount--;
                    }

                    foreach (var pokemon in PokemonList)
                    {
                        Console.WriteLine("------------------------------");    
                        Console.WriteLine($"Name: {pokemon.Name}");
                        Console.WriteLine($"Hp: {pokemon.Hp}");
                        Console.WriteLine($"Exp: {pokemon.Exp}");
                        pokemon.Skill();
                        Console.WriteLine("------------------------------");
                    }
                }

                else if (input == "Q" || input == "q")
                {
                    Console.WriteLine("Thank you for using Pokemon Pocket App");
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}
