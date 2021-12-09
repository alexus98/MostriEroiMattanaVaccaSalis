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
        public IEnumerable<Hero> Fetch(Func<Hero, bool> lambda = null)
        {
            if (lambda != null)
                return MemoryStorage.Heroes.Where(lambda);
            return MemoryStorage.Heroes;
        }
    }
}
