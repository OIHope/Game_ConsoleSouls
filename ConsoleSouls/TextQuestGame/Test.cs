using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSouls
{
    internal class Test
    {
        public static void TestMech()
        {
            int[] value = new int[40];
            int[] newValue = new int[40];

            for (int i = 0; i < value.Length; i++)
            {
                value[i] = i;
                newValue[i] = (int)(value[i]*.5);
                Console.WriteLine("Initial value: " + value[i]);
                Console.WriteLine("New value: " + newValue[i] + "\n");
            }
        }
    }
}
