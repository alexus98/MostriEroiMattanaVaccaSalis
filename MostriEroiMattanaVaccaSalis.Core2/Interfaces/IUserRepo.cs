using MostriEroiMattanaVaccaSalis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Core.Interfaces
{
    public interface IUserRepo : IRepository<User>
    {
        bool CheckCredentials(string username, string password);
    }
}
