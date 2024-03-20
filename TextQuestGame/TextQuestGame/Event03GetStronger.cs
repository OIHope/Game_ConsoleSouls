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
            Console.WriteLine("Start leveling up!");
            Console.ReadKey();
            Console.Clear();

            while (Master.playerStats.playerLevel < 10)
            {
                CombatMechanic.Combat(true, "", 0, 0, 0, 1, [], 20);
                Master.playerStats.playerPotions++;
            }
        }
    }
}
