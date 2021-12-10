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
            switch (Level)
            {
                case 1:
                    if (Exp > 29)
                    {
                        Level++;
                        Exp = 0;
                        LifePoints = 40;

                    }
                    break;
                case 2:
                    if (Exp > 59)
                    {
                        Level++;
                        Exp = 0;
                        LifePoints = 60;
                    }
                    break;
                case 3:
                    if (Exp > 89)
                    {
                        Level++;
                        Exp = 0;
                        LifePoints = 80;

                    }
                    break;
                case 4:
                    if (Exp > 119)
                    {
                        Level++;
                        Exp = 0;
                        LifePoints = 100;
                    }
                    break;
                case 5:
                    break;
            }
        }
    }
}
