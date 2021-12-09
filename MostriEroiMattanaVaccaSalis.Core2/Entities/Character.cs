using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Core.Entities
{
    public abstract class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int LifePoints { get; set; } = 20;
        public CatEnum Category { get; set; }
        public int IdWeapon { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - Livello: {Level} Cat:{Category} \nHP:{LifePoints} \nWeapon: {IdWeapon}\n";
        }
    }

    public enum CatEnum 
    {
        Warrior=1,
        Magician=2,
        Cultist=3,
        Orc=4,
        Saruman=5,
    }
}
