using MostriEroiMattanaVaccaSalis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Mock.Repositories
{
    public class MemoryStorage
    {
        public static List<Hero> Heroes = new List<Hero>()
        {
            new Hero{ Id = 1, Name = "Alexus98", Level = 2, Exp = 10, LifePoints = 40, Category=CatEnum.Warrior, IdWeapon= 5, IdUser=2},
            new Hero{ Id = 2, Name = "MarkS", Level = 3, Exp = 20, LifePoints = 65, Category=CatEnum.Warrior, IdWeapon= 5, IdUser=3},
            new Hero{ Id = 3, Name = "Yuko94", Level = 2, Exp = 45, LifePoints = 35, Category=CatEnum.Magician, IdWeapon= 6, IdUser=1},
        };
        public static List<User> Users = new List<User>()
        {
            new User{ IdUser = 1, NickName = "Yuko", Password = "Yuko123", IsAdmin = false},
            new User{ IdUser = 2, NickName = "Ale", Password = "Ale456", IsAdmin = true},
            new User{ IdUser = 3, NickName = "Mark", Password = "Mark789", IsAdmin = false},
        };
        public static List<Weapon> Weapon = new List<Weapon>()
        {
            //Warrior
            new Weapon{ IdWeapon = 1, WeaponName = "Alabarda", Damage = 15, IdCategory = 1},
            new Weapon{ IdWeapon = 2, WeaponName = "Ascia", Damage= 8, IdCategory = 1},
            new Weapon{ IdWeapon = 3, WeaponName = "Mazza",  Damage= 5, IdCategory = 1},
            new Weapon{ IdWeapon = 4, WeaponName = "Spada", Damage = 10, IdCategory = 1},
            new Weapon{ IdWeapon = 5, WeaponName = "Spadone", Damage = 15, IdCategory = 1},
            //Magician
            new Weapon{ IdWeapon = 6, WeaponName = "Arco e Frecce", Damage = 8, IdCategory = 2},
            new Weapon{ IdWeapon = 7, WeaponName = "Bacchetta", Damage = 5, IdCategory = 2},
            new Weapon{ IdWeapon = 8, WeaponName = "Bastone magico", Damage = 10, IdCategory = 2},
            new Weapon{ IdWeapon = 9, WeaponName = "Onda d'urto", Damage = 15, IdCategory = 2},
            new Weapon{ IdWeapon = 10, WeaponName = "Pugnale", Damage = 5, IdCategory = 2},
            //Cultist
            new Weapon{ IdWeapon = 11, WeaponName = "Discorso noioso", Damage = 4, IdCategory = 3},
            new Weapon{ IdWeapon = 12, WeaponName = "Farneticazione", Damage = 7, IdCategory = 3},
            new Weapon{ IdWeapon = 13, WeaponName = "Imprecazione", Damage= 5, IdCategory = 3},
            new Weapon{ IdWeapon = 14, WeaponName = "Magia nera", Damage = 3, IdCategory = 3},
            //Orc
            new Weapon{ IdWeapon = 15, WeaponName = "Arco", Damage = 7, IdCategory = 4},
            new Weapon{ IdWeapon = 16, WeaponName = "Clava", Damage = 5, IdCategory = 4},
            new Weapon{ IdWeapon = 17, WeaponName = "Spada rotta", Damage = 3, IdCategory = 4},
            new Weapon{ IdWeapon = 18, WeaponName = "Mazza chiodata", Damage= 10, IdCategory = 4},
            //Saruman
            new Weapon{ IdWeapon = 19, WeaponName = "Alabarda del drago", Damage = 30, IdCategory = 5},
            new Weapon{ IdWeapon = 20, WeaponName = "Divinazione", Damage = 15, IdCategory = 5},
            new Weapon{ IdWeapon = 21, WeaponName = "Fulmine", Damage = 10, IdCategory = 5},
            new Weapon{ IdWeapon = 22, WeaponName = "Fulmine celeste", Damage = 15, IdCategory = 5},
            new Weapon{ IdWeapon = 23, WeaponName = "Tempesta", Damage = 8, IdCategory = 5},
            new Weapon{ IdWeapon = 24, WeaponName = "Tempesta oscura", Damage = 15, IdCategory = 5},
            new Weapon{ IdWeapon = 25, WeaponName = "Chiamami i carabinieri veloce", Damage = 20, IdCategory = 5},
        };
        public static List<Monster> Monster = new List<Monster>()
        {
            new Monster{Id = 1, Name = "Nazgul", Level = 1, LifePoints = 20, Category= CatEnum.Cultist, IdWeapon=14},
            new Monster{Id = 2, Name = "Mister Mxyzptlk", Level = 1, LifePoints = 20,  Category= CatEnum.Orc, IdWeapon=15},
            new Monster{Id = 3, Name = "Bane", Level = 3, LifePoints = 60,  Category= CatEnum.Cultist, IdWeapon=14},
            new Monster{Id = 4, Name = "Nenno molto cattivo", Level = 3, LifePoints = 60, Category= CatEnum.Orc, IdWeapon=18},
            new Monster{Id = 5, Name = "Boss Finale", Level = 5, LifePoints = 100, Category= CatEnum.Saruman, IdWeapon=24},
            new Monster{Id = 5, Name = "Mestro Pandolfi", Level = 5, LifePoints = 200, Category= CatEnum.Saruman, IdWeapon=25}
        };


    }
}
