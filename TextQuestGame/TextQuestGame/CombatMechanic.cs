﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextQuestGame
{
    
    class CombatMechanic
    {

        public static void Combat(bool randomEnemy, string enemyName, int enemyHP, int enemyDMG, int enemyArmor, int count)
        {
            Random random = new Random();

            string enName = "";
            int enHP = 0;
            int enDMG = 0;
            int enArmor = 0;
            int enCount = count;

            if (randomEnemy)
            {
                enName = GetEnemyName(random.Next(0,7));
                enHP = random.Next(10,20);
                enDMG = random.Next(3, 11);
                enArmor = random.Next(0, 3);
            }
            else
            {
                enName = enemyName;
                enHP = enemyHP;
                enDMG = enemyDMG;
                enArmor = enemyArmor;
            }

            int plArmor = GameMainCode.playerStats.playerArmor;
            int plPotion = GameMainCode.playerStats.playerPotions;

            int plLvl2XP = GameMainCode.playerStats.xpLvl2;
            int plLvl3XP = GameMainCode.playerStats.xpLvl3;
            int plLvl4XP = GameMainCode.playerStats.xpLvl4;
            int plLvl5XP = GameMainCode.playerStats.xpLvl5;




            while ((enHP > 0) && (enCount > 0))
            {
                string enAP = "";
                int enNumAP = random.Next(0, 10);
                if (enNumAP >= 0 && enNumAP < 6)
                    enAP = "Attack";
                else if (enNumAP >= 6 && enNumAP < 8)
                    enAP = "Deffend";
                else if (enNumAP >= 8 && enNumAP < 10)
                    enAP = "Dodge";

                if (GameMainCode.playerStats.playerHP > GameMainCode.playerStats.plMaxHP) GameMainCode.playerStats.playerHP = GameMainCode.playerStats.plMaxHP;
                if (plPotion < 0) plPotion = 0;

                Console.Clear();

                Console.WriteLine($"   {enName} count: {enCount}");
                Console.WriteLine("===========================");
                Console.WriteLine($"||  HP = {enHP}");
                Console.WriteLine($"||  Armor = {enemyArmor}");
                Console.WriteLine($"||  DMG = {enDMG}");
                Console.WriteLine($"||  Next move = {enAP}");
                Console.WriteLine("===========================");

                Console.WriteLine("\n---VS---\n");

                Console.WriteLine("   Player Lvl "+ GameMainCode.playerStats.playerLevel + " EXP: "+ GameMainCode.playerStats.playerXP);
                Console.WriteLine("===========================");
                Console.WriteLine($"||  HP = {GameMainCode.playerStats.playerHP}");
                Console.WriteLine($"||  Armor = {plArmor}");
                Console.WriteLine($"||  DMG = {GameMainCode.playerStats.playerDMG}");
                Console.WriteLine($"||  Potions = {plPotion}");
                Console.WriteLine("===========================");
                Console.WriteLine("===Actions:\n");
                Console.WriteLine("(1) Attack");
                Console.WriteLine("(2) Deffend");
                Console.WriteLine("(3) Dodge");
                Console.WriteLine("(4) Use Potion\n");

                //Combat System
                string inputValue = Console.ReadLine();
                if (inputValue == "1")
                {
                    int i = random.Next(0, 3);
                    //attack
                    switch (enAP)
                    {
                        case "Attack":
                            if (i == 0)
                            {
                                int ddPL = DDDefend(enDMG, plArmor);
                                int ddEN = DDDefend(GameMainCode.playerStats.playerDMG, enArmor);
                                GameMainCode.playerStats.playerHP -= ddPL;
                                enHP -= ddEN;

                                Console.WriteLine($"You both charge! \n{enName} hit your chin and deal {ddPL} dammage\n" +
                                    $"You manage to hit enemies ear and deal {ddEN} damage\n");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else if (i == 1)
                            {
                                Console.WriteLine($"You both charge! \n{enName} slips on the flour and deal no dammage\n" +
                                    $"You stop and laugh at {enName} and only deal some emotional damage\n" +
                                    $"\n" +
                                    $"---press Enter---");
                                Console.ReadKey();
                            }
                            else
                            {
                                int ddEN = DDCRITAtack(GameMainCode.playerStats.playerDMG, enArmor);
                                enHP -= ddEN;
                                Console.WriteLine($"You both charge! And so happen that you make the right move\n" +
                                    $"and dodge enemies attack. Then you land your CRITICAL strike, dealing {ddEN} damage!");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            break;
                        case "Deffend":
                            if (i == 0)
                            {
                                int ddEN = DDDefend(GameMainCode.playerStats.playerDMG, enArmor);
                                enHP -= ddEN;
                                Console.WriteLine($"You charge! \n{enName} is trying to block your attack\n" +
                                    $"At the last moment you spot a gap in his deffence and land your hit on the weak spot\n" +
                                    $"{enName} bends from pain as you dealt him {ddEN} damage\n" +
                                    $"\n" +
                                    $"---press Enter---");
                                Console.ReadKey();
                            }
                            else if (i >= 1)
                            {
                                Console.WriteLine($"You charge! But maybe is't of your overconfidence, but your leg slips\n" +
                                    $"and you fall on the flour followed by {enName}`s laugh " +
                                    $"\n" +
                                    $"---press Enter---");
                                Console.ReadKey();
                            }
                            break;
                        case "Dodge":
                            if (i == 0)
                            {
                                Console.WriteLine($"{enName} dogded you attack!");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else if (i == 1)
                            {
                                int ddEN = DDDefend(GameMainCode.playerStats.playerDMG, enArmor);
                                enHP -= ddEN;
                                Console.WriteLine($"You manage to hit {enName} with just a tip of your weapon \nand deal {ddEN} damage");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else
                            {
                                int ddEN = DDCRITAtack(GameMainCode.playerStats.playerDMG, enArmor);
                                enHP -= ddEN;
                                Console.WriteLine($"{enName} makes a very predictable move and you land a CRITICAL hit, \ndealing {ddEN} damage!");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            break;
                    }
                }
                else if (inputValue == "2")
                {
                    int i = random.Next(0, 3);
                    //deffend
                    switch (enAP)
                    {
                        case "Attack":
                            if (i == 0)
                            {
                                int ddPL = DDDefend(enDMG, plArmor);
                                GameMainCode.playerStats.playerHP -= ddPL;
                                Console.WriteLine($"Enemies attack is blocked, but you notice blood on your hands.\n" +
                                    $"{enName} seems to get you and deal {ddPL} damage");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else if (i == 1)
                            {
                                Console.WriteLine($"Pefect block!\n" +
                                    $"NO damage dealt!");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else
                            {
                                int ddPL = DDCRITDefend(enDMG, plArmor);
                                GameMainCode.playerStats.playerHP -= ddPL;
                                Console.WriteLine($"As {enName} attacks you manage to twist your weapon \n" +
                                    $"and get a perfect angle for blocking enemies attack!\n" +
                                    $"{ddPL} damage received");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            break;
                        case "Deffend":
                            Console.WriteLine($"Noone makes a move, you watch {enName} watch you...");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                        case "Dodge":
                            Console.WriteLine($"{enName}`s dodge seems so dangerous, so you decide to block...");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                    }
                }
                else if (inputValue == "3")
                {
                    int i = random.Next(0, 3);
                    //dodge
                    switch (enAP)
                    {
                        case "Attack":
                            if (i == 0)
                            {
                                Console.WriteLine($"You dodged {enName} attack!");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else if (i == 1)
                            {
                                Console.WriteLine($"You manage to get away from {enName} attack");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else
                            {
                                int ddPL = DDAtack(enDMG, plArmor);
                                GameMainCode.playerStats.playerHP -= ddPL;
                                Console.WriteLine($"{enName} charges and manage to get you and deal {ddPL} damage");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            break;
                        case "Deffend":
                            Console.WriteLine($"Seems like {enName} blocks you dodge...");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                        case "Dodge":
                            Console.WriteLine($"You both dodge... Maybe you were scared of rats?");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                    }
                }
                else if ((inputValue == "4") && (plPotion > 0))
                {
                    int i = random.Next(0, 3);
                    //potion
                    switch (enAP)
                    {
                        case "Attack":
                            int ddPL = DDCRITAtack(enDMG, plArmor);
                            GameMainCode.playerStats.playerHP -= ddPL;
                            Console.WriteLine($"As {enName} attack, you open yourself looking for a potion\n" +
                                $"Enemy get's you and lends CRITICAL hit dealing {ddPL} damage");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                        case "Deffend":
                            GameMainCode.playerStats.playerHP += 5;
                            plPotion--;
                            Console.WriteLine($"You health if healed by 5 points");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                        case "Dodge":
                            GameMainCode.playerStats.playerHP += 5;
                            plPotion--;
                            Console.WriteLine($"You health if healed by 5 points");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                    }
                }
                else if ((inputValue == "4") && (plPotion == 0))
                {
                    int i = random.Next(0, 3);
                    //potion
                    switch (enAP)
                    {
                        case "Attack":
                            int ddPL = DDCRITAtack(enDMG, plArmor);
                            GameMainCode.playerStats.playerHP -= ddPL;
                            Console.WriteLine($"As {enName} attack, you open yourself looking for a potion\n" +
                                $"Enemy get's you and lends CRITICAL hit dealing {ddPL} damage");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                        case "Deffend":
                            Console.WriteLine($"You reach the pocket, but fine nothing in there!");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                        case "Dodge":
                            Console.WriteLine($"You reach the pocket, but fine nothing in there!");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    switch (enAP)
                    {
                        case "Attack":
                            int ddPL = DDCRITAtack(enDMG, plArmor);
                            GameMainCode.playerStats.playerHP -= ddPL;
                            Console.WriteLine($"As {enName} attack, you just stand and watch how\n" +
                                $"enemy get's you and lends CRITICAL hit dealing {ddPL} damage");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                        case "Deffend":
                            Console.WriteLine($"You stand still and watch {enName} defending");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                        case "Dodge":
                            Console.WriteLine($"You stand still and watch {enName} dodging like crazy");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                    }
                }

                //Win System
                if (GameMainCode.playerStats.playerHP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("=======PLAYER IS DEAD=======\n\n\n");
                    Console.WriteLine("----press Enter to repeat----\n");
                    Console.WriteLine("------press Esc to exit------");

                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (enHP <= 0)
                {
                    Console.Clear();
                    int plEX = random.Next(10, 21);
                    GameMainCode.playerStats.playerXP += plEX;
                    enCount -= 1;
                    if(enCount > 0) enHP = enemyHP;
                    Console.WriteLine($"======={enName} is DEFEATED!=======\n||");
                    Console.WriteLine($"||   You have earned {plEX} EXP");
                    Console.WriteLine($"||");
                    Console.WriteLine($"===================================\n\n");
                    Console.WriteLine("------press Enter to continue------");
                    Console.ReadKey();
                }

                //LevelUp Check
                if (GameMainCode.playerStats.playerXP >= plLvl2XP && GameMainCode.playerStats.playerLevel == 1)
                {
                    GameMainCode.playerStats.playerLevel = 2;
                    GameMainCode.playerStats.playerDMG++;
                    GameMainCode.playerStats.playerArmor++;
                    GameMainCode.playerStats.plMaxHP += 5;
                    LevelUpText();
                }
                else if (GameMainCode.playerStats.playerXP >= plLvl3XP && GameMainCode.playerStats.playerLevel == 2)
                {
                    GameMainCode.playerStats.playerLevel = 3;
                    GameMainCode.playerStats.playerDMG++;
                    GameMainCode.playerStats.playerArmor++;
                    GameMainCode.playerStats.plMaxHP += 5;
                    LevelUpText();
                }
                else if (GameMainCode.playerStats.playerXP >= plLvl4XP && GameMainCode.playerStats.playerLevel == 3)
                {
                    GameMainCode.playerStats.playerLevel = 4;
                    GameMainCode.playerStats.playerDMG++;
                    GameMainCode.playerStats.playerArmor++;
                    GameMainCode.playerStats.plMaxHP += 5;
                    LevelUpText();
                }
                else if (GameMainCode.playerStats.playerXP >= plLvl5XP && GameMainCode.playerStats.playerLevel == 4)
                {
                    GameMainCode.playerStats.playerLevel = 5;
                    GameMainCode.playerStats.playerDMG++;
                    GameMainCode.playerStats.playerArmor++;
                    GameMainCode.playerStats.plMaxHP += 5;
                    LevelUpText();
                }
            }
        }
        static void LevelUpText()
        {
            GameMainCode.playerStats.playerHP = GameMainCode.playerStats.plMaxHP;
            Console.Clear();
            Console.WriteLine($"=======LEVEL UP!=======\n||");
            Console.WriteLine($"||   You are now LVL {GameMainCode.playerStats.playerLevel}!");
            Console.WriteLine($"|| Your HP is now: {GameMainCode.playerStats.plMaxHP}");
            Console.WriteLine($"|| Your ARMOR is now: {GameMainCode.playerStats.playerArmor}");
            Console.WriteLine($"|| Your DMG is now: {GameMainCode.playerStats.playerDMG}");
            Console.WriteLine($"===================================\n\n");
            Console.WriteLine("------press Enter to continue------");
            Console.ReadKey();
        }
        static string GetEnemyName(int randomName)
            {
                int r = randomName;
                string enemyRandName = "";
                switch (r)
                {
                    case 0:
                        enemyRandName = "Thug";
                        break;
                    case 1:
                        enemyRandName = "Bandit";
                        break;
                    case 2:
                        enemyRandName = "Diller";
                        break;
                    case 3:
                        enemyRandName = "Street Fighter";
                        break;
                    case 4:
                        enemyRandName = "Sword Man";
                        break;
                    case 5:
                        enemyRandName = "Guard";
                        break;
                    case 6:
                        enemyRandName = "Bully Boy";
                        break;
                }
                return enemyRandName;
            }
        static int DDAtack(int attackerDMG, int deffenderArmor)
        {
            int hitDMG = attackerDMG - deffenderArmor;
            if (hitDMG < 0) hitDMG = 0;
            return hitDMG;
        }
        static int DDCRITAtack(int attackerDMG, int deffenderArmor)
        {
            int hitDMG = (attackerDMG*2) - deffenderArmor;
            if (hitDMG < 0) hitDMG = 0;
            return hitDMG;
        }
        static int DDDefend(int attackerDMG, int deffenderArmor)
        {
            int hitDMG = attackerDMG - (deffenderArmor*2);
            if (hitDMG < 0) hitDMG = 0;
            return hitDMG;
        }
        static int DDCRITDefend(int attackerDMG, int deffenderArmor)
        {
            int hitDMG = attackerDMG - (deffenderArmor * 4);
            if (hitDMG < 0) hitDMG = 0;
            return hitDMG;
        }
    }
}