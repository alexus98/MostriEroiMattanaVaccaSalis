using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Core.Entities
{
    public class Hero: Character
    {
        public int Exp { get; set; } = 0;
        public int IdUser { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Punti accumulati: {Exp} \n";
        }

        public bool Escape()
        {
            Random r = new Random();
            int i = r.Next(2);
            if (i == 0)
                return false;
            else
                return true;
        }

        /*Livello 1 da 0 a 29
Livello 2 da 30 a 59
Livello 3 da 60 a 89
Livello 4 da 90 a 119
Livello 5 da 120
*/

        public void SetLevelByExp()
        {
            if(Exp >= 0 && Exp <= 29)
                Level = 1;
            if (Exp >= 30 && Exp <= 59)
                Level = 2;
            if (Exp >= 60 && Exp <= 89)
                Level = 3;
            if (Exp >= 90 && Exp <= 119)
                Level = 4;
            if (Exp >= 120)
                Level = 5;
        }
    }
}
