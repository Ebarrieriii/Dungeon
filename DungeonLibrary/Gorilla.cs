using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Gorilla : Monster
    {
        //fields

        //prop
        public bool IsDemonic { get; set; }
        //ctor
        public Gorilla(string name, int life, int maxLife, int hitChance, int block, int minDmg, int maxDmg, string description, bool isDemonic) : base(name, life, maxLife, hitChance, block, minDmg, maxDmg, description)
        {
            IsDemonic = isDemonic;
        }

        public Gorilla()
        {
            MaxLife = 10;
            MaxDamage = 4;
            Name = "Black Gorilla";
            Life = 10;
            HitChance = 30;
            Block = 10;
            MinDamage = 2;
            Description = "Uhhh ohhhh, a gorilla.";
            IsDemonic = false;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + (IsDemonic ? "Demonic!" : "Standard");
        }

        public override int CalcBlock()
        {
            int demonicBlock = Block;

            if (IsDemonic)
            {
                demonicBlock += demonicBlock / 2;
            }
            return demonicBlock;
        }
    }
}
