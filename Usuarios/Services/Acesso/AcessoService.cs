using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Models;

namespace Usuarios.Services
{
    public class AcessoService : IAcessoService
    {
        private readonly IDBService _dbService = new DBService();
        private readonly IJWTService _jWTService = new JWTService();
        public AcessoService()
        {
        }

        public string Login(User _usuario)
        {
            User usuario = _dbService.ObterUsuarioPorNome(_usuario.Name);

            if (usuario == null)
                throw new Exception("Usuário não cadastrado");

            if (_usuario.Password != usuario.Password)
                throw new Exception("Senha inválida");

            return _jWTService.GerarToken(usuario);
        }

        public User TrocarSenha(User _usuario)
        {
            try
            {
                if (_usuario.Id == 0) throw new Exception("Id do usuário não informado.");
                if (string.IsNullOrEmpty(_usuario.Password)) throw new Exception("Senha anterior não informada");
                if (string.IsNullOrEmpty(_usuario.Password)) throw new Exception("Senha não informada");
                User usuario = _dbService.ObterUsuarioPorId(_usuario.Id);
                if (usuario == null) throw new Exception("Não encontrado usuário com o ID informado.");
                if(_usuario.OldPassword != usuario.Password) throw new Exception("Senha anterior difere do cadastro.");

                return _dbService.TrocarSenha(_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CRUD ------------------------------------------------------------------------------------
        public List<User> ObterUsuarios()
        {
            try
            {
                return _dbService.ObterUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User CriarUsuario(User _usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(_usuario.Name)) throw new Exception("Nome não informado.");
                if (_dbService.ObterUsuarioPorNome(_usuario.Name) != null) throw new Exception("Nome já utilizado.");
                if (string.IsNullOrEmpty(_usuario.Password)) throw new Exception("Senha não informada");
                if (string.IsNullOrEmpty(_usuario.Email)) throw new Exception("Email não informado");

                return _dbService.CriarUsuario(_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User AlterarUsuario(User _usuario)
        {
            try
            {
                if (_usuario.Id == 0) throw new Exception("Id do usuário não informado.");
                if (_dbService.ObterUsuarioPorId(_usuario.Id) == null) throw new Exception("Não encontrado usuário com o ID informado.");
                if (string.IsNullOrEmpty(_usuario.Name)) throw new Exception("Nome não informado.");
                if (string.IsNullOrEmpty(_usuario.Password)) throw new Exception("Senha não informada");
                if (string.IsNullOrEmpty(_usuario.Email)) throw new Exception("Email não informado");

                return _dbService.AlterarUsuario(_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoverUsuario(User _usuario)
        {
            try
            {
                if (_usuario.Id == 0) throw new Exception("Id do usuário não informado.");
                if (_dbService.ObterUsuarioPorId(_usuario.Id) == null) throw new Exception("Não encontrado usuário com o ID informado.");

                return _dbService.RemoverUsuario(_usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
