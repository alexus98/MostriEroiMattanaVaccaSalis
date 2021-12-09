using MostriEroiMattanaVaccaSalis.Core.Entities;
using MostriEroiMattanaVaccaSalis.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Mock.Repositories
{
    public class UserRepository : IUserRepo
    {
        public IEnumerable<User> Fetch(Func<User, bool> lambda = null)
        {
            throw new NotImplementedException();
        }
    }
}
