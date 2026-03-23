using System;

namespace DungeonGame
{
    class Program
    {
        static int health = 3;

        static bool keyIronDoor = false;
        static bool keyGoldenDoor = false;
        static bool keySilverDoor = false;
        static bool keyBronzeDoor = false;

        static string adventurerName = "";
        static string gender = "";

        static bool strong = false;
        static bool tall = false;
        static bool intimidating = false;
        static bool quick = false;
        static bool small = false;
        static bool beauty = false;

        static int strength = 1; // str 2 = rusty ironsword // str 3 = goblinsword // str 4 = ironsword
        static int arrows = 0;
        static int potion = 0;
        static bool bow = false;

        static int textSpeed = 25;

        static void Main(string[] args)
        {
            StartGame();
        }

        static void Narrate(string text, int delay = -1)
        {
            if (delay == -1)
            {
                delay = textSpeed;
            }

            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }

            Console.WriteLine();
        }

        static void Pause(int ms = 700)
        {
            System.Threading.Thread.Sleep(ms);
        }

        static void ShowStartArt()
        {
            Console.WriteLine(@"
██╗      ██████╗ ███████╗████████╗    ██╗███╗   ██╗    ██████╗ ██╗   ██╗███╗   ██╗ ██████╗ ███████╗ ██████╗ ███╗   ██╗
██║     ██╔═══██╗██╔════╝╚══██╔══╝    ██║████╗  ██║    ██╔══██╗██║   ██║████╗  ██║██╔════╝ ██╔════╝██╔═══██╗████╗  ██║
██║     ██║   ██║███████╗   ██║       ██║██╔██╗ ██║    ██║  ██║██║   ██║██╔██╗ ██║██║  ███╗█████╗  ██║   ██║██╔██╗ ██║
██║     ██║   ██║╚════██║   ██║       ██║██║╚██╗██║    ██║  ██║██║   ██║██║╚██╗██║██║   ██║██╔══╝  ██║   ██║██║╚██╗██║
███████╗╚██████╔╝███████║   ██║       ██║██║ ╚████║    ██████╔╝╚██████╔╝██║ ╚████║╚██████╔╝███████╗╚██████╔╝██║ ╚████║
╚══════╝ ╚═════╝ ╚══════╝   ╚═╝       ╚═╝╚═╝  ╚═══╝    ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ╚══════╝ ╚═════╝ ╚═╝  ╚═══╝
");
        }

        static void ResetAdventurer()
        {
            health = 3;

            keyIronDoor = false;
            keyGoldenDoor = false;
            keySilverDoor = false;
            keyBronzeDoor = false;

            adventurerName = "";
            gender = "";

            strong = false;
            tall = false;
            intimidating = false;
            quick = false;
            small = false;
            beauty = false;

            strength = 1;
            arrows = 0;
            potion = 0;
            bow = false;
        }

        static void StartGame()
        {
            ResetAdventurer();

            Console.Clear();
            ShowStartArt();
            Pause(1200);

            Narrate("You wake up in a dark dungeon.");
            Narrate("You don't have any memory of how you got here.");
            Narrate("You try to remember your name.");
            Narrate("...");
            Console.Write("Your name is: ");

            adventurerName = Console.ReadLine().Trim();

            while (string.IsNullOrWhiteSpace(adventurerName))
            {
                Console.Write("Please enter a valid name: ");
                adventurerName = Console.ReadLine().Trim();
            }

            while (true)
            {
                Narrate("You try to remember your gender.");
                Narrate("...");
                Console.Write("Your gender (Male or Female): ");

                gender = Console.ReadLine().Trim().ToUpper();

                if (gender == "MALE")
                {
                    strong = true;
                    tall = true;
                    intimidating = true;

                    Narrate("You are a man. You look at your big hands that seem to have fought many battles.");
                    Narrate("You are tall and strong.");
                    break;
                }
                else if (gender == "FEMALE")
                {
                    quick = true;
                    small = true;
                    beauty = true;

                    Narrate("You are a woman. You remember seeing yourself in the mirror.");
                    Narrate("You are short and quick.");
                    break;
                }
                else
                {
                    Narrate("Invalid input. Please type only Male or Female.\n");
                }
            }

            Console.WriteLine();
            Narrate($"Welcome to LostInDungeon, {adventurerName}.");
            Narrate($"Health: {health}");
            Narrate("As you stand up and try to orient yourself, you notice you got robbed.");
            Narrate("All you have right now are the rags you wear.");
            Narrate("You hear voices nearby, maybe fellow adventurers that will rescue you?");
            Narrate("There are two paths ahead: LEFT or RIGHT.");
            Console.Write("Choose a path or WAIT: ");

            string dungeonStart = Console.ReadLine().Trim().ToUpper();

            if (dungeonStart == "LEFT")
            {
                SkeletonRoom();
            }
            else if (dungeonStart == "RIGHT")
            {
                GoblinRoom();
            }
            else
            {
                Narrate("You chose to wait and hope that whoever comes will have mercy with you.");
                Narrate("Three Adventurer approach and a woman says:'See I told, u didnt kill. Stupid Idiots.' ");
                Narrate("You are trapped and try to run trough them but as you are in rags and unnarmed you get overwhelmed by the Men");
                Narrate("As you try to fight back the Woman approaches you and you feel a stab in your heart as your vision goes black.");
                EndGame();
            }
        }

        static void SkeletonRoom()
        {
            Console.WriteLine();
            Narrate("You enter a Room with bones on the ground and a single one armed Skeleton which is facing the other way.");
            Narrate("Torches burn on the walls.");
            Narrate("There is a chest in the middle of the room, and a large stone beside it.");
            Narrate("The only other exit is behind the skeleton.");
            Narrate("You can try to SNEAK around the skeleton.");
            Narrate("Or you can try to SMASH it with the stone.");
            Console.Write("Choose SNEAK or SMASH: ");

            string skeletonRoomDecision = Console.ReadLine().Trim().ToUpper();

            if (skeletonRoomDecision == "SNEAK")
            {
                Narrate("You decide that everything has been terrifying enough already.");
                Narrate("You carefully sneak through the room.");
                Narrate("You have already crossed half the room when the skeleton suddenly turns around and unleashes a piercing scream as he sees you.");
                Narrate("You can try to RUN or SMASH its skull with the stone.");
                Console.Write("Type RUN or SMASH: ");

                string runOrSmash = Console.ReadLine().Trim().ToUpper();

                if (runOrSmash == "RUN")
                {
                    if (quick)
                    {
                        Narrate("You unleash an extraordinary sprint.");
                        Narrate("As you reach the exit, you glance back and see that two more skeletons have risen because of the scream.");
                        Narrate("If you weren't as quick as you are, you would have been trapped.");
                        CorridorAfterSkeleton();
                    }
                    else
                    {
                        Narrate("You sprint for the exit, but two more skeletons rise because of the scream.");
                        Narrate("One rises near the one at chest.");
                        Narrate("The other rises directly in front of you, blocking the exit.");
                        Narrate("You try to fight with your bare hands, but without a weapon you cannot defeat them.");
                        Narrate("The last thing you hear is the clicking of their jaws as they stab you to death.");
                        EndGame();
                    }
                }
                else if (runOrSmash == "SMASH")
                {
                    if (strong)
                    {
                        Narrate("You grab the stone and crush the skeleton's skull with a heavy blow.");
                        Narrate("The skeleton drops a rusty sword, which you pick up.");
                        strength++;
                        Narrate("But because of the scream, two more skeletons rise.");
                        Narrate("They attack from both sides.");
                        Narrate("Thanks to your new weapon, you defeat them, but not without getting hurt.");
                        health--;

                        CheckHealth();

                        Narrate($"Your health is now: {health}");
                        SkeletonChestChoice();
                    }
                    else
                    {
                        Narrate("You grab the stone and try to strike the skeleton.");
                        Narrate("But you are not strong enough to crush it in one blow.");
                        Narrate("The skeleton turns and attacks you before you can recover.");
                        EndGame();
                    }
                }
                else
                {
                    Narrate("You hesitate for too long.");
                    Narrate("The skeletons surround you.");
                    EndGame();
                }
            }
            else if (skeletonRoomDecision == "SMASH")
            {
                if (strong)
                {
                    Narrate("You take the stone and smash the skeleton before it can react.");
                    Narrate("Its bones scatter across the floor.");
                    Narrate("You pick up a rusty sword from the remains.");
                    strength++;
                    SkeletonChestChoice();
                }
                else
                {
                    Narrate("You try to smash the skeleton, but your blow lacks force.");
                    Narrate("It survives and attacks you.");
                    EndGame();
                }
            }
            else
            {
                Narrate("That was not a valid choice.");
                EndGame();
            }
        }

        static void SkeletonChestChoice()
        {
            Narrate("With the skeletons defeated, do you want to examine the chest?");
            Console.Write("Type YES or NO: ");

            while (true)
            {
                string skeletonChest = Console.ReadLine().Trim().ToUpper();

                if (skeletonChest == "YES")
                {
                    Narrate("You open the chest.");
                    Narrate("Inside, you find a bow and three arrows.");
                    bow = true;
                    arrows = 3;
                    Narrate("You are now armed with a bow.");
                    CorridorAfterSkeleton();
                    break;
                }
                else if (skeletonChest == "NO")
                {
                    Narrate("Although it was guarded, you don't trust the chest.");
                    Narrate("You leave it untouched.");
                    CorridorAfterSkeleton();
                    break;
                }
                else
                {
                    Console.Write("Please enter YES or NO: ");
                }
            }
        }

        static void CorridorAfterSkeleton()
        {
            Console.WriteLine();
            Narrate("You want to leave the skeleton room.");
            Narrate("You can go FORWARD or BACKWARD.");
            Console.Write("Choose FORWARD or BACKWARD: ");

            while (true)
            {
                string navigation = Console.ReadLine().Trim().ToUpper();

                if (navigation == "FORWARD")
                {
                    Narrate("You move deeper into the dungeon...");
                    break;
                }
                else if (navigation == "BACKWARD")
                {
                    Narrate("You carefully make your way back.");
                    Narrate("As you reach the Entrace you see three Adventurer´s");
                    Narrate("Two Men and a Woman");
                    Narrate("The Woman says:'See I told you, you didnt kill.'");
                    Narrate("The Men want to go after you as they see you are armed.");

                    if (intimidating)
                    {
                        Narrate("The Adventurer´s are scared, they were lucky when they ambushed you but now that you´re cautious and armed..");
                        Narrate("They are scared and stop the approach.");
                        Narrate("The Woman which seems to be their leader, orders the man back to her side.");
                        Narrate("The Woman says:'Fine without any equiptment he will die down here anyway.'");
                        Narrate("She laughs as she pulls a hidden lever that activates a trap.");
                        Narrate("Rocks start falling at the entrace blocking it absolutely.");
                        break;
                    }
                    else
                    {
                        Narrate("The Woman says:'She is only a woman in rags get her!'");
                        Narrate("The Men approach you but the adrenaline from the skeleton fight is still in your vains.");
                        Narrate("With adrenaline fueled wild hits and some luck you injure the Men");
                        Narrate("The Woman hits you in the arm, wounding you even more");
                        health--;
                        CheckHealth();
                        Narrate("Surprised by your fighting spirit the Adventures retreat to the entrace.");
                        Narrate("The Woman says:'Fine without any equiptment and wounded she will die down here anyway.'");
                        Narrate("She laughs as she pulls a hidden lever that activates a trap.");
                        Narrate("Rocks start falling at the entrace blocking it absolutely.");
                        break;
                    }
                }
                else
                {
                    Console.Write("Please type FORWARD or BACKWARD: ");
                }
            }
        }

        static void GoblinRoom()
        {
            Console.WriteLine();
            Narrate("You enter a filthy chamber that smells of rot.");
            Narrate("A goblin is crouched beside a broken barrel eating a rat.");
            Narrate("It hasn't noticed you yet.");
            Narrate("A Goblinsword is laying against the barrel.");
            Narrate("You may ATTACK(With your bare hands), GRAB(to grab the sword), or TALK(Maybe THIS goblin is friendly).");
            Console.Write("Choose ATTACK, GRAB, or TALK: ");

            string goblinChoice = Console.ReadLine().Trim().ToUpper();

            if (goblinChoice == "ATTACK")
            {
                if (strong)
                {
                    Narrate("You strike first and overwhelm the goblin.");
                    Narrate("It drops a iron key.");
                    keyIronDoor = true;
                    Narrate("You take the iron key.");
                    Narrate("You see a big Iron Door to your left, you wonder if your new found key matches the lock.");
                    Narrate("Do you wish to try and use the iron key on the Iron Door ?");
                    Console.Write("Type YES or NO: ");

                    while (true)
                    {
                        string ironDoorChoice = Console.ReadLine().Trim().ToUpper();

                        if (ironDoorChoice == "YES")
                        {
                            if (keyIronDoor)
                            {
                                IronDoorRoom();
                            }
                            break;
                        }
                        else if (ironDoorChoice == "NO")
                        {
                            Narrate("You decide to leave the Iron Door alone for now.");
                            break;
                        }
                        else
                        {
                            Console.Write("Please type YES or NO: ");
                        }
                    }
                }
                else
                {
                    Narrate("You rush the goblin with your bare hands.");
                    Narrate("It is small, but vicious.");
                    Narrate("You are wounded in the struggle.");
                    health--;
                    CheckHealth();
                    Narrate("But you manage to defeat the goblin.");
                    Narrate("It drops a iron key.");
                    keyIronDoor = true;
                    Narrate("You take the iron key.");
                    Narrate("You see a big Iron Door to your left, you wonder if your new found key matches the lock.");
                    Narrate("Do you wish to try and use the iron key on the Iron Door ?");
                    Console.Write("Type YES or NO: ");

                    while (true)
                    {
                        string ironDoorChoice = Console.ReadLine().Trim().ToUpper();

                        if (ironDoorChoice == "YES")
                        {
                            if (keyIronDoor)
                            {
                                IronDoorRoom();
                            }
                            break;
                        }
                        else if (ironDoorChoice == "NO")
                        {
                            Narrate("You decide to leave the Iron Door alone for now.");
                            break;
                        }
                        else
                        {
                            Console.Write("Please type YES or NO: ");
                        }
                    }
                }
            }
            else if (goblinChoice == "GRAB")
            {
                if (quick)
                {
                    Narrate("You lunge forward managing to grab the sword before the goblin could react.");
                    strength += 2;
                    Narrate("Do you wish to eleminate the surprised Goblin with your new found weapon ?");
                    Console.Write("Type YES or NO: ");

                    while (true)
                    {
                        string attackOrNot = Console.ReadLine().Trim().ToUpper();

                        if (attackOrNot == "YES")
                        {
                            Narrate("You swing with your new found goblin sword and decapitate the little beast.");
                            Narrate("Blood is splashing around the place and as the body hits the floor a iron key falls of his pocket.");
                            keyIronDoor = true;
                            Narrate("You take the iron key.");
                            Narrate("You see a big Iron Door to your left, you wonder if your new found key matches the lock.");
                            Narrate("Do you wish to try and use the iron key on the Iron Door ?");
                            Console.Write("Type YES or NO: ");

                            while (true)
                            {
                                string ironDoorChoice = Console.ReadLine().Trim().ToUpper();

                                if (ironDoorChoice == "YES")
                                {
                                    if (keyIronDoor)
                                    {
                                        IronDoorRoom();
                                    }
                                    break;
                                }
                                else if (ironDoorChoice == "NO")
                                {
                                    Narrate("You decide to leave the Iron Door alone for now.");
                                    break;
                                }
                                else
                                {
                                    Console.Write("Please type YES or NO: ");
                                }
                            }

                            break;
                        }
                        else if (attackOrNot == "NO")
                        {
                            Narrate("You show Mercy upon this creature, in complete disbelief he glances at you for a second before he runs off.");
                            Narrate("As you reevalute the situation this will probably cost you, as he will probably come back with reinforcements.");
                            Narrate("You see an Iron Door to your left, and a path leading out of the room.");
                            Narrate("Do you want to try and open the Iron Door or leave the Room ?");
                            Console.Write("Type Door or leave.");

                            while (true)
                            {
                                string goblinRoomExit = Console.ReadLine().Trim().ToUpper();

                                if (goblinRoomExit == "DOOR")
                                {
                                    if (keyIronDoor)
                                    {
                                        IronDoorRoom();
                                    }
                                    else
                                    {
                                        Narrate("You try to open the door but it doesnt buldge.");
                                        Narrate("The door is locked, you miss the needed key.");
                                        Narrate("You continue moving forward to the next room.");
                                        // NEXT ROOM
                                    }

                                    break;
                                }
                                else if (goblinRoomExit == "LEAVE")
                                {
                                    Narrate("You continue moving forward to the next room.");
                                    // NEXT ROOM
                                    break;
                                }
                                else
                                {
                                    Console.Write("Please type DOOR or LEAVE: ");
                                }
                            }

                            break;
                        }
                        else
                        {
                            Console.Write("Please type YES or NO: ");
                        }
                    }
                }
                else
                {
                    Narrate("You try to grab the sword but the goblin notices you and reacts fast.");
                    Narrate("Unarmed you stand right in fron of him, defenseless.");
                    Narrate("The Goblin swing after you with a sinister grin on his face.");
                    Narrate("He lands a deadly strike and his bloodcovered face is the last thing you see before your vision turned dark.");
                    EndGame();
                }
            }
            else if (goblinChoice == "TALK")
            {
                if (beauty)
                {
                    Narrate("The goblin studies you nervously.");
                    Narrate("Instead of fighting, it throws an iron key at your feet and runs.");
                    keyIronDoor = true;
                    Narrate("You pick up the iron key.");
                    Narrate("You pick up the Goblinsword");
                    strength += 2;
                }
                else if (intimidating)
                {
                    Narrate("The goblin turns around and is terrified by your appearance.");
                    Narrate("He crawls backwards, away from you and his hand finds a rock.");
                    Narrate("He throws the rock at your head, hitting you and runs away.");
                    health--;
                    CheckHealth();
                }
            }
            else
            {
                Narrate("That was not a valid choice.");
                Narrate("The Goblin notices you and slaughters you on the spot.");
                EndGame();
            }

            Narrate("");
        }

        static void IronDoorRoom()
        {
            Narrate("You enter the Iron Door Room.");
            Narrate("You see a small room with a shelf with a healing potion on it and a rusty chest.");
            Narrate("Would you like to take the healing potion?");
            Console.Write("Type Yes or No: ");

            string potiontake;

            while (true)
            {
                potiontake = Console.ReadLine().Trim().ToUpper();

                if (potiontake == "YES" || potiontake == "NO")
                {
                    break;
                }
                else
                {
                    Console.Write("Your input was not correct please write YES or NO: ");
                }
            }

            if (potiontake == "YES")
            {
                potion++;
                Narrate("You decide to take the potion who knows when you´ll need it.");
                Narrate("Info: You cant drink the potion during a fight, you´ll be asked if you want to drink a healing potion when entering a room if you have a potion.");
                Narrate("Info: An healing potion will recover 1 health.");
                Narrate("Info: Only one healing potion can be drinked at a time as the healing effect needs time to manifest.");
                CheckHealth();
                Narrate("Would you like to drink the healing potion now?");
                Narrate("Type Yes or No");

                string drinkanswer;

                while (true)
                {
                    drinkanswer = Console.ReadLine().Trim().ToUpper();

                    if (drinkanswer == "YES" || drinkanswer == "NO")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Your input was not correct please write YES or NO: ");
                    }
                }

                if (drinkanswer == "YES")
                {
                    DrinkPotion();
                }
                else if (drinkanswer == "NO")
                {
                    Narrate("You put the potion away for later use.");
                }

                Narrate("After you took the potion you see a hole right behind where the potion was.");
                Narrate("By looking closer you see a familiar red color");
                Narrate("Probably another potion that fell in the hole in the wall.");
                Narrate("You also see some spiders crawling around in that hole");
                Narrate("If you are fast enough you could grab the potion before the spiders can react.");
                Narrate("Try to grab the Potion ?");
                Console.Write("Type Yes or No: ");

                string grabpotion;

                while (true)
                {
                    grabpotion = Console.ReadLine().Trim().ToUpper();

                    if (grabpotion == "YES" || grabpotion == "NO")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Your input was not correct please write YES or NO: ");
                    }
                }

                if (grabpotion == "YES")
                {
                    if (quick)
                    {
                        Narrate("You got fast fingers, you believe in yourself.");
                        Narrate("You hold your breath, reach in the hole and...");
                        Narrate("Yes there it is, with a firm grab you suddenly pull out the potion!");
                        potion++;
                    }
                    else
                    {
                        Narrate("You need that healing potion, who knows what dangers may wait in the upcoming dungeon.");
                        Narrate("You hold your breath, reach in the hole and...");
                        Narrate("Yes there it is, with your big hands you struggle to grab it tho but as you finally succeeded you feel a sting and let go of the potion.");
                        Narrate("A spider bit you and inflicted you with a poison that is not deadly but damaged your health by 1");
                        health--;
                        CheckHealth();
                    }
                }
                else if (grabpotion == "NO")
                {
                    Narrate("You undoublty would need the healing potion but who knows what kind of spiders crawl around in that hole in the wall.");
                    Narrate("You decide that it´s not worth the risk.");
                }
            }
            else if (potiontake == "NO")
            {
                Narrate("You dont trust this potion..");
                Narrate("As if a potion in an abandoned corner could really help you, guarded by a goblin..");
                Narrate("You decide to leave it where it is");
            }

            Narrate("Your focus falls on the rusty chest.");
            Narrate("Would you like to open it?");
            Console.Write("Type Yes or No: ");

            string openchest;

            while (true)
            {
                openchest = Console.ReadLine().Trim().ToUpper();

                if (openchest == "YES" || openchest == "NO")
                {
                    break;
                }
                else
                {
                    Console.Write("Your input was not correct please write YES or NO: ");
                }
            }

            if (openchest == "YES")
            {
                if (strong)
                {
                    Narrate("You try to open the chest but its really rusty.");
                    Narrate("Muscles tensed to the point of tearing, you give it your all as the things inside might be a great help.");
                    Narrate("Finally thank to your strength you manage to open it.");
                    Narrate("Inside you see a militia armor!");
                    Narrate("Info: This will increase your survivabillity a lot!");
                    strength += 2;
                }
                else
                {
                    Narrate("You try to open the chest but its really rusty.");
                    Narrate("Muscles tensed to the point of tearing, you give it your all as the things inside might be a great help.");
                    Narrate("No matter how hard you pull, you are not strong enough to open the chest.");
                    Narrate("Frustrated you leave the Room and continue your way...");
                    // NEXT ROOM
                }
            }
            else if (openchest == "NO")
            {
                Narrate("You dont trust the chest.");
                Narrate("Who knows, maybe it´s even a mimic you read about those creatures in old books.");
                Narrate("Not with you!");
                Narrate("You feel smart and left the Room to continue your way...");
                // NEXT ROOM
            }
        }

        static void CheckHealth()
        {
            if (health <= 0)
            {
                Narrate("Your wounds are too severe.");
                EndGame();
            }
        }

        static void DrinkPotion()
        {
            if (health < 3)
            {
                Narrate("You open the potion and drink it.");
                Narrate("You feel how the potion slowly starts to work but you already feel rejuvenated");
                health++;
                potion--;
                CheckHealth();
            }
            else if (health >= 3)
            {
                Narrate("You are full health!");
                Narrate("You put the potion away again for later use.");
            }
        }

        static void EndGame()
        {
            Console.WriteLine();
            Narrate("GAME OVER");
            Narrate("Do you want to restart? (YES/NO)");

            string choice = Console.ReadLine().Trim().ToUpper();

            if (choice == "YES")
            {
                StartGame();
            }
            else
            {
                Narrate("Thanks for playing!");
            }
        }
    }
}
