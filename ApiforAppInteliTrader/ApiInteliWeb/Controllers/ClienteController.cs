using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiInteliWeb.Models;
using ApiInteliWeb.Services;
using Microsoft.Extensions.Logging;

namespace ApiInteliWeb.Controllers

{
    [ApiController]
    [Route("v1/Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IClienteService _servicee;
        public ClienteController(IClienteService service ,ILogger<ClienteController> logger)
        {
            _servicee = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Cliente>> GetClientes()
        {
            try
            {
                _logger.LogInformation("Sucesso ao Puxar Usuarios Cadastrados");
                return _servicee.GetClientes().ToList();
            }
            catch (Exception)
            {
                _logger.LogWarning("Bloco catch: Erro ao Puxar Usuarios Cadastrados");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Cliente> PostCliente([FromBody] Cliente model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Sucesso ao Cadastrar Usuario");
                    return _servicee.AddCliente(model);
                }
                _logger.LogError("Erro ao Cadastrar Usuario !");
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                _logger.LogWarning("Bloco Catch: Erro ao Cadastrar Usuario !");
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{Id}")]
        [Route("")]
        public ActionResult EditCLiente(Guid Id, [FromBody] Cliente cliente)
        {
            try
            {
                if (Id == cliente.Id)
                {
                     _logger.LogInformation("Sucesso ao Editar Usuario");
                    _servicee.EditCliente(cliente);
                    return NoContent();
                }
                else
                {
                    _logger.LogError("Erro ao Editar Usuario !");
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                _logger.LogWarning("Bloco Catch: Erro ao Editar Usuario !");
                return BadRequest();
            }
        }


        [HttpDelete("{Id}")]
        [Route("")]
        public ActionResult DeleteCliente(Guid id)
        {
            try
            {
                _logger.LogInformation("Sucesso ao Excluir Usuario");
                _servicee.DeleteById(id);
                return NoContent();
            }
            catch (Exception)
            {
                _logger.LogWarning("Bloco Catch :Erro ao Deletar Usuario !");
                return NotFound();
            }
        }
    }
}
