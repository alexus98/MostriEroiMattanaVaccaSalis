﻿using MostriEroiMattanaVaccaSalis.Core.Entities;
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
            throw new NotImplementedException();
        }
    }
}
