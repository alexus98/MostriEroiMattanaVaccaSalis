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
    }
}
