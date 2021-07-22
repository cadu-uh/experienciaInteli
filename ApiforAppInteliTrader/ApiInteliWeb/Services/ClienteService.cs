using ApiInteliWeb.DAL;
using ApiInteliWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiInteliWeb.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteDAL _context;
        public ClienteService(ClienteDAL context)
        {
            _context = context;
        }

        public  List<Cliente> GetClientes()
        {
            return _context.clientes.ToList();
        }

        public void EditCliente(Cliente cliente)
        {
         _context.Entry(cliente).State = EntityState.Modified;
         _context.SaveChanges();
        }

        public Cliente AddCliente(Cliente model)
        {
            _context.clientes.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteById(Guid Id)
        {
            var cli = _context.clientes.Find(Id);
            _context.clientes.Remove(cli);
            _context.SaveChanges();
        }
    }
}
