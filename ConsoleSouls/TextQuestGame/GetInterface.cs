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
            Console.ReadKey();
        }
        public static void PromptAction()
        {
            Console.WriteLine("\n=====MAKE YOUR CHOICE:\n");
        }
        public static void CombatInterface(string enName, int enHP, int enDMG, 
            string[] nextMove, int i)
        {
            Console.Clear();
            Console.WriteLine($"    {enName} ||   Left: {CombatMechanic.enemyStats.enemyCount}");
            Console.WriteLine("===========================");
            Console.WriteLine($"||  HP = {enHP} ||  DMG = {enDMG}");
            Console.WriteLine($"||  Next move = {nextMove[i]}");
            Console.WriteLine("===========================");
            Console.WriteLine("\n       ---VS---\n");
            Console.WriteLine("     Kvout Lvl " + Master.playerStats.playerLevel + " EXP: " + Master.playerStats.playerXP + "/" + Master.playerStats.xpToLevelUP);
            Console.WriteLine("===========================");
            Console.WriteLine($"||  HP = {Master.playerStats.playerHP}  ||  DMG = {Master.playerStats.playerDMG}");
            Console.WriteLine($"||  Potions = {Master.playerStats.playerPotions}");
            Console.WriteLine("===========================");
            Console.WriteLine("===Actions:\n");
            Console.WriteLine("(1) Low Attack");
            Console.WriteLine("(2) Slash Attack");
            Console.WriteLine("(3) High Attack");
            Console.WriteLine("(4) Block");
            Console.WriteLine("(5) Dodge");
            Console.WriteLine("(6) Parry");
            Console.WriteLine("\n(7) Use Potion\n");
        }
        public static void CombatUsePotion()
        {
            Master.playerStats.playerHP += Master.playerStats.potionHeal;
            Master.playerStats.playerPotions--;
            Console.WriteLine($"You health if healed by {Master.playerStats.potionHeal} points");
            PromptPressEnter();
            Console.ReadKey();
        }
        public static void CombatNoPotion()
        {
            Console.WriteLine($"You reach the pocket, but fine nothing in there!");
            PromptPressEnter();
        }
        public static void CombatEnemyDefeat(string enName, int expForWin)
        {
            Console.WriteLine($"======={enName} is DEFEATED!=======\n||");
            Console.WriteLine($"||   You have earned {expForWin} EXP");
            Console.WriteLine($"||");
            Console.WriteLine($"===================================\n\n");
            PromptPressEnter();
        }
        public static void CombatLevelUp()
        {
            Console.Clear();
            Console.WriteLine($"=======LEVEL UP!=======\n||");
            Console.WriteLine($"||   You are now LVL {Master.playerStats.playerLevel}!");
            Console.WriteLine($"|| Your HP is now: {Master.playerStats.plMaxHP}");
            Console.WriteLine($"|| Your DMG is now: {Master.playerStats.playerDMG}");
            Console.WriteLine("========================");
            PromptPressEnter();
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
        /*
        
        enemy action patterns (enAP[])


        tEn = to enemy
        tPl = to player

           ap type          pl act Low Attack  r       pl act Slash Attack s      pl act High Attack  p    pl act Block     pl act Dodge       pl act Parry


     r   Low Attack      x   0.1 DMG tEn 0.1 tPl   x   0.1 DMG tEn 1   tPl   x   1   DMG tEn 0.1 tPl   x   0.3 DMG tPl   x   0.6 DMG tPl   x   0.0 DMG tPl
     s   Slash Attack    x   1   DMG tEn 0.1 tPl   x   0.1 DMG tEn 0.1 tPl   x   0.1 DMG tEn 1   tPl   x   0.0 DMG tPl   x   0.3 DMG tPl   x   0.6 DMG tPl
     p   High Attack     x   0.1 DMG tEn 1   tPl   x   1   DMG tEn 0.1 tPl   x   0.1 DMG tEn 0.1 tPl   x   0.6 DMG tPl   x   0.0 DMG tPl   x   0.3 DMG tPl

         Block            x    0.3  DMG tEn    x          0.0  DMG tEn    x         0.6  DMG tEn    x    
         Dodge            x    0.6  DMG tEn    x          0.3  DMG tEn    x         0.0  DMG tEn    x    
         Parry            x    0.0  DMG tEn    x          0.6  DMG tEn    x         0.3  DMG tEn    x    


        High <l LOW w> Slash
        Low <l SLASH w> High
        Slash <l HIGH w> Low

        0   low attack
        1   slash atack
        2   high attack
        3   block
        4   dodge
        5   parry

        */





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
