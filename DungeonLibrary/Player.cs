using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        //fields
        //properties
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        //ctors
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Name = name;
            Block = block;
            HitChance = hitChance;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        } //end Player()
        //methods
        public override string ToString()
        {
            return string.Format("-=-= {0} -=-=\n" +
                "Life: {1}/{2}\n" +
                "Hit Chance: {3}%\n" +
                "Weapon: \n{4}\n" +
                "Block: {5}\n" +
                "Description: {6}\n",
                Name, Life, MaxLife, HitChance, EquippedWeapon, Block, CharacterRace);
        }//end ToString()

        public override int CalcDamage()
        {
            Random rand = new Random();
            int dmg = rand.Next(EquippedWeapon.MinDmg, EquippedWeapon.MaxDmg + 1);
            return dmg;
        } //end CalcDamage()

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        } //end int CalcHitChance()


    } //end class
} //end namespace
