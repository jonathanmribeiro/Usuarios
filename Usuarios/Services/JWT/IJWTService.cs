using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Models;

namespace Usuarios.Services
{
    public interface IJWTService
    {
        public string GerarToken(User user);
        string RoleFactory(int tipo);

    }
}
