using System;
using System.Xml.Linq;

namespace ConsoleSouls
{

    class CombatMechanic
    {
        public static EnemyStats enemyStats = new EnemyStats();
        public static void Combat(bool randomEnemy, string enemyName, int enemyHP, int enemyDMG, int enemyArmor, int count, int[] enemyPattern, int expWin)
        {
            Random random = new Random();

            int[] aP = new int[5];
            string[] enAP = new string[5];

            if (randomEnemy)
            {
                CombatMechanic.enemyStats.enemyName = GetEnemyName(random.Next(0,7));
                CombatMechanic.enemyStats.enemyHP = (int)((random.Next(25, 46) * Master.playerStats.playerLevel) * 0.55);
                CombatMechanic.enemyStats.enemyDMG = (int)((random.Next(10, 21) * Master.playerStats.playerLevel) * 0.55);
                CombatMechanic.enemyStats.enemyArmor = (int)((random.Next(3, 11) * Master.playerStats.playerLevel) * 0.55);
                CombatMechanic.enemyStats.expForWin = (int)(random.Next(15, 51) * Master.playerStats.playerLevel);
                CombatMechanic.enemyStats.enemyCount = count;
                aP[0] = 0;
                aP[1] = 0;
                aP[2] = 1;
                aP[3] = 0;
                aP[4] = 2;
            }
            else
            {
                CombatMechanic.enemyStats.enemyName = enemyName;
                CombatMechanic.enemyStats.enemyHP = enemyHP;
                CombatMechanic.enemyStats.enemyDMG = enemyDMG;
                CombatMechanic.enemyStats.enemyArmor = enemyArmor;
                CombatMechanic.enemyStats.expForWin = expWin;
                CombatMechanic.enemyStats.enemyCount = count;
                aP[0] = enemyPattern[0];
                aP[1] = enemyPattern[1];
                aP[2] = enemyPattern[2];
                aP[3] = enemyPattern[3];
                aP[4] = enemyPattern[4];
            }
            for (int j = 0; j < aP.Length; j++)
            {
                string tmpName = "";
                if (aP[j] == 0) tmpName = "Attack";
                else if (aP[j] == 1) tmpName = "Deffend";
                else if (aP[j] == 2) tmpName = "Dodge";
                enAP[j] = tmpName;
            }
            int i = 0;
            ManageCombat(enAP, enemyHP);
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
        static void ManageCombat(string[] enAP, int enemyHP)
        {
            int i = 0;

            while ((CombatMechanic.enemyStats.enemyHP > 0) && (CombatMechanic.enemyStats.enemyCount > 0))
            {
                if (i > enAP.Length - 1) i = 0;
                ManagePlayer();
                GetInterface.CombatInterface(CombatMechanic.enemyStats.enemyName,
                    CombatMechanic.enemyStats.enemyHP, CombatMechanic.enemyStats.enemyArmor,
                    CombatMechanic.enemyStats.enemyDMG, enAP, i);
                PlayerAction(enAP, i);
                i++;
                ManageRound(enemyHP);
            }
        }
        static void ManageRound(int enemyHP)
        {
            if (Master.playerStats.playerHP <= 0)
                ManageGameOver();

            if (CombatMechanic.enemyStats.enemyHP <= 0)
            {
                Console.Clear();
                Master.playerStats.playerXP += CombatMechanic.enemyStats.expForWin;
                CombatMechanic.enemyStats.enemyCount -= 1;
                if (CombatMechanic.enemyStats.enemyCount > 0) CombatMechanic.enemyStats.enemyHP = enemyHP;
                GetInterface.CombatEnemyDefeat(CombatMechanic.enemyStats.enemyName, CombatMechanic.enemyStats.expForWin);
            }

            if (Master.playerStats.playerXP >= Master.playerStats.xpToLevelUP)
                ManageLevelUp();
        }
        static void ManagePlayer()
        {
            if (Master.playerStats.playerHP > Master.playerStats.plMaxHP) Master.playerStats.playerHP = Master.playerStats.plMaxHP;
            if (Master.playerStats.playerPotions < 0) Master.playerStats.playerPotions = 0;
        }
        static void ManageLevelUp()
        {
            Master.playerStats.playerLevel++;
            Master.playerStats.playerDMG += 5;
            Master.playerStats.playerArmor += 2;
            Master.playerStats.plMaxHP += 5;
            Master.playerStats.playerXP -= Master.playerStats.xpToLevelUP;
            Master.playerStats.xpToLevelUP *= 2;
            Master.playerStats.playerHP = Master.playerStats.plMaxHP;
            GetInterface.CombatLevelUp();
        }
        static void ManageGameOver()
        {
            GetInterface.GameOver();
            Console.ReadKey();
            Environment.Exit(0);
        }
        static void PlayerAction(string[] enAP, int i)
        {
            string inputValue = Console.ReadLine();
            Console.WriteLine("");

            if (inputValue == "1")
            {
                PlayerAttack(enAP, i);
            }
            else if (inputValue == "2")
            {
                PlayerDeffend(enAP, i);
            }
            else if (inputValue == "3")
            {
                PlayerDodge(enAP, i);
            }
            else if ((inputValue == "4") && (Master.playerStats.playerPotions > 0))
            {
                PlayerPotion(enAP, i);
            }
            else if ((inputValue == "4") && (Master.playerStats.playerPotions == 0))
            {
                PlayerNoPotion(enAP, i);
            }
            else
            {
                PlayerStand(enAP, i);
            }
        }
        static void PlayerAttack(string[] enAP, int i)
        {
            Random random = new Random();
            int rnd = random.Next(0, 101);

            switch (enAP[i])
            {
                case "Attack":
                    if ((rnd >= 0) && (rnd <= 75))
                    {
                        int ddPL = DDDefend(CombatMechanic.enemyStats.enemyDMG, Master.playerStats.playerArmor);
                        int ddEN = DDDefend(Master.playerStats.playerDMG, CombatMechanic.enemyStats.enemyArmor);
                        Master.playerStats.playerHP -= ddPL;
                        CombatMechanic.enemyStats.enemyHP -= ddEN;

                        Console.WriteLine($"You both charge! \n{CombatMechanic.enemyStats.enemyName} hit your chin and deal {ddPL} dammage\n" +
                            $"You manage to hit enemies ear and deal {ddEN} damage\n");
                        Console.WriteLine("\n---press Enter---");
                        Console.ReadKey();
                    }
                    else if ((rnd >= 76) && (rnd <= 95))
                    {
                        Console.WriteLine($"You both charge! \n{CombatMechanic.enemyStats.enemyName} slips on the flour and deal no dammage\n" +
                            $"You stop and laugh at {CombatMechanic.enemyStats.enemyName} and only deal some emotional damage\n" +
                            $"\n" +
                            $"---press Enter---");
                        Console.ReadKey();
                    }
                    else
                    {
                        int ddEN = DDCRITAtack(Master.playerStats.playerDMG, CombatMechanic.enemyStats.enemyArmor);
                        CombatMechanic.enemyStats.enemyHP -= ddEN;
                        Console.WriteLine($"You both charge! And so happen that you make the right move\n" +
                            $"and dodge enemies attack. Then you land your CRITICAL strike, dealing {ddEN} damage!");
                        Console.WriteLine("\n---press Enter---");
                        Console.ReadKey();
                    }
                    break;
                case "Deffend":
                    if ((rnd >= 0) && (rnd <= 76))
                    {
                        int ddEN = DDDefend(Master.playerStats.playerDMG, CombatMechanic.enemyStats.enemyArmor);
                        CombatMechanic.enemyStats.enemyHP -= ddEN;
                        Console.WriteLine($"You charge! \n{CombatMechanic.enemyStats.enemyName} is trying to block your attack\n" +
                            $"At the last moment you spot a gap in his deffence and land your hit on the weak spot\n" +
                            $"{CombatMechanic.enemyStats.enemyName} bends from pain as you dealt him {ddEN} damage\n" +
                            $"\n" +
                            $"---press Enter---");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"You charge! But {CombatMechanic.enemyStats.enemyName} blocks your attack " +
                            $"\n" +
                            $"---press Enter---");
                        Console.ReadKey();
                    }
                    break;
                case "Dodge":
                    if ((rnd >= 0) && (rnd <= 50))
                    {
                        Console.WriteLine($"{CombatMechanic.enemyStats.enemyName} dogded you attack!");
                        Console.WriteLine("\n---press Enter---");
                        Console.ReadKey();
                    }
                    else if ((rnd >= 51) && (rnd <= 95))
                    {
                        int ddEN = DDAtack(Master.playerStats.playerDMG, CombatMechanic.enemyStats.enemyArmor);
                        CombatMechanic.enemyStats.enemyHP -= ddEN;
                        Console.WriteLine($"You manage to hit {CombatMechanic.enemyStats.enemyName} with just a tip of your weapon \nand deal {ddEN} damage");
                        Console.WriteLine("\n---press Enter---");
                        Console.ReadKey();
                    }
                    else
                    {
                        int ddEN = DDCRITAtack(Master.playerStats.playerDMG, CombatMechanic.enemyStats.enemyArmor);
                        CombatMechanic.enemyStats.enemyHP -= ddEN;
                        Console.WriteLine($"{CombatMechanic.enemyStats.enemyName} makes a very predictable move and you land a CRITICAL hit, \ndealing {ddEN} damage!");
                        Console.WriteLine("\n---press Enter---");
                        Console.ReadKey();
                    }
                    break;
            }
        }
        static void PlayerDeffend(string[] enAP, int i)
        {
            Random random = new Random();
            int rnd = random.Next(0, 101);

            switch (enAP[i])
            {
                case "Attack":
                    if ((rnd >= 0) && (rnd <= 30))
                    {
                        int ddPL = DDDefend(CombatMechanic.enemyStats.enemyDMG, Master.playerStats.playerArmor);
                        Master.playerStats.playerHP -= ddPL;
                        Console.WriteLine($"Enemies attack is blocked, but you notice blood on your hands.\n" +
                            $"{CombatMechanic.enemyStats.enemyName} seems to get you and deal {ddPL} damage");
                        Console.WriteLine("\n---press Enter---");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Attack is blocked!\n" +
                            $"NO damage dealt!");
                        Console.WriteLine("\n---press Enter---");
                        Console.ReadKey();
                    }
                    break;
                case "Deffend":
                    Console.WriteLine($"Noone makes a move, you watch {CombatMechanic.enemyStats.enemyName} watch you...");
                    Console.WriteLine("\n---press Enter---");
                    Console.ReadKey();
                    break;
                case "Dodge":
                    Console.WriteLine($"{CombatMechanic.enemyStats.enemyName}`s dodge seems so dangerous, so you decide to block...");
                    Console.WriteLine("\n---press Enter---");
                    Console.ReadKey();
                    break;
            }
        }
        static void PlayerDodge(string[] enAP, int i)
        {
            Random random = new Random();
            int rnd = random.Next(0, 101);
            switch (enAP[i])
            {
                case "Attack":
                    if ((rnd >= 0) && (rnd <= 85))
                    {
                        Console.WriteLine($"You dodged {CombatMechanic.enemyStats.enemyName} attack!");
                        Console.WriteLine("\n---press Enter---");
                        Console.ReadKey();
                    }
                    else if ((rnd >= 86) && (rnd <= 95))
                    {
                        int ddPL = DDAtack(CombatMechanic.enemyStats.enemyDMG, Master.playerStats.playerArmor);
                        Master.playerStats.playerHP -= ddPL;
                        Console.WriteLine($"{CombatMechanic.enemyStats.enemyName} charges and manage to get you and deal {ddPL} damage");
                        Console.WriteLine("\n---press Enter---");
                        Console.ReadKey();
                    }
                    else
                    {
                        int ddPL = DDCRITAtack(CombatMechanic.enemyStats.enemyDMG, Master.playerStats.playerArmor);
                        Master.playerStats.playerHP -= ddPL;
                        Console.WriteLine($"{CombatMechanic.enemyStats.enemyName} charges and manage to get you and deal CRITICAL {ddPL} damage");
                        Console.WriteLine("\n---press Enter---");
                        Console.ReadKey();
                    }
                    break;
                case "Deffend":
                    Console.WriteLine($"Seems like {CombatMechanic.enemyStats.enemyName} blocks you dodge...");
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
        static void PlayerPotion(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Attack":
                    int ddPL = DDCRITAtack(CombatMechanic.enemyStats.enemyDMG, Master.playerStats.playerArmor);
                    Master.playerStats.playerHP -= ddPL;
                    Console.WriteLine($"As {CombatMechanic.enemyStats.enemyName} attack, you open yourself looking for a potion\n" +
                        $"Enemy get's you and lends CRITICAL hit dealing {ddPL} damage");
                    Console.WriteLine("\n---press Enter---");
                    Console.ReadKey();
                    break;
                case "Deffend":
                    Master.playerStats.playerHP += Master.playerStats.potionHeal;
                    Master.playerStats.playerPotions--;
                    GetInterface.CombatUsePotion();
                    break;
                case "Dodge":
                    Master.playerStats.playerHP += Master.playerStats.potionHeal;
                    Master.playerStats.playerPotions--;
                    GetInterface.CombatUsePotion();
                    break;
            }
        }
        static void PlayerNoPotion(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Attack":
                    int ddPL = DDCRITAtack(CombatMechanic.enemyStats.enemyDMG, Master.playerStats.playerArmor);
                    Master.playerStats.playerHP -= ddPL;
                    Console.WriteLine($"As {CombatMechanic.enemyStats.enemyName} attack, you open yourself looking for a potion\n" +
                        $"Enemy get's you and lends CRITICAL hit dealing {ddPL} damage");
                    Console.WriteLine("\n---press Enter---");
                    Console.ReadKey();
                    break;
                case "Deffend":
                    GetInterface.CombaNoPotion();
                    break;
                case "Dodge":
                    GetInterface.CombaNoPotion();
                    break;
            }
        }
        static void PlayerStand(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Attack":
                    int ddPL = DDCRITAtack(CombatMechanic.enemyStats.enemyDMG, Master.playerStats.playerArmor);
                    Master.playerStats.playerHP -= ddPL;
                    Console.WriteLine($"As {CombatMechanic.enemyStats.enemyName} attack, you just stand and watch how\n" +
                        $"enemy get's you and lends CRITICAL hit dealing {ddPL} damage");
                    Console.WriteLine("\n---press Enter---");
                    Console.ReadKey();
                    break;
                case "Deffend":
                    Console.WriteLine($"You stand still and watch {CombatMechanic.enemyStats.enemyName} defending");
                    Console.WriteLine("\n---press Enter---");
                    Console.ReadKey();
                    break;
                case "Dodge":
                    Console.WriteLine($"You stand still and watch {CombatMechanic.enemyStats.enemyName} dodging like crazy");
                    Console.WriteLine("\n---press Enter---");
                    Console.ReadKey();
                    break;
            }
        }
        static int DDAtack(int attackerDMG, int deffenderArmor)
        {
            int hitDMG = attackerDMG - (deffenderArmor/2);
            if (hitDMG < 0) hitDMG = 0;
            return hitDMG;
        }
        static int DDCRITAtack(int attackerDMG, int deffenderArmor)
        {
            int hitDMG = (attackerDMG*2) - (deffenderArmor/2);
            if (hitDMG < 0) hitDMG = 0;
            return hitDMG;
        }
        static int DDDefend(int attackerDMG, int deffenderArmor)
        {
            int hitDMG = attackerDMG - deffenderArmor;
            if (hitDMG < 0) hitDMG = 0;
            return hitDMG;
        }

    }
}
