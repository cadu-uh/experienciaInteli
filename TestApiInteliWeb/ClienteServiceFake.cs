using ApiInteliWeb.Models;
using ApiInteliWeb.Services;
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
                new Cliente() {Id = Guid.Parse("38e8e0a0-304f-41c7-a612-b4d450bfb898") , firstName = "Jose" , surName = "Pederasta" , age = 55 , creationDate = DateTime.Now },
                new Cliente() {Id = Guid.Parse("7b48712a-2f6b-4ef1-9f45-d4f7add07837") , firstName = "Maria" , surName = "Rosaria" , age = 60 , creationDate = DateTime.Now },
                new Cliente() {Id = Guid.Parse("957dffe2-84ad-452d-88ae-cb4ba6d00b9f")  , firstName = "Guilherme" , surName = "Paiva" , age = 18 , creationDate = DateTime.Now },

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
