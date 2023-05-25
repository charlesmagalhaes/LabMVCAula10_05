using LabMVCAula10_05.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LabMVCAula10_05.Controllers
{

    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<ProdutoModel>> Get(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<ProdutoModel> listaResponse = JsonConvert.DeserializeObject<List<ProdutoModel>>(jsonResponse);
                return listaResponse;
            }
            else
            {
                // Lidar com o erro de acordo com a necessidade do seu aplicativo
                throw new Exception($"Erro ao obter os produtos. StatusCode: {response.StatusCode}");
            }
        }


        public async Task<HttpResponseMessage> Salvar(string url, ProdutoModel produto)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(produto), Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(url, jsonContent);
        }

    }

}