using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonApp
{
    class DungeonApp
    {
        static void Main(string[] args)
        {
            Console.Title = ("=-=-DUNGEON OF DOOM!-=-=");
            Console.WriteLine("Welcome to your journey!");

            //TODO 1. Create a variable that will keep track of player score
            int score = 0;

            //TODO 2. Create the Weapon
            Weapon w1 = new Weapon(1, 15, "Abyssal Whip", 5, false);
            Weapon w2 = new Weapon(1, 6, "Rusted Knife", 3, false);
            Weapon w3 = new Weapon(1, 12, "Long Sword", 7, true);
            Weapon w4 = new Weapon(1, 10, "Combat Knife", 10, false);
            Weapon w5 = new Weapon(1, 15, "Sword", 7, false);
            Weapon w6 = new Weapon(1, 30, "Dragon Breath", 20, false);

            //Put created weapons into an array
            Weapon[] weaponList = { w1, w2, w3, w4, w5 };
            //randomly select weapon
            Random randWeapon = new Random();
            int weapon = randWeapon.Next(weaponList.Length);
            Weapon mainWeapon = weaponList[weapon];

            //TODO 3. Create players

            Player viking = new Player("Viking", 70, 10, 100, 100, Race.Viking, mainWeapon);
            Player chief = new Player("Chief", 90, 20, 120, 120, Race.Fallen, w5);
            Player deathWing = new Player("Deathwing", 95, 50, 200, 200, Race.Dragon, w6);
            Player elf = new Player("Elf", 60, 10, 100, 100, Race.Elf, w6);
            Player caveMan = new Player("Caveman", 40, 50, 300, 300, Race.Caveman, w2);
            Player orc = new Player("Orc", 80, 20, 150, 150, Race.Orc, w3);
            Player gnome = new Player("A cute Gnome", 100, 10, 50, 50, Race.Gnome, w2);
            Player native = new Player("Native", 70, 20, 100, 100, Race.Native, w5);
            Player goblin = new Player("Goblin", 75, 15, 80, 80, Race.Goblin, w1);



            //TODO 4. Create the outer dowhile loop that manages game
            Console.WriteLine("\nSelect your player\n" +
                        "1) Viking\n" +
                        "2) Chief\n" +
                        "3) Deathwing\n" +
                        "4) Elf\n" +
                        "5) Caveman\n" +
                        "6) Orc\n" +
                        "7) Gnome\n" +
                        "8) Native\n" +
                        "9) Goblin\n");


            ConsoleKey userPlayer = Console.ReadKey(true).Key;
            Console.Clear();
            Player selectedPlayer = viking;
            switch (userPlayer)
            {
                case ConsoleKey.D1:
                    selectedPlayer = viking;
                    Console.WriteLine($"You have selected {selectedPlayer}!");
                    break;
                case ConsoleKey.D2:
                    selectedPlayer = chief;
                    Console.WriteLine($"You have selected {selectedPlayer}!");
                    break;
                case ConsoleKey.D3:
                    selectedPlayer = deathWing;
                    Console.WriteLine($"You have selected {selectedPlayer}!");
                    break;
                case ConsoleKey.D4:
                    selectedPlayer = elf;
                    Console.WriteLine($"You have selected {selectedPlayer}!");
                    break;
                case ConsoleKey.D5:
                    selectedPlayer = caveMan;
                    Console.WriteLine($"You have selected {selectedPlayer}!");
                    break;
                case ConsoleKey.D6:
                    selectedPlayer = orc;
                    Console.WriteLine($"You have selected {selectedPlayer}!");
                    break;
                case ConsoleKey.D7:
                    selectedPlayer = gnome;
                    Console.WriteLine($"You have selected {selectedPlayer}!");
                    break;
                case ConsoleKey.D8:
                    selectedPlayer = native;
                    Console.WriteLine($"You have selected {selectedPlayer}!");
                    break;
                case ConsoleKey.D9:
                    selectedPlayer = goblin;
                    Console.WriteLine($"You have selected {selectedPlayer}!");
                    break;
                default:
                    Console.WriteLine("Please select a valid option!");
                    break;
            }

            //counter
            bool exit = false;

            do
            {
                //TODO 5. Write a method for getting room description
                Console.WriteLine(GetRoom());
                //TODO 6. Create monsters for the player to compete against
                //create monsters here
                Rabbit r1 = new Rabbit("Baby Rabbit", 12, 12, 50, 20, 2, 6, "That's no ordinary rabbit", true);
                Rabbit r2 = new Rabbit();
                Vampire v1 = new Vampire("The Count", 25, 25, 40, 30, 2, 12, "One Vampire");
                Gorilla g1 = new Gorilla();
                Gorilla g2 = new Gorilla("Demonic Gorilla", 60, 60, 45, 15, 4, 13, "Uh oh, That's a big gorilla", true);
                //store monsters in collection
                Monster[] monsters = { r1, r2, v1, g1, g2 };
                //randomly generate the monster to compete against
                Random rand = new Random();
                int randNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randNbr];
                //show the monster in the room
                Console.WriteLine("\nIn this room: " + monster.Name);
                //TODO 7. Create a loop for the game menu

                bool reload = false;
                do
                {


                    //TODO 8. Create the menu for interaction with the monster and write it to the screen
                    #region Menu
                    Console.WriteLine("\nChoose an action:\n" +
                        "1) Attack\n" +
                        "2) Run\n" +
                        "3) Player Information\n" +
                        "4) Monster Information\n" +
                        "5) Exit Application");
                    #endregion
                    //TODO 8a. Wait and Capture the user input for their selection in the menu
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    //TODO 8b. Create a switch that houses the functionality based on user choice
                    Console.Clear();
                    switch (userChoice)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("Attack!");
                            Combat.DoBattle(selectedPlayer, monster);
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            } //end if
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("Runnnnnn!!");
                            Console.WriteLine($"{monster.Name} attacks you as you run!");
                            Combat.DoAtk(monster, selectedPlayer);
                            Console.WriteLine();
                            reload = true;
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("Player Information: ");
                            Console.WriteLine(selectedPlayer);
                            Console.WriteLine("Monsters Defeated: " + score);
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine("Monster Information: ");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.D5:
                            Console.WriteLine("Disgraceful...");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("You have chosen an improper action...");
                            break;
                    }
                    if (selectedPlayer.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You are dead!\a");
                        Console.ResetColor();
                        exit = true;
                    }

                } while (!exit && !reload);
            } while (!exit);
            Console.WriteLine($"Game over!\n" +
                        $"You have defeated {score} monsters!");
            //TODO 9. If the player has died, we are going to give them a message here about how many monsters they have defeated

        } //end main
        //TODO 10. Create the GetRoom() and plug it in here. Make sure to call the GetRoom() in TODO 4

        private static string GetRoom()
        {
            string[] rooms = { "Need a little inspiration for your players' next bout of dungeon delving? Find yourself with a dungeon map with many featureless rooms? You can solve those problems by consulting the Dungeon Room Description Generator. This generator contains 100 brief descriptions of dungeon rooms that you can place in your adventures as is or use as a starting point for encounters you design. Simply click on the button below to get a random room description in the form of read-aloud text for your players.",
            "A huge stewpot hangs from a thick iron tripod over a crackling fire in the center of this chamber. A hole in the ceiling allows some of the smoke from the fire to escape, but much of it expands across the ceiling and rolls down to fill the room in a dark fog. Other details are difficult to make out, but some creature must be nearby, because it smells like a good soup is cooking.",
            "Rats inside the room shriek when they hear the door open, then they run in all directions from a putrid corpse lying in the center of the floor. As these creatures crowd around the edges of the room, seeking to crawl through a hole in one corner, they fight one another. The stinking corpse in the middle of the room looks human, but the damage both time and the rats have wrought are enough to make determining its race by appearance an extremely difficult task at best.",
            "This room is shattered. A huge crevasse shears the chamber in half, and the ground and ceilings are tilted away from it. It's as though the room was gripped in two enormous hands and broken like a loaf of bread. Someone has torn a tall stone door from its hinges somewhere else in the dungeon and used it to bridge the 15-foot gap of the chasm between the two sides of the room. Whatever did that must have possessed tremendous strength because the door is huge, and the enormous hinges look bent and mangled.",
            " A pit yawns open before you just on the other side of the door's threshold. The entire floor of the room has fallen into a second room beneath it. Across the way you can spy a door in the wall now 15 feet off the rubble-strewn floor, and near the center of the room stands a thick column of mortared stone that appears to hold the spiral staircase that leads down to what was the lower level.",
            "This small chamber seems divided into three parts. The first has several hooks on the walls from which hang dusty robes. An open curtain separates that space from the next, which has a dry basin set in the floor. Beyond that lies another parted curtain behind which you can see several straw mats in a semicircle pointing toward a statue of a dog-headed man.",
            "The burble of water reaches your ears after you open the door to this room. You see the source of the noise in the far wall: a large fountain artfully carved to look like a seashell with the figure of a seacat spewing clear water into its basin.",
            "A rusted portcullis stands just beyond the door. Looking into the room, you see three other exits, similarly blocked by portcullises. Four skeletons dressed in aged clothing and rusting armor lie on the floor in the room against the walls. They seem in poses of repose rather than violence.",
            "A flurry of bats suddenly flaps through the doorway, their screeching barely audible as they careen past your heads. They flap past you into the rooms and halls beyond. The room from which they came seems barren at first glance.",
            "A pit yawns open before you just on the other side of the door's threshold. The entire floor of the room has fallen into a second room beneath it. Across the way you can spy a door in the wall now 15 feet off the rubble-strewn floor, and near the center of the room stands a thick column of mortared stone that appears to hold the spiral staircase that leads down to what was the lower level."};
            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];

            return room;


        } //end GetRoom()

    } // end class

} //end namespace
