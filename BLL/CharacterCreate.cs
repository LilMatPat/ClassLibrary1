using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class CharacterCreate
    {
        Random diceRoll = new Random();
        public int Roll()
        {
            List<int> rolls = new List<int>();
            for (int x = 0; x < 1; x++)
            {
                rolls.Add(diceRoll.Next(20, 81));
            }
            return rolls.Sum();
 
        }
        public void CharacterModification(KnightBLL k, List<int> stats)
        {
           
        }
    }
}
