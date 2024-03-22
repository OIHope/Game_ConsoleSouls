namespace ConsoleSouls
{
    public class SystemStats
    {

        public int bleedTimer = 5;
        public int bleedDamage = 5;
        public int potionHeal = 20;
    }
    public class PlayerStats
    {
        public string status = "Normal";

        public int playerHP = 50;
        public int plMaxHP = 50;

        public int playerDMG = 10;

        public int playerPotions = 2;

        public int playerXP = 0;
        public int playerLevel = 1;

        public int xpToLevelUP = 50;

        public bool bleed = false;
        public int bleedTimer;

    }
    public class EnemyStats
    {
        public string status = "Normal";

        public string enemyName = "";

        public int enemyMaxHP;
        public int enemyHP;
        public int enemyDMG;

        public int expForWin;
        public int enemyCount;

        public bool bleed = false;
        public int bleedTimer;

    }
}
