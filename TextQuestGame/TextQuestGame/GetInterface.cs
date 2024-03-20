using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSouls
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
        }
        public static void PromptAction()
        {
            Console.WriteLine("\n=====MAKE YOUR CHOICE:\n");
        }
        public static void CombatInterface(string enName, int enHP, int enArmor, int enDMG, 
            string[] nextMove, int i)
        {
            Console.Clear();
            Console.WriteLine($"    {enName}");
            Console.WriteLine("===========================");
            Console.WriteLine($"||  HP = {enHP}  ||  Armor = {enArmor} ||  DMG = {enDMG}");
            Console.WriteLine($"||  Next move = {nextMove[i]}");
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
        public static void CombatUsePotion()
        {
            Console.WriteLine($"You health if healed by {Master.playerStats.potionHeal} points");
            PromptPressEnter();
            Console.ReadKey();
        }
        public static void CombaNoPotion()
        {
            Console.WriteLine($"You reach the pocket, but fine nothing in there!");
            PromptPressEnter();
            Console.ReadKey();
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
        public static void PlayerGivePotion()
        {
            Console.WriteLine("\n--- You get +1 Potion ---\n");
            Master.playerStats.playerPotions++;
            Console.ReadKey();
        }
        /* sequance for choice
          
         
            bool eventOn = true;
            while (eventOn)
            {
                Console.Clear();
                Console.WriteLine("This thing is watching you...\n");
                GetInterface.PromptAction();
                Console.WriteLine("(1) Look around");
                Console.WriteLine("(2) Attack the creature\n");
                string tempInput = Console.ReadLine();

                if (tempInput == "1")
                {
                    Console.WriteLine("\n");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.ReadKey();
                    break;
                }
                else if (tempInput == "2")
                {
                    Console.WriteLine("\n");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("\n");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.ReadKey();
                    break;
                }
            }
        */

    }
}
