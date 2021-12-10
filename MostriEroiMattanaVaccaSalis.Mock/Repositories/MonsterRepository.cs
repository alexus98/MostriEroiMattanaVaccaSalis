using MostriEroiMattanaVaccaSalis.Core.Entities;
using MostriEroiMattanaVaccaSalis.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Mock.Repositories
{
    public class MonsterRepository : IMonsterRepo
    {
        public IEnumerable<Monster> Fetch(Func<Monster, bool> lambda = null)
        {
            if (lambda != null)
                return MemoryStorage.Monster.Where(lambda);
            return MemoryStorage.Monster;
        }

        public bool Add(Monster monster)
        {
            monster.Id = MemoryStorage.Monster.Last().Id + 1;
            MemoryStorage.Monster.Add(monster);
            return true;
        }
    }
}
