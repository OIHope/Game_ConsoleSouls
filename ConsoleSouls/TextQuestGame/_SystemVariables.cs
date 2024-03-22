using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSouls
{
    public class PlayerStats
    {
        public int playerHP = 50;
        public int plMaxHP = 50;

        public int playerDMG = 10;

        public int playerPotions = 2;
        public int potionHeal = 20;

        public int playerXP = 0;
        public int playerLevel = 1;

        public int xpToLevelUP = 50;

    }
    public class EnemyStats
    {
        public string enemyName = "";

        public int enemyMaxHP;
        public int enemyHP;
        public int enemyDMG;

        public int expForWin;
        public int enemyCount;
    }
}
