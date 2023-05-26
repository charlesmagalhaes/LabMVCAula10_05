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

        private readonly string urlProduto = "https://localhost:44395/api/Produto";

        public ProdutoController()
        {
            
        }

        public async Task<ActionResult> Produto()
        {
            ViewBag.ListaProdutos = await _apiService.Get(urlProduto);
            ViewBag.ProdutoEmEdicaoId = false;

            return View(new ProdutoModel());
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(ProdutoModel produto)
        {

            var response = await _apiService.Salvar(urlProduto, produto);
            var responseData = await response.Content.ReadAsStringAsync();
            

            // Trate a resposta recebida da API e retorne para a exibição
            return RedirectToAction("Produto");
        }

        public async Task<ActionResult> ExcluirProduto(int? id)
        {
            var response = await _apiService.Excluir (urlProduto, id);
            return RedirectToAction("Produto");
        }

        public ActionResult EditarProduto()
        {
            ViewBag.ProdutoEmEdicaoId = true;

            return RedirectToAction("Produto");
        }


        [HttpPost]
        public async Task<ActionResult> SalvarEdicaoProduto(ProdutoModel produto)
        {
            var response = await _apiService.Atualizar(urlProduto, produto);
            var responseData = await response.Content.ReadAsStringAsync();


            // Trate a resposta recebida da API e retorne para a exibição
            return RedirectToAction("Produto");
        }


    }
}