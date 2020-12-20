using Microsoft.AspNetCore.Mvc;
using System;
using Usuarios.Controllers;
using Usuarios.Services;
using Xunit;

namespace web_api_testes
{
    public class AcessoTestes
    {
        AcessoController _controller;
        AcessoService _service;

        public AcessoTestes()
        {
            _service = new AcessoService();
            _controller = new AcessoController(_service);
        }
    }
}
