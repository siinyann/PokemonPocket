using System;
using System.Collections.Generic;

namespace PokemonPocket
{
    public class PokemonMaster
    {
        public string name { get; set; }
        public int number { get; set; }
        public string evolve { get; set; }

        public PokemonMaster(string name, int number, string evolve)
        {
            this.name = name;
            this.number = number;
            this.evolve = evolve;
        }
    }
}