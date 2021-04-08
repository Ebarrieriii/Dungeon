using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void DoAtk(Character attacker, Character defender)
        {
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(1500);

            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                int dmgDealt = attacker.CalcDamage();
                defender.Life -= dmgDealt;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {dmgDealt} damage!");
                Console.ResetColor();
            } else
            {
                Console.WriteLine($"{attacker.Name} missed!");
            } //end else
        } //end doAtk

        public static void DoBattle(Player selectedPlayer, Monster monster)
        {
            DoAtk(selectedPlayer, monster);
            if (monster.Life > 0)
            {
                DoAtk(monster, selectedPlayer);
            }
        }

    }//end Class
} //end namespace
