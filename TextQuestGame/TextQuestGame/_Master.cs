namespace ConsoleSouls
{
    class Master
    {
        
        public static PlayerStats playerStats = new PlayerStats();


        static void Main(string[] args)
        {
            Event01TavernStart.EventStart();
            Event02TavernTalk.EventStart();
            Event03GetStronger.GetStronger();

        }   
    }
}
