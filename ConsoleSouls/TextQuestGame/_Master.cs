namespace ConsoleSouls
{
    class Master
    {
        
        public static PlayerStats playerStats = new PlayerStats();
        public static SystemStats systemStats = new SystemStats();


        static void Main(string[] args)
        {
            //Test.TestMech();
            Event01TavernStart.EventStart();
            Event02TavernTalk.EventStart();
            Event03GetStronger.GetStronger();

        }   
    }
}
