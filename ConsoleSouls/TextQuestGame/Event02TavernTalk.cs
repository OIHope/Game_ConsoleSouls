using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSouls
{
    class Event02TavernTalk
    {
        public static void EventStart()
        {

            Console.Clear();
            Console.WriteLine("- So it's you, - says the tavern keeper, - the boy from the guild.");
            Console.ReadKey();

            if (Master.playerStats.playerHP == Master.playerStats.plMaxHP)
            {
                Console.WriteLine("I guess you know how to fight, huh. Good, seems like the guild\n" +
                    "sent me the right guy for a job. So, how can I call you?");
                Console.ReadKey();
            }
            else if ((Master.playerStats.playerHP < Master.playerStats.plMaxHP) && (Master.playerStats.playerHP >= 20))
            {
                Console.WriteLine("As I thought, you'd be a tough guy, but not as good as I need.");
                Console.ReadKey();
                Console.WriteLine("   The keeper looks at you a moment, puts his glass aside.\n" +
                    "- Come here, I'll patch you up. You still look better then that guy");
                Console.ReadKey();
                GetInterface.PlayerRecover();
                Console.WriteLine("- That's better, - the keeper seems satisfied with his work.\n" +
                    "So as I see the guild sent me a rookie. What's your name, boy?");
                Console.ReadKey();
            }
            else if (Master.playerStats.playerHP < 20)
            {
                Console.WriteLine("For fuck sake, what am I supposed to do with you? You're barely can stand!\n" +
                    "No, don't touch that! You'll cover it with blood!");
                Console.ReadKey();
                Console.WriteLine("What did the guild think before sending you do the job, - the keeper seems very upset.");
                Console.ReadKey();
                Console.WriteLine("Just sit here, I'll patch you up... I don't need on more corpse here.\n" +
                    "It's pretty bad for my reputation, you know!");
                GetInterface.PlayerRecover();
                Console.WriteLine("- Well, at least you are in one piece, huh. Can stand? What's you name boy?\n" +
                    "I need to know what to write on your grave stone or whatever...");
            }
            Console.WriteLine("- Kvout.");

            ////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("- Kvout... - he frowns, - No, don't tell me you're THAT Kvout!");
            Console.ReadKey();
            Console.WriteLine("   You look at him with a smile, as you know that you fucked up, and perhaps\n" +
                "there's nothing to lose.");
            Console.ReadKey();
            Console.WriteLine("- The one and only Kvout Bloodless, Silver Bard from Eolian, at your service.");
            Console.ReadKey();
            Console.WriteLine("   The keeper keeps stareeing ant you. And then the lough thunders the tavern.");
            Console.ReadKey();
            Console.WriteLine("- Who would have thought! The legendary Siver Bard is here in my tavern, miles away from Imry town!\n" +
                "My lord... - he frowns again and keeps talking seriously, - I didn't expect... this.\n" +
                "You just can't be HIM!");
            Console.ReadKey();
            Console.WriteLine("- Well, I Am");
            Console.ReadKey();
            Console.WriteLine("- Forget that, I don't need a scumbag like you here, - he turns away, - Darran!\n" +
                "THrough him away, - he looked at the man at the bar, - and that corpse too.");
            Console.ReadKey();
            Console.WriteLine("- As y-you w-w-will, - the man said.");
            Console.ReadKey();

            Console.Clear();

            Console.WriteLine("You stand in front of the tavern.\nThere is nothing to do here anymore.\n" +
                "If you come back - you'll be beaten to death, so better go somhere else and send a report to the guild.\n" +
                "You are still not done here.");
            Console.ReadKey();

            Console.Clear();
            Console.ReadKey();

            Console.WriteLine("- Boy, hold on.");
            Console.ReadKey();
            Console.WriteLine("   You turn back and see the keeper standing at the door.");
            Console.ReadKey();
            Console.WriteLine("- Just why did you agreed to come here?");
            Console.ReadKey();
            Console.WriteLine("   He looks serious, maybe he would consider to give you the job, but the situation\n" +
                "requires a very carefull approach. You can't just tell him the real reason you are here");
            Console.ReadKey();
            Console.WriteLine("- I hand no choice.");
            Console.ReadKey();
            Console.WriteLine(" The keeper seems not satisfied with the answer, but he doesn't look angry.\n" +
                "He frowns but asks you to follow him to the backyard.");
            Console.ReadKey();
            Console.WriteLine("- From what I've seen, I can tell, that you are no fighter.");
            Console.ReadKey();
            Console.WriteLine("But... you remind me of myself at your age. And you have that... spark in your eyes.\n" +
                "That's why I'm gonna help you.");
            Console.ReadKey();
            Console.WriteLine("If you are really THAT Kvout, then I can help you with your combat skills, if you play tonight in my tavern.\n" +
                "So what do you say?");
            Console.ReadKey();
            Console.WriteLine("   - It's really kind of you, but... I don't have my lute, so...");
            Console.ReadKey();
            Console.WriteLine("- I have. And a good one! It's sound can make The Great Taborlyn cry!");
            Console.ReadKey();
            Console.WriteLine("- In that case...");
            Console.ReadKey();
            Console.WriteLine("- In that case, let's get started!");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("   You stant in front of the keeper, he walks back and forward, talking about\n" +
                "different combat technics and styles, about weapons and how to deal with them.");
            Console.ReadKey();
            Console.WriteLine("- ...remember to always look at your enemy! His moves are easy to predict when you look closely." +
                "\nIt deffinitely can save your life. Now look here. If you see your enemy to do a Low Attack, you can simply Parry that\n" +
                "with this move. See? Now try it.");
            Console.ReadKey();
            Console.WriteLine("   The keeper does the Low Attack and you manage to Parry it, so that you get no damage at all!");
            Console.ReadKey();
            Console.WriteLine("- See? It's not that hard. just some practice needed.\n" +
                "The thing is, that you can deal with any attack and get no damage. In some cases you'll be hit, but not that hard.");
            Console.ReadKey();
            Console.WriteLine("Now look at this, - he does a pretty solid High Attack, - you may think that it can't be awoided, right?\n" +
                "But if you manage to make a Slythe attack - you'll hit your opponent with your full strength, but get yourself some damage!");
            Console.ReadKey();
            Console.WriteLine("There are many comboes, I've told you about some, but the rest comes with practice. What do you think, about a friendly fight?");
            Console.ReadKey();

            Master.systemStats.eventOn = "training";
            int[] tempAP = { 0, 0, 2, 2, 0, 1, 4 };
            CombatMechanic.Combat("Tavern Keeper", 1000, 10, 0, 1, tempAP);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("- That's enough, - the keeper stops the fight.");
                Console.ReadKey();

                if ((Master.playerStats.playerHP == Master.playerStats.plMaxHP) || (CombatMechanic.enemyStats.enemyHP <= 900))
                {
                    Console.WriteLine("good fight");
                    Console.ReadKey();
                    break;
                }
                else if ((Master.playerStats.playerHP < Master.playerStats.plMaxHP) && (Master.playerStats.playerHP >= 20))
                {
                    Console.WriteLine("you learn fast");
                    Console.ReadKey();
                    GetInterface.PlayerRecover();
                    break;
                }
                else if (Master.playerStats.playerHP <= 20)
                {
                    Console.WriteLine("try again!");
                    Console.ReadKey();
                    GetInterface.PlayerRecover();

                    Master.systemStats.eventOn = "training";
                    CombatMechanic.Combat("Tavern Keeper", 1000, 10, 0, 1, tempAP);
                }
            }
            
            Console.WriteLine("- Kvout.");

            ////////////////////////////////////////////////////////////////////////////////
        }
    }
}
