using System;
using System.Collections.Generic;

namespace PokemonPocket
{
    public class Pokemon
    {
        private string name;
        private int hp;
        private int exp;
        private string id;

        public Pokemon(string name, int hp, int exp,string id)
        {
            this.name = name;
            this.hp = hp;
            this.exp = exp;
            this.id = id;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual void Skill()
        {
            if (name == "pikachu" || name == "Raichu")
            {
                Console.WriteLine("Skill: Lightning Bolt");
            } 
            
            else if (name == "eevee" || name == "Flareon")
            {
                Console.WriteLine("Skill: Run Away");
            }

            else if (name == "charmander" || name == "Charmeleon")
            {
                Console.WriteLine("Skill: Solar Power");
            }
        }
    }

    class Charmander : Pokemon
    {
        public Charmander(string name,int hp,int exp,string id) : base(name,hp,exp,id)
        {
            
        }
    }

    class Eevee: Pokemon
    {
        public Eevee(string name,int hp,int exp,string id) : base(name,hp,exp,id)
        {
           
        }
    }

    class Pikachu: Pokemon
    {
        public Pikachu(string name,int hp,int exp,string id) : base(name,hp,exp,id)
        {
            
        }
    }
}