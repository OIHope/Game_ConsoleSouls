using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuestGame
{
    public class GetInterface
    {
        public static void GameName()
        {
            Console.WriteLine("====CONSOLE SOULS====\n\n");
        }
        public static void PromptPressEnter()
        {
            Console.WriteLine("\n===PRESS ENTER===\n");
            Console.ReadKey();
        }
        public static void PromptAction()
        {
            Console.WriteLine("\n=====MAKE YOUR CHOICE:\n");
        }
        public static void CombatInterface(string enName, int enHP, int enArmor, int enDMG, string nextMove)
        {
            Console.Clear();
            Console.WriteLine($"    {enName}");
            Console.WriteLine("===========================");
            Console.WriteLine($"||  HP = {enHP}  ||  Armor = {enArmor} ||  DMG = {enDMG}");
            Console.WriteLine($"||  Next move = {nextMove}");
            Console.WriteLine("===========================");
            Console.WriteLine("\n       ---VS---\n");
            Console.WriteLine("     Kvout Lvl " + Master.playerStats.playerLevel + " EXP: " + Master.playerStats.playerXP + "/" + Master.playerStats.xpToLevelUP);
            Console.WriteLine("===========================");
            Console.WriteLine($"||  HP = {Master.playerStats.playerHP}  ||  Armor = {Master.playerStats.playerArmor}  ||  DMG = {Master.playerStats.playerDMG}");
            Console.WriteLine($"||  Potions = {Master.playerStats.playerPotions}");
            Console.WriteLine("===========================");
            Console.WriteLine("===Actions:\n");
            Console.WriteLine("(1) Attack");
            Console.WriteLine("(2) Deffend");
            Console.WriteLine("(3) Dodge");
            Console.WriteLine("(4) Use Potion\n");
        }
        public static void CombatEnemyDefeat(string enName, int expForWin)
        {
            Console.WriteLine($"======={enName} is DEFEATED!=======\n||");
            Console.WriteLine($"||   You have earned {expForWin} EXP");
            Console.WriteLine($"||");
            Console.WriteLine($"===================================\n\n");
            PromptPressEnter();
            Console.ReadKey();
        }
        public static void CombatLevelUp()
        {
            Console.Clear();
            Console.WriteLine($"=======LEVEL UP!=======\n||");
            Console.WriteLine($"||   You are now LVL {Master.playerStats.playerLevel}!");
            Console.WriteLine($"|| Your HP is now: {Master.playerStats.plMaxHP}");
            Console.WriteLine($"|| Your ARMOR is now: {Master.playerStats.playerArmor}");
            Console.WriteLine($"|| Your DMG is now: {Master.playerStats.playerDMG}");
            Console.WriteLine("========================");
            PromptPressEnter();
            Console.ReadKey();
        }
        public static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("=======PLAYER IS DEAD=======\n\n\n");
            Console.WriteLine("----press Enter to repeat----\n");
            Console.WriteLine("------press Esc to exit------");
        }

    }
}
