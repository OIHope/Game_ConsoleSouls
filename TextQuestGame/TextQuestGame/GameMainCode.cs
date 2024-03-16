namespace TextQuestGame
{
    class Master
    {
        
        public static PlayerStats playerStats = new PlayerStats();


        static void Main(string[] args)
        {
            Event01TavernStart.EventStart();
            Event02TavernTalk.EventStart();
            Event02Choose();
            string event02ChooseMain = Event02Choose();
            switch(event02ChooseMain)
            {
                case ("Port"):
                    int[] tmpAP = {0,0,1,1,2 };
                    CombatMechanic.Combat(true, "", 0, 0, 0, 5, tmpAP);
                    break;
                case ("Street"):
                    int[] tmpAP2 = { 1, 0, 1, 0, 2 };
                    CombatMechanic.Combat(true, "", 0, 0, 0, 5, tmpAP2);
                    break;
            }
        }
        static string Event02Choose()
        {
            string event02result = "";
            bool startEvent = true;
            while (startEvent = true)
            {
                Console.Clear();
                Console.WriteLine("===== Actions:");
                Console.WriteLine("(1) Go to the City Port");
                Console.WriteLine("(2) Go to the Venessa Street\n");
                string tempInput = Console.ReadLine();


                if (string.IsNullOrEmpty(tempInput)) { }
                else if (tempInput == "1")
                {
                    Console.Clear();
                    event02result = "Port";
                    break;
                }
                else if (tempInput == "2")
                {
                    Console.Clear();
                    event02result = "Street";
                    break;
                }
            }
            return event02result;
        }   
    }
}
