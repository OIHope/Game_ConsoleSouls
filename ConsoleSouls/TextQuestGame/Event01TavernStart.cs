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

            bool startEvent = true;
            int waitEvent = 0;

            while (startEvent = true)
            {
                Console.Clear();
                GetInterface.PromptAction();
                Console.WriteLine("(1) Look around");
                Console.WriteLine("(2) Go to the bar\n");
                string tempInput = Console.ReadLine();

                if (string.IsNullOrEmpty(tempInput) && tempInput != "1" && tempInput != "2" && waitEvent < 2)
                {
                    Console.WriteLine("You might have a litle shock, so you stay and stare in front of you. People around are getting nervy...");
                    waitEvent++;
                    Console.ReadKey();
                }
                else if (tempInput == "1" && waitEvent < 2)
                {
                    Console.WriteLine("You look around and spot lots of people. Dirty and stinky, just like this cursed town...");
                    waitEvent++;
                    Console.ReadKey();
                }
                else
                if (waitEvent > 1)
                {
                    Console.WriteLine("Seems like you stay still for too long. One man from the corner stands up and gets to you");
                    Console.ReadKey();
                    Console.WriteLine("As he goes closer you spot a knife that he tries to hide in his robe.");
                    Console.ReadKey();
                    Console.WriteLine("This might not end well...");
                    Console.ReadKey();

                    int[] tmpAP = {2, 0, 4, 1, 4, 1};
                    CombatMechanic.Combat("Tavern Thug", 35, 10, 25, 1, tmpAP);

                    Console.Clear();
                    Console.WriteLine("You look and this poor guy and feel that people are about to attack you.");
                    Console.ReadKey();
                    Console.WriteLine("But right before some thugs stood up to beat your soul,");
                    Console.ReadKey();
                    Console.WriteLine("the tavern keeper called you. So you go to the bar...");
                    Console.ReadKey();
                    GetInterface.PlayerGivePotion();
                    break;
                }
                else if (tempInput == "2" && waitEvent < 2)
                {
                    Console.Clear();
                    Console.WriteLine("You walk to the wooden bar towards an old man, who looks at you with his one eye.");
                    Console.ReadKey();
                    Console.WriteLine("People around seem to calm down, but your back still feels someones stare...");
                    waitEvent = 0;
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
