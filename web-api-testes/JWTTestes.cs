using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using Usuarios.Controllers;
using Usuarios.Models;
using Usuarios.Services;
using Xunit;

namespace web_api_testes
{
    public class JWTTestes
    {
        JWTService _service;

        public JWTTestes()
        {
            _service = new JWTService();
        }

        [Fact]
        public void GerarToken_WhenCalled_ReturnsString()
        {
            //Arrange
            User usuario = new User { Id = 10, Name = "Usuário de teste", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };

            //Act
            string okResult = _service.GerarToken(usuario);

            //Assert
            Assert.IsType<string>(okResult);
        }
    }
}
