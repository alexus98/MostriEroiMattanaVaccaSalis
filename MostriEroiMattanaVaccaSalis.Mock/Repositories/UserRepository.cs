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


        public bool CheckCredentials(string username, string password)
        {
            List<User> users = MemoryStorage.Users;
            users.Where(u => u.NickName == username && u.Password == password).ToList();
            if (users != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<User> Fetch(Func<User, bool> lambda = null)
        {

            throw new NotImplementedException();
        }


        public bool CheckNickName(string? username)
        {
            List<User> users = MemoryStorage.Users;
            
            return users.Exists(u => u.NickName == username);   
        }

        public bool AddUser(User user)
        {
            MemoryStorage.Users.Add(user);
            return true;
        }

        public int GetAvailableId()
        {
            return MemoryStorage.Users.
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
