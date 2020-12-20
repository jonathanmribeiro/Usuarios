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
        User _usuarioCriado;

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
            User usuario = new User { Name = "Usuário de teste", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };

            //Act
            User okResult = _service.CriarUsuario(usuario);
            _usuarioCriado = okResult;

            //Assert
            Assert.IsType<User>(okResult);
        }

        [Fact]
        public void ObterUsuarioPorNome_WhenCalled_ReturnsUser()
        {
            //Act
            User okResult = _service.ObterUsuarioPorNome("Usuário de teste");

            //Assert
            Assert.IsType<User>(okResult);
        }

        [Fact]
        public void ObterUsuarioPorId_WhenCalled_ReturnsUser()
        {
            //Act
            User okResult = _service.ObterUsuarioPorId(_usuarioCriado.Id);

            //Assert
            Assert.IsType<User>(okResult);
        }

        [Fact]
        public void AlterarUsuario_WhenCalled_ReturnsUser()
        {
            //Arrange
            _usuarioCriado.Name = "Usuário teste alterado";
            //Act
            User okResult = _service.AlterarUsuario(_usuarioCriado);

            //Assert
            Assert.IsType<User>(okResult);
        }

        [Fact]
        public void TrocarSenha_WhenCalled_ReturnsUser()
        {
            //Arrange
            _usuarioCriado.OldPassword = _usuarioCriado.Password;
            _usuarioCriado.Password = "12345";

            //Act
            User okResult = _service.TrocarSenha(_usuarioCriado);

            //Assert
            Assert.IsType<User>(okResult);
        }

        [Fact]
        public void RemoverUsuario_WhenCalled_ReturnsBool()
        {
            //Act
            bool okResult = _service.RemoverUsuario(_usuarioCriado);

            //Assert
            Assert.IsType<bool>(okResult);
        }
    }
}
