using MostriEroiMattanaVaccaSalis.Core.Entities;
using MostriEroiMattanaVaccaSalis.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Mock.Repositories
{
    public class HeroRepository : IHeroRepo
    {
        public bool Delete(Hero eroe)
        {
            MemoryStorage.Heroes.Remove(eroe);
            return true;
        }

        public IEnumerable<Hero> Fetch(Func<Hero, bool> lambda = null)
        {
            if (lambda != null)
                return MemoryStorage.Heroes.Where(lambda);
            return MemoryStorage.Heroes;
        }

        public List<Hero> FetchTop10()
        {
            return MemoryStorage.Heroes.OrderByDescending(e => e.Level).ThenByDescending(e => e.Exp).Take(10).ToList();
        }

        public Hero Add(Hero hero)
        {
            hero.Id = MemoryStorage.Heroes.Last().Id + 1;
            MemoryStorage.Heroes.Add(hero);
            return hero;
        }
    }
}
