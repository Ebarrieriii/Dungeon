using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Rabbit : Monster
    {
        public bool IsFluffy { get; set; }

        //ctor
        public Rabbit(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isFluffy) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            //Prop = param
            IsFluffy = isFluffy;
        } // end ctor

        //Create a ctor here that will assemble a Rabbit with values added in for it's properties
        public Rabbit()
        {
            //Set values for each of the properties
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Baby Rabbit";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "It's just a cute little bunny...Why would you want to fight it?";
            IsFluffy = false;
        } // end of ctor

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsFluffy ? "Fluffy" : "Not Fluffy");
        } //end ToString()

        //Override the CalcBlock() to say that if the rabbit is fluffy they get a 50% bonus to their block value
        public override int CalcBlock()
        {
            //Typically when dealing with a method with a return type, you create a variable of that return type, then write the return line, then write the logic to give that variable the appropriate value.
            int calculatedBlock = Block;

            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            } //end CalcBlock()


            return calculatedBlock;
        }
    }
}
