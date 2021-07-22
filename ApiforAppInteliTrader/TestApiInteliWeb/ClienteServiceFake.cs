using ApiInteliWeb.Controllers;
using ApiInteliWeb.Models;
using ApiInteliWeb.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApiInteliWeb
{
    class ClienteServiceFake : IClienteService
    {
        private readonly List<Cliente> _clie;
        public ClienteServiceFake()
        {
            _clie = new List<Cliente>()
            {
                new Cliente() {Id = Guid.Parse("38e8e0a0-304f-41c7-a612-b4d450bfb898") , FirstName = "Jose" , SurName = "Pederasta" , Age = 55 , CreationDate = DateTime.Now },
                new Cliente() {Id = Guid.Parse("7b48712a-2f6b-4ef1-9f45-d4f7add07837") , FirstName = "Maria" , SurName = "Rosaria" , Age = 60 , CreationDate = DateTime.Now },
                new Cliente() {Id = Guid.Parse("957dffe2-84ad-452d-88ae-cb4ba6d00b9f")  , FirstName = "Guilherme" , SurName = "Paiva" , Age = 18 , CreationDate = DateTime.Now },

            };          
        }

        public void DeleteById(Guid id)
        {
            var item = _clie.First(a => a.Id == id);
            _clie.Remove(item);
        }

        public void EditCliente(Cliente cliente)
        {
          var index =   _clie.FindIndex(a => a.Id == cliente.Id );
            _clie[index] = cliente;  
    
        }
        
        public Cliente AddCliente(Cliente novoItem)
        {
 
            _clie.Add(novoItem);
            return novoItem;
        }

        public List<Cliente> GetClientes()
        {
            return _clie;
        }
    }
}
