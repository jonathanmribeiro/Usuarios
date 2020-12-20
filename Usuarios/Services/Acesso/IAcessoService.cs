using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Models;

namespace Usuarios.Services
{
    public interface IAcessoService
    {
        string Login(User user);
        void InserirAcesso();
        List<User> ObterUsuarios();
        User CriarUsuario(User usuario);
        User AlterarUsuario(User usuario);
        void RemoverUsuario(User usuario);
        User TrocarSenha(User usuario);
    }
}
