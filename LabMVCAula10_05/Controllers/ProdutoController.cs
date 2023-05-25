using LabMVCAula10_05.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LabMVCAula10_05.Controllers
{
    public class ProdutoController : Controller
    {
        public ApiService _apiService = new ApiService();

        public ProdutoController()
        {
            
        }

        public async Task<ActionResult> Produto()
        {
            ViewBag.ListaProdutos = await _apiService.Get("https://localhost:44395/api/values");

            return View(new ProdutoModel());
        }


        public async Task<ActionResult> Salvar(ProdutoModel produto)
        {

            var response = await _apiService.Salvar("https://localhost:44395/api/values", produto);
            var responseData = await response.Content.ReadAsStringAsync();
            

            // Trate a resposta recebida da API e retorne para a exibição
            return RedirectToAction("Produto");
        }

    }
}