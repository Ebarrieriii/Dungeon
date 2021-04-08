using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Vampire : Monster
    {
        public DateTime HourChangeBack { get; set; }

        //ctors
        public Vampire(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            HourChangeBack = DateTime.Now;
            if (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18)
            {
                HitChance += 10; //use the assignment operator because we want to add to the already established HitChance value
                Block += 10;
                MinDamage += 1;
                MaxDamage += 2;
            } //end if
        } // end ctor
        //methods
        public override string ToString()
        {
            return base.ToString() + (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18 ? "It looks quite angry and strong..." : "In the daylight, it's looking kind of weak!");
        } //end ToString()
    }
}
