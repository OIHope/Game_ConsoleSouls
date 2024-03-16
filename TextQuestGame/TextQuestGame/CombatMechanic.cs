namespace TextQuestGame
{

    class CombatMechanic
    {

        public static void Combat(bool randomEnemy, string enemyName, int enemyHP, int enemyDMG, int enemyArmor, int count, int[] enemyPattern, int expWin)
        {
            Random random = new Random();

            string enName = "";
            int enHP = 0;
            int enDMG = 0;
            int enArmor = 0;
            int enCount = count;
            int expForWin = 0;
            int[] aP = new int[5];
            string[] enAP = new string[5];

            if (randomEnemy)
            {
                enName = GetEnemyName(random.Next(0,7));
                enHP = random.Next(40,86);
                enDMG = random.Next(10, 26);
                enArmor = random.Next(5, 21);
                expForWin = random.Next(15, 31);
                aP[0] = 0;
                aP[1] = 0;
                aP[2] = 1;
                aP[3] = 0;
                aP[4] = 2;
            }
            else
            {
                enName = enemyName;
                enHP = enemyHP;
                enDMG = enemyDMG;
                enArmor = enemyArmor;
                expForWin = expWin;
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

            while ((enHP > 0) && (enCount > 0))
            {
                if (i > enAP.Length-1) i = 0;
                ManagePlayer();

                Console.Clear();
                Console.WriteLine($"    {enName}");
                Console.WriteLine("===========================");
                Console.WriteLine($"||  HP = {enHP}  ||  Armor = {enArmor} ||  DMG = {enDMG}");
                Console.WriteLine($"||  Next move = {enAP[i]}");
                Console.WriteLine("===========================");
                Console.WriteLine("\n       ---VS---\n");
                Console.WriteLine("     Kvout Lvl "+ Master.playerStats.playerLevel + " EXP: "+ Master.playerStats.playerXP+"/"+Master.playerStats.xpToLevelUP);
                Console.WriteLine("===========================");
                Console.WriteLine($"||  HP = {Master.playerStats.playerHP}  ||  Armor = {Master.playerStats.playerArmor}  ||  DMG = {Master.playerStats.playerDMG}");
                Console.WriteLine($"||  Potions = {Master.playerStats.playerPotions}");
                Console.WriteLine("===========================");
                Console.WriteLine("===Actions:\n");
                Console.WriteLine("(1) Attack");
                Console.WriteLine("(2) Deffend");
                Console.WriteLine("(3) Dodge");
                Console.WriteLine("(4) Use Potion\n");

                string inputValue = Console.ReadLine();
                Console.WriteLine("");

                if (inputValue == "1") // Player Attack System
                {
                    int rnd = random.Next(0, 101);
                    switch (enAP[i])
                    {
                        case "Attack":
                            if ((rnd >= 0) && (rnd <= 75))
                            {
                                int ddPL = DDDefend(enDMG, Master.playerStats.playerArmor);
                                int ddEN = DDDefend(Master.playerStats.playerDMG, enArmor);
                                Master.playerStats.playerHP -= ddPL;
                                enHP -= ddEN;

                                Console.WriteLine($"You both charge! \n{enName} hit your chin and deal {ddPL} dammage\n" +
                                    $"You manage to hit enemies ear and deal {ddEN} damage\n");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else if ((rnd >= 76) && (rnd <= 95))
                            {
                                Console.WriteLine($"You both charge! \n{enName} slips on the flour and deal no dammage\n" +
                                    $"You stop and laugh at {enName} and only deal some emotional damage\n" +
                                    $"\n" +
                                    $"---press Enter---");
                                Console.ReadKey();
                            }
                            else
                            {
                                int ddEN = DDCRITAtack(Master.playerStats.playerDMG, enArmor);
                                enHP -= ddEN;
                                Console.WriteLine($"You both charge! And so happen that you make the right move\n" +
                                    $"and dodge enemies attack. Then you land your CRITICAL strike, dealing {ddEN} damage!");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            break;
                        case "Deffend":
                            if ((rnd >= 0) && (rnd <= 51))
                            {
                                int ddEN = DDDefend(Master.playerStats.playerDMG, enArmor);
                                enHP -= ddEN;
                                Console.WriteLine($"You charge! \n{enName} is trying to block your attack\n" +
                                    $"At the last moment you spot a gap in his deffence and land your hit on the weak spot\n" +
                                    $"{enName} bends from pain as you dealt him {ddEN} damage\n" +
                                    $"\n" +
                                    $"---press Enter---");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($"You charge! But {enName} blocks your attack " +
                                    $"\n" +
                                    $"---press Enter---");
                                Console.ReadKey();
                            }
                            break;
                        case "Dodge":
                            if ((rnd >= 0) && (rnd <= 75))
                            {
                                Console.WriteLine($"{enName} dogded you attack!");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else if ((rnd >= 76) && (rnd <= 95))
                            {
                                int ddEN = DDAtack(Master.playerStats.playerDMG, enArmor);
                                enHP -= ddEN;
                                Console.WriteLine($"You manage to hit {enName} with just a tip of your weapon \nand deal {ddEN} damage");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else
                            {
                                int ddEN = DDCRITAtack(Master.playerStats.playerDMG, enArmor);
                                enHP -= ddEN;
                                Console.WriteLine($"{enName} makes a very predictable move and you land a CRITICAL hit, \ndealing {ddEN} damage!");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            break;
                    }
                }
                else if (inputValue == "2") // Player Deffence System
                {
                    int rnd = random.Next(0, 101);
                    switch (enAP[i])
                    {
                        case "Attack":
                            if ((rnd >= 0) && (rnd <= 30))
                            {
                                int ddPL = DDDefend(enDMG, Master.playerStats.playerArmor);
                                Master.playerStats.playerHP -= ddPL;
                                Console.WriteLine($"Enemies attack is blocked, but you notice blood on your hands.\n" +
                                    $"{enName} seems to get you and deal {ddPL} damage");
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
                    int rnd = random.Next(0, 101);
                    //dodge
                    switch (enAP[i])
                    {
                        case "Attack":
                            if ((rnd >= 0) && (rnd <= 85))
                            {
                                Console.WriteLine($"You dodged {enName} attack!");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else if ((rnd >= 86) && (rnd <= 95))
                            {
                                int ddPL = DDAtack(enDMG, Master.playerStats.playerArmor);
                                Master.playerStats.playerHP -= ddPL;
                                Console.WriteLine($"{enName} charges and manage to get you and deal {ddPL} damage");
                                Console.WriteLine("\n---press Enter---");
                                Console.ReadKey();
                            }
                            else
                            {
                                int ddPL = DDCRITAtack(enDMG, Master.playerStats.playerArmor);
                                Master.playerStats.playerHP -= ddPL;
                                Console.WriteLine($"{enName} charges and manage to get you and deal CRITICAL {ddPL} damage");
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
                else if ((inputValue == "4") && (Master.playerStats.playerPotions > 0))
                {
                    //potion
                    switch (enAP[i])
                    {
                        case "Attack":
                            int ddPL = DDCRITAtack(enDMG, Master.playerStats.playerArmor);
                            Master.playerStats.playerHP -= ddPL;
                            Console.WriteLine($"As {enName} attack, you open yourself looking for a potion\n" +
                                $"Enemy get's you and lends CRITICAL hit dealing {ddPL} damage");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                        case "Deffend":
                            Master.playerStats.playerHP += Master.playerStats.potionHeal;
                            Master.playerStats.playerPotions--;
                            Console.WriteLine($"You health if healed by 5 points");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                        case "Dodge":
                            Master.playerStats.playerHP += Master.playerStats.potionHeal;
                            Master.playerStats.playerPotions--;
                            Console.WriteLine($"You health if healed by 5 points");
                            Console.WriteLine("\n---press Enter---");
                            Console.ReadKey();
                            break;
                    }
                }
                else if ((inputValue == "4") && (Master.playerStats.playerPotions == 0))
                {
                    //no potion
                    switch (enAP[i])
                    {
                        case "Attack":
                            int ddPL = DDCRITAtack(enDMG, Master.playerStats.playerArmor);
                            Master.playerStats.playerHP -= ddPL;
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
                    switch (enAP[i])
                    {
                        case "Attack":
                            int ddPL = DDCRITAtack(enDMG, Master.playerStats.playerArmor);
                            Master.playerStats.playerHP -= ddPL;
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

                i++;

                if (Master.playerStats.playerHP <= 0)
                    ManageGameOver();

                if (enHP <= 0)
                {
                    Console.Clear();
                    int plEX = expForWin;
                    Master.playerStats.playerXP += plEX;
                    enCount -= 1;
                    if(enCount > 0) enHP = enemyHP;
                    Console.WriteLine($"======={enName} is DEFEATED!=======\n||");
                    Console.WriteLine($"||   You have earned {plEX} EXP");
                    Console.WriteLine($"||");
                    Console.WriteLine($"===================================\n\n");
                    Console.WriteLine("------press Enter to continue------");
                    Console.ReadKey();
                }

                if (Master.playerStats.playerXP >= Master.playerStats.xpToLevelUP)
                    ManageLevelUp();
            }
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
            Console.Clear();
            Console.WriteLine($"=======LEVEL UP!=======\n||");
            Console.WriteLine($"||   You are now LVL {Master.playerStats.playerLevel}!");
            Console.WriteLine($"|| Your HP is now: {Master.playerStats.plMaxHP}");
            Console.WriteLine($"|| Your ARMOR is now: {Master.playerStats.playerArmor}");
            Console.WriteLine($"|| Your DMG is now: {Master.playerStats.playerDMG}");
            Console.WriteLine($"===================================\n\n");
            Console.WriteLine("------press Enter to continue------");
            Console.ReadKey();
        }
        static void ManageGameOver()
        {
            Console.Clear();
            Console.WriteLine("=======PLAYER IS DEAD=======\n\n\n");
            Console.WriteLine("----press Enter to repeat----\n");
            Console.WriteLine("------press Esc to exit------");

            Console.ReadKey();
            Environment.Exit(0);
        }

    }
}
