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
            if(users != null)
            {
                return true;
            }
            return false;
            
            throw new NotImplementedException();
        }
    
        public IEnumerable<User> Fetch(Func<User, bool> lambda = null)
        {
            throw new NotImplementedException();
        }
    }
}
