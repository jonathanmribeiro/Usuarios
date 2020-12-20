using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Usuarios.Controllers;
using Usuarios.Models;
using Usuarios.Services;
using Xunit;

namespace web_api_testes
{
    public class DBTestes
    {
        DBService _service;

        public DBTestes()
        {
            _service = new DBService();
        }

        [Fact]
        public void ObterUsuarios_WhenCalled_ReturnsList()
        {
            //Act
            List<User> okResult = _service.ObterUsuarios();

            //Assert
            Assert.IsType<List<User>>(okResult);
        }

        [Fact]
        public void CriarUsuario_WhenCalled_ReturnsUser()
        {
            //Arrange
            User usuario = new User { Name = "TESTE - CRIAÇÃO", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };

            //Act
            User okResult = _service.CriarUsuario(usuario);
            _service.RemoverUsuario(okResult);

            //Assert
            Assert.IsType<User>(okResult);
        }

        [Fact]
        public void ObterUsuarioPorNome_WhenCalled_ReturnsUser()
        {
            //Arrange
            User usuario = new User { Name = "TESTE - OBTER POR NOME", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };
            usuario = _service.CriarUsuario(usuario);

            //Act
            User okResult = _service.ObterUsuarioPorNome(usuario.Name);
            _service.RemoverUsuario(usuario);

            //Assert
            Assert.IsType<User>(okResult);
        }

        [Fact]
        public void ObterUsuarioPorId_WhenCalled_ReturnsUser()
        {
            //Arrange
            User usuario = new User { Name = "TESTE - OBTER POR ID", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };
            usuario = _service.CriarUsuario(usuario);

            //Act
            User okResult = _service.ObterUsuarioPorId(usuario.Id);
            _service.RemoverUsuario(usuario);

            //Assert
            Assert.IsType<User>(okResult);
        }

        [Fact]
        public void AlterarUsuario_WhenCalled_ReturnsUser()
        {
            //Arrange
            User usuario = new User { Name = "TESTE - ALTERAR", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };
            usuario = _service.CriarUsuario(usuario);
            usuario.Name = "Nome de usuario de teste alterado";

            //Act
            User okResult = _service.AlterarUsuario(usuario);
            _service.RemoverUsuario(usuario);

            //Assert
            Assert.IsType<User>(okResult);
        }

        [Fact]
        public void TrocarSenha_WhenCalled_ReturnsUser()
        {
            //Arrange
            User usuario = new User { Name = "TESTE - TROCAR SENHA", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };
            usuario = _service.CriarUsuario(usuario);
            usuario.OldPassword = usuario.Password;
            usuario.Password = "123456789";

            //Act
            User okResult = _service.TrocarSenha(usuario);
            _service.RemoverUsuario(usuario);

            //Assert
            Assert.IsType<User>(okResult);
        }

        [Fact]
        public void RemoverUsuario_WhenCalled_ReturnsBool()
        {
            //Arrange
            User usuario = new User { Name = "TESTE - REMOÇÃO", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };
            usuario = _service.CriarUsuario(usuario);

            //Act
            bool okResult = _service.RemoverUsuario(usuario);

            //Assert
            Assert.IsType<bool>(okResult);
        }
    }
}
