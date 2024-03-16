using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuestGame
{
    class Event02TavernTalk
    {
        public static void EventStart()
        {
            string event02result = "";

            Console.Clear();
            Console.WriteLine("- So it's you, - says the tavern keeper, - the hunters guild member.");
            Console.ReadKey();
            Console.WriteLine("     He looks at you and seems kind of dissapoined.");
            Console.ReadKey();
            Console.WriteLine("- I'll be honest with you, - his face frowned, - I didn't expect you to be so... weak.");
            Console.ReadKey();
            Console.WriteLine("The guild told me they'd send me a real hunted, but not a scumbag like you.");
            Console.ReadKey();
            Console.WriteLine("- Just tell me about the job, - you speak in deep and calm voice, - and I'll go.");
            Console.ReadKey();
            Console.WriteLine("     The keeper seems surprised to hear you be so confident. A litle smile appears on his face.");
            Console.ReadKey();
            Console.WriteLine("- Good. Let's get to the gig. - He puts a plate he've been rubbing aside and invites you to follow.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("     The basement of the tavern is dark and wet.");
            Console.ReadKey();
            Console.WriteLine("- It's not a job, - he mumbles, - think of it as a test.");
            Console.ReadKey();
            Console.WriteLine("I need to know what you can do.");
            Console.ReadKey();
            Console.WriteLine("     As you step in, you hear something...");
            Console.ReadKey();
            Console.WriteLine("Then the smell hist your nose. Rotten flesh... rotten food...");
            Console.ReadKey();
            Console.WriteLine("As you stare into the darkness, you like like this void is trying to swallow you...");
            Console.ReadKey();
            Console.WriteLine("- Hope you'll come back, - said the keeper and closed the door.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("*scrrr* *hshrrrr*");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You use matches to lit the torch on the wall, and then you see something");
            Console.ReadKey();
            Console.WriteLine("Dark siluet runs behind pillars...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("This thing is watching you...");
            Console.ReadKey();
            Console.Clear();

            bool eventOn = true;
            while (eventOn)
            {
                Console.Clear();
                Console.WriteLine("This thing is watching you...\n");
                Console.WriteLine("===== Actions:");
                Console.WriteLine("(1) Look around");
                Console.WriteLine("(2) Attack the creature\n");
                string tempInput = Console.ReadLine();

                if (tempInput == "1")
                {
                    Console.WriteLine("\nYou look around and spot more siluets...");
                    Console.ReadKey();
                    Console.WriteLine("And due to the torch light you see blades shining.");
                    Console.ReadKey();
                    break;
                }
                else if (tempInput == "2")
                {
                    Console.WriteLine("\nYou make a step towards this creature and then see more of them.");
                    Console.ReadKey();
                    Console.WriteLine("They try to surround you...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("\nYou are waiting in the light of the torch, but then you see many of them move.");
                    Console.ReadKey();
                    Console.WriteLine("They come for you...");
                    Console.ReadKey();
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("*schrr*...*shhchAARRRAARA!!!*");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("And so the fight begins...");
            Console.ReadKey();
            Console.Clear();

            int[] tmpAP = { 0, 2, 0, 0, 2 };
            CombatMechanic.Combat(false, "Creature", 8, 2, 0, 5, tmpAP);
        }
    }
}
