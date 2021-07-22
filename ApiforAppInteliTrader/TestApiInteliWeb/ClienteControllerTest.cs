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
        public ClienteControllerTest()
        {
            _service = new ClienteServiceFake();
            var _mockLogger = new Mock<ILogger<ClienteController>>();
            _controller = new ClienteController(_service, _mockLogger.Object);
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
           
            Cliente _MoqCli = new Cliente()
            {
                FirstName = "Jose Carlos",
                SurName = "Macoratti",
                Age = 45,            
            };        
            var result = _controller.PostCliente(_MoqCli);
            Assert.IsAssignableFrom<ActionResult<ApiInteliWeb.Models.Cliente>>(result);

        }
        [Fact]
        public void Put_EditClienteOk()
        {
            
            Cliente _MoqCli = new Cliente()
            {  
                Id = Guid.Parse("38e8e0a0-304f-41c7-a612-b4d450bfb898"),
                FirstName = "Jose Carlos",
                SurName = "Macoratti",
                Age = 45,
            };
            var result = _controller.EditCLiente(_MoqCli.Id,_MoqCli);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_RemoveResultingOk()
        {
           
            Cliente _MoqCli = new Cliente()
            {
                Id = Guid.Parse("7b48712a-2f6b-4ef1-9f45-d4f7add07837"),
            };           
            var result = _controller.DeleteCliente(_MoqCli.Id);
            Assert.IsType<NoContentResult>(result);
        }


    }
}
