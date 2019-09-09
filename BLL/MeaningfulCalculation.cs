using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL
{
    public class MeaningfulCalculation
    {

        Random diceRoll = new Random();
        public int Roll()
        {
            List<int> rolls = new List<int>();
            for (int x=0; x <1; x++)
            {
                rolls.Add(diceRoll.Next(20,101));
            }
            return rolls.Sum();
           
        }
            //Inputs 40 to 210 expect output -5 to +5
           public int CheckP1(int a, int b)
        {
            return ((a - b+170) / 35)-5;
        }
        public int CheckP2(int a, int b)
        {
            if(a>b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public class Joust
        {
           
        }
           
    }
}
