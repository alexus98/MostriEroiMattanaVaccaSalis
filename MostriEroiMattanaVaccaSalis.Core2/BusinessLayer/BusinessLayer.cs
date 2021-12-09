﻿using MostriEroiMattanaVaccaSalis.Core.Entities;
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
            return heroRepo.Fetch(h => h.Name == heroName);
        }

        public List<Hero> GetAllHeroes()
        {
            throw new NotImplementedException();
        }

        public Hero GetHeroById(int id)
        {
            heroRepo.GetById(id);
        }

        public bool DeleteHero(Hero eroe)
        {
            throw new NotImplementedException();
        }
    }
}
