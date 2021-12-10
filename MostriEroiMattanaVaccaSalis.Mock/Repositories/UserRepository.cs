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
            User user = users.Where(u => u.NickName == username && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<User> Fetch(Func<User, bool> lambda = null)
        {
            if (lambda != null)
                return MemoryStorage.Users.Where(lambda);
            return MemoryStorage.Users;
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
            int count = MemoryStorage.Users.Count;
            int id = MemoryStorage.Users[count - 1].IdUser;
            return id + 1;
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

        public void UpdateUser(User u)
        {
          
           User user = MemoryStorage.Users.Where(user => user.IdUser == u.IdUser).FirstOrDefault();
            if (user != null)
                user = u;
           
        }
    }
}
