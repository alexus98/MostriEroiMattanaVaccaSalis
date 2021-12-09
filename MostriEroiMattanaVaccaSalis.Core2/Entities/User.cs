using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriEroiMattanaVaccaSalis.Core.Entities
{
    public class User
    {
        public string NickName { get; set; }
        public int IdUser { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;

        public override string ToString()
        {
            return $"[{IdUser}] - Nickname: {NickName} Admin: {IsAdmin} \n";
        }
    }
}