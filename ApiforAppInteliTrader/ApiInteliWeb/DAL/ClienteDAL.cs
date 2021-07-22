using ApiInteliWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiInteliWeb.DAL
{
    public class ClienteDAL : DbContext 
    {      
        public ClienteDAL(DbContextOptions<ClienteDAL> options) : base(options){}
        public DbSet<Cliente> clientes { get; set; }
    }
}
