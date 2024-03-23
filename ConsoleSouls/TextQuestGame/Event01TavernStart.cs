using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSouls
{
    class Event01TavernStart
    {
        public static void EventStart()
        {
            GetInterface.GameName();
            GetInterface.PromptPressEnter();

            Console.Clear();
            Console.WriteLine("Doors open and you enter a small but crowded room of city tavern. All the attention is yours.");
            Console.ReadKey();
            Console.WriteLine("Speaks get quieter, plates stop spanking, peoples eyes are on you.");
            Console.ReadKey();

            bool fightEvent = false;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Doors open and you enter a small but crowded room of city tavern. All the attention is yours.");
                Console.WriteLine("Speaks get quieter, plates stop spanking, peoples eyes are on you.");
                GetInterface.PromptAction();
                Console.WriteLine("(1) Look around");
                Console.WriteLine("(2) Go to the bar\n");
                //string tempInput = Console.ReadLine();
                //Console.ReadKey();

                if (Console.ReadKey().Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("You look around and spot lots of people. Dirty and stinky, just as you thought...");
                    Console.ReadKey();
                    Console.WriteLine("Seems like you stay still for too long. One man from the corner stands up and gets to you");
                    Console.ReadKey();
                    Console.WriteLine("As he goes closer you spot a knife that he tries to hide in his robe.");
                    Console.ReadKey();
                    Console.WriteLine("This might not end well...");
                    Console.ReadKey();

                    int[] tmpAP = { 2, 0, 4, 1, 4, 1 };
                    CombatMechanic.Combat("Tavern Thug", 35, 10, 25, 1, tmpAP);

                    fightEvent = true;
                    break;
                }
                else if (Console.ReadKey().Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("You walk to the wooden bar towards an old man, who looks at you with his one eye.");
                    Console.ReadKey();
                    Console.WriteLine("But as you cross the room, someone stands up at your way. He doesn't look friendly...");
                    Console.ReadKey();

                    int[] tmpAP = { 2, 0, 4, 1, 4, 1 };
                    CombatMechanic.Combat("Tavern Thug", 35, 10, 25, 1, tmpAP);

                    fightEvent = true;
                    break;
                }
                else
                {
                    Console.WriteLine("\nYou might have a litle shock, so you stay and stare in front of you. People around are getting nervy...");
                    Console.ReadKey();
                    int[] tmpAP = { 2, 0, 4, 1, 4, 1 };
                    CombatMechanic.Combat("Tavern Thug", 35, 10, 25, 1, tmpAP);

                    fightEvent = true;
                    break;
                }
            }
            if (fightEvent)
            {
                Console.Clear();
                Console.WriteLine("You look and this poor guy and feel that people are about to attack you.");
                Console.ReadKey();
                Console.WriteLine("But right before some thugs stood up to beat your soul,");
                Console.ReadKey();
                Console.WriteLine("the tavern keeper called you. So you go to the bar...");
                Console.ReadKey();
            }
        }
    }
}
