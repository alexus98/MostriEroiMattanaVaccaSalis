using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Core.Entities
{
    public class Weapon
    {
        public int IdWeapon { get; set; }
        public string WeaponName { get; set; }
        public int Damage { get; set; }
        
        public int IdCategory { get; set; }


        //public override string ToString()
        //{
        //    return $"[{IdWeapon}] ";
        //}
    }
}
