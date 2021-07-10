using ApiInteliWeb.Controllers;
using ApiInteliWeb.Models;
using ApiInteliWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestApiInteliWeb
{
    public class ClienteControllerTest
    {
        private readonly ClienteController _controller;
        private readonly IClienteService _service;
        Mock<Cliente> _mock;
        private readonly ILogger<ClienteController> _logger;

        public ClienteControllerTest()
        {
            _service = new ClienteServiceFake();
            _controller = new ClienteController(_service, _logger);
        }

        [Fact]
        public void Get_RetornandoStatusOk()
        {
            var okResult = _controller.GetClientes();
            Assert.IsAssignableFrom<ActionResult<List<Cliente>>>(okResult);
        }

        [Fact]
        public void Post_RetornaObjOk()
        {
            _mock = new Mock<Cliente>();
            Cliente _MoqCli = new Cliente()
            {
                firstName = "Jose Carlos",
                surName = "Macoratti",
                age = 45,            
            };

            var result = _controller.PostCliente(_MoqCli);
            Assert.IsAssignableFrom<ActionResult<ApiInteliWeb.Models.Cliente>>(result);

        }
        [Fact]
        public void Put_EditClienteOk()
        {
            _mock = new Mock<Cliente>();
            Cliente _MoqCli = new Cliente()
            {             
                firstName = "Jose Carlos",
                surName = "Macoratti",
                age = 45,
            };
            var result = _controller.EditCLiente(_MoqCli);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_RemoveResultingOk()
        {
            _mock = new Mock<Cliente>();
            Cliente _MoqCli = new Cliente()
            {
                Id = Guid.Parse("7b48712a-2f6b-4ef1-9f45-d4f7add07837"),
            };
            var result = _controller.DeleteCliente(_MoqCli.Id);
            Assert.IsType<NoContentResult>(result);
        }


    }
}
