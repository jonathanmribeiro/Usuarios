using System;
using Usuarios.Models;
using Usuarios.Services;
using Xunit;

namespace TestesUnitarios
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
