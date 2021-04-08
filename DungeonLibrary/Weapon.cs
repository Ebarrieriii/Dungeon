using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //fields
        private int _minDmg;
        //properties
        public int MaxDmg { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public bool IsTwoHanded { get; set; }
        public int MinDmg
        {
            get { return _minDmg; }
            set
            {
                if (value > 0 && value <= MaxDmg)
                {
                    _minDmg = value;
                }
                else
                {
                    _minDmg = 1;
                }
            }
        }
        //ctors
        public Weapon(int minDmg, int maxDmg, string name, int bonusHitChance, bool isTwoHanded)
        {
            MaxDmg = maxDmg;
            MinDmg = minDmg;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }
        //methods
        public override string ToString()
        {
            return string.Format("{0}\t{1}-{2} Damage\n" +
                "Bonus Hit: {3}%\t{4}",
                Name, MinDmg, MaxDmg, BonusHitChance,
                IsTwoHanded ? "Two-Handed" : "One-Handed");
        }

    }
}
