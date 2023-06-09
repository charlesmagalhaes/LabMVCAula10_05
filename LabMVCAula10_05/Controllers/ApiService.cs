﻿using LabMVCAula10_05.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

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
            try
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
            catch (HttpRequestException ex)
            {
                // Lidar com a exceção quando a API não estiver disponível
                // Aqui você pode fazer algo como registrar o erro, exibir uma mensagem de erro para o usuário, etc.
                // Por exemplo:
                string mensagem = "Erro ao se comunicar com a API: " + ex.Message;
                ExibirMensagemErro(mensagem);
                return new List<ProdutoModel>(); // Retornar uma lista vazia ou outro valor padrão adequado
            }
        }



        public async Task<HttpResponseMessage> Salvar(string url, ProdutoModel produto)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(produto), Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(url, jsonContent);
        }


        public async Task<HttpResponseMessage> Excluir(string url, int? id)
        {
            var deleteUrl = $"{url}/{id}";
            return await _httpClient.DeleteAsync(deleteUrl);
        }


        private void ExibirMensagemErro(string mensagem)
        {
            System.Windows.Forms.MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

}