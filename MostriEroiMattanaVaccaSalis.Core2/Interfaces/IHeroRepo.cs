using MostriEroiMattanaVaccaSalis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Core.Interfaces
{
    public interface IHeroRepo : IRepository<Hero>
    {
        bool Delete(Hero eroe);
        List<Hero> FetchTop10();
        Hero Add(Hero hero);
        void Update(Hero hero);
    }
}
