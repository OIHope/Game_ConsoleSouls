using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSouls
{
    class Event03GetStronger
    {
        public static void GetStronger()
        {
            Console.Clear();
            Console.WriteLine("Start leveling up!");
            Console.ReadKey();
            Console.Clear();

            while (Master.playerStats.playerLevel <= 4)
            {
                CombatMechanic.CombatRandom(1);
                Master.playerStats.playerPotions++;
            }

            bool eventOn = true;
            while (eventOn)
            {
                Console.Clear();
                Console.WriteLine("Now you are ready for boss fight!");
                Console.WriteLine("But you can train more, it's up to you");
                GetInterface.PromptAction();
                Console.WriteLine("(1) Fight the BOSS!");
                Console.WriteLine("(2) Go train more\n");
                string tempInput = Console.ReadLine();

                if (tempInput == "1")
                {
                    Console.WriteLine("\nLet the final battle begin!");
                    Console.ReadKey();
                    GetInterface.PlayerGivePotion();

                    int[] tempAP = { 1, 1, 2, 0, 1, 0, 2, 3, 1, 4, 0, 5 };
                    CombatMechanic.Combat("Ash Lord", 500, 100, 5000, 1, tempAP);
                    break;
                }
                else if (tempInput == "2")
                {
                    Console.WriteLine("\nYou go to the city to get even more stronger!");
                    Console.ReadKey();
                    GetInterface.PlayerGivePotion();

                    CombatMechanic.CombatRandom(5);
                    eventOn = false;
                }
                else
                {

                }
            }
        }
    }
}
