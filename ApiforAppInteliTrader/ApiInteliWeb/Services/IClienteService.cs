using ApiInteliWeb.Models;
using System;
using System.Collections.Generic;

namespace ApiInteliWeb.Services
{
    public interface IClienteService
    {
        public List<Cliente> GetClientes();
        public Cliente AddCliente(Cliente model);
        public void DeleteById(Guid Id);
        public void EditCliente(Cliente cliente);
    }
}
