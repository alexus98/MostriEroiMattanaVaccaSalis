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

        public List<User> FetchByHeroes(List<Hero> heroes)
        {
            List<User> utentiEroi = new List<User>();
            foreach (var e in heroes)
            {
                User user = MemoryStorage.Users.Where(u => u.IdUser == e.IdUser).FirstOrDefault();
                utentiEroi.Add(user);
            }
            return utentiEroi;
        }
    }
}
