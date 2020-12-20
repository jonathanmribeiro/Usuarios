using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Usuarios.Controllers;
using Usuarios.Models;
using Usuarios.Services;
using Xunit;

namespace TestesUnitarios
{
    public class AcessoTestes
    {
        AcessoService _service;
        public AcessoTestes()
        {
            _service = new AcessoService();
        }

        [Fact]
        public void Login_WhenCalled_ReturnsString()
        {
            //Arrange
            User usuario = new User { Name = "TESTE - CRIAÇÃO", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };
            usuario = _service.CriarUsuario(usuario);

            //Act
            string okResult = _service.Login(usuario);
            _service.RemoverUsuario(usuario);

            //Assert
            Assert.IsType<string>(okResult);
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
        public void AlterarUsuario_WhenCalled_ReturnsUser()
        {
            //Arrange
            User usuario = new User { Name = "TESTE - ALTERAÇÃO", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };
            usuario = _service.CriarUsuario(usuario);
            usuario.Name = "TESTE - ALTERADO---------------------------";

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
            usuario.Password = "senha_alterada";

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
