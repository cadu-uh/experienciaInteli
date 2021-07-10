using ApiInteliWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiInteliWebTest
{
    public class ClienteServiceTest : IClienteService
    {
        [Fact]
        public void TestaGetUsuarios()
        {
            ClienteService.GetClientes();
        }
    }
}
