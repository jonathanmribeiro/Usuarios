using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Models;

namespace Usuarios.Services
{
    public interface IDBService
    {
        void PrepararConexao();
        User ObterUsuarioPorNome(string name);
        List<User> ObterUsuarios();
        User CriarUsuario(User usuario);
        User ObterUsuarioPorId(int id);
        User AlterarUsuario(User usuario);
        bool RemoverUsuario(User usuario);
        User TrocarSenha(User usuario);
    }
}
