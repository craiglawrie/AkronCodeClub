using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCowsConsole
{
    public class Guess
    {
        public string Value { get; set; } = "1234";
        public int[] CountBullsAndCows(string actualValue)
        {
            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < Value.Length; i++)
            {
                if(Value[i] == actualValue[i])
                {
                    bulls++;
                }
                else if (actualValue.Contains(Value[i]))
                {
                    cows++;
                }
            }

            return new int[] { bulls, cows };
        }
    }
}
