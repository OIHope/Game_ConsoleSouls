using System;
using System.Xml.Linq;

namespace ConsoleSouls
{

    class CombatMechanic
    {
        public static EnemyStats enemyStats = new EnemyStats();
        public static void Combat(string enemyName, int enemyHP, int enemyDMG, int expWin, int count, int[] enemyPattern)
        {
            GetInterface.CombatGetReady(enemyName);

            int[] aP = new int[enemyPattern.Length];
            string[] enAP = new string[enemyPattern.Length];

            ResetEnemy();

            enemyStats.enemyName = enemyName;
            enemyStats.enemyMaxHP = enemyHP;
            enemyStats.enemyHP = enemyStats.enemyMaxHP;
            enemyStats.enemyDMG = enemyDMG;
            enemyStats.expForWin = expWin;
            enemyStats.enemyCount = count;

            for (int j = 0; j < aP.Length; j++)
            {
                string tmpName = "";
                aP[j] = enemyPattern[j];
                if (aP[j] == 0) tmpName = "Low Attack";
                else if (aP[j] == 1) tmpName = "Slash Attack";
                else if (aP[j] == 2) tmpName = "High Attack";
                else if (aP[j] == 3) tmpName = "Block";
                else if (aP[j] == 4) tmpName = "Dodge";
                else if (aP[j] == 5) tmpName = "Parry";
                enAP[j] = tmpName;
            }
            int i = 0;
            if (Master.systemStats.eventOn == "training")
                ManageCombatTraining(enAP);
            else
                ManageCombat(enAP);
        }
        public static void CombatRandom(int count)
        {
            Random random = new Random();


            int[] aP = new int[7];
            string[] enAP = new string[7];

            ResetEnemy();

            enemyStats.enemyName = GetEnemyName(random.Next(0, 7));
            enemyStats.enemyMaxHP = (int)((random.Next(25, 46) * Master.playerStats.playerLevel) * 0.55);
            enemyStats.enemyHP = enemyStats.enemyMaxHP;
            enemyStats.enemyDMG = (int)((random.Next(10, 21) * Master.playerStats.playerLevel) * 0.55);
            enemyStats.expForWin = (int)(random.Next(15, 51) * Master.playerStats.playerLevel);
            enemyStats.enemyCount = count;

            GetInterface.CombatGetReady(enemyStats.enemyName);
            
            for (int j = 0; j < aP.Length; j++)
            {
                string tmpName = "";
                aP[j] = random.Next(0, 6);
                if (aP[j] == 0) tmpName = "Low Attack";
                else if (aP[j] == 1) tmpName = "Slash Attack";
                else if (aP[j] == 2) tmpName = "High Attack";
                else if (aP[j] == 3) tmpName = "Block";
                else if (aP[j] == 4) tmpName = "Dodge";
                else if (aP[j] == 5) tmpName = "Parry";
                enAP[j] = tmpName;
            }
            int i = 0;
            ManageCombat(enAP);
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
        static void ManageCombat(string[] enAP)
        {
            int i = 0;

            while ((enemyStats.enemyHP > 0) && (enemyStats.enemyCount > 0))
            {
                if (i > enAP.Length - 1) i = 0;
                ManagePlayer();
                GetInterface.CombatInterface(enemyStats.enemyName,
                    enemyStats.enemyHP,
                    enemyStats.enemyDMG, enAP, i);
                PlayerAction(enAP, i);
                i++;
                ManageRound();
            }
        }
        static void ManageCombatTraining(string[] enAP)
        {
            int i = 0;
            int roundCount = 0;

            while ((enemyStats.enemyHP > 900) && (roundCount != 15) && (Master.playerStats.playerHP > 20))
            {
                if (i > enAP.Length - 1) i = 0;
                ManagePlayer();
                GetInterface.CombatInterface(enemyStats.enemyName,
                    enemyStats.enemyHP,
                    enemyStats.enemyDMG, enAP, i);
                PlayerAction(enAP, i);
                i++;
                roundCount++;
                ManageRound();
            }
            Master.systemStats.eventOn = "";

        }
        static void ManageRound()
        {
            if (Master.playerStats.playerHP <= 0)
                ManageGameOver();

            if (enemyStats.enemyHP <= 0)
            {

                Console.Clear();
                Master.playerStats.playerXP += enemyStats.expForWin;
                enemyStats.enemyCount -= 1;
                if (enemyStats.enemyCount > 0)
                    ResetEnemy();
                GetInterface.CombatEnemyDefeat(enemyStats.enemyName, enemyStats.expForWin);
            }

            if (Master.playerStats.playerXP >= Master.playerStats.xpToLevelUP)
                ManageLevelUp();
        }
        static void ManagePlayer()
        {
            if (Master.playerStats.playerHP > Master.playerStats.plMaxHP) Master.playerStats.playerHP = Master.playerStats.plMaxHP;
            if (Master.playerStats.playerPotions < 0) Master.playerStats.playerPotions = 0;
            if (Master.playerStats.bleedTimer < 0) Master.playerStats.bleedTimer = 0;
            if (!Master.playerStats.bleed) Master.playerStats.bleedTimer = 0;
        }
        static void ManageLevelUp()
        {
            Master.playerStats.playerLevel++;
            Master.playerStats.playerDMG += 5;
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
        static void ResetEnemy()
        {
            enemyStats.enemyHP = enemyStats.enemyMaxHP;
            enemyStats.bleed = false;
            enemyStats.bleedTimer = 0;
            enemyStats.status = "Normal";
        }
        static void PlayerAction(string[] enAP, int i)
        {
            string inputValue = Console.ReadLine();
            Console.WriteLine("");

            if (inputValue == "1")
                PlayerLowAttack(enAP, i);
            else if (inputValue == "2")
                PlayerSlashAttack(enAP, i);
            else if (inputValue == "3")
                PlayerHighAttack(enAP, i);
            else if (inputValue == "4")
                PlayerBlock(enAP, i);
            else if (inputValue == "5")
                PlayerDodge(enAP, i);
            else if (inputValue == "6")
                PlayerParry(enAP, i);
            else if ((inputValue == "7") && (Master.playerStats.playerPotions > 0))
                PlayerPotion(enAP, i);
            else if ((inputValue == "7") && (Master.playerStats.playerPotions == 0))
                PlayerNoPotion(enAP, i);
            else
                PlayerStand(enAP, i);
        }
        static void PlayerLowAttack(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Low Attack":
                    {
                        int plHit = DamagePlayerLow();
                        int enHit = DamageEnemyLow();
                        Console.WriteLine($"Player is hit by {plHit} DMG\n" +
                            $"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(1, "player");
                        BleedingApply(1, "enemy");
                        break;
                    }
                case "Slash Attack":
                    {   
                        int plHit = DamagePlayerLow();
                        int enHit = DamageEnemyMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG\n" +
                            $"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(1, "player");
                        BleedingApply(25, "enemy");
                        break;
                    }
                case "High Attack":
                    {
                        int plHit = DamagePlayerMax();
                        int enHit = DamageEnemyLow();
                        Console.WriteLine($"Player is hit by {plHit} DMG\n" +
                            $"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(25, "player");
                        BleedingApply(1, "enemy");
                        break;

                    }
                case "Block":
                    {
                        int enHit = DamageEnemyBlockLow();
                        Console.WriteLine($"{enemyStats.enemyName} is hit by {enHit} DMG");
                        break;
                    }
                case "Dodge":
                    {
                        int enHit = DamageEnemyBlockHigh();
                        Console.WriteLine($"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(5, "enemy");
                        break;
                    }
                case "Parry":
                    {
                        Console.WriteLine($"{enemyStats.enemyName} takes NO DMG");
                        break;
                    }
            }
            BleedingCheck();
            GetInterface.PromptPressEnter();
        }
        static void PlayerSlashAttack(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Low Attack":
                    {
                        int plHit = DamagePlayerMax();
                        int enHit = DamageEnemyLow();
                        Console.WriteLine($"Player is hit by {plHit} DMG\n" +
                            $"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(25, "player");
                        BleedingApply(1, "enemy");
                        break;
                    }
                case "Slash Attack":
                    {
                        int plHit = DamagePlayerLow();
                        int enHit = DamageEnemyLow();
                        Console.WriteLine($"Player is hit by {plHit} DMG\n" +
                            $"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(1, "player");
                        BleedingApply(1, "enemy");
                        break;
                    }
                case "High Attack":
                    {
                        int plHit = DamagePlayerLow();
                        int enHit = DamageEnemyMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG\n" +
                            $"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(1, "player");
                        BleedingApply(25, "enemy");
                        break;
                    }
                case "Block":
                    {
                        Console.WriteLine($"{enemyStats.enemyName} takes NO DMG");
                        break;
                        
                    }
                case "Dodge":
                    {
                        int enHit = DamageEnemyBlockLow();
                        Console.WriteLine($"{enemyStats.enemyName} is hit by {enHit} DMG");
                        break;
                    }
                case "Parry":
                    {
                        int enHit = DamageEnemyBlockHigh();
                        Console.WriteLine($"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(5, "enemy");
                        break;
                    }
            }
            BleedingCheck();
            GetInterface.PromptPressEnter();
        }
        static void PlayerHighAttack(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Low Attack":
                    {
                        int plHit = DamagePlayerLow();
                        int enHit = DamageEnemyMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG\n" +
                            $"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(1, "player");
                        BleedingApply(25, "enemy");
                        break;
                    }
                case "Slash Attack":
                    {
                        int plHit = DamagePlayerMax();
                        int enHit = DamageEnemyLow();
                        Console.WriteLine($"Player is hit by {plHit} DMG\n" +
                            $"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(25, "player");
                        BleedingApply(1, "enemy");
                        break;
                    }
                case "High Attack":
                    {
                        int plHit = DamagePlayerLow();
                        int enHit = DamageEnemyLow();
                        Console.WriteLine($"Player is hit by {plHit} DMG\n" +
                            $"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(1, "player");
                        BleedingApply(1, "enemy");
                        break;
                    }
                case "Block":
                    {
                        int enHit = DamageEnemyBlockHigh();
                        Console.WriteLine($"{enemyStats.enemyName} is hit by {enHit} DMG");
                        BleedingApply(5, "enemy");
                        break;
                    }
                case "Dodge":
                    {
                        Console.WriteLine($"{enemyStats.enemyName} takes NO DMG");
                        break;
                    }
                case "Parry":
                    {
                        int enHit = DamageEnemyBlockLow();
                        Console.WriteLine($"{enemyStats.enemyName} is hit by {enHit} DMG");
                        break;
                    }
            }
            BleedingCheck();
            GetInterface.PromptPressEnter();
        }
        static void PlayerBlock(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Low Attack":
                    {
                        int plHit = DamagePlayerBlockLow();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        break;
                    }
                case "Slash Attack":
                    {
                        Console.WriteLine($"Player takes NO DMG");
                        break;
                    }
                case "High Attack":
                    {
                        int plHit = DamagePlayerBlockMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(5, "player");
                        break;
                    }
                case "Block":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
                case "Dodge":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
                case "Parry":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
            }
            BleedingCheck();
            GetInterface.PromptPressEnter();
        }
        static void PlayerDodge(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Low Attack":
                    {
                        int plHit = DamagePlayerBlockMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(5, "player");
                        break;
                    }
                case "Slash Attack":
                    {
                        int plHit = DamagePlayerBlockLow();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        break;
                    }
                case "High Attack":
                    {
                        Console.WriteLine($"Player takes NO DMG");
                        break;
                    }
                case "Block":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
                case "Dodge":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
                case "Parry":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
            }
            BleedingCheck();
            GetInterface.PromptPressEnter();
        }
        static void PlayerParry(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Low Attack":
                    {
                        Console.WriteLine($"Player takes NO DMG");
                        break;
                    }
                case "Slash Attack":
                    {
                        int plHit = DamagePlayerBlockMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(5, "player");
                        break;
                    }
                case "High Attack":
                    {
                        int plHit = DamagePlayerBlockLow();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        break;
                    }
                case "Block":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
                case "Dodge":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
                case "Parry":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
            }
            BleedingCheck();
            GetInterface.PromptPressEnter();
        }
        static void PlayerPotion(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Low Attack":
                    {
                        int plHit = DamagePlayerMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(40, "player");
                        break;
                    }
                case "Slash Attack":
                    {
                        int plHit = DamagePlayerMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(40, "player");
                        break;
                    }
                case "High Attack":
                    {
                        int plHit = DamagePlayerMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(40, "player");
                        break;
                    }
                case "Block":
                    {
                        GetInterface.CombatUsePotion();
                        break;
                    }
                case "Dodge":
                    {
                        GetInterface.CombatUsePotion();
                        break;
                    }
                case "Parry":
                    {
                        GetInterface.CombatUsePotion();
                        break;
                    }
            }
            BleedingCheck();
            GetInterface.PromptPressEnter();
        }
        static void PlayerNoPotion(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Low Attack":
                    {
                        int plHit = DamagePlayerMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(40, "player");
                        break;
                    }
                case "Slash Attack":
                    {
                        int plHit = DamagePlayerMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(40, "player");
                        break;
                    }
                case "High Attack":
                    {
                        int plHit = DamagePlayerMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(40, "player");
                        break;
                    }
                case "Block":
                    {
                        GetInterface.CombatNoPotion();
                        break;
                    }
                case "Dodge":
                    {
                        GetInterface.CombatNoPotion();
                        break;
                    }
                case "Parry":
                    {
                        GetInterface.CombatNoPotion();
                        break;
                    }
            }
            BleedingCheck();
            GetInterface.PromptPressEnter();
        }
        static void PlayerStand(string[] enAP, int i)
        {
            switch (enAP[i])
            {
                case "Low Attack":
                    {
                        int plHit = DamagePlayerMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(80, "player");
                        break;
                    }
                case "Slash Attack":
                    {
                        int plHit = DamagePlayerMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(80, "player");
                        break;
                    }
                case "High Attack":
                    {
                        int plHit = DamagePlayerMax();
                        Console.WriteLine($"Player is hit by {plHit} DMG");
                        BleedingApply(80, "player");
                        break;
                    }
                case "Block":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
                case "Dodge":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
                case "Parry":
                    {
                        Console.WriteLine($"Nothing happens");
                        break;
                    }
            }
            BleedingCheck();
            GetInterface.PromptPressEnter();
        }
        static int DamagePlayerLow()
        {
            int hitDMG = (int)(enemyStats.enemyDMG*0.1);
            if (hitDMG < 0) hitDMG = 0;
            Master.playerStats.playerHP -= hitDMG;
            return hitDMG;
        }
        static int DamagePlayerMax()
        {
            int hitDMG = enemyStats.enemyDMG;
            if (hitDMG < 0) hitDMG = 0;
            Master.playerStats.playerHP -= hitDMG;
            return hitDMG;
        }
        static int DamagePlayerBlockLow()
        {
            int hitDMG = (int)(enemyStats.enemyDMG * 0.3);
            if (hitDMG < 0) hitDMG = 0;
            Master.playerStats.playerHP -= hitDMG;
            return hitDMG;
        }
        static int DamagePlayerBlockMax()
        {
            int hitDMG = (int)(enemyStats.enemyDMG * 0.6);
            if (hitDMG < 0) hitDMG = 0;
            Master.playerStats.playerHP -= hitDMG;
            return hitDMG;
        }
        static int DamageEnemyLow()
        {
            int hitDMG = (int)(Master.playerStats.playerDMG * 0.1);
            if (hitDMG < 0) hitDMG = 0;
            enemyStats.enemyHP -= hitDMG;
            return hitDMG;
        }
        static int DamageEnemyMax()
        {
            int hitDMG = Master.playerStats.playerDMG;
            if (hitDMG < 0) hitDMG = 0;
            enemyStats.enemyHP -= hitDMG;
            return hitDMG;
        }
        static int DamageEnemyBlockLow()
        {
            int hitDMG = (int)(Master.playerStats.playerDMG * 0.3);
            if (hitDMG < 0) hitDMG = 0;
            enemyStats.enemyHP -= hitDMG;
            return hitDMG;
        }
        static int DamageEnemyBlockHigh()
        {
            int hitDMG = (int)(Master.playerStats.playerDMG * 0.6);
            if (hitDMG < 0) hitDMG = 0;
            enemyStats.enemyHP -= hitDMG;
            return hitDMG;
        }
        static void BleedingCheck()
        {
            if (Master.playerStats.bleed && (Master.playerStats.bleedTimer > 0))
            {
                Master.playerStats.status = "Bleeding";
                Master.playerStats.playerHP -= Master.systemStats.bleedDamage;
                Master.playerStats.bleedTimer--;
                Console.WriteLine($"Player loses {Master.systemStats.bleedDamage} HP because of BLEEDING STATUS");
            }
            if (CombatMechanic.enemyStats.bleed && (CombatMechanic.enemyStats.bleedTimer > 0))
            {
                CombatMechanic.enemyStats.status = "Bleeding";
                CombatMechanic.enemyStats.enemyHP -= Master.systemStats.bleedDamage;
                CombatMechanic.enemyStats.bleedTimer--;
                Console.WriteLine($"{CombatMechanic.enemyStats.enemyName} loses {Master.systemStats.bleedDamage} HP because of BLEEDING STATUS");
            }
            if (Master.playerStats.bleedTimer == 0)
            { 
                Master.playerStats.bleed = false;
                Master.playerStats.status = "Normal";
            }
            if (CombatMechanic.enemyStats.bleedTimer == 0)
            {
                CombatMechanic.enemyStats.bleed = false;
                CombatMechanic.enemyStats.status = "Normal";
            }
        }
        static void BleedingApply(int chance, string victim)
        {
            Random random = new Random();
            int bleedCheck = random.Next(0,101);
            if ((bleedCheck <= chance) && (victim == "player"))
            {
                Master.playerStats.bleed = true;
                Master.playerStats.bleedTimer += Master.systemStats.bleedTimer;
                Console.WriteLine($"Player gain BLEEDING status for +{Master.systemStats.bleedTimer} turns!");
            }
            else if ((bleedCheck <= chance) && (victim == "enemy"))
            {
                CombatMechanic.enemyStats.bleed = true;
                CombatMechanic.enemyStats.bleedTimer += Master.systemStats.bleedTimer;
                Console.WriteLine($"{CombatMechanic.enemyStats.enemyName} gain BLEEDING status for +{Master.systemStats.bleedTimer} turns!");
            }
        }
    }
}
