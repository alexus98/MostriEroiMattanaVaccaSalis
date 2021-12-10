using MostriEroiMattanaVaccaSalis.Core.Entities;
using MostriEroiMattanaVaccaSalis.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Core.BusinessLayer
{
    public class BusinessLayer: IBusinessLayer
    {
        private readonly IUserRepo userRepo;
        private readonly IHeroRepo heroRepo;
        private readonly IMonsterRepo monsterRepo;
        private readonly IWeaponRepo weaponRepo;

        public BusinessLayer(IUserRepo user, IHeroRepo hero, IMonsterRepo monster, IWeaponRepo weapon)
        {
            userRepo = user;
            heroRepo = hero;
            monsterRepo = monster;
            weaponRepo = weapon;
        }


        public Hero GetHeroByName(string heroName)
        {
            return heroRepo.Fetch(h => h.Name == heroName).ToList().FirstOrDefault();
        }

        public Monster GetMonsterByName(string monsterName)
        {
            return monsterRepo.Fetch(m => m.Name == monsterName).ToList().FirstOrDefault();
        }


        public List<Hero> GetAllHeroes()
        public List<Hero> GetAllHeroes(User u)
        {
            return heroRepo.Fetch().Where(e => e.IdUser == u.IdUser).ToList();
        }

        public Hero GetHeroById(int id)
        {
            return heroRepo.Fetch(h => h.Id == id).ToList().FirstOrDefault();
        }

        public bool DeleteHero(Hero eroe)
        {
            return heroRepo.Delete(eroe);
        }

        

        public bool CheckCredentials(string username, string password)
        {
            return userRepo.CheckCredentials(username, password);
            
        }

        public bool CheckNickName(string? username)
        {
            return userRepo.CheckNickName(username);
        }

        public int GetAvailableId()
        {
            return userRepo.GetAvailableId();
        }
        public bool AddUser(User user)
        {
            return userRepo.AddUser(user);
        }

        public List<Weapon> GetWeaponsByCategory(CatEnum cat)
        {
            return weaponRepo.Fetch(w => w.IdCategory == (int)cat).ToList();
        }

        public Weapon GetWeaponsById(int id)
        {
            return weaponRepo.Fetch(w => w.IdWeapon == id).ToList().FirstOrDefault();
        }

        public List<Weapon> GetAllWeapons()
        {
            return weaponRepo.Fetch().ToList();
        }

        public List<Hero> FetchClassica()
        {
            return heroRepo.FetchTop10();
        }

        public List<User> FetchUtenti(List<Hero> heroes)
        {
            return userRepo.FetchByHeroes(heroes);
        }

        public bool InsertHero(Hero hero)
        {
            return heroRepo.Add(hero);
        }

        public bool InsertMonster(Monster hero)
        {
            return monsterRepo.Add(hero);
        }
        

        public bool isUserAdmin(string username)
        {
            User u = userRepo.Fetch(u => u.NickName == username).FirstOrDefault();
            if (u != null)
                if(u.IsAdmin)
                    return true;
                else
                    return false;
            return false;
        }

        public User GetUser(string username)
        {
            User u = userRepo.Fetch(u => u.NickName == username).FirstOrDefault();
            return u;
            
        }

        public Monster GetRandomMonster(int level)
        {
            throw new NotImplementedException();
        }
    }
}
