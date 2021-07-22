using AppInteliWeb.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace AppInteliWeb.Service
{

    class ClienteApi
    {      
        const string URL = "http://10.0.2.2:50758/v1/Cliente";
        HttpClient client = new HttpClient();

        public async Task<Cliente> GetById(Guid Id) 
        {
            string dados = URL + "/" + Id.ToString();          
            HttpResponseMessage result = await client.GetAsync(dados);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Cliente>(content);
            }
            return new Cliente();
        }

        public async Task<List<Cliente>> GetAllClient()
        {          
            HttpResponseMessage result = await client.GetAsync(URL);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Cliente>>(content);
            }
            return new List<Cliente>();
        }

        public async Task CreateClient(Cliente cliente)
        {
            string json = JsonConvert.SerializeObject(cliente);          
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(URL, content);
        }

        public async Task UpDateClient(Cliente cliente)
        {
            string dados = URL + "/" + cliente.Id;
            string json = JsonConvert.SerializeObject(cliente);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(dados, content);
        }

        public async Task DeleteClient(Guid Id)
        {
            string dados = URL + "/" + Id.ToString();
            HttpResponseMessage response = await client.DeleteAsync(dados);
        }
    }
}

