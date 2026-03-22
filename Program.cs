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
        static bool bow = false;

        static void Main(string[] args)
        {
            StartGame();
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
            bow = false;
        }

        static void StartGame()
        {
            ResetAdventurer();

            Console.WriteLine("You wake up in a dark dungeon.");
            Console.WriteLine("You don't have any memory of how you got here.");
            Console.WriteLine("You try to remember your name.");
            Console.WriteLine("...");
            Console.Write("Your name is: ");

            adventurerName = Console.ReadLine().Trim();

            while (string.IsNullOrWhiteSpace(adventurerName))
            {
                Console.Write("Please enter a valid name: ");
                adventurerName = Console.ReadLine().Trim();
            }

            while (true)
            {
                Console.WriteLine("You try to remember your gender.");
                Console.WriteLine("...");
                Console.Write("Your gender (Male or Female): ");

                gender = Console.ReadLine().Trim().ToUpper();

                if (gender == "MALE")
                {
                    strong = true;
                    tall = true;
                    intimidating = true;

                    Console.WriteLine("You are a man. You look at your big hands that seem to have fought many battles.");
                    Console.WriteLine("You are tall and strong.");
                    break;
                }
                else if (gender == "FEMALE")
                {
                    quick = true;
                    small = true;
                    beauty = true;

                    Console.WriteLine("You are a woman. You remember seeing yourself in the mirror.");
                    Console.WriteLine("You are short and quick.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please type only Male or Female.\n");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Welcome to LostInDungeon, {adventurerName}.");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine("As you stand up and try to orient yourself, you notice you got robbed.");
            Console.WriteLine("All you have right now are the rags you wear.");
            Console.WriteLine("You hear voices nearby, maybe fellow adventurers that will rescue you?");
            Console.WriteLine("There are two paths ahead: LEFT or RIGHT.");
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
                Console.WriteLine("You chose to wait and hope that whoever comes will have mercy with you.");
                Console.WriteLine("Three Adventurer approach and a woman says:'See I told, u didnt kill. Stupid Idiots.' ");
                Console.WriteLine("You are trapped and try to run trough them but as you are in rags and unnarmed you get overwhelmed by the Men");
                Console.WriteLine("As you try to fight back the Woman approaches you and you feel a stab in your heart as your vision goes black.");
                EndGame();
            }
        }

        static void SkeletonRoom()
        {
            Console.WriteLine();
            Console.WriteLine("You enter a Room with bones on the ground and a single one armed Skeleton which is facing the other way.");
            Console.WriteLine("Torches burn on the walls.");
            Console.WriteLine("There is a chest in the middle of the room, and a large stone beside it.");
            Console.WriteLine("The only other exit is behind the skeleton.");
            Console.WriteLine("You can try to SNEAK around the skeleton.");
            Console.WriteLine("Or you can try to SMASH it with the stone.");
            Console.Write("Choose SNEAK or SMASH: ");

            string skeletonRoomDecision = Console.ReadLine().Trim().ToUpper();

            if (skeletonRoomDecision == "SNEAK")
            {
                Console.WriteLine("You decide that everything has been terrifying enough already.");
                Console.WriteLine("You carefully sneak through the room.");
                Console.WriteLine("You have already crossed half the room when the skeleton suddenly turns around and unleashes a piercing scream as he sees you.");
                Console.WriteLine("You can try to RUN or SMASH its skull with the stone.");
                Console.Write("Type RUN or SMASH: ");

                string runOrSmash = Console.ReadLine().Trim().ToUpper();

                if (runOrSmash == "RUN")
                {
                    if (quick)
                    {
                        Console.WriteLine("You unleash an extraordinary sprint.");
                        Console.WriteLine("As you reach the exit, you glance back and see that two more skeletons have risen because of the scream.");
                        Console.WriteLine("If you weren't as quick as you are, you would have been trapped.");
                        CorridorAfterSkeleton();
                    }
                    else
                    {
                        Console.WriteLine("You sprint for the exit, but two more skeletons rise because of the scream.");
                        Console.WriteLine("One rises near the one at chest.");
                        Console.WriteLine("The other rises directly in front of you, blocking the exit.");
                        Console.WriteLine("You try to fight with your bare hands, but without a weapon you cannot defeat them.");
                        Console.WriteLine("The last thing you hear is the clicking of their jaws as they stab you to death.");
                        EndGame();
                    }
                }
                else if (runOrSmash == "SMASH")
                {
                    if (strong)
                    {
                        Console.WriteLine("You grab the stone and crush the skeleton's skull with a heavy blow.");
                        Console.WriteLine("The skeleton drops a rusty sword, which you pick up.");
                        strength++;
                        Console.WriteLine("But because of the scream, two more skeletons rise.");
                        Console.WriteLine("They attack from both sides.");
                        Console.WriteLine("Thanks to your new weapon, you defeat them, but not without getting hurt.");
                        health--;

                        CheckHealth();

                        Console.WriteLine($"Your health is now: {health}");
                        SkeletonChestChoice();
                    }
                    else
                    {
                        Console.WriteLine("You grab the stone and try to strike the skeleton.");
                        Console.WriteLine("But you are not strong enough to crush it in one blow.");
                        Console.WriteLine("The skeleton turns and attacks you before you can recover.");
                        EndGame();
                    }
                }
                else
                {
                    Console.WriteLine("You hesitate for too long.");
                    Console.WriteLine("The skeletons surround you.");
                    EndGame();
                }
            }
            else if (skeletonRoomDecision == "SMASH")
            {
                if (strong)
                {
                    Console.WriteLine("You take the stone and smash the skeleton before it can react.");
                    Console.WriteLine("Its bones scatter across the floor.");
                    Console.WriteLine("You pick up a rusty sword from the remains.");
                    strength++;
                    SkeletonChestChoice();
                }
                else
                {
                    Console.WriteLine("You try to smash the skeleton, but your blow lacks force.");
                    Console.WriteLine("It survives and attacks you.");
                    EndGame();
                }
            }
            else
            {
                Console.WriteLine("That was not a valid choice.");
                EndGame();
            }
        }

        static void SkeletonChestChoice()
        {
            Console.WriteLine("With the skeletons defeated, do you want to examine the chest?");
            Console.Write("Type YES or NO: ");

            while (true)
            {
                string skeletonChest = Console.ReadLine().Trim().ToUpper();

                if (skeletonChest == "YES")
                {
                    Console.WriteLine("You open the chest.");
                    Console.WriteLine("Inside, you find a bow and three arrows.");
                    bow = true;
                    arrows = 3;
                    Console.WriteLine("You are now armed with a bow.");
                    CorridorAfterSkeleton();
                    break;
                }
                else if (skeletonChest == "NO")
                {
                    Console.WriteLine("Although it was guarded, you don't trust the chest.");
                    Console.WriteLine("You leave it untouched.");
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
            Console.WriteLine("You want to leave the skeleton room.");
            Console.WriteLine("You can go FORWARD or BACKWARD.");
            Console.Write("Choose FORWARD or BACKWARD: ");

            while (true)
            {
                string navigation = Console.ReadLine().Trim().ToUpper();

                if (navigation == "FORWARD")
                {
                    Console.WriteLine("You move deeper into the dungeon...");
                    break;
                }
                else if (navigation == "BACKWARD")
                {
                    Console.WriteLine("You carefully make your way back.");
                    Console.WriteLine("As you reach the Entrace you see three Adventurer´s");
                    Console.WriteLine("Two Men and a Woman");
                    Console.WriteLine("The Woman says:'See I told you, you didnt kill.'");
                    Console.WriteLine("The Men want to go after you as they see you are armed.");

                    if (intimidating)
                    {
                        Console.WriteLine("The Adventurer´s are scared, they were lucky when they ambushed you but now that you´re cautious and armed..");
                        Console.WriteLine("They are scared and stop the approach.");
                        Console.WriteLine("The Woman which seems to be their leader, orders the man back to her side.");
                        Console.WriteLine("The Woman says:'Fine without any equiptment he will die down here anyway.'");
                        Console.WriteLine("She laughs as she pulls a hidden lever that activates a trap.");
                        Console.WriteLine("Rocks start falling at the entrace blocking it absolutely.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The Woman says:'She is only a woman in rags get her!'");
                        Console.WriteLine("The Men approach you but the adrenaline from the skeleton fight is still in your vains.");
                        Console.WriteLine("With adrenaline fueled wild hits and some luck you injure the Men");
                        Console.WriteLine("The Woman hits you in the arm, wounding you even more");
                        health--;
                        CheckHealth();
                        Console.WriteLine("Surprised by your fighting spirit the Adventures retreat to the entrace.");
                        Console.WriteLine("The Woman says:'Fine without any equiptment and wounded she will die down here anyway.'");
                        Console.WriteLine("She laughs as she pulls a hidden lever that activates a trap.");
                        Console.WriteLine("Rocks start falling at the entrace blocking it absolutely.");
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
            Console.WriteLine("You enter a filthy chamber that smells of rot.");
            Console.WriteLine("A goblin is crouched beside a broken barrel eating a rat.");
            Console.WriteLine("It hasn't noticed you yet.");
            Console.WriteLine("A Goblinsword is laying against the barrel.");
            Console.WriteLine("You may ATTACK(With your bare hands), GRAB(to grab the sword), or TALK(Maybe THIS goblin is friendly).");
            Console.Write("Choose ATTACK, GRAB, or TALK: ");

            string goblinChoice = Console.ReadLine().Trim().ToUpper();

            if (goblinChoice == "ATTACK")
            {
                if (strong)
                {
                    Console.WriteLine("You strike first and overwhelm the goblin.");
                    Console.WriteLine("It drops a iron key.");
                    keyIronDoor = true;
                    Console.WriteLine("You take the iron key.");
                }
                else
                {
                    Console.WriteLine("You rush the goblin with your bare hands.");
                    Console.WriteLine("It is small, but vicious.");
                    Console.WriteLine("You are wounded in the struggle.");
                    health--;
                    CheckHealth();
                    Console.WriteLine("But you manage to defeat the goblin.");
                }
            }
            else if (goblinChoice == "GRAB")
            {
                if (quick)
                {
                    Console.WriteLine("You lunge forward managing to grab the sword before the goblin could react.");
                    strength += 2;
                    Console.WriteLine("Do you wish to eleminate the surprised Goblin with your new found weapon ?");
                    Console.Write("Type YES or NO: ");

                    string attackOrNot = Console.ReadLine().Trim().ToUpper();

                    if (attackOrNot == "YES")
                    {
                        Console.WriteLine("You swing with your new found goblin sword and decapitate the little beast.");
                        Console.WriteLine("Blood is splashing around the place and as the body hits the floor a iron key falls of his pocket.");
                        keyIronDoor = true;
                    }
                    else if (attackOrNot == "NO")
                    {
                        Console.WriteLine("You show Mercy upon this creature, in complete disbelief he glances at you for a second before he runs off.");
                        Console.WriteLine("As you reevalute the situation this will probably cost you, as he will probably come back with reinforcements.");
                    }
                }
                else
                {
                    Console.WriteLine("You try to grab the sword but the goblin notices you and reacts fast.");
                    Console.WriteLine("Unarmed you stand right in fron of him, defenseless.");
                    Console.WriteLine("The Goblin swing after you with a sinister grin on his face.");
                    Console.WriteLine("He lands a deadly strike and his bloodcovered face is the last thing you see before your vision turned dark.");
                    EndGame();
                }
            }
            else if (goblinChoice == "TALK")
            {
                if (beauty)
                {
                    Console.WriteLine("The goblin studies you nervously.");
                    Console.WriteLine("Instead of fighting, it throws an iron key at your feet and runs.");
                    keyIronDoor = true;
                    Console.WriteLine("You pick up the iron key.");
                    Console.WriteLine("You pick up the Goblinsword");
                    strength += 2;
                }
                else if (intimidating)
                {
                    Console.WriteLine("The goblin turns around and is terrified by your appearance.");
                    Console.WriteLine("He crawls backwards, away from you and his hand finds a rock.");
                    Console.WriteLine("He throws the rock at your head, hitting you and runs away.");
                    health--;
                    CheckHealth();
                }
                else
                {
                    Console.WriteLine("The goblin does not trust you.");
                }
            }
            else
            {
                Console.WriteLine("That was not a valid choice.");
                Console.WriteLine("The Goblin notices you and slaughters you on the spot.");
                EndGame();
            }
        }

        static void CheckHealth()
        {
            if (health <= 0)
            {
                Console.WriteLine("Your wounds are too severe.");
                EndGame();
            }
        }

        static void EndGame()
        {
            Console.WriteLine();
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Do you want to restart? (YES/NO)");

            string choice = Console.ReadLine().Trim().ToUpper();

            if (choice == "YES")
            {
                StartGame();
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
            }
        }
    }
}