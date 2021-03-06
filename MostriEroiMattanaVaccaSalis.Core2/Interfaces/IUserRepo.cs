using MostriEroiMattanaVaccaSalis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Core.Interfaces
{
    public interface IUserRepo: IRepository<User>
    {
        bool CheckCredentials(string username, string password);
        bool CheckNickName(string? username);
        bool AddUser(User user);
        int GetAvailableId();
        List<User> FetchByHeroes(List<Hero> heroes);
        void UpdateUser(User u);
    }
}
