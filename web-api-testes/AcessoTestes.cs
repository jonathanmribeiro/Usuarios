using Microsoft.AspNetCore.Mvc;
using Usuarios.Controllers;
using Usuarios.Models;
using Usuarios.Services;
using Xunit;

namespace web_api_testes
{
    class AcessoTestes
    {
        AcessoController _controller;
        AcessoService _service;
        public AcessoTestes()
        {
            _service = new AcessoService();
            _controller = new AcessoController(_service);
        }

        public void CriarUsuario_WhenCalled_ReturnsIActionResult()
        {
            //Arrange
            User usuario = new User { Name = "TESTE - CRIAÇÃO", Password = "12345", Email = "usuariodeteste@outlook.com", Type = 1 };

            //Act
            IActionResult okResult = _controller.CriarUsuario(usuario);
            _controller.RemoverUsuario(usuario);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(okResult);
        }
    }

}